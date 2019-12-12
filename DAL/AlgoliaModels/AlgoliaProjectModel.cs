using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BasefugeesWebApp.DAL.AlgoliaModels
{
    public class AlgoliaProjectModel
    {
        [JsonProperty(PropertyName = "objectID")]
        public string ObjectID { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty(PropertyName = "privacy")]
        public bool Privacy { get; set; }

        [JsonProperty(PropertyName = "supportNeeded")]
        public string SupportNeeded { get; set; }

        [JsonProperty(PropertyName = "teamMembers")]
        public string[] TeamMembers { get; set; }

        [JsonProperty(PropertyName = "url")] public string Url { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "type")] public string Type { get; set; }
    }
}
