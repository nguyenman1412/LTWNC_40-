using SocialMedia.ViewModels;

namespace SocialMedia
{
    public interface ISecurityService
    {
        void SaveUserToDB(RegisterViewModel model);
        bool IsValidUser(LogonViewModel model);
    }
}