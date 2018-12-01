using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Viajah.Models
{
    public partial class RegiaoHistoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(255)]
        public string ExperienciasBoas { get; set; }

        [Required]
        [StringLength(255)]
        public string ExperienciasRuin { get; set; }

        [Required]
        [StringLength(255)]
        public string Conclusao { get; set; }

        [Required]
        [StringLength(255)]
        public string Indicacao { get; set; }


        public DateTime? DataPostagem { get; set; }
        public int? IdRegiao { get; set; }
        public int? IdUsuario { get; set; }

        public Regiao IdRegiaoNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
