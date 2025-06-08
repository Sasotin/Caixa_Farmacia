namespace Caixa_Farmacia
{
    internal class ChooseFunctionality
    {
        public static void Chooses()
        {
            bool running = true;
            while (running)
            {
                Utilities.Dialogues("""
                    ------------------------------------
                    ### SELECIONE UMA FUNCIONALIDADE ###
                    1. Medicametos.
                    2. Vendas.
                    3. Sair.
                    ------------------------------------
                    """, false);

                var option = Console.ReadLine();
                switch(option)
                {
                    case "1":
                        ChoosesMedicines();
                        break;
                    case "2":
                        ChoosesSales();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Utilities.ErrorMessage("OPÇÃO INVÁLIDA!");
                        break;
                }
            }
        }
        
        private static void ChoosesMedicines()
        {
            while (true)
            {
                Utilities.Dialogues("""
                    ----------------------------
                    ### SELECIONE UMA OPÇÃO ###
                    1. Cadastrar Medicametos.
                    2. Atualizar Medicametos.
                    3. Listar Medicametos.
                    4. Remover Medicametos.
                    5. Sair.
                    ----------------------------
                    """, false);

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        InventoryManagement.RegisterMedicines();
                        return;
                    case "2":
                        InventoryManagement.UpdateRegistration();
                        return;
                    case "3":
                        InventoryManagement.ListMedicines();
                        return;
                    case "4":
                        InventoryManagement.RemoveMedicines();
                        return;
                    case "5":
                        return;
                    default:
                        Utilities.ErrorMessage("OPÇÃO INVÁLIDA!");
                        break;
                }
            }
        }

        private static void ChoosesSales()
        {
            while (true)
            {
                Utilities.Dialogues("""
                    ----------------------------
                    ### SELECIONE UMA OPÇÃO ###
                    1. Realizar Venda.
                    2. Histórico de vendas.
                    3. Sair.
                    ----------------------------
                    """, false);

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        SaleOfMedicines.SaleMecidines();
                        return;
                    case "2":
                        SalesHistory.ListSalesHistory();
                        return;
                    case "3":
                        return;
                    default:
                        Utilities.ErrorMessage("OPÇÃO INVÁLIDA!");
                        break;

                }
            }
        }
    }
}
