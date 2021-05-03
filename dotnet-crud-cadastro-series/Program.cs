using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_crud_cadastro_series
{
    class Program
    {
		//Camada de dados
		static SerieRepositorio repositorio = new SerieRepositorio();
		
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			//mostra as series
			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));//condicional ternario
			}
		}

		private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			Console.Write($"Deseja realmente excluir a serie {indiceSerie}? Informe  S=sim ou N=não : ");			
            if (Console.ReadLine().ToLower().Equals("s"))
            {
				repositorio.Exclui(indiceSerie);
				return;
			}
						
		}

		private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

		private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			Serie atualizaSerie = new Serie();
			atualizaSerie.SetId(indiceSerie); 
			repositorio.Atualiza(indiceSerie, CarregaObjeto(atualizaSerie));
		}

		/// <summary>
		/// inserie uma nova serie
		/// </summary>
		private static void InserirSerie()
		{
			Serie novaSerie = new Serie();
			repositorio.Insere(CarregaObjeto(novaSerie));
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("---------------------------------------------------------------------------------");
			Console.WriteLine("Andre.Séries a seu dispor!!!");
			Console.WriteLine("---------------------------------------------------------------------------------");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static Serie CarregaObjeto(Serie obj)
		{
			int indiceSerie = 0;

			if (obj.Id < 0)
			{
				Console.WriteLine("Inserir nova série");
				indiceSerie = repositorio.ProximoId();
			}

			//Lista de genero:
			int entradaGenero = ListaGeneros();

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(
							id: indiceSerie,
							genero: (Genero)entradaGenero,
							titulo: entradaTitulo,
							ano: entradaAno,
							descricao: entradaDescricao);

			obj = novaSerie;

			return obj;
		}

		private static int ListaGeneros()
		{
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			// Mostra a lista de generos: 
			Console.WriteLine("Gêneros disponiveis:");
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
                if (i>0)
                {
					Console.WriteLine("  {0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
								
			}
			Console.Write("Digite o gênero entre as opções acima: ");

			return int.Parse(Console.ReadLine());
		}
	}
}