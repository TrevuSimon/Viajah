using System;
using System.Collections.Generic;

namespace Viajah.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioDetalhe = new HashSet<UsuarioDetalhe>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool? Moderador { get; set; }

        public RegiaoComentario RegiaoComentario { get; set; }
        public ICollection<UsuarioDetalhe> UsuarioDetalhe { get; set; }
    }
}
