using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria_App.Model
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }

        public Livro(string titulo, string autor, string descricao, int quantidade, string imagem)
        {
            Titulo = titulo;
            Autor = autor;
            Descricao = descricao;
            Quantidade = quantidade;
            Imagem = imagem;
        }
    }
}
