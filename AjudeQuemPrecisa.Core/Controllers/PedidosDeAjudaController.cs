using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AjudeQuemPrecisa.Core.Data;
using AjudeQuemPrecisa.Core.Services.PedidosDeAjuda;
using AjudeQuemPrecisa.Core.ViewModels.PedidosDeAjuda;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AjudeQuemPrecisa.Core.Controllers
{
    [Authorize]
    public class PedidosDeAjudaController : Controller
    {
        private readonly IPedidosDeAjudaService _pedidosDeAjudaService;

        public PedidosDeAjudaController(IPedidosDeAjudaService pedidosDeAjudaService)
        {
            _pedidosDeAjudaService = pedidosDeAjudaService;
        }

        // GET: PedidosDeAjuda
        public async Task<IActionResult> Index()
        {
            return View(await _pedidosDeAjudaService.ObterTodosPedidosDeAjuda());
        }       

        // GET: PedidosDeAjuda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PedidosDeAjuda/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoDeAjudaViewModel pedidoDeAjudaViewModel)
        {
            if (ModelState.IsValid)
            {                   
                pedidoDeAjudaViewModel.UsuarioId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));           
                await _pedidosDeAjudaService.CriaPedidoDeAjuda(pedidoDeAjudaViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoDeAjudaViewModel);
        }

        // GET: PedidosDeAjuda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoDeAjudaViewModel = await _pedidosDeAjudaService.ObterPedidoDeAjudaPorId((int)id);
            if (pedidoDeAjudaViewModel == null)
            {
                return NotFound();
            }
            return View(pedidoDeAjudaViewModel);
        }

        // POST: PedidosDeAjuda/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PedidoDeAjudaViewModel pedidoDeAjudaViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pedidoDeAjudaViewModel.UsuarioId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));  
                    var resultado = await _pedidosDeAjudaService.EditaPedidoDeAjuda(pedidoDeAjudaViewModel); 
                    if(resultado == null)
                    {
                        return NotFound();
                    } 
                    return RedirectToAction(nameof(Index));                
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(pedidoDeAjudaViewModel);
                }                
            }
            return View(pedidoDeAjudaViewModel);
        }
    }
}
