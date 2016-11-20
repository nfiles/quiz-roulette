using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace QuizRoulette.Database
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Enrollments = new HashSet<Enrollment>();
            StudentQuizResponses = new HashSet<StudentQuizResponse>();
        }

        public Guid Identifier { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<StudentQuizResponse> StudentQuizResponses { get; set; }
    }
}
