
using Newtonsoft.Json;

namespace nijapmsapi
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        [JsonIgnore]
        public bool IsDelete { get; set; }
        [JsonIgnore]
        public bool Active { get; set; }
        [JsonIgnore]
        public string Status { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime ModifiedDate { get; set; }
        [JsonIgnore]
        public int ModifiedBy { get; set; }
        [JsonIgnore]
        public string Department { get; set; }

    }
}
