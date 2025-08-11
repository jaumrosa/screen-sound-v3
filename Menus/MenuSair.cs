using ScreenSound.API;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override async Task Executar(Dictionary<string, Banda> bandasRegistradas, ChatGptService chatGptService)
    {
        Console.WriteLine("Tchau tchau :)");
        await Task.CompletedTask;
    }
}