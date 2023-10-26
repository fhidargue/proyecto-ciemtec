using Ciemtec_Api.Pattern.IRepository;
using Pattern.IRepository;
using System;

namespace Repository.UnitOfWork
{
    public interface IUnitWork : IDisposable
    {
        IRolRepository Roles { get; }

        IEmpleadoRepository Empleados { get; }

        IPermisoRepository Permisos { get; }

        IRolPermisoRepository RolPermisos { get; }
        int Complete();

    }
}
