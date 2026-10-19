var manager = new TaskManager();
bool running = true;

while (running)
{
    Console.WriteLine("\n=== TaskFlow ===");
    Console.WriteLine("1 - Adicionar tarefa");
    Console.WriteLine("2 - Listar tarefas");
    Console.WriteLine("3 - Concluir tarefa");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("Título: ");
            try
            {
                var task = manager.AddTask(Console.ReadLine() ?? "");
                Console.WriteLine($"Tarefa criada: {task.Id}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            break;

        case "2":
            if (manager.Tasks.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa cadastrada.");
                break;
            }
            foreach (var t in manager.Tasks)
            {
                Console.WriteLine($"[{(t.IsCompleted ? "x" : " ")}] {t.Title} ({t.Id})");
            }
            break;

        case "3":
            Console.Write("ID da tarefa: ");
            if (Guid.TryParse(Console.ReadLine(), out var id) && manager.CompleteTask(id))
            {
                Console.WriteLine("Tarefa concluída!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
            break;

        case "0":
            running = false;
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}