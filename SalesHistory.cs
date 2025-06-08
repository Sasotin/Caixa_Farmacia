using System.Runtime.ConstrainedExecution;

namespace Caixa_Farmacia
{
    internal class SalesHistory
    {
        /// <summary>
        /// Exibe o histórico de vendas realizadas.
        /// </summary>
        /// <remarks> Esse método verifica se existem vendas realizadas e, se exitirem vendas, as exibe.
        /// As vendas são exibidas a partir do arquivo .json onde as vendas foram salvas.
        /// </remarks>
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
