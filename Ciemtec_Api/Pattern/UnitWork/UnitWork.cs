using Ciemtec_Api.Entities;
using Ciemtec_Api.Models.Config;
using Ciemtec_Api.Pattern.IRepository;
using Ciemtec_Api.Pattern.Repository;
using Microsoft.Extensions.Options;
using Pattern.IRepository;
using Pattern.Repository;

namespace Repository.UnitOfWork
{
    public class UnitWork : IUnitWork
    {
        private readonly CiemtecContext _context;

        private readonly IOptions<AppSettings> _appSettings;

        public IRolRepository Roles { get; private set; }

        public IEmpleadoRepository Empleados { get; private set; }

        public IPermisoRepository Permisos { get; private set; }

        public IRolPermisoRepository RolPermisos { get; private set; }

        public UnitWork(CiemtecContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings;
            Roles = new RolRepository(_context);
            Empleados = new EmpleadoRepository(_context);
            Permisos = new PermisoRepository(_context, _appSettings);
            RolPermisos = new RolPermisoRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
