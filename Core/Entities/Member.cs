namespace Core.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public float DBreakfast { get; set; }
        public float DLunch { get; set; }
        public float DDinner { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string PhotoName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public DateTime LastModifiedOn { get; set; }
        public int MessId { get; set; }
        public string MessRole { get; set; } = string.Empty;
    }
}