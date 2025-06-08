namespace Caixa_Farmacia
{
    internal class Sale
    {
        public string Code { get; set; }
        public int QuantitySold { get; set; }
        public DateTime DateOfSale { get; set; }
        public double TotalPrice { get; set; }

        /// <summary>
        /// Construtor da classe Sale.cs
        /// </summary>
        /// <param name="code"> Recene o código do medicamento vendido. </param>
        /// <param name="quantitySold"> Recebe a quantidade de medicamento vendido. </param>
        /// <param name="dateOfSale"> Recebe a data do sistema como data da venda. </param>
        /// <param name="totalPrice"> Recebe o valor total da venda. </param>
        public Sale(string code, int quantitySold, DateTime dateOfSale, double totalPrice)
        {
            Code = code;
            QuantitySold = quantitySold;
            DateOfSale = dateOfSale;
            TotalPrice = totalPrice;
        }
    }
}
