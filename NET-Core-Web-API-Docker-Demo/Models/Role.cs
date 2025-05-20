namespace nijapmsapi
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }
        public bool IsDelete { get; set; }
        public bool Active { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string Rolename { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
