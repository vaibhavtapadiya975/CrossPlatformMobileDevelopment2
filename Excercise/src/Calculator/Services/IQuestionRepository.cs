using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public interface IQuestionRepository
    {
        Task<List<Question>> getAllQuestions();
    }
}
