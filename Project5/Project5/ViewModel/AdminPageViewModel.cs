using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Project5.Models;
using Project5.Services;




namespace Project5.ViewModel
{
    [QueryProperty(nameof(Question), "Question")]
    public partial class AdminPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Question _question = new Question();

        private readonly IQuestionService _questionService;
        public AdminPageViewModel(IQuestionService questionService)
        {
            this._questionService = questionService;
        }

        [ICommand]
        public async void AddQuestion()
        {
            int response = -1;
            response = await _questionService.AddQuestion(new Models.Question
            {
                question = Question.question,
                option1 = Question.option1,
                option2 = Question.option2,
                option3 = Question.option3,
                answer = Question.answer
            });
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Question", "Question Inserted Successfully", "OK");
            }
        }
    }
}
