using System;
using System.Collections.Generic;

namespace QuizRoulette.Database
{
    public partial class QuizTemplate
    {
        public QuizTemplate()
        {
            Questions = new HashSet<Question>();
        }

        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public Guid ClassIdentifier { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual Class Class { get; set; }
    }
}
