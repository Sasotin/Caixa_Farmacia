using System.Runtime.ConstrainedExecution;

namespace Caixa_Farmacia
{
    internal class SalesHistory
    {
        public static void ListSalesHistory()
        {
            if (Lists.listSaleMedicines.Count == 0)
            {
                Utilities.ErrorMessage("AINDA NÃO EXISTEM VENDAS REALIZADAS!");
                return;
            }
            foreach (Sale s in Repositories.ReposSales.LoadList())
            {
                Utilities.Dialogues($"""
                 -------------------------------
                 CÓDIGO: {s.Code}
                 QUANT. VENDIDA: {s.QuantitySold}
                 PREÇO TOTAL: R$ {s.TotalPrice:f2}
                 DATA DA VENDA: {s.DateOfSale}
                 """, false, ConsoleColor.Yellow);
            }
        }
    }
}
