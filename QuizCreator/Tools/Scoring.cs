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
                    if (quizVM.UserA[i] == quizVM.Quiz.Questions[i].A[j].AId)
                    {
                        aKey.Add((bool)quizVM.Quiz.Questions[i].AKey[j].AKeyBool);
                    }
                }
            }
            decimal TempScore = 100.00m;
            quizVM.Score = 100;
            for (var i = 0; i < aKey.Count; i++)
            {
                if (aKey[i] != true)
                {
                    TempScore = TempScore - (100.00m / aKey.Count);
                }
            }
            quizVM.Score = (int)Math.Round(TempScore);
            decimal n = quizVM.Quiz.EndResult.EndTitles.Count;
            decimal s = TempScore;
            quizVM.EndTitle = quizVM.Quiz.EndResult.EndTitles[(int)Math.Round((n - 1.00m) - ((s * (n - 1)) / 100.00m))].EndResultString;  //Thank you for the math, Logan.
            quizVM.EndMessage = quizVM.Quiz.EndResult.EndMessages[(int)Math.Round((n - 1.00m) - ((s * (n - 1)) / 100.00m))].EndResultString;
            return quizVM;
        }
    }
}
