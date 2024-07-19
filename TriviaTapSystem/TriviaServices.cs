using DLTriviaTap;
using MODELSTriviaTap;


namespace BLTriviaTap
{
    public class TriviaServices
    {
        public List<Trivia> GetAllTrivia()
        {
            UserData userData = new UserData();

            return userData.GetTrivia();

        }

        public Trivia GetTrivia(string questions, string answers)
        {
            Trivia foundtrivia = new Trivia();

            foreach (var trivia in GetAllTrivia())
            {
                if (trivia.questions == questions && trivia.answers == answers)
                {
                    foundtrivia = trivia;
                }
            }

            return foundtrivia;
        }
    }
}
