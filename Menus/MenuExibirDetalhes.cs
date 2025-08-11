using ScreenSound.API;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhes : Menu
{
    public override async Task Executar(Dictionary<string, Banda> bandasRegistradas, ChatGptService chatGptService)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Exibir detalhes da banda");
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];

           
            if (string.IsNullOrEmpty(banda.Resumo))
            {
                Console.WriteLine("\nGerando resumo da banda no ChatGPT. Aguarde...");
                
                banda.Resumo = await chatGptService.GerarResumoDaBandaAsync(nomeDaBanda);
            }
            
            Console.WriteLine($"\n{banda.Resumo}"); 

            Console.WriteLine($"\nA média da banda {nomeDaBanda} é {banda.Media:F1}.");
            Console.WriteLine("\nDiscografia:");
            foreach (Album album in banda.Albuns)
            {
                Console.WriteLine($"{album.Nome} -> {album.Media:F1}");
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}