# MedControl - Controle de Medicamentos

![Versão](https://img.shields.io/badge/version-1.0.0-blue.svg)
![CI](https://github.com/SEU_USUARIO/MedControl/actions/workflows/ci.yml/badge.svg)

🚀 **Acesso à aplicação:** [Clique aqui para testar o sistema no Replit](https://replit.com/@gh972027/MedControl)

## Problema Real e Proposta
**Dor social:** Muitos idosos (e seus cuidadores) possuem dificuldades em gerenciar horários de múltiplos medicamentos, o que pode levar a esquecimentos, perdas de horário ou superdosagem.
**Solução:** O `MedControl` é uma aplicação CLI simples e direta que permite o registro e a consulta rápida dos medicamentos e seus horários, garantindo um acompanhamento organizado e reduzindo a carga cognitiva do cuidador ou paciente.
**Público-alvo:** Idosos, familiares e cuidadores.

## Funcionalidades Principais
- Adicionar novo medicamento atrelado ao seu horário de consumo.
- Listar todos os medicamentos cadastrados na rotina.
- Consultar endereço automático de pacientes/farmácias através de integração com a API ViaCEP.

## Tecnologias e Ferramentas Utilizadas
- **Linguagem:** C# (.NET 8)
- **Testes Automatizados:** xUnit
- **Análise Estática (Linting):** `dotnet format`
- **Integração Contínua (CI):** GitHub Actions
- **Deploy:** Replit

## Como Instalar e Executar
1. Clone este repositório em sua máquina:
   `git clone https://github.com/Henrique897777/MedControl.git`
2. Acesse a pasta do projeto:
   `cd MedControl`
3. Execute a aplicação:
   `dotnet run --project MedControl.App`

## Como rodar os Testes e o Linting
- **Para rodar os testes automatizados:** No terminal, na raiz do projeto, execute o comando `dotnet test`
- **Para executar a análise estática (linting):** No terminal, na raiz do projeto, execute o comando `dotnet format`

## Versionamento e Dependências
A aplicação utiliza versionamento semântico (MAJOR.MINOR.PATCH). 
A versão atual é a **1.0.0**, e está declarada formalmente no arquivo manifesto `.csproj`, juntamente com as dependências do projeto.

## Autor
- GABRIEL HENRIQUE MACHADO PEREIRA