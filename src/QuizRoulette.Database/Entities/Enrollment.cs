using System;

namespace QuizRoulette.Database
{
    public partial class Enrollment
    {
        public Guid StudentIdentifier { get; set; }
        public Guid ClassIdentifier { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
