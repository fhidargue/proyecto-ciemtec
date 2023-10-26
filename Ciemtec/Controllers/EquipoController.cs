using AutoMapper;
using Ciemtec_FND.Models.Config;
using Ciemtec_FND.Models.ViewModel;
using Ciemtec_FND.Pattern.UnitWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_FND.Controllers
{
    public class EquipoController : Controller
    {
        private readonly IUnitWork _context;

        private readonly IMapper _mapper;

        public EquipoController(IUnitWork context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }

        public IActionResult EquipoIndex()
        {
            return View();
        }


        public IActionResult EquipoEditar()
        {
            return View();
        }

        public IActionResult EquipoInsertar()
        {
            return View();
        }

    }
}
