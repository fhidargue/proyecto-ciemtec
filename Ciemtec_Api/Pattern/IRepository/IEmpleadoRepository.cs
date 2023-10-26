using Ciemtec_Api.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Pattern.IRepository
{
    public interface IEmpleadoRepository : IRepository<Empleado>
    {
        bool ExistEmpleadoByCedula(string cedula);

        bool ExistEmpleadoById(int id);

        IEnumerable<Empleado> GetRolInEmpleado();

        Empleado GetRolInEmpleado(int id);

    }
}
