using Newtonsoft.Json;
using StaticFiles.MVC.Models;

namespace StaticFiles.MVC.Services;
public class QuestionRepository
{
    public List<QuestionEntity> Questions { get; set; }
    public int TicketQuestionsCount = 10;

    public QuestionRepository()
    {
        LoadQuestionsFromJsonFile();
    }

    public void LoadQuestionsFromJsonFile()
    {
        string path = "JsonData/uzlotin.json";
        string jsonString = File.ReadAllText(path);
        Questions = JsonConvert.DeserializeObject<List<QuestionEntity>>(jsonString);
    }

    //we have to get the of the questions
    public int GetTicketsCount()
    {
        return Questions.Count / TicketQuestionsCount;
    }

    public List<QuestionEntity> GetQuestionsRange(int from)
    {
        var ticketFrom = from * 10;
        return Questions.Skip(from).Take(TicketQuestionsCount).ToList();
    }
}
