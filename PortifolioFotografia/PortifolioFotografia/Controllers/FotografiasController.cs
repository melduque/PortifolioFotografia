using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PortifolioFotografia.Config;
using PortifolioFotografia.Models;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.AspNetCore.Http.Metadata;

namespace PortifolioFotografia.Controllers {
    public class FotografiasController : Controller {
        
        private readonly FotografiaContexto _fotografiaContexto;

        public FotografiasController() {
            _fotografiaContexto = new FotografiaContexto();
        }

        public async Task<IActionResult> Index() {
            return View(await _fotografiaContexto.Fotografias.Find(a => true).ToListAsync());
        }
        
        [HttpGet]
        public IActionResult NovaFotografia() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovaFotografia(Fotografia fotografia) {
            fotografia.idFotografia = Guid.NewGuid();
            await _fotografiaContexto.Fotografias.InsertOneAsync(fotografia);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarFotografia(Guid idFotografia) {
            Fotografia fotografia = await _fotografiaContexto.Fotografias.Find(a => a.idFotografia == idFotografia).FirstOrDefaultAsync();
            return View(fotografia);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarFotografia(Fotografia fotografia) {
            await _fotografiaContexto.Fotografias.ReplaceOneAsync(a => a.idFotografia == fotografia.idFotografia, fotografia);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> ExcluirFotografia(Guid idFotografia) {
            await _fotografiaContexto.Fotografias.DeleteOneAsync(a => a.idFotografia == idFotografia);
            return RedirectToAction(nameof(Index));
        }
    }
}
