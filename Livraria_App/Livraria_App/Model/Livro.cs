using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria_App.Model
{
    public class Livro
    {
        public Livro()
        {
            this.id = 0;
            this.Titulo = "";
            this.Autor = "";
            this.Descricao = "";
            this.Quantidade = 0;
            this.Imagem = "";
        }
        public int id { get; set; }
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
