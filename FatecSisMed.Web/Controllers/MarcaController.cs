using FatecSisMed.Web.Models;
using FatecSisMed.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FatecSisMed.Web.Controllers;

public class MarcaController : Controller
{

    private readonly IMarcaService _convenioService;

    public MarcaController(IMarcaService convenioService)
    {
        _convenioService = convenioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MarcaViewModel>>> Index()
    {
        var result = await _convenioService.GetAllMarcas(await GetAccessToken());
        if (result is null) return View("Error");
        return View(result);
    }

    // criar a view CreateMarca
    [HttpGet]
    public async Task<IActionResult> CreateMarca()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult>
        CreateMarca(MarcaViewModel convenioViewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await
                _convenioService.CreateMarca(convenioViewModel, await GetAccessToken());
            if (result is not null) return RedirectToAction(nameof(Index));
        }
        else
            return BadRequest("Error");

        return View(convenioViewModel);
    }

    // Criar a view UpdateMarca
    [HttpGet]
    public async Task<IActionResult> UpdateMarca(int id)
    {
        var result = await _convenioService.FindMarcaById(id, await GetAccessToken());
        if (result is null) return View("Error");
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult>
        UpdateMarca(MarcaViewModel convenioViewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await
                _convenioService.UpdateMarca(convenioViewModel, await GetAccessToken());
            if (result is not null) return RedirectToAction(nameof(Index));
        }

        return View(convenioViewModel);
    }

    // criar a view delete convenio
    [HttpGet]
    public async Task<ActionResult
        <MarcaViewModel>> DeleteMarca(int id)
    {
        var result = await _convenioService.FindMarcaById(id, await GetAccessToken());
        if (result is null) return View("Error");
        return View(result);
    }

    // nesse caso os dois precisariam ter o msm nome, só que como não pode ter 
    // duas assinaturas de métodos iguais, foi nomeado como DeleteConfirmed
    // porém é necessário chamar uma ação DeleteBrand
    // por isso tem o ActionName
    [HttpPost(), ActionName("DeleteMarca")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _convenioService.DeleteMarcaById(id, await GetAccessToken());
        if (!result) return View("Error");
        return RedirectToAction("Index");
    }

    private async Task<string> GetAccessToken()
    {
        return await HttpContext.GetTokenAsync("access token");
    }
}

