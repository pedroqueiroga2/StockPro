using ControleDeEstoque.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Api.Controllers;


public class MotivosController : Controller
{

    private readonly IMotivosServices _motivosServices;

    public MotivosController(IMotivosServices motivosServices)
    {
        _motivosServices = motivosServices;
    }

    [HttpGet]
    public async Task<IActionResult> Index() 
    {

        try 
        {
            return View(await _motivosServices.ListaTodosMotivos());
        }
        catch 
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id = 0)
    {

        try
        {
            return View(await _motivosServices.ObterMotivoPorId(id));
        }
        catch
        {
            return StatusCode(500);
        }
    }
}
