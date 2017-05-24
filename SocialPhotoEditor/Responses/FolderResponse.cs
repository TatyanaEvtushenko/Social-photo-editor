using Newtonsoft.Json;

namespace SocialPhotoEditor.Responses
{
    public class FolderResponse
    {
        [JsonProperty("page")]
        public int PageNumber { get; set; }

        [JsonProperty("folderId")]
        public string FolderId { get; set; }
    }
}