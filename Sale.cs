namespace Caixa_Farmacia
{
    internal class Sale
    {
        public string Code { get; set; }
        public int QuantitySold { get; set; }
        public DateTime DateOfSale { get; set; }
        public double TotalPrice { get; set; }

        public Sale(string code, int quantitySold, DateTime dateOfSale, double totalPrice)
        {
            Code = code;
            QuantitySold = quantitySold;
            DateOfSale = dateOfSale;
            TotalPrice = totalPrice;
        }
    }
}
