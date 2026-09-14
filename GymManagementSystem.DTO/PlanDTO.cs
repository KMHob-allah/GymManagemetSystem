namespace GymManagementSystem.DTO
{
    public class PlanDTO
    {
        public int PlanID { get; set; }

        public string PlanName { get; set; }

        public int DurationInDays { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }
    }
}