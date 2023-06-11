using Bizlite.SharedLib.Resource;
using Bizlite.SharedLib.ViewModel;
using Bizlite.Web.LIBS;
using Bizlite.Web.Models;
using Bizlite.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Bizlite.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _Login()
        {
            LoginRequestDto model = new LoginRequestDto();
            return PartialView("_Login", model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            try
            {

                if (!ModelState.IsValid)
                {

                    ShowErrorMessage("failed", BaseResponseMessages.INVALID_DATA);
                    return NewtonSoftJsonResult(new RequestOutcome<string> { ErrorMessage = BaseResponseMessages.INVALID_DATA });
                }

                //Calling API Method

                var returndata = await _accountService.GetLoginUser(model);
                ShowSuccessMessage("Success", BaseResponseMessages.ACCOUNT_CREATED);               
                return NewtonSoftJsonResult(new RequestOutcome<string> { Message = "Account has been created successfully.", RedirectUrl= @Url.Action("DashboardIndex", "Dashboard") });
            }
            catch (Exception)
            {
                ShowErrorMessage("failed", BaseResponseMessages.INVALID_DATA);
                return NewtonSoftJsonResult(new RequestOutcome<string> { ErrorMessage = BaseResponseMessages.INVALID_DATA });
            }
        }

        public IActionResult InProgress()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}