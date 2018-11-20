using System;
using System.Collections.Generic;

namespace Viajah.Models
{
    public partial class UsuarioDetalhe
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Pais { get; set; }
        public int? IdRegiao { get; set; }
        public byte[] Foto { get; set; }

        public Regiao IdRegiaoNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
