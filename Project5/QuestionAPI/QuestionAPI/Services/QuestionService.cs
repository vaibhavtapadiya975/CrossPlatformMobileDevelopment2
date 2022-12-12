using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using QuestionAPI.Model;

namespace QuestionAPI.Services
{
    public class QuestionService : IQuestionService
    {
        private SQLiteAsyncConnection _dbConnection;

        public QuestionService()
        {
            SetUpDb();
        }
       
        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Question.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Question>();
            }
        }
        
        public async Task<int> AddQuestion(Question questionModel)
        {
            //await SetUpDb();
            return await _dbConnection.InsertAsync(questionModel);
        }

        public async Task<int> UpdateQuestion(Question questionModel)
        {
            //await SetUpDb();
            return await _dbConnection.UpdateAsync(questionModel);
        }
        public async Task<int> DeleteQuestion(Question questionModel)
        {
            //await SetUpDb();
            return await _dbConnection.DeleteAsync(questionModel);
        }

        public async Task<Question> GetQuestionAsync(string id)
        {
            return await _dbConnection.Table<Question>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public async Task<List<Question>> GetAllQuestions()
        {
            SetUpDb();
            List<Question> result = new List<Question>();
            result = await _dbConnection.Table<Question>().ToListAsync();
            var temp = result;
            Console.WriteLine(temp);
            return result;
        }
    }
}
