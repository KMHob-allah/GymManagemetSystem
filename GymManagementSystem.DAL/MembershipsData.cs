using GymManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GymManagementSystem.DAL
{
    public static class MembershipsData
    {
        public static MembershipDTO GetByID(int membershipID)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Memberships_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue(
                    "@MembershipID", membershipID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new MembershipDTO
                        {
                            MembershipID = (int)reader["MembershipID"],
                            MemberID = (int)reader["MemberID"],
                            PlanID = (int)reader["PlanID"],
                            StartDate = (DateTime)reader["StartDate"],
                            EndDate = (DateTime)reader["EndDate"],
                            TotalAmount = (decimal)reader["TotalAmount"]
                        };
                    }
                }
            }

            return null;
        }

        public static List<MembershipDTO> GetAll()
        {
            List<MembershipDTO> memberships =
                new List<MembershipDTO>();

            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT * FROM VW_Memberships", connection))
            {
                command.CommandType = CommandType.Text;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MembershipDTO membership = new MembershipDTO
                        {
                            MembershipID = (int)reader["MembershipID"],
                            MemberID = (int)reader["MemberID"],
                            StartDate = (DateTime)reader["StartDate"],
                            EndDate = (DateTime)reader["EndDate"],
                            TotalAmount = (decimal)reader["TotalAmount"],
                            PaidAmount = (decimal)reader["PaidAmount"],
                            RemainingAmount = (decimal)reader["RemainingAmount"],
                            PaymentStatus = (string)reader["PaymentStatus"],
                            Status = (string)reader["Status"]
                        };

                        memberships.Add(membership);
                    }
                }
            }

            return memberships;
        }

        public static int Add(MembershipDTO membership)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Memberships_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue(
                    "@MemberID", membership.MemberID);

                command.Parameters.AddWithValue(
                    "@PlanID", membership.PlanID);

                command.Parameters.AddWithValue(
                    "@StartDate", membership.StartDate);

                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static void Update(MembershipDTO membership)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Memberships_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue(
                    "@MembershipID", membership.MembershipID);

                command.Parameters.AddWithValue(
                    "@PlanID", membership.PlanID);

                command.Parameters.AddWithValue(
                    "@StartDate", membership.StartDate);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}