using Trainova.Domain.Common;
using Trainova.Domain.Results;

namespace Trainova.Domain.Examinations
{
    public class Examination : BaseEntity
    {
        public Guid TrainingId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public DateTime ExamDate { get; private set; }

        private readonly List<Result> _results = [];
        public IReadOnlyCollection<Result> Results => _results;
    }

}
