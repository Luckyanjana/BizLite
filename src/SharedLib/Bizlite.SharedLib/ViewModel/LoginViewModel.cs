using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizlite.SharedLib.ViewModel
{
    public class LoginViewModel
    {
        /// <summary>
        /// User Name credential for login
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// User Password for login
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Optional param JWT toke
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Optional param RoleId
        /// </summary>
        public int RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
