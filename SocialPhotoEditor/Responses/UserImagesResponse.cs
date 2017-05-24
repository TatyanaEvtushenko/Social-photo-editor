using Newtonsoft.Json;

namespace SocialPhotoEditor.Responses
{
    public class UserImagesResponse
    {
        [JsonProperty("page")]
        public int PageNumber { get; set; }

        [JsonProperty("user")]
        public string UserName { get; set; }
    }
}