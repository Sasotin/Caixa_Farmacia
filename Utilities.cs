namespace Caixa_Farmacia
{
    internal class Utilities
    {
        public static List<Medicines> ExpiringMedicines(int futureDays = 1)
        {
            DateOnly futureSystemDate = DateOnly.FromDateTime(DateTime.Now).AddDays(futureDays);       
            DateOnly systemDate = DateOnly.FromDateTime(DateTime.Now);
            return Lists.listOfMedicines.Where(m => m.ExpirationDate > systemDate && m.ExpirationDate <= futureSystemDate).ToList();
        }

        public static List<Medicines> ExpiredMedicines()
        {
            DateOnly systemDate = DateOnly.FromDateTime(DateTime.Now);
            return Lists.listOfMedicines.Where(m => m.ExpirationDate <= systemDate).ToList();
        }

        public static void CustomForeach<T>(string title, ConsoleColor cor, List<T> list) where T : IMedicines
        {
            Dialogues(title, false, cor);
            foreach (T m in list)
            {
                Utilities.Dialogues($"""
                 -------------------------------
                 NOME: {m.Name}
                 CÓDIGO: {m.Code}
                 ESTOQUE: {m.Stock}
                 PREÇO UNITÁRIO: R$ {m.UnitPrice:f2}
                 VALIDADE: {m.ExpirationDate}
                 """, false, cor);
            }
        }
        
        /// <summary>
        /// Gera um código aleatório para o medicamento.
        /// </summary>
        /// <returns> Retorna um código após verificar se já existe na lista. Se já existir, retorna um novo código. </returns>
        public static string CodeGenerator()
        {
            Random rand = new Random();
            string generetedCode;
            bool codeExists;
            do
            {
                generetedCode = $"{rand.Next(100000, 999999)}";
                codeExists = Lists.listOfMedicines.Exists(codeExists => codeExists.Code == generetedCode);
            }
            while (codeExists);
            return generetedCode;
        }

        /// <summary>
        /// Unifica a criação de mensagens de diálogo para interação do usuário.
        /// </summary>
        /// <param name="dialogues"> Recebe a message que vai ser exibida. </param>        
        /// <param name="inLine"> Se <c>true</c>, usa Write, se <c>false</c> usa WriteLine. </param>
        /// <param name="color"> Parâmetro para modificar a cor da message. Por padrão é White/Branco. </param>
        public static void Dialogues (string dialogues, bool inLine = true, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            if (inLine)
            {
                Console.Write(dialogues);
            }
            else
            {
                Console.WriteLine(dialogues);
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Unifica a criação de mensagens de erro.
        /// </summary>
        /// <param name="errorMessage"> Parâmetro que recebe a message. </param>
        public static void ErrorMessage (string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{errorMessage}\n");
            Console.ResetColor();
        }           
    }
}
