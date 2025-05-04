using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PortifolioFotografia.Config;
using PortifolioFotografia.Models;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace PortifolioFotografia.Controllers {
    public class FotografiasController : Controller {
        
        private readonly FotografiaContexto _fotografiaContexto;

        public FotografiasController(IOptions<ConfigDB> opcoes) {
            _fotografiaContexto = new FotografiaContexto(opcoes);
        }

        public async Task<IActionResult> Index() {
            return View(await _fotografiaContexto.Fotografias.Find(a => true).ToListAsync());
        }
    }
}
