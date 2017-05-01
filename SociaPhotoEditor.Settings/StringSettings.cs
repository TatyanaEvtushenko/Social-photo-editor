using System.Configuration;

namespace SociaPhotoEditor.Settings
{
    public static class StringSettings
    {
        public static string DefaultAvatar => ConfigurationManager.AppSettings["DefaultAvatarFileName"];
    }
}
