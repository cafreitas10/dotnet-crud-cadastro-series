using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet_crud_cadastro_series.Interfaces;

namespace dotnet_crud_cadastro_series
{
	public class SerieRepositorio : IRepositorio<Serie> //implementa a interface
	{
		/// <summary>
		/// Banco de dados em momoria...
		/// </summary>
		private List<Serie> listaSerie = new List<Serie>();
		public void Atualiza(int id, Serie objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count; //retorna o ultimo id - numero de registros
		}

		public Serie RetornaPorId(int id)
		{
			return listaSerie[id];//pega pelo indice da lista
		}
	}
}
