using Bizlite.SharedLib.DTO;
using Bizlite.SharedLib.ViewModel;

namespace Bizlite.Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpService httpService;

        public AccountService(HttpClient httpClient, IHttpService _httpService)
        {
            httpService = _httpService;
            httpService.Client = httpClient;
        }

      

        #region Login User Calling APi method
        public async Task<BaseApiResponseModel<LoginViewModel>> GetLoginUser(LoginRequestDto model)
        {
            LoginRequestDto userDto = new LoginRequestDto();
            userDto.UserName = model.UserName!.Trim();
            userDto.Password = model.Password!;
            var data = await httpService.PostAsync<LoginViewModel>("api/Account/Login", userDto);
            return data;
        }
        #endregion

    }
}
