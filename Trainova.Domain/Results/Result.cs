using Trainova.Domain.Common;

namespace Trainova.Domain.Results
{
    public class Result : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid ExaminationId { get; private set; }

        public int Score { get; private set; }

        public Grade Grade { get; private set; }

        public decimal Percentage { get; private set; }

        public bool IsPassed => Score >= 50;

        public Result(Guid userId, Guid examId, int score)
        {
            UserId = userId;
            ExaminationId = examId;
            Score = score;

            CalculateGrade();
        }

        private void CalculateGrade()
        {
            Percentage = Score;

            Grade = Score switch
            {
                >= 90 => Grade.Excellent,
                >= 80 => Grade.VeryGood,
                >= 70 => Grade.Good,
                >= 60 => Grade.Pass,
                _ => Grade.Fail
            };
        }
    }

}
