using System;

namespace QuizRoulette.Database
{
    public partial class StudentQuizResponse
    {
        public Guid QuizIdentifier { get; set; }
        public Guid StudentIdentifier { get; set; }
        public Guid? QuestionResponseIdentifier { get; set; }

        public virtual QuestionResponse QuestionResponse { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual ApplicationUser Student { get; set; }
    }
}
