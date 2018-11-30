using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Viajah.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioDetalhe = new HashSet<UsuarioDetalhe>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        public string Senha { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }


        public DateTime? DataCadastro { get; set; }
        public bool? Moderador { get; set; }

        public RegiaoComentario RegiaoComentario { get; set; }
        public ICollection<UsuarioDetalhe> UsuarioDetalhe { get; set; }
    }
}
