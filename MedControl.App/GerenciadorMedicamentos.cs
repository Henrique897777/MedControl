namespace MedControl.App;

public class GerenciadorMedicamentos
{
    private readonly List<string> _medicamentos = new();

    public void Adicionar(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do medicamento não pode ser vazio.");

        _medicamentos.Add(nome);
    }

    public List<string> Listar() => _medicamentos;

    public void Remover(string nome)
    {
        if (!_medicamentos.Contains(nome))
            throw new InvalidOperationException("Medicamento não encontrado.");

        _medicamentos.Remove(nome);
    }
}