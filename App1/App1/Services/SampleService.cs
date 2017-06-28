using App1.Interface;
using App1.Models;
using App1.Services;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(SampleService))]
namespace App1.Services
{
    public class SampleService : ISampleService
    {
        HttpClient httpClient;
        private const string ApiBaseAddress = "somebaseaddress";
        private const string ApiSomePostAddress = "somepostaddress";

        private HttpClient CreateHttpClient()
        {
            httpClient = new HttpClient(new NativeMessageHandler() { UseCookies = false, AllowAutoRedirect = false });
            httpClient.BaseAddress = new Uri(ApiBaseAddress);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public async Task<SampleModel> GetSomeDummyData(Dictionary<string, string> parameters)
        {
            SampleModel sample = new SampleModel { };
            using (var httpClient = CreateHttpClient())
            {
                FormUrlEncodedContent sampleContent = new FormUrlEncodedContent(parameters);
                var response = await httpClient.PostAsync(ApiSomePostAddress, sampleContent).ConfigureAwait(false);

                if(response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(json))
                        sample = await Task.Run(() => JsonConvert.DeserializeObject<SampleModel>(json));
                }

                return sample;
            }
        }

        public string SomeDummyString(string btnText)
        {
            int caseSwitch = int.Parse(btnText);
            string sampleString = string.Empty;
            switch (caseSwitch)
            {
                case 1:
                    sampleString = "sample string 1";
                    break;

                case 2:
                    sampleString = "sample string 2";
                    break;

                case 3:
                    sampleString = "sample string 3";
                    break;

                case 4:
                    sampleString = "sample string 4";
                    break;
            }

            return sampleString;
        }
    }
}
