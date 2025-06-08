using System.Text.Json;
namespace Caixa_Farmacia
{
    internal class GenericRepository<GenericList>
    {
        private readonly string filePath;

        /// <summary>
        /// Construtor para receber o nome do arquivo e criá-lo na posta "Documentos".
        /// </summary>
        /// <param name="fileName"> Recebe o nome do arquivo para ser criado. </param>
        public GenericRepository(string fileName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Path.Combine(documentsPath, fileName);
        }

        /// <summary>
        /// Carrega a lista que utilizar o método.
        /// </summary>
        /// <returns> Caso o arquivo não exista, retorna uma nova lista. Em caso de ocorrer algum outro erro/exceção, retorna uma nova lista. </returns>
        /// <remarks> Esse método carrega o arquivo .json contendo os dados para a lista correspondente. </remarks>
        public List<GenericList> LoadList()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return [];
                }

                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<GenericList>>(json) ?? [];
            }
            catch (Exception ex)
            {
                Utilities.ErrorMessage($"""
                    ERRO AO CARREGAR LISTA! 
                    CAMINHO: {filePath}                    
                    ERRO: {ex.Message}
                    """);
                return [];
            }
        }

        /// <summary>
        /// Salva a lista passada como parâmetro no formato JSON.
        /// </summary>
        /// <param name="list"> Lista genérica passada como parâmetro para utilizar o método SaveList<. </param>
        /// <remarks> Esse método salva a lista passada como parametro em um arquivo .json para posterior utilização dentro do programa. </remarks>
        public void SaveList(List<GenericList> list)
        {
            try
            {
                string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Utilities.ErrorMessage($"""
                    ERRO AO SALVAR!
                    CAMINHO: {filePath} 
                    ERRO: {ex.Message}
                    """);
            }
        }
    }
}
