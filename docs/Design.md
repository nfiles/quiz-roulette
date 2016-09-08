# Quiz Roulette Design

## Table of Contents

1. [Teacher Workflows](#teacher-workflows)
    - [Creating a Quiz](#creating-a-quiz)
    - [Administering a Quiz](#administering-a-quiz)
    - [Viewing the Results of a Quiz](#viewing-the-results-of-a-quiz)
    - [Viewing the Results of all Quizzes](#viewing-the-results-of-all-quizzes)
1. [Student Workflows](#student-workflows)
    - [Taking a Quiz](#taking-a-quiz)
1. [Database](#database-tables)

---

## Teacher Workflows

### Creating a Quiz

1. Create a `Class` with:
    - Name
1. Create a `QuizTemplate` for a `Class` with:
    - Name
1. Edit multiple choice questions for the `Quiz`. Questions have:
    - Order
    - Responses
    - Max Point Value

### Administering a Quiz

1. Select the `QuizTemplate`.
1. Start a new `Quiz` and get the link.
1. Provide the link to all class members who should take the `Quiz`.
1. When you decide that the time is up, close the `Quiz`. After this point, no new answers will be accepted. A button to view the results of the `Quiz` is automatically displayed.

### Viewing the Results of a Quiz

1. A link to view the results of a Quiz is displayed:
    - Automatically, after closing a `Quiz`
    - On the list of `Quizzes`
1. The `Quiz` results should show:
    - Individual score for all members of the class
    - Average score
    - Percentage of times a student chose the safe vs. risky option

### Viewing the Results of all Quizzes

1. Show results similar to the individual `Quiz` results, but for all `Quizzes` or `Quizzes` in a specific `Class`.

## Student Workflows

### Taking a Quiz

1. Receive a `Quiz` link from the `Teacher` and navigate to it.
1. Register with Student ID (expected to know this out-of-band).
1. For each question, select an answer or choose "Roulette".
1. Either question-by-question or all at the end, the `Student` is presented with the results of his answers and the overall score of the `Quiz`.
1. `Student` can see where the score places among publicly posted scores.
1. `Student` has the option to post the score publicly.
1. Link is generated for the `Student` to view the `QuizResults` later.

---

## Database Tables

1. `Teachers`
    - Identifier
    - {connected to user by this identifier?}
1. `Classes`
    - Identifier
    - Name
1. `Sections`
    - Identifier
    - TeacherIdentifier
    - Name
1. `Enrollment`
    - StudentIdentifier
    - SectionIdentifier
1. `Students`
    - Identifier
    - StudentNumber
    - Name
1. `QuizTemplates`
    - collects all of the questions that are on a quiz
    - Identifier
    - Name
1. `Questions`
    - Identifier
    - QuizTemplateIdentifier
    - CorrectResponseIdentifier
1. `QuestionResponses`
    - Identifier
    - QuestionIdentifier
    - Text
1. `Quizzes`
    - Identifier
    - QuizTemplateIdentifier
    - StartTime
    - EndTime
1. `QuizResults`
    - Identifier
    - StudentIdentifier
    - QuestionResponseIdentifier? (NULL = roll the dice)
