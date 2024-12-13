using career_service.Src.Services.Interface;

namespace career_service.Src.Services
{
    public class BlackListService : IBlackListService
    {
        private readonly HashSet<string> _blacklist = [];
        public void AddToBlacklist(string token)
        {
            _blacklist.Add(token);
        }

        public bool IsBlacklisted(string token)
        {
            return _blacklist.Contains(token);
        }
    }
}