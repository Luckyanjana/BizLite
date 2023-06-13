﻿using AutoMapper;
using Bizlite.API.Config;
using Bizlite.Core.Interfaces;
using Bizlite.Core.Specifications;
using Bizlite.SharedLib.Resource;
using Bizlite.SharedLib.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class MasterController : BaseController
    {
        private readonly ILogger<MasterController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MasterController(ILogger<MasterController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet] 
        public IActionResult GetAllArea()
        {
            try
            {
                var areas = _unitOfWork.Master.GetAllAreas();
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


        [HttpGet]
        public IActionResult GetAllAreaList([FromQuery] MasterSpecification specs)
        {
            try
            {
                //var authUser = new AuthUser(User);
                var areas = _unitOfWork.Master.GetAreaList(specs);
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


        [HttpGet("{id}", Name = "GetAreaById")]
        public IActionResult GetAreaById(int id)
        {
            try
            {
                var area = _unitOfWork.Master.GetAreaById(id);
                if (area != null)
                {
                    var areadto = _mapper.Map<AreaDTO>(area);

                    _logger.LogInformation("Return Data successfully");
                    return SuccessResult(areadto);
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
        public IActionResult CreateArea(AreaCreateUpdateDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    _logger.LogError("User has not provided correct data");
                    return BadRequestErrorResult("User has not provided correct data");
                }
                //var authUser = new AuthUser(User);
                var areaEntity = _mapper.Map<Bizlite.Core.Entities.TblAreaMaster>(model);
                _unitOfWork.Master.CreateArea(areaEntity);
                _unitOfWork.Save();
                var area = _mapper.Map<AreaDTO>(areaEntity);
                return CreatedAtRoute("GetAreaById", new { id = areaEntity.AreaId }, area);
            }
            catch (Exception ex)
            {
                _logger.LogError("Some error occur when saving todo:" + ex.GetBaseException().Message.ToString());
                return ErrorResult("Internal Server Error");
            }


        }

        [HttpPut("{id}", Name = "UpdateArea")]
        public IActionResult UpdateArea(int id, AreaCreateUpdateDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    _logger.LogError("User has not provided correct data");
                    return BadRequestErrorResult("User has not provided correct data");
                }
                // var authUser = new AuthUser(User);
                var areaobj = _unitOfWork.Master.GetAreaById(id);
                if (areaobj == null)
                {
                    _logger.LogError("User not found");
                    return NotFoundResult("User not found");
                }

                //if (areaobj.UserId != authUser.Id)
                //{
                //    _logger.LogError("Todo does not belongs to this user");
                //    return Unauthorized();
                //}
                _mapper.Map(model, areaobj);
                _unitOfWork.Master.UpdateArea(areaobj);
                _unitOfWork.Save();
                var areaEntity = _mapper.Map<AreaDTO>(areaobj);


                return CreatedAtRoute("GetToDoById", new { id = areaEntity.AreaId }, areaEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError("Some error occur when updating area:" + ex.GetBaseException().Message.ToString());
                return ErrorResult("Internal Server Error");
            }


        }




        [HttpDelete("{id}", Name = "DeleteArea")]
        public IActionResult DeleteArea(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    _logger.LogError("User has not provided correct data");
                    return BadRequestErrorResult("User has not provided correct data");
                }
                var areaObj = _unitOfWork.Master.GetAreaById(id);
                if (areaObj == null)
                {
                    _logger.LogError("User not found");
                    return NotFoundResult("User not found");
                }

                _unitOfWork.Master.DeleteArea(areaObj);
                _unitOfWork.Save();
                var areaEntity = _mapper.Map<AreaDTO>(areaObj);


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
