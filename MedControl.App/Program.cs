using MedControl.App;

var gerenciador = new GerenciadorMedicamentos();
bool rodando = true;

Console.WriteLine("=== MedControl: Controle de Medicamentos para Idosos ===");

while (rodando)
{
    Console.WriteLine("\n1. Adicionar Medicamento");
    Console.WriteLine("2. Listar Medicamentos");
    Console.WriteLine("3. Sair");
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
            rodando = false;
            Console.WriteLine("Encerrando o MedControl...");
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}