using Ciemtec_Api.Entities;
using Ciemtec_FND.Models.ViewModel;
using Ciemtec_FND.Pattern.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ciemtec_FND.Pattern.Repository
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }
    }
}
