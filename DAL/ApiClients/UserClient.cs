using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasefugeesWebApp.DAL.DTO;

namespace BasefugeesWebApp.DAL.ApiClients
{
    public partial class ApiClient
    {
        public async Task<List<UserModel>> GetUsers()
        {
            return await GetAsync<List<UserModel>>("users");
        }

        public async Task<bool> CheckEmail(EmailCheckModel userEmail)
        {
            return await PostAsyncAnon<bool, EmailCheckModel>("check", userEmail);
        }

        public async Task<UserLoginResponseModel> LoginUser(UserLoginModel model)
        {
            return await PostAsyncAnon<UserLoginResponseModel, UserLoginModel>("login", model);
        }

        public async Task<UserModel> SigninUser(UserModel model)
        {
            return await PostAsyncAnon("signup", model);
        }
    }
}
