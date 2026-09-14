using GymManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GymManagementSystem.DAL
{
    public static class TrainersData
    {
        public static TrainerDTO GetByID(int trainerID)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Trainers_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TrainerID", trainerID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TrainerDTO
                        {
                            TrainerID = (int)reader["TrainerID"],
                            PersonID = (int)reader["PersonID"],
                            FirstName = (string)reader["FirstName"],
                            SecondName = (string)reader["SecondName"],
                            ThirdName = reader["ThirdName"] == DBNull.Value
                                ? null
                                : (string)reader["ThirdName"],
                            LastName = (string)reader["LastName"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            BirthDate = (DateTime)reader["BirthDate"],
                            Gender = (byte)reader["Gender"],
                            Area = (string)reader["Area"],
                            IsActive = (bool)reader["IsActive"]
                        };
                    }
                }
            }

            return null;
        }

        public static List<TrainerDTO> GetAll()
        {
            List<TrainerDTO> trainers = new List<TrainerDTO>();

            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT * FROM VW_Trainers", connection))
            {
                command.CommandType = CommandType.Text;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TrainerDTO trainer = new TrainerDTO
                        {
                            TrainerID = (int)reader["TrainerID"],
                            PersonID = (int)reader["PersonID"],
                            FirstName = (string)reader["FirstName"],
                            SecondName = (string)reader["SecondName"],
                            ThirdName = reader["ThirdName"] == DBNull.Value
                                ? null
                                : (string)reader["ThirdName"],
                            LastName = (string)reader["LastName"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            BirthDate = (DateTime)reader["BirthDate"],
                            Gender = (byte)reader["Gender"],
                            Area = (string)reader["Area"],
                            IsActive = (bool)reader["IsActive"]
                        };

                        trainers.Add(trainer);
                    }
                }
            }

            return trainers;
        }

        public static int Add(TrainerDTO trainer)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Trainers_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FirstName", trainer.FirstName);
                command.Parameters.AddWithValue("@SecondName", trainer.SecondName);
                command.Parameters.AddWithValue("@ThirdName",
                    (object)trainer.ThirdName ?? DBNull.Value);
                command.Parameters.AddWithValue("@LastName", trainer.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", trainer.PhoneNumber);
                command.Parameters.AddWithValue("@BirthDate", trainer.BirthDate);
                command.Parameters.AddWithValue("@Gender", trainer.Gender);
                command.Parameters.AddWithValue("@Area", trainer.Area);
                command.Parameters.AddWithValue("@IsActive", trainer.IsActive);

                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public static void Update(TrainerDTO trainer)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Trainers_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TrainerID", trainer.TrainerID);
                command.Parameters.AddWithValue("@FirstName", trainer.FirstName);
                command.Parameters.AddWithValue("@SecondName", trainer.SecondName);
                command.Parameters.AddWithValue("@ThirdName",
                    (object)trainer.ThirdName ?? DBNull.Value);
                command.Parameters.AddWithValue("@LastName", trainer.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", trainer.PhoneNumber);
                command.Parameters.AddWithValue("@BirthDate", trainer.BirthDate);
                command.Parameters.AddWithValue("@Gender", trainer.Gender);
                command.Parameters.AddWithValue("@Area", trainer.Area);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public static void Activate(int trainerID)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Trainers_Activate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TrainerID", trainerID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
        public static void Deactivate(int trainerID)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Trainers_Deactivate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TrainerID", trainerID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}