using Ciemtec_Api.Entities;
using Ciemtec_Api.Models.Config;
using Ciemtec_Api.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using Pattern.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Repository
{
    public class PermisoRepository : Repository<Permiso>, IPermisoRepository
    {
        private readonly AppSettings _appSettings;
        public PermisoRepository(CiemtecContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticationToken Authentication(AuthenticationDto authenticate)
        {
            Empleado empleado = _context.Empleados
                .Where(e => e.UsuarioEmpleado.Equals(authenticate.Usuario) && e.ContraseniaEmpleado.Equals(authenticate.Contrasenia))
                .FirstOrDefault();

            if (empleado == null) return null;

            return new AuthenticationToken { Token = GetToken(empleado) };
        }

        public IEnumerable<Permiso> GetPermisos()
        {
            return _context.Permisos.Include(m => m.IdentificadorModuloNavigation);
        }

        public IEnumerable<PR_GET_PERMISO_VALUE> GetPermisosByRol(int rolId)
        {
            return _context.Set<PR_GET_PERMISO_VALUE>().FromSqlRaw("CALL PR_GET_PERMISO_VALUE({0});", rolId);
        }

        public IEnumerable<PrivilegiosResult> ValidateAll(int empleadoId)
        {
            return _context.Set<PrivilegiosResult>().FromSqlRaw("CALL PR_GET_SELECT_PERMISO({0});", empleadoId);
        }

        public IEnumerable<PrivilegiosResult> ValidateModulo(PrivilegiosDto privilegios)
        {
            return _context.Set<PrivilegiosResult>().FromSqlRaw("CALL PR_GET_MODULO_PERMISO({0},{1});", privilegios.Identificador_Empleado, privilegios.Nombre_Modulo);
        }

        private string GetToken(Empleado empleado)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, empleado.IdentificadorEmpleado.ToString()),
                        new Claim(ClaimTypes.Role, empleado.IdentificadorRol.ToString())
                    }
                ),

                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }


}
