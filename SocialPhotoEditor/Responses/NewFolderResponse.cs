using Newtonsoft.Json;

namespace SocialPhotoEditor.Responses
{
    public class NewFolderResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subscribe")]
        public string Subscribe { get; set; }

        [JsonProperty("owner")]
        public string OwnerUserName { get; set; }
    }
}