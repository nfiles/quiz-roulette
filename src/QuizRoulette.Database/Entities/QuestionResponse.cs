using System;
using System.Collections.Generic;

namespace QuizRoulette.Database
{
    public partial class QuestionResponse
    {
        public QuestionResponse()
        {
            Questions = new HashSet<Question>();
            StudentQuizResponses = new HashSet<StudentQuizResponse>();
        }

        public Guid Identifier { get; set; }
        public Guid QuestionIdentifier { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<StudentQuizResponse> StudentQuizResponses { get; set; }
        public virtual Question Question { get; set; }
    }
}
