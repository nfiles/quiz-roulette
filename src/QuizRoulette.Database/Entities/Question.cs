using System;
using System.Collections.Generic;

namespace QuizRoulette.Database
{
    public partial class Question
    {
        public Question()
        {
            QuestionResponses = new HashSet<QuestionResponse>();
        }

        public Guid Identifier { get; set; }
        public Guid QuizTemplateIdentifier { get; set; }
        public Guid CorrectResponseIdentifier { get; set; }

        public virtual ICollection<QuestionResponse> QuestionResponses { get; set; }
        public virtual QuestionResponse CorrectResponse { get; set; }
        public virtual QuizTemplate QuizTemplate { get; set; }
    }
}
