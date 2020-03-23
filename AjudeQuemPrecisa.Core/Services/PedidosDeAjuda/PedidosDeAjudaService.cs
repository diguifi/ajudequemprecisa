using System.Collections.Generic;
using System.Threading.Tasks;
using AjudeQuemPrecisa.Core.Data;
using AjudeQuemPrecisa.Core.Models.PedidosDeAjuda;
using AjudeQuemPrecisa.Core.ViewModels.PedidosDeAjuda;
using Microsoft.EntityFrameworkCore;

namespace AjudeQuemPrecisa.Core.Services.PedidosDeAjuda
{
    public class PedidosDeAjudaService : IPedidosDeAjudaService
    {
        private readonly ApplicationDbContext _context;

        public PedidosDeAjudaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PedidoDeAjudaViewModel>> ObterTodosPedidosDeAjuda()
        {
            var pedidosDeAjuda = await _context.PedidosDeAjuda.AsNoTracking().ToListAsync();
            var pedidosDeAjudaViewModelList = new List<PedidoDeAjudaViewModel>();

            foreach (var pedidoDeAjuda in pedidosDeAjuda)
            {
                pedidosDeAjudaViewModelList.Add(new PedidoDeAjudaViewModel
                {
                    Id = pedidoDeAjuda.Id,
                    Titulo = pedidoDeAjuda.Titulo,
                    FotoUrl = pedidoDeAjuda.FotoUrl,
                    TipoPessoa = pedidoDeAjuda.TipoPessoa,
                    TipoAjuda = pedidoDeAjuda.TipoAjuda,
                    Estado = pedidoDeAjuda.Estado,
                    Cidade = pedidoDeAjuda.Cidade,
                    Descricao = pedidoDeAjuda.Descricao,
                    Email = pedidoDeAjuda.Email,
                    WhatsApp = pedidoDeAjuda.WhatsApp,
                    WebsiteUrl = pedidoDeAjuda.WebsiteUrl,
                    FacebookUrl = pedidoDeAjuda.FacebookUrl,
                    FinanciamentoColetivoUrl = pedidoDeAjuda.FinanciamentoColetivoUrl,
                    UsuarioId = pedidoDeAjuda.UsuarioId
                });
            }

            return pedidosDeAjudaViewModelList;
        }

        public async Task<PedidoDeAjudaViewModel> ObterPedidoDeAjudaPorId(int id)
        {
            var pedidoDeAjuda = await _context.PedidosDeAjuda.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if(pedidoDeAjuda == null)
            {
                return null;
            }

            return new PedidoDeAjudaViewModel
            {
                Id = pedidoDeAjuda.Id,
                Titulo = pedidoDeAjuda.Titulo,
                FotoUrl = pedidoDeAjuda.FotoUrl,
                TipoPessoa = pedidoDeAjuda.TipoPessoa,
                TipoAjuda = pedidoDeAjuda.TipoAjuda,
                Estado = pedidoDeAjuda.Estado,
                Cidade = pedidoDeAjuda.Cidade,
                Descricao = pedidoDeAjuda.Descricao,
                Email = pedidoDeAjuda.Email,
                WhatsApp = pedidoDeAjuda.WhatsApp,
                WebsiteUrl = pedidoDeAjuda.WebsiteUrl,
                FacebookUrl = pedidoDeAjuda.FacebookUrl,
                FinanciamentoColetivoUrl = pedidoDeAjuda.FinanciamentoColetivoUrl,
                UsuarioId = pedidoDeAjuda.UsuarioId
            };
        }

        public async Task<PedidoDeAjudaViewModel> EditaPedidoDeAjuda(PedidoDeAjudaViewModel pedidoDeAjudaViewModel)
        {
            var pedidoDeAjuda = await _context.PedidosDeAjuda.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == pedidoDeAjudaViewModel.Id);

            if(pedidoDeAjuda == null)
            {
                return null;
            }

            pedidoDeAjuda.Id = pedidoDeAjudaViewModel.Id;
            pedidoDeAjuda.Titulo = pedidoDeAjudaViewModel.Titulo;
            pedidoDeAjuda.FotoUrl = pedidoDeAjudaViewModel.FotoUrl;
            pedidoDeAjuda.TipoPessoa = pedidoDeAjudaViewModel.TipoPessoa;
            pedidoDeAjuda.TipoAjuda = pedidoDeAjudaViewModel.TipoAjuda;
            pedidoDeAjuda.Estado = pedidoDeAjudaViewModel.Estado;
            pedidoDeAjuda.Cidade = pedidoDeAjudaViewModel.Cidade;
            pedidoDeAjuda.Descricao = pedidoDeAjudaViewModel.Descricao;
            pedidoDeAjuda.Email = pedidoDeAjudaViewModel.Email;
            pedidoDeAjuda.WhatsApp = pedidoDeAjudaViewModel.WhatsApp;
            pedidoDeAjuda.WebsiteUrl = pedidoDeAjudaViewModel.WebsiteUrl;
            pedidoDeAjuda.FacebookUrl = pedidoDeAjudaViewModel.FacebookUrl;
            pedidoDeAjuda.FinanciamentoColetivoUrl = pedidoDeAjudaViewModel.FinanciamentoColetivoUrl;
            pedidoDeAjuda.UsuarioId = pedidoDeAjudaViewModel.UsuarioId;

            _context.Update(pedidoDeAjuda);
            await _context.SaveChangesAsync();

            return pedidoDeAjudaViewModel;
        }

        public async Task<PedidoDeAjudaViewModel> CriaPedidoDeAjuda(PedidoDeAjudaViewModel pedidoDeAjudaViewModel)
        {
            var pedidoDeAjuda = new PedidoDeAjuda
            {
                Id = pedidoDeAjudaViewModel.Id,
                Titulo = pedidoDeAjudaViewModel.Titulo,
                FotoUrl = pedidoDeAjudaViewModel.FotoUrl,
                TipoPessoa = pedidoDeAjudaViewModel.TipoPessoa,
                TipoAjuda = pedidoDeAjudaViewModel.TipoAjuda,
                Estado = pedidoDeAjudaViewModel.Estado,
                Cidade = pedidoDeAjudaViewModel.Cidade,
                Descricao = pedidoDeAjudaViewModel.Descricao,
                Email = pedidoDeAjudaViewModel.Email,
                WhatsApp = pedidoDeAjudaViewModel.WhatsApp,
                WebsiteUrl = pedidoDeAjudaViewModel.WebsiteUrl,
                FacebookUrl = pedidoDeAjudaViewModel.FacebookUrl,
                FinanciamentoColetivoUrl = pedidoDeAjudaViewModel.FinanciamentoColetivoUrl,
                UsuarioId = pedidoDeAjudaViewModel.UsuarioId
            };

            _context.Add(pedidoDeAjuda);
            await _context.SaveChangesAsync();

            pedidoDeAjudaViewModel.Id = pedidoDeAjuda.Id;
            return pedidoDeAjudaViewModel;
        }
    }
}