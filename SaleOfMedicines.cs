using System.Xml.Linq;

namespace Caixa_Farmacia
{
    internal class SaleOfMedicines
    {
        /// <summary>
        /// Permite ao usuário vender medicamentos previamente cadastrados.
        /// </summary>
        /// <remarks> Esse método pesquisa o medicamento pelo código e verifica se existe, se existir, verifica se já expirou.
        /// A venda de medicamentos expirados é bloqueada.
        /// O calculo do valor total é feito após a quantidade ser inserida, após isso uma mensagem de confirmação de venda é exibida.
        /// </remarks>
        public static void SaleMecidines()
        {
            DateOnly dateOfSale = DateOnly.FromDateTime(DateTime.Now);
            string codeInput = DataInput.InputString("Inisira o código do medicamento: ");
            Medicines medicineFound = Lists.listOfMedicines.Find(m => m.Code == codeInput);
            
            if (medicineFound != null)
            {
                if (medicineFound.ExpirationDate <= dateOfSale)
                {
                    Utilities.ErrorMessage("MEDICAMENTO VENCIDO. VENDA CANCELADA!");
                    return;
                }
                else if (medicineFound.ExpirationDate > dateOfSale && medicineFound.ExpirationDate <= dateOfSale.AddDays(30))
                {
                    Utilities.Dialogues($"\nMedicamento próximo do vencimento ({medicineFound.ExpirationDate})!\n", false, ConsoleColor.DarkYellow);
                }
                Utilities.Dialogues($"""
                -------------------------------------------
                ### MEDICAMENTO ENCONTRADO! ###
                NOME: {medicineFound.Name}
                CÓDIGO: {medicineFound.Code}
                ESTOQUE: {medicineFound.Stock}
                PREÇO UNITÁRIO: R$ {medicineFound.UnitPrice:f2}
                VALIDADE: {medicineFound.ExpirationDate}
                -------------------------------------------
                """, false, ConsoleColor.Yellow);
            }
            else
            {
                Utilities.ErrorMessage("MEDICAMENTO NÃO ENCONTRADO!");
            }

            double totalPriceSale;
            int amountMedicine = DataInput.InputInt("Insira a quantidade: ");
            if (amountMedicine > medicineFound.Stock)
            {
                Utilities.ErrorMessage("ESTOQUE INSUFICIENTE!");
                return;
            }           
            totalPriceSale = (double)amountMedicine * medicineFound.UnitPrice;
            Utilities.Dialogues($"Preço Total: {totalPriceSale:f2}", false);
                        
            while (true)
            {
                Utilities.Dialogues("Deseja confirmar a venda? (S/N)", false);
                var selection = Console.ReadLine().ToUpper();
                if (selection == "S")
                {
                    
                    medicineFound.Stock -= amountMedicine;
                    Sale newSale = new Sale(medicineFound.Code, amountMedicine, DateTime.Now, totalPriceSale);
                    Lists.listSaleMedicines.Add(newSale);
                    Repositories.ReposSales.SaveList(Lists.listSaleMedicines);
                    Utilities.Dialogues("Venda realizada com sucesso!", false, ConsoleColor.Green);
                    break;
                }
                else if (selection == "N")
                {
                    Utilities.Dialogues("Venda cancelada!", false, ConsoleColor.Red);
                    break;
                }
                else
                {
                    Utilities.ErrorMessage("OPÇÃO INVÁLIDA!");
                }
            }            
        }
    }
}
