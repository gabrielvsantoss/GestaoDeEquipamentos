using System.ComponentModel.Design;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaEquipamento telaEquipamento = new TelaEquipamento();

            ChamadoGerenciador gerenciadorChamados = new ChamadoGerenciador();
            TelaChamado telaChamado = new TelaChamado(telaEquipamento, gerenciadorChamados);

            while (true)
            {
                while (true)
                {
                    Console.Clear();
                    Console.Clear();
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Menu Principal");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Escolha a seção:");
                    Console.WriteLine("1 - Gestão de Equipamentos");
                    Console.WriteLine("2 - Gestão de Chamados");
                    Console.WriteLine("3 - Sair");
                    Console.WriteLine("--------------------------------------------");
                    Console.Write("Digite sua opção: ");
                    string opcaoPrincipal = Console.ReadLine();

                    if (opcaoPrincipal == "1")
                    {
                        string opcaoEscolhida = telaEquipamento.ApresentarMenu();

                        while (opcaoEscolhida == "1" || opcaoEscolhida == "2" || opcaoEscolhida == "3" || opcaoEscolhida == "4")
                        {

                            switch (opcaoEscolhida)
                            {
                                case "1":
                                    telaEquipamento.CadastrarEquipamento();
                                    break;

                                case "2":
                                    telaEquipamento.EditarEquipamento();
                                    break;

                                case "3":
                                    telaEquipamento.ExcluirEquipamento();
                                    break;

                                case "4":
                                    telaEquipamento.VisualizarEquipamentos(true);
                                    break;

                                default:
                                    Console.WriteLine("Saindo do programa...");
                                    break;
                            }

                            Console.ReadLine();
                        }
                    }

                    else if (opcaoPrincipal == "2")
                    {
                        string opcaoChamado = telaChamado.ApresentarMenuChamados();

                        while (opcaoChamado == "1" || opcaoChamado == "2" || opcaoChamado == "3" || opcaoChamado == "4")
                        {

                            switch (opcaoChamado)
                            {
                                case "1":
                                    telaChamado.RegistrarChamado();
                                    break;
                                case "2":
                                    telaChamado.VisualizarChamados();
                                    break;
                                case "3":
                                    telaChamado.EditarChamado();
                                    break;
                                case "4":
                                    telaChamado.ExcluirChamado();
                                    break;
                                default:
                                    Console.WriteLine("Voltando ao Menu Principal...");
                                    break;
                            }

                            if (opcaoChamado != "1" && opcaoChamado != "2" && opcaoChamado != "3" && opcaoChamado != "4")
                            {
                                break;
                            }
                        }
                    }
                }

                }
            }
        }
    } 