using System;
using System.Collections.Generic;

namespace QuizRoulette.Database
{
    public partial class Quiz
    {
        public Quiz()
        {
            StudentQuizResponses = new HashSet<StudentQuizResponse>();
        }

        public Guid Identifier { get; set; }
        public Guid QuizTemplateIdentifier { get; set; }

        public virtual ICollection<StudentQuizResponse> StudentQuizResponses { get; set; }
    }
}
