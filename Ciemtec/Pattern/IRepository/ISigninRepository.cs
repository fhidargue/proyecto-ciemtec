using Ciemtec_FND.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_FND.Pattern.IRepository
{
    public interface ISigninRepository : IRepository<UserViewModel>
    {
        Task<UserViewModel> SigninAsync(string url, UserViewModel user);

        Task<bool> SignipAsync(string url, UserViewModel user);
    }
}
