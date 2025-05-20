
namespace nijapmsapi
{
    public interface IDepartmentRepository
    {

        Task<IEnumerable<Department>> Get();
        Task<Department> Find(int id);
        Task<Department> Add(Department activeDepartment);
        Task<Department> Update(Department activeDepartment);
        Task<int> Remove(int id,bool isDelete);

    }
}
