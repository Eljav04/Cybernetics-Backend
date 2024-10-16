using System;
namespace Lesson_50_HT.Model
{
	internal class Result
	{
		public DateTime Time { get; private set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentLogin { get; set; }

        public int RightAnswers  { get; set; }
        public int WrongAnswers { get; set; }
        public int QuestionCount { get; set; }
        public int SkippedQuestionCount { get; set; }
        public int OverallScore { get; set; }
        public string PassStatus { get; set; }

        public Result(
            string StudentName,
            string StudentSurname,
            string StudentLogin,

            int RightAnswers, 
            int WrongAnswers, 
            int QuestionCount, 
            int SkippedQuestionCount
			)
        {
            Time = DateTime.Now;

            this.StudentName = StudentName;
            this.StudentSurname = StudentSurname;
            this.StudentLogin = StudentLogin;

            this.RightAnswers = RightAnswers;
            this.WrongAnswers = WrongAnswers;
            this.QuestionCount = QuestionCount;
            this.SkippedQuestionCount = SkippedQuestionCount;
            OverallScore = CalculateOverallScore(RightAnswers, QuestionCount);
            PassStatus = (OverallScore >= 50) ? "Yes" : "No";
        }

        public void ShowInfo()
        {
            Console.WriteLine(
                "Student: " + StudentName + " " + StudentSurname + "\n" +
                $"Finished in {Time}\n" +
                $"Right answers: {RightAnswers}\n" +
                $"Wrong answers: {WrongAnswers}\n" +
                $"Skipped questions: {SkippedQuestionCount}\n" +
                $"------\n" +
                $"Overall score: {OverallScore} / 100\n" +
                $"Exam passed: {PassStatus}\n");
        }

        public static int CalculateOverallScore(
            int right_answers,
            int question_count
            )
        {
            decimal overall_score = Math.Round(
                Convert.ToDecimal(right_answers) * 100 /
                Convert.ToDecimal(question_count));

            return Convert.ToInt32(overall_score);
        }



	}
}

