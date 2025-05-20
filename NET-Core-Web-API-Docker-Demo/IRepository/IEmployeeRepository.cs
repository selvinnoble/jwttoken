

namespace nijapmsapi
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Get(int id);
        Task<Employee> Find(int id);
        Task<Employee> Add(Employee activeUser);
        Task<Employee> Update(Employee activeUser);
        Task<int> Remove(int id, bool isDelete);

    }
}
