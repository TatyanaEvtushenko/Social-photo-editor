using Newtonsoft.Json;

namespace SocialPhotoEditor.Responses
{
    public class NewImageResponse
    {
        [JsonProperty("image")]
        public string ImagePath { get; set; }

        [JsonProperty("subscribe")]
        public string Subscribe { get; set; }

        [JsonProperty("folder")]
        public string FolderId { get; set; }
    }
}