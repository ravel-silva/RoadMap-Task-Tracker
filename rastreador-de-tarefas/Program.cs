using System.Text.Json;

public class Program
{
    private static void Main(string[] args)
    {
        // Verifica se o arquivo existe
        if (!File.Exists("Db.json"))
        {
            File.WriteAllText("Db.json", "[]");
        }

        string tarefasJson = File.ReadAllText("Db.json");

        // Se estiver vazio
        if (string.IsNullOrWhiteSpace(tarefasJson))
        {
            tarefasJson = "[]";
        }

        var tarefas =
            JsonSerializer.Deserialize<List<Tarefa>>(tarefasJson);

        bool sempreAtivo = true;

        while (sempreAtivo)
        {
            Console.WriteLine("== Menu: ==");
            Console.WriteLine("1 - Adicionar tarefa");
            Console.WriteLine("2 - Atualizar tarefa");
            Console.WriteLine("3 - Listar tarefas");
            Console.WriteLine("4 - Excluir tarefa");
            Console.WriteLine("5 - Marcar tarefa como concluída");

            Console.WriteLine("Digite a opção desejada:");
            string? opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Descreva a tarefa:");
                    string? descricao = Console.ReadLine();
                    tarefas.Add(new Tarefa
                    {
                        Id = tarefas.Count + 1,
                        Description = descricao,
                        Status = "todo",
                        CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        UpdatedAt = null
                    });
                    File.WriteAllText("Db.json", JsonSerializer.Serialize(tarefas));

                    break;
                case "2":
                    Console.WriteLine("Atualizar tarefa selecionada.");
                    if (tarefas == null || tarefas.Count == 0)
                    {
                        Console.WriteLine("Nenhuma tarefa encontrada para atualizar.");
                        return;
                    }
                    Console.WriteLine("Digite o ID da tarefa que deseja atualizar:");
                    string? idInput = Console.ReadLine();
                    if (!int.TryParse(idInput, out int id))
                    {
                        Console.WriteLine("ID inválido. Por favor, tente novamente.");
                        return;
                    }
                    var tarefaParaAtualizar = tarefas.FirstOrDefault(t => t.Id == id);
                    if (tarefaParaAtualizar == null)
                    {
                        Console.WriteLine("Tarefa não encontrada. Por favor, tente novamente.");
                        return;
                    }
                    Console.WriteLine("Digite a nova descrição da tarefa:");
                    string? novaDescricao = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(novaDescricao))
                    {
                        tarefaParaAtualizar.Description = novaDescricao;
                    }
                    tarefaParaAtualizar.UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    File.WriteAllText("Db.json", JsonSerializer.Serialize(tarefas));
                    break;
                case "3":
                    Console.WriteLine("Para Listar todas as tarefas aperte ENTER ou digite o Status (todo, in-progress, done):");
                    string? statusFiltro = Console.ReadLine()?.ToLower();
                    if (statusFiltro == null)
                    {
                        Console.WriteLine("Status inválido.");
                    }
                    else if (statusFiltro == "")
                    {
                        Console.WriteLine("=== Lista de Tarefas ===");
                        // Verifica se a lista está vazia
                        if (tarefas == null || tarefas.Count == 0)
                        {
                            Console.WriteLine("Nenhuma tarefa encontrada.");
                            return;
                        }
                        // Exibe as tarefas
                        foreach (var tarefa in tarefas)
                        {
                            Console.WriteLine($"ID: {tarefa.Id}");
                            Console.WriteLine($"Descrição: {tarefa.Description}");
                            Console.WriteLine($"Status: {tarefa.Status}");
                            Console.WriteLine($"Criado em: {tarefa.CreatedAt}");
                            Console.WriteLine($"Atualizado em: {tarefa.UpdatedAt}");
                            Console.WriteLine("----------------------");
                        }
                    }
                    while (statusFiltro == "todo")
                    {
                        var tarefasFiltradas = tarefas.Where(t => t.Status == "todo").ToList();
                        if (tarefasFiltradas.Count == 0)
                        {
                            Console.WriteLine("Nenhuma tarefa encontrada com status 'todo'.");
                            break;
                        }
                        Console.WriteLine("=== Tarefas com status 'todo' ===");
                        foreach (var tarefa in tarefasFiltradas)
                        {
                            Console.WriteLine($"ID: {tarefa.Id}");
                            Console.WriteLine($"Descrição: {tarefa.Description}");
                            Console.WriteLine($"Status: {tarefa.Status}");
                            Console.WriteLine($"Criado em: {tarefa.CreatedAt}");
                            Console.WriteLine($"Atualizado em: {tarefa.UpdatedAt}");
                            Console.WriteLine("----------------------");
                        }
                        break;
                    }
                    while (statusFiltro == "in-progress")
                    {
                        var tarefasFiltradas = tarefas.Where(t => t.Status == "in-progress").ToList();
                        if (tarefasFiltradas.Count == 0)
                        {
                            Console.WriteLine("Nenhuma tarefa encontrada com status 'in-progress'.");
                            break;
                        }
                        Console.WriteLine("=== Tarefas com status 'in-progress' ===");
                        foreach (var tarefa in tarefasFiltradas)
                        {
                            Console.WriteLine($"ID: {tarefa.Id}");
                            Console.WriteLine($"Descrição: {tarefa.Description}");
                            Console.WriteLine($"Status: {tarefa.Status}");
                            Console.WriteLine($"Criado em: {tarefa.CreatedAt}");
                            Console.WriteLine($"Atualizado em: {tarefa.UpdatedAt}");
                            Console.WriteLine("----------------------");
                        }
                        break;
                    }
                    while (statusFiltro == "done")
                    {
                        var tarefasFiltradas = tarefas.Where(t => t.Status == "done").ToList();
                        if (tarefasFiltradas.Count == 0)
                        {
                            Console.WriteLine("Nenhuma tarefa encontrada com status 'done'.");
                            break;
                        }
                        Console.WriteLine("=== Tarefas com status 'done' ===");
                        foreach (var tarefa in tarefasFiltradas)
                        {
                            Console.WriteLine($"ID: {tarefa.Id}");
                            Console.WriteLine($"Descrição: {tarefa.Description}");
                            Console.WriteLine($"Status: {tarefa.Status}");
                            Console.WriteLine($"Criado em: {tarefa.CreatedAt}");
                            Console.WriteLine($"Atualizado em: {tarefa.UpdatedAt}");
                            Console.WriteLine("----------------------");
                        }
                        break;
                    }

                    break;
                case "4":
                    Console.WriteLine("Excluir tarefa selecionada.");
                    if (tarefas == null || tarefas.Count == 0)
                    {
                        Console.WriteLine("Nenhuma tarefa encontrada para excluir.");
                        return;
                    }
                    Console.WriteLine("Digite o ID da tarefa que deseja excluir:");
                    string? idExcluirInput = Console.ReadLine();
                    if (!int.TryParse(idExcluirInput, out int idExcluir))
                    {
                        Console.WriteLine("ID inválido. Por favor, tente novamente.");
                        return;
                    }
                    var tarefaParaExcluir = tarefas.FirstOrDefault(t => t.Id == idExcluir);
                    if (tarefaParaExcluir == null)
                    {
                        Console.WriteLine("Tarefa não encontrada. Por favor, tente novamente.");
                        return;
                    }
                    tarefas.Remove(tarefaParaExcluir);
                    File.WriteAllText("Db.json", JsonSerializer.Serialize(tarefas));
                    break;
                case "5":

                    Console.WriteLine("Informe o ID da tarefa que deseja marcar:");

                    string? idMarcar = Console.ReadLine();

                    if (!int.TryParse(idMarcar, out int idMarcarInt))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    var tarefaParaMarcar =
                        tarefas.FirstOrDefault(t => t.Id == idMarcarInt);

                    if (tarefaParaMarcar == null)
                    {
                        Console.WriteLine("Tarefa não encontrada.");
                        break;
                    }

                    Console.WriteLine("Marcar tarefa como:");
                    Console.WriteLine("(todo, in-progress, done)");
                    Console.WriteLine("Digite 'menu' para voltar");

                    string? novoStatus =
                        Console.ReadLine()?.ToLower();

                    while (
                        novoStatus != "todo" &&
                        novoStatus != "in-progress" &&
                        novoStatus != "done")
                    {
                        if (novoStatus == "menu")
                        {
                            break;
                        }

                        Console.WriteLine("Status inválido.");
                        Console.WriteLine("Digite:");
                        Console.WriteLine("'todo', 'in-progress', 'done' ou 'menu'");

                        novoStatus =
                            Console.ReadLine()?.ToLower();
                    }

                    // volta ao menu principal
                    if (novoStatus == "menu")
                    {
                        break;
                    }

                    tarefaParaMarcar.Status = novoStatus;

                    tarefaParaMarcar.UpdatedAt =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    File.WriteAllText(
                        "Db.json",
                        JsonSerializer.Serialize(tarefas));

                    Console.WriteLine("Status atualizado com sucesso!");

                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                    break;
            }
        }
    }
}

class Tarefa
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public string? CreatedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    public string? UpdatedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
}