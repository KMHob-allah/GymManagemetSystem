namespace GymManagementSystem.BLL
{
    public class Plan
    {
        public int PlanID { get; private set; }

        public string PlanName { get; private set; }

        public int DurationInDays { get; private set; }

        public decimal Price { get; private set; }

        public bool IsActive { get; private set; }

        public Plan(int planID, string planName, int durationInDays, decimal price, bool isActive)
        {
            PlanID = planID;
            PlanName = planName;
            DurationInDays = durationInDays;
            Price = price;
            IsActive = isActive;
        }

        public Plan(string planName, int durationInDays, decimal price, bool isActive)
        {
            PlanName = planName;
            DurationInDays = durationInDays;
            Price = price;
            IsActive = isActive;
        }

        public void Update(string planName, int durationInDays, decimal price)
        {
            PlanName = planName;
            DurationInDays = durationInDays;
            Price = price;
        }
    }
}