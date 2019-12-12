using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasefugeesWebApp.Models
{
    public class WebConfig
    {
        public static string ApiUrl { get; set; }
        public static string AlgoliaAppID { get; set; }
        public static string AlgoliaAPIKey { get; set; }
        public static string LocalStoragePassword { get; set; }
        public static string LocalStorageSalt { get; set; }
    }
}
