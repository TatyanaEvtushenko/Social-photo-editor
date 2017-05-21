using Newtonsoft.Json;
using SocialPhotoEditor.BuisnessLayer.Enums;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.Responses
{
    public class SearchResponse
    {
        [JsonProperty("page")]
        public int PageNumber { get; set; }

        [JsonProperty("search")]
        public string SearchString { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("minAge")]
        public int MinAge { get; set; }

        [JsonProperty("maxAge")]
        public int MaxAge { get; set; }

        [JsonProperty("sex")]
        public SexEnum Sex { get; set; }

        [JsonProperty("sort")]
        public SortEnum SortType { get; set; }
    }
}