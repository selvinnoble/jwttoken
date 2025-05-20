
namespace nijapmsapi
{
    public interface IDesignationRepository
    {

        Task<IEnumerable<Designation>> Get();
        Task<Designation> Find(int id);
        Task<Designation> Add(Designation activeDesignation);
        Task<Designation> Update(Designation activeDesignation);
        Task<int> Remove(int id, bool isDelete);

    }
}
