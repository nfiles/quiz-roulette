using System;
using System.Collections.Generic;

namespace QuizRoulette.Database
{
    public partial class Class
    {
        public Class()
        {
            Enrollments = new HashSet<Enrollment>();
            QuizTemplates = new HashSet<QuizTemplate>();
        }

        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<QuizTemplate> QuizTemplates { get; set; }
    }
}
