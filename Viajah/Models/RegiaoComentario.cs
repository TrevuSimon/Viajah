using System;
using System.Collections.Generic;

namespace Viajah.Models
{
    public partial class RegiaoComentario
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdRegiao { get; set; }
        public string Comentario { get; set; }
        public DateTime? Data { get; set; }

        public Usuario Id1 { get; set; }
        public Regiao IdNavigation { get; set; }
    }
}
