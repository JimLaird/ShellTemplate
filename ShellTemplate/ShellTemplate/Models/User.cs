using SQLite;

namespace ShellTemplate.Models
{
    public class User
    {
        //  Defines a typical "User" object
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string RegDate { get; set; }
        public string Image { get; set; }
    }
}
