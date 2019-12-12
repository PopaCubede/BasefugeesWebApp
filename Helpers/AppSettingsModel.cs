using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasefugeesWebApp.Helpers
{
    public class AppSettingsModel
    {
        public string ApiUrl { get; set; }
        public string AlgoliaAppID { get; set; }
        public string AlgoliaAPIKey { get; set; }
        public string LocalStoragePassword { get; set; }
        public string LocalStorageSalt { get; set; }
    }
}
