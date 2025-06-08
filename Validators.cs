namespace Caixa_Farmacia
{
    internal class Validators
    {
        /// <summary>
        /// Validador de campo string.
        /// </summary>
        /// <param name="value"> Recebe o valor da variável, ou seja, seu nome para validar seu conteúdo. </param>
        /// <param name="message"> Mensagem que vai ser exibida se value cair dentro do IF. </param>        
        /// <returns> Retorna <c>true</c> se for nula ou vazia, caso contrário, retorna <c>false</c>. </returns>
        public static bool ValidateRequiredField(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                Utilities.ErrorMessage(message);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica se existem itens da lista de medicamentos.
        /// </summary>
        /// <returns> Retorna <c>false</c> se não houver itens, e <c>true</c> se houver. </returns>
        public static bool ListHasItens()
        {
            if (Lists.listOfMedicines.Count == 0)
            {
                Utilities.ErrorMessage("AINDA NÃO EXISTEM MEDICAMENTOS CADASTRADOS!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Recebe um input e tenta converter e validar para Int.
        /// </summary>
        /// <param name="input"> Parâmetro que recebe uma variável que coleta o input do usuário. </param>
        /// <param name="value"> Parâmetro que recebe a variável externa onde o valor convertido de <c>string input</c> será armazenado. </param>
        /// <returns>Retorna true se a conversão e validação forem cumpridas, caso contrário, retorna false. </returns>
        public static bool TryParseAndValidadeInt(string input, out int value)
        {
            if (int.TryParse(input, out value) && value > 0)
            {
                return true;
            }
            Utilities.ErrorMessage("QUANTIDADE DEVE SER MAIOR QUE ZERO!");
            return false;
        }

        /// <summary>
        /// Recebe um input e tenta converter e validar para Double.
        /// </summary>
        /// <param name="input"> Parâmetro que recebe uma variável que coleta o input do usuário. </param>
        /// <param name="value"> Parâmetro que recebe a variável externa onde o valor convertido de <c>string input</c> será armazenado. </param>
        /// <returns>Retorna true se a conversão e validação forem cumpridas, caso contrário, retorna false. </returns>
        public static bool TryParseAndValidadeDouble(string input, out double value)
        {
            if (double.TryParse(input, out value) && value >= 0)
            {
                return true;
            }
            Utilities.ErrorMessage("PREÇO UNITÁRIO DEVE SER MAIOR OU IGUAL À ZERO!");
            return false;
        }

        /// <summary>
        /// Recebe um input e tenta converter e validar para DateOnly.
        /// </summary>
        /// <param name="input"> Parâmetro que recebe uma variável que coleta o input do usuário. </param>
        /// <param name="date"> Parâmetro que recebe a variável externa onde o valor convertido de <c>string input</c> será armazenado. </param>
        /// <returns>Retorna true se a conversão e validação forem cumpridas, caso contrário, retorna false. </returns>
        public static bool TryParseDateOnly(string input, out DateOnly date)
        {
            if (DateOnly.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
            {
                return true;
            }
            Utilities.ErrorMessage("DATA INVÁLIDA! TENTE NO FORMATO 'dd/MM/yyyy'!");
            return false;
        }
    }
}
