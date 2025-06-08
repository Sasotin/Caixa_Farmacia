namespace Caixa_Farmacia
{
    internal class InventoryManagement
    {
        /// <summary>
        /// Cadastra medicamentos novos na lista/json.
        /// </summary>
        /// <remarks> Esse método invoca métodos de DataInput para receber strings e validar/converter a entrada.
        /// Também invoca um método que atribui um código unico ao medicamento.
        /// Depois de cadastrado, os dados do medicamento são salvos no .json e exibidos ao usuário.
        /// </remarks>
        public static void RegisterMedicines()
        {
            string name = DataInput.InputString("Insira o nome do medicamento: ");
            int stock = DataInput.InputInt("Insira a quantidade para ser integrada ao estoque: ");
            double unitPrice = DataInput.InputDouble("Insira o preço unitário do medicamento: R$ ");
            DateOnly expirationDate = DataInput.InputDateOnly("Insira a data de vencimento do medicamento (dd/MM/yyyy): ");
            string generetedCode = Utilities.CodeGenerator();

            Medicines newMedicines = new Medicines(name, generetedCode, stock, unitPrice, expirationDate);
            Lists.listOfMedicines.Add(newMedicines);
            Repositories.ReposMedicines.SaveList(Lists.listOfMedicines);
            Utilities.Dialogues($"""
                -------------------------------------------
                ### MEDICAMENTO ADICIONADO COM SUCESSO! ###
                NOME: {name}
                CÓDIGO: {generetedCode}
                ESTOQUE: {stock}
                PREÇO UNITÁRIO: R$ {unitPrice:f2}
                VALIDADE: {expirationDate}
                -------------------------------------------
                """, false, ConsoleColor.Green);
            return;
        }

        /// <summary>
        /// Exibe os medicamentos dentro da lista/json.
        /// </summary>
        /// <remarks> Esse método permite listar os medicamentos cadastrados.
        /// É possivel listar todos os medicamentos, apenas os com data de veicmento próximo e também os já expirados.
        /// </remarks>
        public static void ListMedicines()
        {
            while (true)
            {
                if (!Validators.ListHasItens()) return;
                Utilities.Dialogues("""

                1. Listar todos os medicamentos.
                2. Listar apenas os medicamentos próximos do vencimento.
                3. Listar apenas os medicamentos vencidos.

                """, false);
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Utilities.CustomForeach("### TODOS OS MEDICAMENTOS ###", ConsoleColor.Cyan, Lists.listOfMedicines);
                        return;
                    case "2":
                        Utilities.CustomForeach("### MEDICAMENTOS PRÓXIMOS DO VENCIMENTO ###", ConsoleColor.DarkYellow, Utilities.ExpiringMedicines(30));
                        return;
                    case "3":
                        Utilities.CustomForeach("### MEDICAMENTOS VENCIDOS ###", ConsoleColor.Red, Utilities.ExpiredMedicines());
                        return;
                    default:
                        Utilities.ErrorMessage("OPÇÃO INVÁLIDA!");
                        return;
                }                
            }
        }

        /// <summary>
        /// Atualiza os detalhes de um medicamento existente na lista/json.
        /// </summary>
        /// <remarks>Este método permite que o usuário pesquise um medicamento pelo nome ou código e atualize
        /// seus detalhes, incluindo nome, quantidade em estoque, preço unitário e data de validade. Se o medicamento for encontrado, seus
        /// detalhes atuais serão exibidos antes de solicitar atualizações. Se nenhum medicamento correspondente for encontrado, uma mensagem de
        /// erro será exibida..</remarks>
        public static void UpdateRegistration()
        {
            if (!Validators.ListHasItens()) return;
            Utilities.Dialogues("\nInsira o nome ou código do medicamento que deseja atualizar: ");
            string searchForMedicine = Console.ReadLine().Trim();
            Validators.ValidateRequiredField(searchForMedicine, "NÃO EXISTEM MEDICAMENTOS CADASTRADOS!");
            Medicines medicineFound = Lists.listOfMedicines.Find(m => m.Name.Equals(searchForMedicine, StringComparison.OrdinalIgnoreCase) || m.Code == searchForMedicine); 
            if (medicineFound != null)
            {
                Utilities.Dialogues($"""
                -----------------------------------------------
                ### MEDICAMENTO ENCONTRADO! ###
                NOME: {medicineFound.Name}
                CÓDIGO: {medicineFound.Code}
                ESTOQUE: {medicineFound.Stock}
                PREÇO UNITÁRIO: R$ {medicineFound.UnitPrice:f2}
                VALIDADE: {medicineFound.ExpirationDate}
                -----------------------------------------------
                """, false, ConsoleColor.Magenta);

                medicineFound.Name = DataInput.InputString("Novo nome: ");
                medicineFound.Stock = DataInput.InputInt("Insira a quantidade para ser integrada ao estoque: ");
                medicineFound.UnitPrice = DataInput.InputDouble("Insira o preço unitário do medicamento: R$ ");
                medicineFound.ExpirationDate = DataInput.InputDateOnly("Insira a data de vencimento do medicamento (dd/MM/yyyy): ");
                Repositories.ReposMedicines.SaveList(Lists.listOfMedicines);
                Utilities.Dialogues($"Medicamento {medicineFound.Code} atualizado com sucesso!", false, ConsoleColor.Green);
            }
            else
            {
                Utilities.ErrorMessage("MEDICAMENTO NÃO ENCONTRADO!");
            }
        }

        /// <summary>
        /// Remove um medicamento da lista/json.
        /// </summary>
        /// <remarks> 
        /// Este método permite que o usuário pesquise um medicamento pelo nome ou código e remova-o.
        /// Se não for nulo, remove o item e salva a lista, se for, retorna uma mensagem de erro.
        /// </remarks>
        public static void RemoveMedicines()
        {
            if (!Validators.ListHasItens()) return;
            string searchForMedicine = DataInput.InputString("\nInsira o nome ou código do medicamento que deseja remover: ", "NÃO EXISTEM MEDICAMENTOS CADASTRADOS!");
            Medicines medicineFound = Lists.listOfMedicines.Find(m => m.Name.Equals(searchForMedicine, StringComparison.OrdinalIgnoreCase) || m.Code == searchForMedicine);
            if (medicineFound != null)
            {
                Lists.listOfMedicines.Remove(medicineFound);
                Repositories.ReposMedicines.SaveList(Lists.listOfMedicines);
                Utilities.Dialogues($"Medicamento {medicineFound.Name}, código {medicineFound.Code} removido com sucesso!", false, ConsoleColor.Green);
            }
            else
            {
                Utilities.ErrorMessage("MEDICAMENTO NÃO ENCONTRADO!");
            }
        }
    }
}
