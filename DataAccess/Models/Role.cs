namespace DataAccess.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? Last_IsActive_ChangeDate { get; set; }

    }
}
