using GestaoDeEquipamentos.ConsoleApp;

public class TelaChamado
{
    private ChamadoGerenciador gerenciadorChamados;
    private TelaEquipamento telaEquipamento;

    public TelaChamado(TelaEquipamento telaEquipamento, ChamadoGerenciador gerenciadorChamados)
    {
        this.telaEquipamento = telaEquipamento;
        this.gerenciadorChamados = gerenciadorChamados;
    }

    public string ApresentarMenuChamados()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Escolha a operação desejada:");
        Console.WriteLine("1 - Registrar Chamado");
        Console.WriteLine("2 - Visualizar Chamados");
        Console.WriteLine("3 - Editar Chamado");
        Console.WriteLine("4 - Excluir Chamado");
        Console.WriteLine("--------------------------------------------");

        Console.Write("Digite uma opção válida: ");
        string opcaoEscolhida = Console.ReadLine();

        return opcaoEscolhida;
    }

    public void RegistrarChamado()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Registrar Chamado");
        Console.WriteLine("--------------------------------------------");

        if (telaEquipamento.contadorEquipamentos == 0)
        {
            Console.WriteLine("Nenhum equipamento cadastrado. Cadastre um equipamento primeiro.");
            return;
        }

        Console.WriteLine("Equipamentos Cadastrados:");
        telaEquipamento.VisualizarEquipamentos(false);

        Console.Write("Digite o ID do equipamento para o chamado: ");
        int idEquipamento;
        if (!int.TryParse(Console.ReadLine(), out idEquipamento))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        Equipamento equipamentoSelecionado = null;
        for (int i = 0; i < telaEquipamento.equipamentos.Length; i++)
        {
            if (telaEquipamento.equipamentos[i] != null && telaEquipamento.equipamentos[i].Id == idEquipamento)
            {
                equipamentoSelecionado = telaEquipamento.equipamentos[i];
                break;
            }
        }

        if (equipamentoSelecionado == null)
        {
            Console.WriteLine($"Equipamento com ID {idEquipamento} não encontrado.");
            return;
        }

        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição do chamado: ");
        string descricao = Console.ReadLine();

        Console.Write("Digite a data de abertura do chamado (dd/MM/yyyy): ");
        DateTime dataAbertura;
        if (!DateTime.TryParse(Console.ReadLine(), out dataAbertura))
        {
            Console.WriteLine("Data inválida.");
            return;
        }

        Chamado novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado, dataAbertura);
        gerenciadorChamados.AdicionarChamado(novoChamado);

        Console.WriteLine("Chamado registrado com sucesso!");
    }

    public void VisualizarChamados()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Visualizar Chamados");
        Console.WriteLine("--------------------------------------------");

        if (gerenciadorChamados.ObterContadorChamados() == 0)
        {
            Console.WriteLine("Nenhum chamado registrado.");
            return;
        }

        Console.WriteLine("{0, -10} | {1, -20} | {2, -15} | {3, -12} | {4, -15}",
                          "ID", "Título", "Equipamento", "Abertura", "Dias Abertos");
        Console.WriteLine("------------------------------------------------------------------");

        Chamado[] chamados = gerenciadorChamados.ObterTodosChamados();
        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i] != null)
            {
                Console.WriteLine(chamados[i].ObterInformacoesParaVisualizacao());
            }
        }

        Console.WriteLine();
    }

    public void EditarChamado()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Editar Chamado");
        Console.WriteLine("--------------------------------------------");

        if (gerenciadorChamados.ObterContadorChamados() == 0)
        {
            Console.WriteLine("Nenhum chamado registrado para editar.");
            return;
        }

        Console.WriteLine("Chamados Registrados:");
        Chamado[] chamados = gerenciadorChamados.ObterTodosChamados();
        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i] != null)
            {
                Console.WriteLine($"ID: {chamados[i].Id} | Título: {chamados[i].Titulo} | Equipamento: {chamados[i].Equipamento.Nome}");
            }
        }

        Console.Write("Digite o ID do chamado que deseja editar: ");
        int idChamadoEditar;
        if (!int.TryParse(Console.ReadLine(), out idChamadoEditar))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        Chamado chamadoParaEditar = gerenciadorChamados.EncontrarChamadoPorId(idChamadoEditar);

        if (chamadoParaEditar == null)
        {
            Console.WriteLine($"Chamado com ID {idChamadoEditar} não encontrado.");
            return;
        }

        Console.WriteLine("\nPreencha os novos dados do chamado:");

        Console.Write($"Novo título ({chamadoParaEditar.Titulo}): ");
        string novoTitulo = Console.ReadLine();

        Console.Write($"Nova descrição ({chamadoParaEditar.Descricao}): ");
        string novaDescricao = Console.ReadLine();

        Console.WriteLine("Equipamentos Cadastrados:");
        telaEquipamento.VisualizarEquipamentos(false);
        Console.Write($"Novo ID do equipamento ({chamadoParaEditar.Equipamento.Id} - {chamadoParaEditar.Equipamento.Nome}): ");
        int novoIdEquipamento;
        Equipamento novoEquipamentoSelecionado = null;
     
     
        
            novoEquipamentoSelecionado = chamadoParaEditar.Equipamento;
        

        Console.Write($"Nova data de abertura ({chamadoParaEditar.DataAbertura:dd/MM/yyyy}): ");
        string novaDataAberturaStr = Console.ReadLine();
        DateTime novaDataAbertura;
      
            novaDataAbertura = chamadoParaEditar.DataAbertura;
           
        

        chamadoParaEditar.Editar(novoTitulo, novaDescricao, novoEquipamentoSelecionado, novaDataAbertura);
        Console.WriteLine("Chamado editado com sucesso!");
    }

    public void ExcluirChamado()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Excluir Chamado");
        Console.WriteLine("--------------------------------------------");

        if (gerenciadorChamados.ObterContadorChamados() == 0)
        {
            Console.WriteLine("Nenhum chamado registrado para excluir.");
            return;
        }

        Console.WriteLine("Chamados Registrados:");
        Chamado[] chamados = gerenciadorChamados.ObterTodosChamados();
        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i] != null)
            {
                Console.WriteLine($"ID: {chamados[i].Id} | Título: {chamados[i].Titulo}");
            }
        }

        Console.Write("Digite o ID do chamado que deseja excluir: ");
        int idChamadoExcluir;
        if (!int.TryParse(Console.ReadLine(), out idChamadoExcluir))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        gerenciadorChamados.RemoverChamado(idChamadoExcluir);
        Console.WriteLine("Chamado excluído com sucesso!");
    }
}