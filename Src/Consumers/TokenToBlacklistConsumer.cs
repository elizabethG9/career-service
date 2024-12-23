using careers_service.Src.Services.Interfaces;
using MassTransit;
using Shared.Messages;


namespace careers_service.Src.Consumers
{
    public class TokenToBlacklistConsumer : IConsumer<TokenToBlacklistMessage>
    {
        private readonly IBlackListService _blacklistService;

        public TokenToBlacklistConsumer(IBlackListService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        public Task Consume(ConsumeContext<TokenToBlacklistMessage> context)
        {
            var Messages = context.Message;
            Console.WriteLine($"Adding token to blacklist: {Messages.Token}");
            _blacklistService.AddToBlacklist(Messages.Token);
            return Task.CompletedTask;
        }
    }
    
}