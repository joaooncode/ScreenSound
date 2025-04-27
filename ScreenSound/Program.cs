string msg = " ScreenSound v1.0.0\n\n" +
            "A simple program to play sound on screen events.\n" +
            "Press 'q' to quit.\n";

List<string> bandas = new List<string> { "AC/DC", "Iron Maiden", "Guns N' Roses" };

void ExibeScreenSound()
{
    Console.Clear();
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(msg);
}

void ExibeMenuOpcoes()
{
    bool continuar = true;

    while (continuar)
    {
        ExibeScreenSound();

        // Novo layout do menu
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╭────────────────────────────────────────╮");
        Console.WriteLine("│              MENU DE OPÇÕES           │");
        Console.WriteLine("├────────────────────────────────────────┤");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("│ [1] Registrar uma banda               │");
        Console.WriteLine("│ [2] Mostrar todas as bandas           │");
        Console.WriteLine("│ [3] Avaliar uma banda                 │");
        Console.WriteLine("│ [4] Exibir média de avaliação         │");
        Console.WriteLine("│ [5] Para sair                         │");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╰────────────────────────────────────────╯");
        Console.ResetColor();

        Console.Write("\nEscolha uma opção: ");

        try
        {
            int opcao = int.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 1:
                    RegistrarBandas();
                    break;
                case 2:
                    ExibirBandas();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Avaliar uma banda");
                    Console.ResetColor();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Exibir média de avaliação da banda");
                    Console.ResetColor();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Saindo...");
                    Console.ResetColor();
                    continuar = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida.");
                    Console.ResetColor();
                    break;
            }
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Formato inválido. Por favor informe apenas números (1-5). Tente novamente.");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro: {ex.Message}");
            Console.ResetColor();
        }
    }
}


void RegistrarBandas()
{
    Console.Clear();
    Console.WriteLine("Registrar uma banda");
    Console.Write("Nome da banda: ");
    try
    {
        string nomeBanda = Console.ReadLine()!;
        if (string.IsNullOrEmpty(nomeBanda))
            throw new Exception("Nome da banda não pode ser vazio.");
        bandas.Add(nomeBanda);
        Console.WriteLine($"{nomeBanda} registrada com sucesso!\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    finally
    {
        Thread.Sleep(3000);
    }
}

void ExibirBandas()
{
    Console.Clear();
    Console.WriteLine("Bandas registradas:");
    if (bandas.Count == 0)
    {
        Console.WriteLine("Nenhuma banda registrada.");
    }
    else
    {
        foreach (var banda in bandas)
        {
            Console.WriteLine($" - {banda}");
        }
        
        Console.WriteLine($"\nTotal de bandas registradas: {bandas.Count}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();
}

ExibeMenuOpcoes();
