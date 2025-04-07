namespace GestaoDeEquipamentos.ConsoleApp
{
    public class Chamado
    {
        public int Id;
        public string Titulo;
        public string Descricao;
        public Equipamento Equipamento;
        public DateTime DataAbertura;

        public Chamado(string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {
            Id = GeradorIdsChamados.GerarNovoId();
            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
            DataAbertura = dataAbertura;
        }

        public void Editar(string novoTitulo, string novaDescricao, Equipamento novoEquipamento, DateTime novaDataAbertura)
        {
            if (string.IsNullOrEmpty(novoTitulo) == false)
            {
                Titulo = novoTitulo;
            }
            if (string.IsNullOrEmpty(novaDescricao) == false)
            {
                Descricao = novaDescricao;
            }
            if (novoEquipamento != null)
            {
                Equipamento = novoEquipamento;
            }
            DataAbertura = novaDataAbertura;
        }

        public string ObterInformacoesParaVisualizacao()
        {
            TimeSpan diasAbertos = DateTime.Now - DataAbertura;
            return $"{Id,-10} | {Titulo,-20} | {Equipamento.Nome,-15} | {DataAbertura,-12:dd/MM/yyyy} | {diasAbertos.Days,-15}";
        }
    }

    public static class GeradorIdsChamados
    {
        private static int _idChamados = 0;

        public static int GerarNovoId()
        {
            _idChamados++;
            return _idChamados;
        }
    }

    public class ChamadoGerenciador
    {
        private Chamado[] _chamados = new Chamado[100];
        private int _contadorChamados = 0;

        public void AdicionarChamado(Chamado chamado)
        {
            if (_contadorChamados < _chamados.Length)
            {
                _chamados[_contadorChamados++] = chamado;
            }
            else
            {
                Console.WriteLine("Limite de chamados atingido.");
            }
        }

        public Chamado EncontrarChamadoPorId(int id)
        {
            for (int i = 0; i < _chamados.Length; i++)
            {
                if (_chamados[i] != null && _chamados[i].Id == id)
                {
                    return _chamados[i];
                }
            }
            return null;
        }

        public Chamado[] ObterTodosChamados()
        {
            return _chamados;
        }

        public void RemoverChamado(int id)
        {
            for (int i = 0; i < _chamados.Length; i++)
            {
                if (_chamados[i] != null && _chamados[i].Id == id)
                {
                    _chamados[i] = null;
                    // Opcional: Compactar o array
                    break;
                }
            }
        }

        public int ObterContadorChamados()
        {
            return _contadorChamados;
        }
    }
}