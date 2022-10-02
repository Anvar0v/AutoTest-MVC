using Microsoft.AspNetCore.Mvc;
using StaticFiles.MVC.Models;
using StaticFiles.MVC.Services;

namespace StaticFiles.MVC.Controllers
{
    public class QuestionsController : Controller
    {
        public IActionResult Index(int? index,int? choiceIndex = null)
        {
            var questionsData = new QuestionRepository();
            var question = questionsData.Questions.Find(q => q.Id == index);

            if(index == null)
            {

            }
            ViewBag.QuestionIndex = index;


            if (choiceIndex != null) //input 
            {
                ViewBag.ChoiceIndex = choiceIndex.Value;
                ViewBag.ChoiceResult = isAnswer(question,choiceIndex.Value);
            }

            if (question == null)
            {
                return View();
            }

            return View(question);
        }

        public string Answer(int questionIndex, int choiceIndex)
        {
            var questionsData = new QuestionRepository();
            var question = questionsData.Questions.Find(q => q.Id == questionIndex);
            if (question == null)
            {
                return "Not found";
            }

            var choice = question.Choices[choiceIndex];

            return choice.Answer.ToString();
        }

        public IActionResult Tickets(int? index)
        {
            var questionsData = new QuestionRepository();
            var question = questionsData.Questions.Find(q => q.Id == index);
            if(question == null)
            {
                return View();
            }
            return View(question);
        }

        public bool isAnswer(QuestionEntity question, int choiceIndex)
        {
            var choice = question.Choices[choiceIndex];
            return choice.Answer;
        }

        
    }
}
