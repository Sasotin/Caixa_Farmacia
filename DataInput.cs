namespace Caixa_Farmacia
{
    internal class DataInput
    {
        /// <summary>
        /// Recebe uma string se 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string InputString(string message, string error = "CAMPO OBRIGATÓRIO!")
        {
            string input;
            do
            {
                Utilities.Dialogues(message);
                input = Console.ReadLine();
            }
            while (Validators.ValidateRequiredField(input, error));
            return input;
        }

        public static int InputInt(string message)
        {
            int value;
            while (true)
            {
                Utilities.Dialogues(message);
                var userInputInt = Console.ReadLine().Trim();
                if (Validators.TryParseAndValidadeInt(userInputInt, out value))
                {
                    break;
                }
            }
            return value;
        }

        public static double InputDouble(string message)
        {
            double unitPrice;
            while (true)
            {
                Utilities.Dialogues(message);
                var inputUnitPrice = Console.ReadLine().Trim();
                if (Validators.TryParseAndValidadeDouble(inputUnitPrice, out unitPrice))
                {
                    break;
                }
            }
            return unitPrice;
        }

        public static DateOnly InputDateOnly(string message)
        {
            DateOnly expirationDate;
            while (true)
            {
                Utilities.Dialogues(message);
                string inputExpirationDate = Console.ReadLine().Trim();
                if (Validators.TryParseDateOnly(inputExpirationDate, out expirationDate))
                {
                    break;
                }
            }
            return expirationDate;
        }
    }
}
