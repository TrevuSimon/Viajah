using System;
using System.Collections.Generic;

namespace Viajah.Models
{
    public partial class RegiaoPontoTuristico
    {
        public RegiaoPontoTuristico()
        {
            PontoTuristicoFoto = new HashSet<PontoTuristicoFoto>();
        }

        public int Id { get; set; }
        public int? IdRegiao { get; set; }
        public string Descricao { get; set; }

        public Regiao IdNavigation { get; set; }
        public ICollection<PontoTuristicoFoto> PontoTuristicoFoto { get; set; }
    }
}
