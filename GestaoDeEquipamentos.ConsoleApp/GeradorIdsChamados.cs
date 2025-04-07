namespace GestaoDeEquipamentos.ConsoleApp
{
    public static class GeradorIdsChamados
    {
        public static int idChamados = 0;

        public static void GerarNovoId(int idChamados)
        {
            idChamados++;
            
        }
    }
}