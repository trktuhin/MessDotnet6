namespace Core.Specifications.SearchParams
{
    public class MemberSearchParams : BasePagingParams
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public int MessId { get; set; }
        public string MessRole { get; set; } = string.Empty;
    }
}