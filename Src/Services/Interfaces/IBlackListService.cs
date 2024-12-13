namespace career_service.Src.Services.Interface
{
    public interface IBlackListService
    {
        void AddToBlacklist(string token);
        bool IsBlacklisted(string token);
    }
}