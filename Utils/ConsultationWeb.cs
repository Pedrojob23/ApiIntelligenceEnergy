using System.Text.Json;

namespace ApiIntelligenceEnergy.Utils;

public static class ConsultationWeb
{
    public static async Task<bool> ConsultationCnpj(string cnpj)
    {
        string apiUrl = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";
        HttpClient httpClient = new HttpClient();
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            string responseData = await response.Content.ReadAsStringAsync();
            return !responseData.Contains("\"message\": \"CNPJ inválido\"");
        }
        catch (Exception)
        {
            return false;
        }
    }


}