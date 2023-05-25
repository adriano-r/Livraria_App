using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria_App.Model
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        // Adicione outras propriedades conforme necessário, como ISBN, gênero, etc.

        public Livro(string titulo, string autor, string descricao, int quantidade)
        {
            Titulo = titulo;
            Autor = autor;
            Descricao = descricao;
            Quantidade = quantidade;
        }
    }
}
