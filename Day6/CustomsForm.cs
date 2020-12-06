using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class CustomsForm
    {
        private List<string> Answers {get; set;}

        public CustomsForm(List<string> input) {
            Answers = input;
        }

        public CustomsForm() : this( new List<string>()) { }
        
        public int CountDistinctYesAnswers() {
            List<string> answeredQuestions = new List<string>();

            foreach (string personAnswers in Answers)
            {
                char[] answer = personAnswers.ToCharArray();
                for (var i = 0; i < personAnswers.Length; i++)
                {
                    if(!answeredQuestions.Contains(answer[i].ToString())) {
                        answeredQuestions.Add(answer[i].ToString());
                    }
                }
            }
            return answeredQuestions.Count;
        }

        public int CountCollectivYesAnswers() {
            int numberOfPersons = Answers.Count;
            List<Question> answeredQuestions = new List<Question>();

            foreach (string personAnswers in Answers)
            {
                char[] answer = personAnswers.ToCharArray();
                for (var i = 0; i < personAnswers.Length; i++)
                {
                    Question q = new Question(personAnswers[i].ToString());
                    if (answeredQuestions.Contains(q)) {
                        answeredQuestions[answeredQuestions.IndexOf(q)].IncreaseCount();
                    } else {
                        answeredQuestions.Add(q);
                    }
                }
            }
            return QuestionEveryoneAnsweredYes(numberOfPersons, answeredQuestions);
        }

        private int QuestionEveryoneAnsweredYes(int numberOfPersons, List<Question> answeredQuestions)
        {
            int count = 0;
            foreach (Question question in answeredQuestions)
            {
                if (question.Count == numberOfPersons) {
                    count++;
                }
            }
            return count;
        }
    }
}