// api/ChatGptService.cs

using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenSound.API;

public class ChatGptService
{
    private readonly OpenAIService _client;

    public ChatGptService(string apiKey)
    {
        _client = new OpenAIService(new OpenAI.OpenAiOptions()
        {
            ApiKey = apiKey
        });
    }

    public async Task<string> GerarResumoDaBandaAsync(string nomeDaBanda)
    {
        try
        {
            var chatResult = await _client.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
                {
                    ChatMessage.FromUser($"Resuma a banda {nomeDaBanda} em 1 parágrafo. Adote um estilo informal.")
                },
                Model = Models.Gpt_3_5_Turbo,
                MaxTokens = 256
            });

            if (chatResult.Successful)
            {
                return chatResult.Choices.First().Message.Content;
            }
            else
            {
                if (chatResult.Error == null)
                {
                    return "Ocorreu um erro desconhecido na API.";
                }
                return $"Não foi possível gerar o resumo. Erro: {chatResult.Error.Message}";
            }
        }
        catch (Exception ex)
        {
            return $"Ocorreu um erro inesperado na aplicação: {ex.Message}";
        }
    }
}