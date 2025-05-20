using System.Text.Json.Serialization;

namespace nijapmsapi
{
    public class RoleRights
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public string RoleName { get; set; }
        [JsonIgnore]
        public string ModuleName { get; set; }
        [JsonIgnore]
        public string SubModuleName { get; set; }
        [JsonIgnore]
        public string Url { get; set; }
        [JsonIgnore]
        public string Icon { get; set; }

        public string title { get; set; }
        public string classsChange { get; set; }
        public string iconStyle { get; set; }

        public List<MenuList> data = new List<MenuList>();
        public List<Content> content = new List<Content>();
    }

    public class MenuList
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string title { get; set; }
        public string classsChange { get; set; }
        public string iconStyle { get; set; }
        public string to { get; set; }
        [JsonIgnore]
        public int RoleId { get; set; }
        [JsonIgnore]
        public int MLId { get; set; }
        public List<Content> content { get; set; }

    }

    public class Content
    {
        public string title { get; set; }
        public string to { get; set; }
    }
}
