using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BasefugeesWebApp.Helpers;
using BasefugeesWebApp.Models;

namespace BasefugeesWebApp.DAL.ApiClients
{
    internal static class ApiClientFactory
    {
        private static readonly Uri _apiUri;

        private static readonly Lazy<ApiClient> _restClient = new Lazy<ApiClient>(
            () => new ApiClient(_apiUri),
            LazyThreadSafetyMode.ExecutionAndPublication);

        static ApiClientFactory()
        {
            _apiUri = new Uri(Constants.ApiUrl);
        }

        public static ApiClient Instance => _restClient.Value;
    }
}
