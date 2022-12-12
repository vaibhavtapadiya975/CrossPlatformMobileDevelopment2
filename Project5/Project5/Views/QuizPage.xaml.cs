using Project5.Models;
using Project5.Services;

namespace Project5.Views;

public partial class QuizPage : ContentPage
{
    String option = "11";
    IQuestionService _questionService;

    List<Question> questions = new List<Question>();
    int i = 0;
    public QuizPage(IQuestionService questionService)
    {
        InitializeComponent();
        _questionService = questionService;
        loadAllQuestions();

    }

    public QuizPage()
    {
        InitializeComponent();
        _questionService =new QuestionService();
        loadAllQuestions();
    }
    async void onSubmit(object sender, EventArgs e)
    {
        if (option == questions[i].answer)
        {
            await DisplayAlert("Correct", "you selected the Correct Option", "OK");
            onChangeQuestion(sender, e);
        }
        else
        {
            bool answer = await DisplayAlert("Wrong answer", "Would you like to try it again?", "Yes", "No");
            if (answer == false)
            {
                onChangeQuestion(sender, e);
            }
        }

    }
    void onCheckResult(object sender, EventArgs e)
    {
        RadioButton button = sender as RadioButton;
        option = button.Content.ToString();
    }
    void onChangeQuestion(object sender, EventArgs e)
    {
        i += 1;
        if (i == questions.Count)
        {
            i = 0;
        }
        q.Text = questions[i].question;
        option1.Content = questions[i].option1;
        option2.Content = questions[i].option2;
        option3.Content = questions[i].option3;
    }
    public async void loadAllQuestions()
    {
        questions = await _questionService.getAllQuestions();
    }
}