using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Project5.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Project5.Services
{
    public class QuestionService : IQuestionService
    {
        HttpClient client;
        string url;
        HttpResponseMessage response;
        public QuestionService()
        {
            client = new HttpClient();
            url = "https://localhost:7228/api/Question";
            client.BaseAddress = new Uri(url);
        }
        public async Task<List<Question>> getAllQuestions()
        {

            response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var question = new List<Question>();
                question = JsonConvert.DeserializeObject<List<Question>>(content);
                return await Task.FromResult(question);
            }
            return null;
        }
        public async Task<int> AddQuestion(Question q)
        {
            var values = new Dictionary<string, string>();
            values.Add("id", "1");
            values.Add("question", q.question);
            values.Add("option1", q.option1);
            values.Add("option2", q.option2);
            values.Add("option3", q.option3);
            values.Add("answer", q.answer);
            
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            var stringContent = new StringContent(json);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync("https://localhost:7228/api/Question", stringContent);
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(@"\Question successfully saved.");
            }
            return 0;
        }

            
        
    }
}
