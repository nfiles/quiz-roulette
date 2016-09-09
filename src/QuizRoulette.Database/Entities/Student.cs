using System;
using System.Collections.Generic;

namespace QuizRoulette.Database
{
    public partial class Student
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
            StudentQuizResponses = new HashSet<StudentQuizResponse>();
        }

        public Guid Identifier { get; set; }
        public string StudentNumber { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<StudentQuizResponse> StudentQuizResponses { get; set; }
    }
}
