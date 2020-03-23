using System.ComponentModel.DataAnnotations;
using AjudeQuemPrecisa.Core.Models.PedidosDeAjuda;

namespace AjudeQuemPrecisa.Core.ViewModels.PedidosDeAjuda
{
    public class PedidoDeAjudaViewModel
    {
        public int Id { get; set; }
        [MaxLength(32)]
        public string Titulo { get; set; }
        public string FotoUrl { get; set; }
        public TipoPessoaEnum TipoPessoa { get; set; }
        public TipoAjudaEnum TipoAjuda { get; set; }
        public EstadoEnum Estado { get; set; }
        [MaxLength(32)]
        public string Cidade { get; set; }
        [MaxLength(1024)]
        public string Descricao { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        [Url]
        public string WebsiteUrl { get; set; }
        [Url]
        public string FacebookUrl { get; set; }
        [Url]
        public string FinanciamentoColetivoUrl { get; set; }
        public int UsuarioId { get; set; }
    }
}