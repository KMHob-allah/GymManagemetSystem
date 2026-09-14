using System;

namespace GymManagementSystem.BLL
{
    public class Membership
    {
        public int MembershipID { get; private set; }

        public int MemberID { get; private set; }

        public int PlanID { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public decimal TotalAmount { get; private set; }


        public Membership(
            int membershipID,
            int memberID,
            int planID,
            DateTime startDate,
            DateTime endDate,
            decimal totalAmount)
        {
            MembershipID = membershipID;
            MemberID = memberID;
            PlanID = planID;
            StartDate = startDate;
            EndDate = endDate;
            TotalAmount = totalAmount;
        }


        public Membership(
            int memberID,
            int planID,
            DateTime startDate,
            DateTime endDate,
            decimal totalAmount)
        {
            MemberID = memberID;
            PlanID = planID;
            StartDate = startDate;
            EndDate = endDate;
            TotalAmount = totalAmount;
        }


        public void Update(
            int planID,
            DateTime startDate,
            DateTime endDate,
            decimal totalAmount)
        {
            PlanID = planID;
            StartDate = startDate;
            EndDate = endDate;
            TotalAmount = totalAmount;
        }
    }
}