namespace Caixa_Farmacia
{
    internal class Loads
    {
        /// <summary>
        /// Carrega os itens salvos nos arquivos .json para as listas estáticas da classe Lists.cs
        /// </summary>
        public static void LoadJsonList()
        {
            Lists.listOfMedicines = Repositories.ReposMedicines.LoadList();
            Lists.listSaleMedicines = Repositories.ReposSales.LoadList();
        }

    }
}
