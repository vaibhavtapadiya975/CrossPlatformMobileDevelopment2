using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Calculator.Models;
using Newtonsoft.Json;

namespace Calculator.Services
{
    public class QuestionService: IQuestionRepository
    {
        public QuestionService()
        {

        }
        public async Task<List<Question>> getAllQuestions()
        {
            var client = new HttpClient();
            string url = "https://localhost:7228/api/Question";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var question = new List<Question>();
                question = JsonConvert.DeserializeObject<List<Question>>(content);
                return await Task.FromResult(question);
            }
            return null;
        }

        
    }
}
