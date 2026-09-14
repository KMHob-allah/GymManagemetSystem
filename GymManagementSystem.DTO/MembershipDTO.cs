using System;

namespace GymManagementSystem.DTO
{
    public class MembershipDTO
    {
        public int MembershipID { get; set; }

        public int MemberID { get; set; }

        public int PlanID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public string PaymentStatus { get; set; }

        public string Status { get; set; }
    }
}