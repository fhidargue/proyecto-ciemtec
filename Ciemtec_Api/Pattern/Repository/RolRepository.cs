using Ciemtec_Api.Entities;
using Pattern.IRepository;
using System.Linq;


namespace Pattern.Repository
{
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        public RolRepository(CiemtecContext context) : base(context)
        {
        }

        public bool ExistRol(string rolName)
        {
            return _context.Roles.Any(r => r.NombreRol.ToLower().Trim().Equals(rolName.ToLower().Trim()));
        }

        public bool ExistRol(int rolId)
        {
            return _context.Roles.Any(r => r.IdentificadorRol == rolId);
        }

        public Rol GetRolByName(string name)
        {
            return _context.Roles.FirstOrDefault(r => r.NombreRol == name);
        }

        public bool ValidateRolName(int rolId, string name)
        {
            return _context.Roles.Any(r => r.IdentificadorRol == rolId && r.NombreRol.ToLower().Trim().Equals(name.ToLower().Trim()));
        }

    }
}
