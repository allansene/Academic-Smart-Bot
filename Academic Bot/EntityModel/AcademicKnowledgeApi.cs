using Academic_Bot.EntityModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Academic_Bot
{
    public static class AcademicKnowledgeApi
    {
        private const string SECRET = "a2dc4773d89541dcb1b8cdccbf16a6ee";
    
        public static async Task<AcademicResult> Interpret(string query)
        {

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SECRET);

            // Request parameters
            queryString["query"] = query;
            queryString["model"] = "latest";
            queryString["count"] = "10";
            queryString["complete"] = "1";
            var uri = "https://api.projectoxford.ai/academic/v1.0/interpret?" + queryString;

            var response = await client.GetAsync(uri);
            string resp = await response.Content.ReadAsStringAsync();
            AcademicResult result = JsonConvert.DeserializeObject<AcademicResult>(resp);
            return result;
        }

        public static async Task<EvaluateResult> Evaluate(string query)
        {

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SECRET);

            // Request parameters
            queryString["expr"] = query;
            queryString["model"] = "latest";
            queryString["count"] = "10";
            queryString["attributes"] = "Id,E";
            var uri = "https://api.projectoxford.ai/academic/v1.0/evaluate?" + queryString;

            var response = await client.GetAsync(uri);
            string resp = await response.Content.ReadAsStringAsync();
            EvaluateResult result = JsonConvert.DeserializeObject<EvaluateResult>(resp);
            return result;
        }

    }

}