using Bizlite.API.Config;
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

namespace Bizlite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        #region Service 

        private readonly ILogger<AccountController> _logger;
        private readonly JwtConfig _jwtConfig;
        #endregion
    
        #region Constructor

        public AccountController(ILogger<AccountController> logger, IOptions<JwtConfig> jwtConfigOption)
        {
            _logger = logger;
            
            _jwtConfig = jwtConfigOption.Value;


        }
        #endregion

        #region Login User


        [HttpPost]
        [Route("Login")]
        public IActionResult UserLogin([FromBody] LoginRequestDto userLogin)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    _logger.LogError(BaseResponseMessages.INVALID_USER_CREDENTIAL);
                    return BadRequest();
                }
                var userData = new LoginViewModel();
                userData.UserId = Guid.NewGuid();
                userData.UserName = userLogin.UserName;
                



                //var usertype = userData.UserRoleId;


                if (userData == null)
                {
                    _logger.LogError(BaseResponseMessages.INVALID_USER_CREDENTIAL);
                    return BadRequest();
                }

                //var isAuthorized = CommonClass.PasswordsMatch(userData.Password!, userLogin.Password!, userData.SaltKey!);

                //if (!isAuthorized)
                //{
                //    _logger.LogError(BaseResponseMessages.INVALID_USER_CREDENTIAL);
                //    return BadRequest();
                //}
           
                var token = GenerateToken(userData);
                userData.AccessToken = token;
                return SuccessResult(userData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Some error occur when login user:" + ex.GetBaseException().Message.ToString());
                return StatusCode(500, BaseResponseMessages.INTERNAL_SERVER_ERROR);
                throw;
            }
        }

        #endregion
        #region Generate Token 

        //private string GenerateToken(LoginViewModel user)
        //{
        //    var authClaim = new List<Claim> {

        //    new Claim(ClaimTypes.Name,user.UserName!.Trim()),
        //    new Claim(ClaimTypes.Sid,user.UserId.ToString()),
        //    new Claim(ClaimTypes.Role,user.RoleId.ToString()!),
        //    new Claim(JwtRegisteredClaimNames.Email,user.UserName!),
        //    };
        //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secrete));
        //    var token = new JwtSecurityToken
        //    (
        //        issuer: _jwtConfig.Issuer,
        //        audience: _jwtConfig.Audience,
        //        expires: DateTime.Now.AddMinutes(10),
        //        claims: authClaim,
        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

        //    );
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        private string GenerateToken(LoginViewModel user)
        {
            var authClaim = new List<Claim> {
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.Sid,user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Name,Guid.NewGuid().ToString()),
            };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secrete));
            var token = new JwtSecurityToken
            (
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                expires: DateTime.Now.AddMinutes(10),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        #endregion
    }
}
