using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_50_HT.Services.Messages
{
    public static class Message
    {
        public static void ShowMessage(string messageText)
        {
            Console.WriteLine(messageText);
        }
        // Message that inform user about ending of some action
        public static void EndOfProcess()
        {
            string messageText = "Push any key to continue...";
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void NewStudentAdded()
        {
            string messageText = $"New student added successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void NewCategoryAdded()
        {
            string messageText = $"New category added successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void NewQuestionAdded()
        {
            string messageText = $"New question added successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void StudentDeleted()
        {
            string messageText = $"Student deleted successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void CategoryDeleted()
        {
            string messageText = $"Category deleted successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void QuestiionDeleted()
        {
            string messageText = $"Question deleted successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void MistakeError()
        {
            string errorText = "You have a mistake! Please try again";
            ShowMessage(errorText);
        }

        public static void ExamStarted()
        {
            string errorText = "Before beginning the exam you must read and confirm all rules.\n" +
            "The exam will last 60 minutes. Every question has a bunch of answers. You should choose ONLY ONE.\n" +
            "For start just push enter...";
            Console.Clear();
            ShowMessage(errorText);
            Console.ReadKey();
        }

        public static void ExamFinised(
            string category,
            int questions_count,
            int skipped_questions,
            int right_answers,
            int wrong_answers
            )
        {
            decimal ovarall_score = Math.Round(
                Convert.ToDecimal(right_answers) * 100 /
                Convert.ToDecimal(questions_count));

            string exam_passer_status = (ovarall_score >= 50) ? "Yes" : "No";

            string errorText = $"You succesfully finished your \"{category}\" exam\n" +
                $"Here is your results:\n" +
                $"Finished in {DateTime.Now.ToString()}\n" +
                $"Right answers: {right_answers}\n" +
                $"Wrong answers: {wrong_answers}\n" +
                $"Skipped questions: {skipped_questions}\n" +
                $"============================\n" +
                $"Your overall score: {ovarall_score} / 100\n" +
                $"Exam passed: {exam_passer_status}";

            Console.Clear();
            ShowMessage(errorText);
            Console.ReadKey();
        }

    }
}
