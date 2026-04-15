using MedControl.App;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

var gerenciador = new GerenciadorMedicamentos();
bool rodando = true;

Console.WriteLine("=== MedControl: Controle de Medicamentos para Idosos ===");

while (rodando)
{
    Console.WriteLine("\n1. Adicionar Medicamento");
    Console.WriteLine("2. Listar Medicamentos");
    Console.WriteLine("3. Buscar Endereço de Farmácia (ViaCEP)");
    Console.WriteLine("4. Sair");
    Console.Write("Escolha uma opção: ");

    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Nome do medicamento e horário (Ex: Losartana - 08:00): ");
            var nome = Console.ReadLine();
            try
            {
                gerenciador.Adicionar(nome!);
                Console.WriteLine("Adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            break;

        case "2":
            var lista = gerenciador.Listar();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum medicamento cadastrado no momento.");
            }
            else
            {
                Console.WriteLine("\n--- Medicamentos Cadastrados ---");
                foreach (var m in lista)
                {
                    Console.WriteLine($"- {m}");
                }
            }
            break;

        case "3":
            Console.Write("Digite o CEP da farmácia ou paciente (somente números): ");
            var cep = Console.ReadLine();
            await BuscarEnderecoPorCepAsync(cep!);
            break;

        case "4":
            rodando = false;
            Console.WriteLine("Encerrando o MedControl...");
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}

// Função de busca da API
async Task BuscarEnderecoPorCepAsync(string cep)
{
    using HttpClient client = new HttpClient();
    try
    {
        Console.WriteLine("\nConsultando API do ViaCEP...");
        string url = $"https://viacep.com.br/ws/{cep}/json/";
        
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(responseBody);
        JsonElement root = doc.RootElement;

        if (root.TryGetProperty("erro", out _))
        {
            Console.WriteLine("CEP não encontrado na base de dados.");
            return;
        }

        string logradouro = root.GetProperty("logradouro").GetString() ?? "";
        string bairro = root.GetProperty("bairro").GetString() ?? "";
        string localidade = root.GetProperty("localidade").GetString() ?? "";
        string uf = root.GetProperty("uf").GetString() ?? "";

        Console.WriteLine($"\n--- Endereço Encontrado ---");
        Console.WriteLine($"Rua: {logradouro}");
        Console.WriteLine($"Bairro: {bairro}");
        Console.WriteLine($"Cidade: {localidade} - {uf}");
        Console.WriteLine("---------------------------\n");
    }
    catch (Exception e)
    {
        Console.WriteLine($"\nErro ao conectar com a API: {e.Message}");
    }
}