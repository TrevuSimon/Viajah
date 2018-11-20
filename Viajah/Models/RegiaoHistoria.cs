using System;
using System.Collections.Generic;

namespace Viajah.Models
{
    public partial class RegiaoHistoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string ExperienciasBoas { get; set; }
        public string ExperienciasRuin { get; set; }
        public string Conclusao { get; set; }
        public string Indicacao { get; set; }
        public DateTime? DataPostagem { get; set; }
        public int? IdRegiao { get; set; }

        public Regiao IdNavigation { get; set; }
    }
}
