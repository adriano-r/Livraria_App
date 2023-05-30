using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria_App.Model
{
    public class ReservaLivro
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataReserva { get; set; }
        public string Status { get; set; }
    }
}
