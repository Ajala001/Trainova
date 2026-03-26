namespace Trainova.Domain.Courses
{
    public interface ICourseRepository
    {
        Task DeleteAsync(Course training);
        Task<Course> GetByIdAsync(Guid id);
        Task<IEnumerable<Course>> GetAllAsync();
    }
}
