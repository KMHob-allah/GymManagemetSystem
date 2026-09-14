using GymManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GymManagementSystem.DAL
{
    public static class MembersData
    {
        public static MemberDTO GetByID(int memberID)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Members_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MemberID", memberID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new MemberDTO
                        {
                            MemberID = (int)reader["MemberID"],
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

                            EmergencyPhone = (string)reader["EmergencyPhone"],
                            JoinDate = (DateTime)reader["JoinDate"],
                            IsActive = (bool)reader["IsActive"]
                        };
                    }
                }
            }

            return null;
        }

        public static List<MemberDTO> GetAll()
        {
            List<MemberDTO> members = new List<MemberDTO>();

            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT * FROM VW_Members", connection))
            {
                command.CommandType = CommandType.Text;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MemberDTO member = new MemberDTO
                        {
                            MemberID = (int)reader["MemberID"],
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

                            EmergencyPhone = (string)reader["EmergencyPhone"],
                            JoinDate = (DateTime)reader["JoinDate"],
                            IsActive = (bool)reader["IsActive"]
                        };

                        members.Add(member);
                    }
                }
            }

            return members;
        }

        public static int Add(MemberDTO member)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Members_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FirstName", member.FirstName);
                command.Parameters.AddWithValue("@SecondName", member.SecondName);
                command.Parameters.AddWithValue("@ThirdName",
                    (object)member.ThirdName ?? DBNull.Value);
                command.Parameters.AddWithValue("@LastName", member.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", member.PhoneNumber);
                command.Parameters.AddWithValue("@BirthDate", member.BirthDate);
                command.Parameters.AddWithValue("@Gender", member.Gender);
                command.Parameters.AddWithValue("@Area", member.Area);
                command.Parameters.AddWithValue("@EmergencyPhone", member.EmergencyPhone);
                command.Parameters.AddWithValue("@JoinDate", member.JoinDate);
                command.Parameters.AddWithValue("@IsActive", member.IsActive);

                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static void Update(MemberDTO member)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Members_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MemberID", member.MemberID);
                command.Parameters.AddWithValue("@FirstName", member.FirstName);
                command.Parameters.AddWithValue("@SecondName", member.SecondName);
                command.Parameters.AddWithValue("@ThirdName",
                    (object)member.ThirdName ?? DBNull.Value);
                command.Parameters.AddWithValue("@LastName", member.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", member.PhoneNumber);
                command.Parameters.AddWithValue("@BirthDate", member.BirthDate);
                command.Parameters.AddWithValue("@Gender", member.Gender);
                command.Parameters.AddWithValue("@Area", member.Area);
                command.Parameters.AddWithValue("@EmergencyPhone", member.EmergencyPhone);
                command.Parameters.AddWithValue("@JoinDate", member.JoinDate);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public static void Activate(int memberID)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Members_Activate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MemberID", memberID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public static void Deactivate(int memberID)
        {
            using (SqlConnection connection = DataAccessSettings.GetConnection())
            using (SqlCommand command = new SqlCommand(
                "SP_Members_Deactivate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MemberID", memberID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}