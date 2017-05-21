using SocialPhotoEditor.BuisnessLayer.Enums;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.Responses
{
    public class SearchResponse
    {
        public int PageNumber { get; set; }

        public string SearchString { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public SexEnum Sex { get; set; }

        public SortEnum SortType { get; set; }
    }
}