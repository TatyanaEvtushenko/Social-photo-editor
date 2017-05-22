using Newtonsoft.Json;

namespace SocialPhotoEditor.Responses
{
    public class NewCommentResponse
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("image")]
        public string ImageId { get; set; }

        [JsonProperty("recipient")]
        public string RecipientUserName { get; set; }
    }
}