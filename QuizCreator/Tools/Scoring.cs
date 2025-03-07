using QuizCreator.Models.ViewModels;

namespace QuizCreator.Tools
{
    public class Scoring
    {
        public static QuizVM CheckAll(QuizVM quizVM)
        {
            List<bool> aKey = new List<bool>();
            for (int i = 0; i < quizVM.Quiz.Questions.Count; i++)
            {
                for (int j = 0; j < quizVM.Quiz.Questions[i].A.Count; j++)
                {
                    if (quizVM.UserA[i] == quizVM.Quiz.Questions[i].A[j].AString)
                    {
                        aKey.Add((bool)quizVM.Quiz.Questions[i].AKey[j].AKeyBool);
                    }
                }
            }
            quizVM.Score = 100;
            for (var i = 0; i < aKey.Count; i++)
            {
                if (aKey[i] != true)
                {
                    quizVM.Score = quizVM.Score - (100 / aKey.Count);
                }
            }
            int n = quizVM.Quiz.EndResult.EndTitles.Count;
            int s = quizVM.Score;
            quizVM.EndTitle = quizVM.Quiz.EndResult.EndTitles[(n - 1) - ((s * (n - 1)) / 100)].EndResultString;  //Thank you for the math, Logan.
            quizVM.EndMessage = quizVM.Quiz.EndResult.EndMessages[(n - 1) - ((s * (n - 1)) / 100)].EndResultString;
            return quizVM;
        }
    }
}
