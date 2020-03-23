using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AjudeQuemPrecisa.Core.Models.PedidosDeAjuda
{
    public class PedidoDeAjuda
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string FotoUrl { get; set; }
        public TipoPessoaEnum TipoPessoa { get; set; }
        public TipoAjudaEnum TipoAjuda { get; set; }
        public EstadoEnum Estado { get; set; }
        public string Cidade { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public string WebsiteUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string FinanciamentoColetivoUrl { get; set; }
        public IdentityUser<int> Usuario { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
    }
}