using Dominio.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Teste.Application.Interface;

namespace TesteEDeploy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICidadeService _cidadeService;

        public HomeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObterCidadesPorNomeEEstado(Cidade cidade)
        {
            var retornoBusca = _cidadeService.ListarCidadesPorNomeEstado(cidade).ToList();

            return Json(retornoBusca, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObterPontuacaoCidade(Cidade cidade)
        {
            string retornoBusca = _cidadeService.PontuacaoCidadePorNomeEEstado(cidade);

            return Json(retornoBusca, JsonRequestBehavior.AllowGet);
        }
    }
}