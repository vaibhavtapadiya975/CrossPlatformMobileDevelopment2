using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionAPI.Model;

namespace QuestionAPI.Services
{
    public interface IQuestionService
    {
        Task<int> AddQuestion(Question questionModel);
        Task<int> DeleteQuestion(Question questionModel);
        Task<int> UpdateQuestion(Question questionModel);
        Task<Question> GetQuestionAsync(string id);
        Task<List<Question>> GetAllQuestions();
    }
}
