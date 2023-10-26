using Ciemtec_FND.Pattern.IRepository;
using Ciemtec_FND.Pattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ciemtec_FND.Pattern.UnitWork
{
    public class UnitWork : IUnitWork
    {
        private IHttpClientFactory _clientFactory;

        public IEmpleadoRepository Empleados { get; private set; }

        public IRolRepository Roles { get; private set; }

        public UnitWork(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            Empleados = new EmpleadoRepository(_clientFactory);
            Roles = new RolRepository(_clientFactory);
        }
    }
}
