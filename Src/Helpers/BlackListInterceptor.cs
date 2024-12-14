using Grpc.Core;
using Grpc.Core.Interceptors;
using careers_service.Src.Services.Interfaces;

namespace careers_service.Src.Helpers
{
    public class BlacklistInterceptor : Interceptor
    {
        private readonly IBlackListService _blacklistService;


        public BlacklistInterceptor(IBlackListService blacklistService)
        {
            _blacklistService = blacklistService;
        }


        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var authHeader = context.RequestHeaders.FirstOrDefault(h => h.Key == "authorization")?.Value;

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return await continuation(request, context);
            }

            var token = authHeader.Replace("Bearer ", string.Empty);

            if (_blacklistService.IsBlacklisted(token))
            {
                throw new RpcException(new Status(StatusCode.PermissionDenied, "Token is blacklisted"));
            }

            return await continuation(request, context);
        }
    }

}