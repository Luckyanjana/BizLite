using Bizlite.SharedLib.DTO;
using Bizlite.SharedLib.ViewModel;

namespace Bizlite.Web.Services
{
    public interface IAccountService
    {
       
        Task<BaseApiResponseModel<LoginViewModel>> GetLoginUser(LoginRequestDto model);
        //Task<UserDto> GetAllUsers(bool data = false);
        //Task<BaseApiResponseModel<UserDto>> GetAllUsers(RegistrationViewModel model);


    }
}
