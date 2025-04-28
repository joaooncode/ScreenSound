string msg = " ScreenSound v1.0.0\n\n" +
            "A simple program to play sound on screen events.\n" +
            "Press 'q' to quit.\n";

//List<string> bandas = new List<string> { "AC/DC", "Iron Maiden", "Guns N' Roses" };

Dictionary<string, List<int>> bandas = new Dictionary<string, List<int>>();

// Adicionando bandas e suas avaliações
bandas.Add("AC/DC", new List<int> { 10, 9, 8, 6});
bandas.Add("Iron Maiden", new List<int>());

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
                    AvaliarBanda();
                    break;
                case 4:
                    ExibirMediaBanda();
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
        bandas.Add(nomeBanda, new List<int>());
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
        foreach (var banda in bandas.Keys)
        {
            Console.WriteLine($" - {banda}");
        }
        
        Console.WriteLine($"\nTotal de bandas registradas: {bandas.Count}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();
}

void AvaliarBanda()
{
    Console.Clear();
    Console.WriteLine("Avaliar uma banda");

    // Exibe as bandas registradas com índices
    if (bandas.Count == 0)
    {
        Console.WriteLine("Nenhuma banda registrada para avaliar.");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("\nBandas registradas:");
    var listaBandas = bandas.Keys.ToList(); // Converte as chaves do dicionário para uma lista
    for (int i = 0; i < listaBandas.Count; i++)
    {
        Console.WriteLine($"[{i}] {listaBandas[i]}");
    }

    Console.Write("\nDigite o número da banda que deseja avaliar: ");
    try
    {
        int indice = int.Parse(Console.ReadLine()!);

        // Verifica se o índice é válido
        if (indice < 0 || indice >= listaBandas.Count)
        {
            Console.WriteLine("Índice inválido. Tente novamente.");
        }
        else
        {
            string nomeBanda = listaBandas[indice];
            Console.Write($"Avaliação para {nomeBanda} (0-10): ");
            int avaliacao = int.Parse(Console.ReadLine()!);

            if (avaliacao < 0 || avaliacao > 10)
                throw new Exception("Avaliação deve ser entre 0 e 10.");

            bandas[nomeBanda].Add(avaliacao);
            Console.WriteLine($"Avaliação {avaliacao} registrada para {nomeBanda}.\n");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Formato inválido. Por favor informe apenas números.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }

    Thread.Sleep(3000);
}

void ExibirMediaBanda()
{
    Console.Clear();
    Console.WriteLine("Exibir média de avaliação da banda");
    // Exibe as bandas registradas com índices
    if (bandas.Count == 0)
    {
        Console.WriteLine("Nenhuma banda registrada para avaliar.");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        return;
    }
    Console.WriteLine("\nBandas registradas:");
    var listaBandas = bandas.Keys.ToList(); // Converte as chaves do dicionário para uma lista
    for (int i = 0; i < listaBandas.Count; i++)
    {
        Console.WriteLine($"[{i}] {listaBandas[i]}");
    }
    Console.Write("\nDigite o número da banda que deseja ver a média: ");
    try
    {
        int indice = int.Parse(Console.ReadLine()!);
        // Verifica se o índice é válido
        if (indice < 0 || indice >= listaBandas.Count)
        {
            Console.WriteLine("Índice inválido. Tente novamente.");
        }
        else
        {
            string nomeBanda = listaBandas[indice];
            List<int> avaliacoes = bandas[nomeBanda];
            if (avaliacoes.Count == 0)
            {
                Console.WriteLine($"Nenhuma avaliação registrada para {nomeBanda}.");
            }
            else
            {
                double media = avaliacoes.Average();
                Console.WriteLine($"Média de avaliações para {nomeBanda}: {media:F2}");
            }
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Formato inválido. Por favor informe apenas números.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Thread.Sleep(5000);
}


ExibeMenuOpcoes();
