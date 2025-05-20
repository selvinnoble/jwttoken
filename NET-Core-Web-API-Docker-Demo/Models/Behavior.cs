namespace nijapmsapi
{
    public class Behavior
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorparateValues { get; set; }
        public string FutureDescription { get; set; }
        public bool Active { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
