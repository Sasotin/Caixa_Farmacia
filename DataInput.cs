namespace Caixa_Farmacia
{
    internal class DataInput
    {
        /// <summary>
        /// Recebe uma string não null/empty.
        /// </summary>
        /// <param name="message"> Menssagem de interação. </param>
        /// <param name="error"> Mensagem de erro caso a string seja null/empty. </param>
        /// <returns> Retorna a string recebida. </returns>
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

        /// <summary>
        /// Recebe uma string e retorna um int.
        /// </summary>
        /// <param name="message"> Mensagem de interação. </param>
        /// <returns> Retorna a string convertida em interiro. </returns>
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

        /// <summary>
        /// Recebe uma string e retorna um double.
        /// </summary>
        /// <param name="message"> Mensagem de interação. </param>
        /// <returns> Retorna a string convertida em double. </returns>
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

        /// <summary>
        /// Recebe uma string e retorna para DateOnly.
        /// </summary>
        /// <param name="message"> Mensagem de interação. </param>
        /// <returns> Retorna a string convertida em DateOnly. </returns>
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
