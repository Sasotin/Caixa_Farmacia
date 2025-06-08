namespace Caixa_Farmacia
{
    internal interface IMedicines
    {
        string Name { get; }
        string Code { get; }
        int Stock { get; }
        double UnitPrice { get; }
        DateOnly ExpirationDate { get; }
    }
}
