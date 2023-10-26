using Ciemtec_Api.Entities;
using Ciemtec_Api.Models.Dto;
using Pattern.IRepository;
using System.Collections.Generic;

namespace Pattern.IRepository
{
    public interface IPermisoRepository : IRepository<Permiso>
    {
        AuthenticationToken Authentication(AuthenticationDto authenticate);

        IEnumerable<PrivilegiosResult> ValidateModulo(PrivilegiosDto privilegios);

        IEnumerable<PrivilegiosResult> ValidateAll(int empleadoId);

        IEnumerable<Permiso> GetPermisos();

        IEnumerable<PR_GET_PERMISO_VALUE> GetPermisosByRol(int rolId);
    }
}
