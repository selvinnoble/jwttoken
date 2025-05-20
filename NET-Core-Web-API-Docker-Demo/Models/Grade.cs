namespace nijapmsapi
{
    public class Grade
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public bool Active { get; set; }
        public bool IsDelete { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
