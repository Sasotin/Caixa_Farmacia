namespace Caixa_Farmacia
{
    internal class Loads
    {
        public static void LoadJsonList()
        {
            Lists.listOfMedicines = Repositories.ReposMedicines.LoadList();
            Lists.listSaleMedicines = Repositories.ReposSales.LoadList();
        }

    }
}
