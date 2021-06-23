using System;
using DIO.series.Classes;

namespace DIO.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while(opcaoUsuario.ToUpper() != "X")
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
            Console.WriteLine("Listar series");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
            } else
            {
                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : "");
                }
            }
      
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir serie");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
                                        genero: (Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        descricao: entradaDescricao,
                                        ano: entradaAno );
            
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da serie a ser atualizada");
            int idSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: idSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Atualiza(idSerie, novaSerie);
        }

        static void ExcluirSerie()
        {
            Console.WriteLine("Favor, digite o ID da serie a ser excluída");
            int idSerieExcluida = int.Parse(Console.ReadLine());
            repositorio.Exclui(idSerieExcluida);
        }

        static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da serie:");
            int idSerieVer = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornoPorId(idSerieVer);
            Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Series a seu dispor");
            Console.WriteLine("Informe a opcao desejada");
            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
