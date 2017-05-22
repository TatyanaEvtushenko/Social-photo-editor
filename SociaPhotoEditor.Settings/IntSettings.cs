using System;
using System.Configuration;

namespace SociaPhotoEditor.Settings
{
    public static class IntSettings
    {
        public static int CountPopularImages => Convert.ToInt32(ConfigurationManager.AppSettings["CountPopularImages"]);

        public static int CountUserLists => Convert.ToInt32(ConfigurationManager.AppSettings["CountUserLists"]);

        public static int CountImageLists => Convert.ToInt32(ConfigurationManager.AppSettings["CountImageLists"]);

        public static int CountNews => Convert.ToInt32(ConfigurationManager.AppSettings["CountNews"]);

        public static int CountEvents => Convert.ToInt32(ConfigurationManager.AppSettings["CountEvents"]);
    }
}
