namespace Caixa_Farmacia
{
    internal class Repositories
    {
        public static GenericRepository<Medicines> ReposMedicines = new("Repositorio_Medicamentos.json");
        public static GenericRepository<Sale> ReposSales = new("Repositorio_Vendas.json");
    }
}
