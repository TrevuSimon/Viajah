using System;
using System.Collections.Generic;

namespace Viajah.Models
{
    public partial class RegiaoFoto
    {
        public int Id { get; set; }
        public int? IdRegiao { get; set; }
        public byte[] Foto { get; set; }
        public string Descricao { get; set; }

        public Regiao IdNavigation { get; set; }
    }
}
