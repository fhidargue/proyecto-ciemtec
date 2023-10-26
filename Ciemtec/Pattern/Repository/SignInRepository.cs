using Ciemtec_FND.Models.ViewModel;
using Ciemtec_FND.Pattern.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ciemtec_FND.Pattern.Repository
{
    public class SignInRepository : Repository<UserViewModel>, ISigninRepository
    {
        public SignInRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public Task<UserViewModel> SigninAsync(string url, UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignipAsync(string url, UserViewModel user)
        {
            throw new NotImplementedException();
        }
    }
}
