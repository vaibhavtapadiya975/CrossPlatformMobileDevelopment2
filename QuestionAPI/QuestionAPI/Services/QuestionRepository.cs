using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionAPI.Interfaces;
using QuestionAPI.Model;
namespace QuestionAPI.Services
{
    public class QuestionRepository : IQuestionRepository
    {
        private List<Question> _questionList;

        public QuestionRepository()
        {
            InitializeData();
        }

        public IEnumerable<Question> All
        {

            get { return _questionList; }
        }

        public bool DoesItemExist(string id)
        {
            return _questionList.Any(item => item.ID == id);
        }

        public Question Find(string id)
        {
            return _questionList.FirstOrDefault(item => item.ID == id);
        }

        public void Insert(Question item)
        {
            _questionList.Add(item);
        }

        public void Update(Question item)
        {
            var todoItem = this.Find(item.ID);
            var index = _questionList.IndexOf(todoItem);
            _questionList.RemoveAt(index);
            _questionList.Insert(index, item);
        }

        public void Delete(string id)
        {
            _questionList.Remove(this.Find(id));
        }
        private void InitializeData()
        {
            _questionList = new List<Question>();

            var q1 = new Question
            {
                ID = "1",
                question = "5*8",
                option1 = 36,
                option2 = 40,
                option3 = 13.5,
                answer = 40
            };

            var q2 = new Question
            {
                ID = "2",
                question = "9*4+3-25/1",
                option1 = 37,
                option2 = 14,
                option3 = 28,
                answer = 14
            };

            var q3 = new Question
            {
                ID = "3",
                question = "10*5-1",
                option1 = 40,
                option2 = 55,
                option3 = 49,
                answer = 49
            };

            var q4 = new Question
            {
                ID = "4",
                question = "100+(20*5)",
                option1=20,
                option2=100,
                option3=200,
                answer=100
            };
            var q5 = new Question
            {
                ID = "5",
                question = "(49/7)+(8*13)",
                option1 = 111,
                option2 = 100,
                option3 = 122,
                answer = 111
            };
            var q6 = new Question
            {
                ID = "6",
                question = "10+20-59",
                option1 = -20,
                option2 = -39,
                option3 = -29,
                answer = -29
            };
            var q7 = new Question
            {
                ID = "7",
                question = "9*8-(21/3)",
                option1 = 45,
                option2 = 65,
                option3 = 56,
                answer = 65
            };
            var q8 = new Question
            {
                ID = "8",
                question = "45+90+33",
                option1 = 33,
                option2 = 168,
                option3 = 120,
                answer = 168
            };
            var q9 = new Question
            {
                ID = "9",
                question = "78*5",
                option1 = 395,
                option2 = 390,
                option3 = 380,
                answer = 390
            };
            var q10 = new Question
            {
                ID = "10",
                question = "(56+12)*2",
                option1 = 130,
                option2 = 136,
                option3 = 0,
                answer = 136
            };
            _questionList.Add(q1);
            _questionList.Add(q2);
            _questionList.Add(q3);
            _questionList.Add(q4);
            _questionList.Add(q5);
            _questionList.Add(q6);
            _questionList.Add(q7);
            _questionList.Add(q8);
            _questionList.Add(q9);
            _questionList.Add(q10);
        }
    }
}
