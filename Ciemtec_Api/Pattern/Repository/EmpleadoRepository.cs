using Ciemtec_Api.Entities;
using Microsoft.EntityFrameworkCore;
using Pattern.IRepository;
using System.Collections.Generic;
using System.Linq;


namespace Pattern.Repository
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {


        public EmpleadoRepository(CiemtecContext context) : base(context)
        {
        }

        public bool ExistEmpleadoByCedula(string cedula)
        {
            return _context.Empleados.Any(e => e.CedulaEmpleado.Equals(cedula));
        }

        public bool ExistEmpleadoById(int id)
        {
            return _context.Empleados.Any(e => e.IdentificadorEmpleado == id);
        }

        public IEnumerable<Empleado> GetRolInEmpleado()
        {
            return _context.Empleados.Include(r => r.IdentificadorRolNavigation).ToList();
        }

        public Empleado GetRolInEmpleado(int id)
        {
            return _context.Empleados.Include(r => r.IdentificadorRolNavigation).FirstOrDefault(a => a.IdentificadorEmpleado == id);
        }
    }
}
