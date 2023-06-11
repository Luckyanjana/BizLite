using Bizlite.SharedLib.Helper;
using Bizlite.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using static Bizlite.Web.LIBS.Enums;

namespace Bizlite.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }


        /// remove Authentication From Cookies..
        /// </summary>
        /// <returns>return true after set null </returns>
        public async Task RemoveAuthentication()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }


        #region [ MESSAGE NOTIFICATION ]

        /// <summary>
        /// Shows Notification Message After Succesfully Record Submited or Failed to Submit any Record From Submit Of Form.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        /// <param name="isCurrentView"></param>
        private void ShowMessages(string title, string message, MessageType messageType, bool isCurrentView)
        {
            Notification model = new Notification
            {
                Heading = title,
                Message = message,
                Type = messageType
            };

            if (isCurrentView)
            {
                ViewData!.AddOrReplace("NotificationModel", model);
            }
            else
            {
                TempData["NotificationModel"] = JsonConvert.SerializeObject(model);
                TempData.Keep("NotificationModel");
            }
        }

        protected void ShowErrorMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Danger, isCurrentView);
        }

        protected void ShowSuccessMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Success, isCurrentView);
        }




        protected void ShowWarningMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Warning, isCurrentView);
        }

        protected void ShowInfoMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Info, isCurrentView);
        }


        #endregion [ MESSAGE NOTIFICATION ]

        #region [ HTTP ERROR REDIRECTION ]

        /// <summary>
        /// redirect to respected Status Code of Error
        /// </summary>
        /// <returns>redirect to 404</returns>
        protected ActionResult Redirect404()
        {
            return Redirect("~/error/pagenotfound");
        }

        /// <summary>
        /// redirect to respected Status Code of Error
        /// </summary>
        /// <returns>redirect to 500</returns>
        protected ActionResult Redirect500()
        {
            return Redirect("~/error/servererror");
        }

        protected ActionResult Redirect401()
        {
            return View();
        }

        #endregion [ HTTP ERROR REDIRECTION ]

        #region [ EXCEPTION HANDLING ]
        /// <summary>
        /// Handle Exception Of Model State Of Validation Summary
        /// </summary>
        /// <returns>return Error Message</returns>
        public PartialViewResult CreateModelStateErrors()
        {
            return PartialView("_ValidationSummary", ModelState.Values.SelectMany(x => x.Errors));
        }

        #endregion [ EXCEPTION HANDLING ]

        #region  [ SERIALIZATION ]
        /// <summary>
        /// Serilize Data into Json
        /// </summary>
        /// <param name="data"></param>
        /// <returns>return Json Data</returns>
        public IActionResult NewtonSoftJsonResult(object data)
        {
            if (data != null)
            {
                return Json(data);
            }
            else
            {
                throw new NullReferenceException("Data is null");
            }
        }
        #endregion [ SERIALIZATION ]

        #region [ DISPOSE ]

        /// <summary>
        /// Dispose All Service 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion [ DISPOSE ]

        public string GetIPAddress(IHttpContextAccessor accessor)
        {
            return accessor.HttpContext!.Connection.RemoteIpAddress!.ToString();
        }
        protected int? GetCurrentUserId(IHttpContextAccessor accessor)
        {
            string userId = accessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            return string.IsNullOrWhiteSpace(userId) ? Convert.ToInt32(userId) : (int?)null;
        }

    }
}