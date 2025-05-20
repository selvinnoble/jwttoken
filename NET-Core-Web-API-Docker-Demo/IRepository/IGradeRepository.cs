
namespace nijapmsapi
{
    public interface IGradeRepository
    {

        Task<IEnumerable<Grade>> Get();
        Task<Grade> Find(int id);
        Task<Grade> Add(Grade activeGrade);
        Task<Grade> Update(Grade activeGrade);
        Task<int> Remove(int id, bool isDelete);

    }
}
