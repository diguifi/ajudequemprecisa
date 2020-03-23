using System.Collections.Generic;
using System.Threading.Tasks;
using AjudeQuemPrecisa.Core.ViewModels.PedidosDeAjuda;

namespace AjudeQuemPrecisa.Core.Services.PedidosDeAjuda
{
    public interface IPedidosDeAjudaService
    {
        Task<PedidoDeAjudaViewModel> CriaPedidoDeAjuda(PedidoDeAjudaViewModel pedidoDeAjudaViewModel);
        Task<PedidoDeAjudaViewModel> EditaPedidoDeAjuda(PedidoDeAjudaViewModel pedidoDeAjudaViewModel);
        Task<PedidoDeAjudaViewModel> ObterPedidoDeAjudaPorId(int id);
        Task<List<PedidoDeAjudaViewModel>> ObterTodosPedidosDeAjuda();
    }
}