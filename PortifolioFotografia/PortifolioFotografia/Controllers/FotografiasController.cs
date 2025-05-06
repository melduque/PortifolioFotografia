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
public async Task<IActionResult> NovaFotografia(Fotografia fotografia, IFormFile imagem)
{
    fotografia.idFotografia = Guid.NewGuid();

    if (imagem != null && imagem.Length > 0)
    {
        using (var ms = new MemoryStream())
        {
            await imagem.CopyToAsync(ms);
            var imagemBytes = ms.ToArray();
            fotografia.imagemBase64 = Convert.ToBase64String(imagemBytes);
        }
    }

    await _fotografiaContexto.Fotografias.InsertOneAsync(fotografia);
    return RedirectToAction(nameof(Index));
}

        [HttpGet]
        public async Task<IActionResult> AtualizarFotografia(Guid idFotografia) {
            Fotografia fotografia = await _fotografiaContexto.Fotografias.Find(a => a.idFotografia == idFotografia).FirstOrDefaultAsync();
            return View(fotografia);
        }


        [HttpGet]
public async Task<IActionResult> Galeria()
{
    var fotos = await _fotografiaContexto.Fotografias.Find(_ => true).ToListAsync();
    return View(fotos); 
}


[HttpPost]
public async Task<IActionResult> AtualizarFotografia(Fotografia fotografia, IFormFile imagem)
{
    if (imagem != null && imagem.Length > 0)
    {
        using (var ms = new MemoryStream())
        {
            await imagem.CopyToAsync(ms);
            var imagemBytes = ms.ToArray();
            fotografia.imagemBase64 = Convert.ToBase64String(imagemBytes);
        }
    }
    else
    {
        var fotoExistente = await _fotografiaContexto.Fotografias
            .Find(a => a.idFotografia == fotografia.idFotografia)
            .FirstOrDefaultAsync();

        if (fotoExistente != null)
        {
            fotografia.imagemBase64 = fotoExistente.imagemBase64;
        }
    }

    await _fotografiaContexto.Fotografias.ReplaceOneAsync(
        a => a.idFotografia == fotografia.idFotografia,
        fotografia
    );

    return RedirectToAction(nameof(Index));
}


        [HttpPost]
        public async Task<ActionResult> ExcluirFotografia(Guid idFotografia) {
            await _fotografiaContexto.Fotografias.DeleteOneAsync(a => a.idFotografia == idFotografia);
            return RedirectToAction(nameof(Index));
        }
    }
}
