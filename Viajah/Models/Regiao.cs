using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Viajah.Models
{
    public partial class Regiao
    {
        public Regiao()
        {
            UsuarioDetalhe = new HashSet<UsuarioDetalhe>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(100)]
        public string Pais { get; set; }

        public bool? Aprovada { get; set; }

        public RegiaoComentario RegiaoComentario { get; set; }
        public RegiaoFoto RegiaoFoto { get; set; }
        public RegiaoHistoria RegiaoHistoria { get; set; }
        public RegiaoPontoTuristico RegiaoPontoTuristico { get; set; }
        public ICollection<UsuarioDetalhe> UsuarioDetalhe { get; set; }
    }
}
