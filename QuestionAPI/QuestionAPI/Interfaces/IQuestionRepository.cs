using QuestionAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAPI.Interfaces
{
    public interface IQuestionRepository
    {
        bool DoesItemExist(string id);
        IEnumerable<Question> All { get; }
        Question Find(string id);
        void Insert(Question q);
        void Update(Question q);
        void Delete(string id);
        
    }
}
