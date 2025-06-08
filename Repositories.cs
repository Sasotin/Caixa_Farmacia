namespace Caixa_Farmacia
{
    /// <summary>
    /// Essa classe é responsável por criar os repositórios de itens.
    /// </summary>
    internal class Repositories
    {
        public static GenericRepository<Medicines> ReposMedicines = new("Repositorio_Medicamentos.json");
        public static GenericRepository<Sale> ReposSales = new("Repositorio_Vendas.json");
    }
}
