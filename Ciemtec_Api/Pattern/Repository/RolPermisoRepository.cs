using Ciemtec_Api.Entities;
using Ciemtec_Api.Pattern.IRepository;
using Pattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_Api.Pattern.Repository
{
    public class RolPermisoRepository : Repository<RolPermiso>, IRolPermisoRepository
    {
        public RolPermisoRepository(CiemtecContext context) : base(context)
        {

        }
    }
}
