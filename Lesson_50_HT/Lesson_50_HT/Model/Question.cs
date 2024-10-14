using System;
using System.Collections.Generic;
using Lesson_50_HT.Services.AutoIncrement;

namespace Lesson_50_HT.Model
{
    public class Question
    {
        public int ID { get; private set; }
        public string QuestionText { get; set; }
        public List<string> Answers { get; set; }
        public int RightAnswerID { get; set; }

        public Question(
            string questionText,
            List<string> answers,
            int rightAnswerID)
        {
            ID = AutoIncrement.GetQuestionID();
            QuestionText = questionText;
            Answers = answers;
            RightAnswerID = rightAnswerID;
        }

        public Question() {
            ID = AutoIncrement.GetQuestionID();
            Answers = new();
        } 

        public void ShowQuestion()
        {
            Console.WriteLine($"№{ID} " + QuestionText);
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Answers[i]}");
            }
        }

	}
}

