using Ciemtec_Api.Entities;
using Ciemtec_FND.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_FND.Pattern.IRepository
{
    public interface IRolRepository : IRepository<Rol>
    {
        Task<IEnumerable<PermisoViewModel>> GetPermisos(string url);

        Task<IEnumerable<PermisoByRol>> GetPermisosByRol(int rolID, string url);

        Task<bool> CreateRolPermisos(List<PermisoByRolApi> rolDto, string url);
    }
}
