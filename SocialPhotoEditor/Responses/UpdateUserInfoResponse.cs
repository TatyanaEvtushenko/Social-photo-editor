using System;
using Newtonsoft.Json;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.Responses
{
    public class UpdateUserInfoResponse
    {
        [JsonProperty("avatar")]
        public string AvatarFileName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("subscribe")]
        public string Subscribe { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sex")]
        public SexEnum Sex { get; set; }

        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }
    }
}