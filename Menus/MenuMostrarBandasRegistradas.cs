using ScreenSound.API;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarBandasRegistradas : Menu
{
    public override async Task Executar(Dictionary<string, Banda> bandasRegistradas, ChatGptService chatGptService)
    {
        await base.Executar(bandasRegistradas, chatGptService);
        ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");

        foreach (string banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}