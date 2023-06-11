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
    public class DashboardController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;

        public DashboardController(ILogger<HomeController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public IActionResult DashboardIndex()
        {
            return View();
        }      

       
        
    }
}