using System;
using System.Collections.Generic;

namespace Viajah.Models
{
    public partial class PontoTuristicoFoto
    {
        public int Id { get; set; }
        public int? IdPontoTuristico { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }

        public RegiaoPontoTuristico IdPontoTuristicoNavigation { get; set; }
    }
}
