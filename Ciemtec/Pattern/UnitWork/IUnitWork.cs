using Ciemtec_FND.Pattern.IRepository;
using System;


namespace Ciemtec_FND.Pattern.UnitWork
{
    public interface IUnitWork
    {
        IEmpleadoRepository Empleados { get; }

        IRolRepository Roles { get; }
    }
}
