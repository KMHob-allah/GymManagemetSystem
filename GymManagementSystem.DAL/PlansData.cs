using GymManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GymManagementSystem.DAL
{
    public static class PlansData
    {
        public static PlanDTO GetByID(int planID)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Plans_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PlanID", planID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new PlanDTO
                        {
                            PlanID = (int)reader["PlanID"],
                            PlanName = (string)reader["PlanName"],
                            DurationInDays = (int)reader["DurationInDays"],
                            Price = (decimal)reader["Price"],
                            IsActive = (bool)reader["IsActive"]
                        };
                    }
                }
            }

            return null;
        }

        public static List<PlanDTO> GetAll()
        {
            List<PlanDTO> plans = new List<PlanDTO>();

            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT * FROM VW_Plans", connection))
            {
                command.CommandType = CommandType.Text;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PlanDTO plan = new PlanDTO
                        {
                            PlanID = (int)reader["PlanID"],
                            PlanName = (string)reader["PlanName"],
                            DurationInDays = (int)reader["DurationInDays"],
                            Price = (decimal)reader["Price"],
                            IsActive = (bool)reader["IsActive"]
                        };

                        plans.Add(plan);
                    }
                }
            }

            return plans;
        }

        public static int Add(PlanDTO plan)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Plans_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PlanName", plan.PlanName);
                command.Parameters.AddWithValue(
                    "@DurationInDays", plan.DurationInDays);
                command.Parameters.AddWithValue("@Price", plan.Price);
                command.Parameters.AddWithValue("@IsActive", plan.IsActive);

                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static void Update(PlanDTO plan)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Plans_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PlanID", plan.PlanID);
                command.Parameters.AddWithValue("@PlanName", plan.PlanName);
                command.Parameters.AddWithValue("@DurationInDays", plan.DurationInDays);
                command.Parameters.AddWithValue("@Price", plan.Price);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public static void Activate(int planID)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Plans_Activate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PlanID", planID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public static void Deactivate(int planID)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Plans_Deactivate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PlanID", planID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}