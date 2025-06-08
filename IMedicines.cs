namespace Caixa_Farmacia
{
    /// <summary>
    /// Interface criada para que o método CustomForeach consiga ler as propriedades de Medicines.cs
    /// </summary>
    internal interface IMedicines
    {
        string Name { get; }
        string Code { get; }
        int Stock { get; }
        double UnitPrice { get; }
        DateOnly ExpirationDate { get; }
    }
}
