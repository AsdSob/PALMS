using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALMS.ViewModels.Services
{
    public class ApiHelper : IApiHelper
    {
        private const string ServiceAddress = "http://localhost:11564/api";
        private readonly HttpClient _httpClient;

        public ApiHelper()
        {
            _httpClient = new HttpClient(new HttpClientHandler
            {
                CookieContainer = new CookieContainer(),
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            });

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            _httpClient.Timeout = TimeSpan.FromSeconds(300);
        }

        public UrlParameterAttribute GetUrlParameterAttribute(Type type)
        {
            var urlParameter = Attribute.GetCustomAttribute(type, typeof(UrlParameterAttribute)) as UrlParameterAttribute;
            if (urlParameter == null)
                throw new Exception("UrlParameterAttribute not set");
            return urlParameter;
        }

        public async Task<List<T>> GetItemsAsync<T>() where T : IEntity
        {
            return await GetAsync<List<T>>(GetUrl<T>()) ?? new List<T>();
        }

        public async Task<T> SaveAsync<T>(T entity) where T : IEntity
        {
            if (!entity.IsNew)
                return await UpdateAsync(entity);

            return await CreateAsync(entity);
        }

        public async Task<T> DeleteAsync<T>(int id) where T : IEntity
        {
            return await DeleteAsync<T>($"{GetUrl<T>()}/{id}");
        }

        private async Task<T> CreateAsync<T>(T entity)
        {
            return await PostAsync<T>(GetUrl<T>(), entity);
        }

        private async Task<T> UpdateAsync<T>(T entity)
        {
            return await PutAsync<T>(GetUrl<T>(), entity);
        }

        private async Task<T> GetAsync<T>(string url)
        {
            return await HttpMethodAsync<T>(HttpMethod.Get, url);
        }

        private async Task<T> PostAsync<T>(string url, object obj)
        {
            return await HttpMethodAsync<T>(HttpMethod.Post, url, obj);
        }

        private async Task<T> PutAsync<T>(string url, object obj)
        {
            return await HttpMethodAsync<T>(HttpMethod.Put, url, obj);
            //return await HttpMethodAsync<T>(new HttpMethod("PATCH"), url, obj);
        }

        private async Task<T> DeleteAsync<T>(string url, object obj = null)
        {
            return await HttpMethodAsync<T>(HttpMethod.Delete, url, obj);
        }

        private async Task<T> HttpMethodAsync<T>(HttpMethod httpMethod, string url, object obj = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                AddLog(new ApiException($"Problem with {httpMethod}. Url is null or empty"));
                return default(T);
            }

            try
            {
                using (var httpRequestMessage = new HttpRequestMessage(httpMethod, url))
                {
                    httpRequestMessage.Version = HttpVersion.Version10;
                    if ((obj != null) && (httpMethod != HttpMethod.Get) && (httpMethod != HttpMethod.Head))
                    {
                        var contentObj = obj.Serialize();
                        httpRequestMessage.Content = GetContent(contentObj);
                    }

                    using (var response = await _httpClient.SendAsync(httpRequestMessage))
                    {
                        if (response != null)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var json = await response.Content.ReadAsStringAsync();

                                return SerializationHelper.Deserialize<T>(json);
                            }

                            var responseContent = response.Content?.ReadAsStringAsync();
                            AddLog(responseContent != null
                                ? new ApiException($"Problem with {httpMethod}. Response content:\r\n{await responseContent}", url, obj)
                                : new ApiException($"Problem with {httpMethod}. Response content is null", url, obj));
                        }
                        else
                            AddLog(new ApiException($"Problem with {httpMethod}. Response is null", url, obj));
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog(new ApiException($"Problem with {httpMethod}", url, ex));
            }

            return default(T);
        }

        private string GetUrl<T>()
        {
            return $"{ServiceAddress}/{GetUrlParameterAttribute(typeof(T)).Parameter}";
        }

        private static StringContent GetContent(string json)
        {
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        #region Log

        private void AddLog(ApiException apiException)
        {
            //ApiExceptionLogAction?.BeginInvoke(apiException, null, null);
        }

        #endregion
    }

    public class ApiException
    {
        public Exception Exception { get; }
        public string Message { get; }
        public string Request { get; }
        public string Url { get; }
        public object Object { get; }

        public ApiException(string message, string url, Exception exception, string request = null)
        {
            Message = message;
            Url = url;
            Exception = exception;
            Request = request;
        }

        public ApiException(string message)
        {
            Message = message;
        }

        public ApiException(string message, string url, object obj)
        {
            Message = message;
            Url = url;
            Object = obj;
        }

        public override string ToString()
        {
            var result = string.Empty;
            if (!string.IsNullOrEmpty(Message))
                result += Message;

            if (!string.IsNullOrEmpty(Url))
                result += $"\r\nUrl: {Url}";

            if (Exception != null)
                result += $"\r\nException msg: {Exception.Message}" +
                          $"\r\nSource: {Exception.Source}" +
                          $"\r\nError stack: {Exception.StackTrace}";

            if (!string.IsNullOrEmpty(Request))
                result += $"\r\nRequest: {Request}";

            if (Object != null)
                result += $"\r\nObject: {Object.Serialize()}";

            return result;
        }
    }
}
