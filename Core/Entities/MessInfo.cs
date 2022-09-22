namespace Core.Entities
{
    public class MessInfo : BaseEntity
    {
        public string MessName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string SecretCode { get; set; } = string.Empty;
        public DateTime MealChangeFrom { get; set; }
        public DateTime MealChangeTo { get; set; }
        public string OwnerId { get; set; } = string.Empty;
        public bool IsAutoMealSave { get; set; }
        public DateTime AutoMealSaveTime { get; set; }
    }
}