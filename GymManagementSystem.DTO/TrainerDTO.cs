namespace GymManagementSystem.DTO
{
    public class TrainerDTO : PersonDTO
    {
        public int TrainerID { get; set; }

        public bool IsActive { get; set; }
    }
}