namespace Caixa_Farmacia
{
    internal class Medicines : IMedicines
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Stock { get; set; }
        public double UnitPrice { get; set; }
        public DateOnly ExpirationDate { get; set; }

        /// <summary>
        /// Construtor da classe <c>Medicines</c>.
        /// </summary>
        /// <param name="name"> Nome do medicamento. </param>
        /// <param name="code"> Códico único gerado por um método. </param>
        /// <param name="stock"> Estoque do medicamento. </param>
        /// <param name="unitPrice"> Preço unitário do medicamento. </param>
        /// <param name="expirationDate"> Data de validade do medicamento. </param>
        public Medicines(string name, string code, int stock, double unitPrice, DateOnly expirationDate)
        {
            Name = name;
            Code = code;
            Stock = stock;
            UnitPrice = unitPrice;
            ExpirationDate = expirationDate;
        }
    }
}
