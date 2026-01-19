using System.Net.Http.Json;
using Oid85.Medicaments.Application.Interfaces.ApiClients;
using Oid85.Medicaments.Common.KnownConstants;
using Oid85.Medicaments.Core.Exceptions;

namespace Oid85.Medicaments.Infrastructure.ApiClients.Health
{
    /// <inheritdoc />
    public class HealthServiceApiClient(
        IHttpClientFactory httpClientFactory) 
        : IHealthServiceApiClient
    {
        /// <inheritdoc />
        public async Task<int> GetCountGlucoseAsync(DateOnly date)
        {
            var response = await GetResponseAsync<GetCountGlucoseRequest, GetCountGlucoseResponse>(
                "/api/glucose/count", new GetCountGlucoseRequest { Date = date });
            
            if (response is null)
                return 0;

            return response.Result.TotalCount;
        }

        public class GetCountGlucoseRequest
        {
            public DateOnly Date { get; set; }
        }

        public class GetCountGlucoseResponse
        {
            public GetCountGlucoseResultResponse Result { get; set; }
        }

        public class GetCountGlucoseResultResponse
        {
            public int TotalCount { get; set; }
        }

        private async Task<TResponse> GetResponseAsync<TRequest, TResponse>(string url, TRequest request) where TResponse : new()
        {
            try
            {
                var content = JsonContent.Create(request);
                using var httpResponse = await SendPostRequestAsync(url, content);
                var data = await httpResponse.Content.ReadFromJsonAsync<TResponse>();
                return data ?? new TResponse();
            }

            catch (Exception exception)
            {
                throw new CustomBusinessException("500", "Ошибка при выполнении запроса", exception);
            }
        }

        private async Task<HttpResponseMessage> SendPostRequestAsync(string url, HttpContent content)
        {
            using var httpClient = httpClientFactory.CreateClient(KnownHttpClients.HealthServiceApiClient);
            return await httpClient.PostAsync(url, content);
        }
    }
}
