using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClientBarometer.Contracts.Requests;
using ClientBarometer.Domain.Constants;
using ClientBarometer.Domain.Models;
using ClientBarometer.Domain.Repositories;
using Requests = ClientBarometer.Contracts.Requests;
using Responses = ClientBarometer.Contracts.Responses;

namespace ClientBarometer.Domain.Services
{
    public class SuggestionService : ISuggestionService
    {
        private readonly IMessageReadRepository _messageReadRepository;
        private readonly IObjectionHandlingReadRepository _objectionHandlingReadRepository;

        public SuggestionService(IMessageReadRepository messageReadRepository, IObjectionHandlingReadRepository objectionHandlingReadRepository)
        {
            _messageReadRepository = messageReadRepository;
            _objectionHandlingReadRepository = objectionHandlingReadRepository;
        }

        public static string[] Suggestions = new[]
        {
            "Давайте я вам помогу?",
            "Не хотите узнать о других предложениях?",
            "Предлагаю узнать о новых поступлениях",
            "Как я могу к вам обращаться?",
            "Есть ли какие-нибудь вопросы?",
        };
        
        public async Task<Responses.Suggestions> GetSuggestions(Guid chatId, CancellationToken cancellationToken)
        {
            var message = (await _messageReadRepository.GetLastMessages(chatId, 1, cancellationToken)).FirstOrDefault();
            var objections = await _objectionHandlingReadRepository.GetAllObjections(0, int.MaxValue, cancellationToken);

            var objectionClass = objections.Select((obj) => new KeyValuePair<string, int>(
                obj.ObjectionClass,
                obj.SplittedExample
                    .Sum((se) => message.SplittedText.Contains(se) ? 1 : 0)))
                    .Aggregate(new KeyValuePair<string, int>("Неопределено", -1), (curMax, tuple) => tuple.Value > curMax.Value ? tuple : curMax).Key;



            //var suggestions = Suggestions.Where((sg, i) => messages.Length % 2 == i % 2).ToArray();
            return new Responses.Suggestions
            {
                //Messages = suggestions
            };
        }
    }
}