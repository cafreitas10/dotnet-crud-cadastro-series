using System;
using dotnet_crud_cadastro_series.Classes;

namespace dotnet_crud_cadastro_series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }//mostra se ja foi excluido - Ativo

        public Serie()
        {
            this.Id = -1;
            this.Genero = Genero.Nd;
            this.Titulo = "";
            this.Descricao = "";
            this.Ano = 0;
            this.Excluido = false;//ativo - controla o status Ativo ou não
        }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;//vem da base
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;//ativo - controla o status Ativo ou não
        }

        public override string ToString()
        {
            // Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine; // da uma nova linha de acordo com o sistema operacional
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        /// <summary>
        /// Desativa o registro
        /// </summary>
        public void Excluir()
        {
            this.Excluido = true;
        }


    }
}
