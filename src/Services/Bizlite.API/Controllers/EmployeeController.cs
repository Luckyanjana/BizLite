using AutoMapper;
using Bizlite.API.Config;
using Bizlite.Core.Interfaces;
using Bizlite.Core.Specifications;
using Bizlite.SharedLib.Helper;
using Bizlite.SharedLib.Resource;
using Bizlite.SharedLib.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ToDo.WebApi.DTOs;
using ToDo.WebApi.Models;

namespace Bizlite.API.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeController(ILogger<EmployeeController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employee = _unitOfWork.Employee.GetAllEmployee();
                var employeeDto = _mapper.Map<List<EmployeeDto>>(employee);

                _logger.LogInformation("Return Data successfully");
                return SuccessResult(employeeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured :{ex.GetBaseException().Message}");
                return BadRequestErrorResult("Internal Server Error");
                throw;
            }

        }


        [HttpGet]
        public IActionResult GetAllEmployeeList([FromQuery] EmployeeSpecification specs)
        {
            try
            {
                //var authUser = new AuthUser(User);
                var areas = _unitOfWork.Employee.GetEmployeeList(specs);
                var pageMetaData = new
                {
                    areas.CurrentPage,
                    areas.HasNext,
                    areas.HasPrevious,
                    areas.TotalCount,
                    areas.TotalPages
                };
                Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(pageMetaData));
                var areaDto = _mapper.Map<List<AreaDTO>>(areas);

                _logger.LogInformation("Return Data successfully");
                return SuccessResult(areaDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured :{ex.GetBaseException().Message}");
                return ErrorResult("Internal Server Error");
                throw;
            }

        }


        [HttpGet("{id}",Name = "GetEmployeeById")]
        public IActionResult GetEmployeeById(long id)
        {
            try
            {
                var employee = _unitOfWork.Employee.GetEmployeeById(id);
                if (employee != null)
                {
                    var employeedto = _mapper.Map<EmployeeDto>(employee);

                    _logger.LogInformation("Return Data successfully");
                    return SuccessResult(employeedto);
                }
                else
                {
                    _logger.LogInformation("No Data Found");
                    return NotFoundResult("No Data Found");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured :{ex.GetBaseException().Message}");
                return ErrorResult("Internal Server Error");
                throw;
            }

        }
        [HttpGet("{id}", Name = "GetEmployeeByEmail")]
        public IActionResult GetEmployeeByEmail(long id)
        {
            try
            {
                var employee = _unitOfWork.Employee.GetEmployeeById(id);
                if (employee != null)
                {
                    var employeedto = _mapper.Map<EmployeeDto>(employee);

                    _logger.LogInformation("Return Data successfully");
                    return SuccessResult(employeedto);
                }
                else
                {
                    _logger.LogInformation("No Data Found");
                    return NotFoundResult("No Data Found");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured :{ex.GetBaseException().Message}");
                return ErrorResult("Internal Server Error");
                throw;
            }

        }

        [HttpPost]
        public IActionResult RegisterEmployee(EmployeeCreateUpdateDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    _logger.LogError("User has not provided correct data");
                    return BadRequest();
                }

                string SaltKey = CommonClass.CreateSaltKey(15);
                
                //var authUser = new AuthUser(User);
                var employeeEntity = _mapper.Map<Bizlite.Core.Entities.TblEmployee>(model);
                employeeEntity.SaltKey = SaltKey;
                employeeEntity.EmpPassword = CommonClass.CreatePasswordHash(model.Password, SaltKey, "MD5");
                _unitOfWork.Employee.RegisterEmployee(employeeEntity);
                _unitOfWork.Save();
                var employee = _mapper.Map<EmployeeDto>(employeeEntity);
                return CreatedAtRoute("GetEmployeeById", new { id = employeeEntity.EmpId }, employee);
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;
                if (sqlException != null && sqlException.Number == 2627)
                {
                    // Unique key constraint violation
                    return ErrorResult("User with this email already exists.");
                }
                // Handle other database exceptions if needed
                return StatusCode(500, "Internal server error");
            }
            catch (Exception ex)
            {
                _logger.LogError("Some error occur when saving todo:" + ex.GetBaseException().Message.ToString());
                return BadRequestErrorResult(ex.GetBaseException().Message.ToString());
            }


        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeCreateUpdateDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    _logger.LogError("User has not provided correct data");
                    return BadRequest();
                }
                // var authUser = new AuthUser(User);
                var employeeobj = _unitOfWork.Employee.GetEmployeeById(id);
                if (employeeobj == null)
                {
                    _logger.LogError("User not found");
                    return NotFoundResult("User not found");
                }

                //if (areaobj.UserId != authUser.Id)
                //{
                //    _logger.LogError("Todo does not belongs to this user");
                //    return Unauthorized();
                //}
                _mapper.Map(model, employeeobj);
                _unitOfWork.Employee.UpdateEmployee(employeeobj);
                _unitOfWork.Save();
                var employeeEntity = _mapper.Map<EmployeeDto>(employeeobj);


                return CreatedAtRoute("GetEmployeeById", new { id = employeeEntity.EmpId }, employeeEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError("Some error occur when updating area:" + ex.GetBaseException().Message.ToString());
                return ErrorResult("Internal Server Error");
            }


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    _logger.LogError("User has not provided correct data");
                    return BadRequest();
                }
                var employeeObj = _unitOfWork.Employee.GetEmployeeById(id);
                if (employeeObj == null)
                {
                    _logger.LogError("User not found");
                    return NotFoundResult("User not found");
                }

                _unitOfWork.Employee.DeleteEmployee(employeeObj);
                _unitOfWork.Save();
                var employeeEntity = _mapper.Map<EmployeeDto>(employeeObj);


                return SuccessResult("Record has been deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError("Some error occur when updating todo:" + ex.GetBaseException().Message.ToString());
                return ErrorResult("Internal Server Error");
            }


        }
    }
}
