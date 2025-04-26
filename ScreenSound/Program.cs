
string msg = " ScreenSound v1.0.0\n\n" +
            "A simple program to play sound on screen events.\n" +
            "Press 'q' to quit.\n";


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
    Console.WriteLine("[1] Registrar uma banda.");
    Console.WriteLine("[2] Mostrar todas as bandas.");
    Console.WriteLine("[3] Avaliar uma banda");
    Console.WriteLine("[4] Exibir média de avalição da banda");
    Console.WriteLine("[5] Para sair");

    Console.Write("\nEscolha uma opção: ");
    int opcao = int.Parse(Console.ReadLine()!);
    
    switch(opcao)
    {
        case 1:
            Console.WriteLine("Registrar uma banda");
            break;
        case 2:
            Console.WriteLine("Mostrar todas as bandas");
            break;
        case 3:
            Console.WriteLine("Avaliar uma banda");
            break;
        case 4:
            Console.WriteLine("Exibir média de avaliação da banda");
            break;
        case 5:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}

ExibeScreenSound();
ExibeMenuOpcoes();