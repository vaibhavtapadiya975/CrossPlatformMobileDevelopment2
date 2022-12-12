using Project5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5.Services
{
    public interface IQuestionService
    {
        Task<List<Question>> getAllQuestions();
        Task<int> AddQuestion(Question questionModel);
    }
}
