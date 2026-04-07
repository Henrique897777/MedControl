using MedControl.App;

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