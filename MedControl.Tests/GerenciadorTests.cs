using MedControl.App;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MedControl.Tests;

public class GerenciadorTests
{
    // Cenário 1: Caminho Feliz (Entrada Correta)
    [Fact]
    public void Adicionar_MedicamentoValido_DeveAdicionarALista()
    {
        // Arrange (Preparação)
        var gerenciador = new GerenciadorMedicamentos();

        // Act (Ação)
        gerenciador.Adicionar("Dipirona - 12:00");

        // Assert (Verificação)
        Assert.Contains("Dipirona - 12:00", gerenciador.Listar());
    }

    // Cenário 2: Entrada Inválida (Tentativa de adicionar vazio)
    [Fact]
    public void Adicionar_NomeVazio_DeveLancarExcecao()
    {
        // Arrange
        var gerenciador = new GerenciadorMedicamentos();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => gerenciador.Adicionar(""));
    }

    // Cenário 3: Caso Limite (Tentativa de remover um medicamento que não está na lista)
    [Fact]
    public void Remover_MedicamentoInexistente_DeveLancarExcecao()
    {
        // Arrange
        var gerenciador = new GerenciadorMedicamentos();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => gerenciador.Remover("Losartana"));
    }
}

// === NOVO TESTE DE INTEGRAÇÃO DA API AQUI ===
public class ApiIntegrationTests
{
    [Fact]
    public async Task ViaCep_DeveRetornarEndereco_ParaCepValido()
    {
        // Arrange: Prepara os dados (Vamos usar o CEP da Praça da Sé em SP)
        using var client = new HttpClient();
        string cepValido = "01001000";
        string url = $"https://viacep.com.br/ws/{cepValido}/json/";

        // Act: Faz a chamada real para a API
        var response = await client.GetAsync(url);
        string responseBody = await response.Content.ReadAsStringAsync();

        // Assert: Verifica se a resposta foi um sucesso e contém as informações certas
        Assert.True(response.IsSuccessStatusCode, "A API não retornou sucesso.");
        Assert.Contains("Praça da Sé", responseBody);
        Assert.Contains("São Paulo", responseBody);
    }
}