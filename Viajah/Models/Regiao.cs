using System;
using System.Collections.Generic;

namespace Viajah.Models
{
    public partial class Regiao
    {
        public Regiao()
        {
            UsuarioDetalhe = new HashSet<UsuarioDetalhe>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }

        public RegiaoComentario RegiaoComentario { get; set; }
        public RegiaoFoto RegiaoFoto { get; set; }
        public RegiaoHistoria RegiaoHistoria { get; set; }
        public RegiaoPontoTuristico RegiaoPontoTuristico { get; set; }
        public ICollection<UsuarioDetalhe> UsuarioDetalhe { get; set; }
    }
}
