using Newtonsoft.Json;

namespace nijapmsapi
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Username { get; set; }
        [JsonIgnore]
        public bool Active { get; set; }
        [JsonIgnore]
        public int RoleId { get; set; }
        [JsonIgnore]
        public bool IsEmployee { get; set; }
        [JsonIgnore]
        public int EmployeeId { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public string Status { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public string Rolename { get; set; }
        [JsonIgnore]
        public bool IsAdmin { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime ModifiedDate { get; set; }
        [JsonIgnore]
        public int ModifiedBy { get; set; }
    }

    public class login
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int EmpId { get; set; }
        [JsonIgnore]
        public string email { get; set; }
        [JsonIgnore]
        public string displayName { get; set; }
        [JsonIgnore]
        public int RoleId { get; set; }
        [JsonIgnore]
        public DateTime expireDate { get; set; }
        [JsonIgnore]
        public int expiresIn { get; set; }
        public string idToken { get; set; }
        [JsonIgnore]
        public string kind { get; set; }
        [JsonIgnore]
        public string localId { get; set; }
        [JsonIgnore]
        public string refreshToken { get; set; }
        [JsonIgnore]
        public bool registered { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string rolename { get; set; }
        [JsonIgnore]
        public string name { get; set; }
        [JsonIgnore]
        public string ProfilePic { get; set; }


    }
}
