using GymManagementSystem.DAL;
using GymManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GymManagementSystem.BLL
{
    public static class MembersBusiness
    {
        private static Member MapToMember(MemberDTO memberDTO)
        {
            return new Member(
                memberDTO.MemberID,
                memberDTO.PersonID,
                memberDTO.FirstName,
                memberDTO.SecondName,
                memberDTO.ThirdName,
                memberDTO.LastName,
                memberDTO.PhoneNumber,
                memberDTO.BirthDate,
                (Member.eGender)memberDTO.Gender,
                memberDTO.Area,
                memberDTO.EmergencyPhone,
                memberDTO.JoinDate,
                memberDTO.IsActive
            );
        }

        private static MemberDTO MapToDTO(Member member)
        {
            return new MemberDTO
            {
                MemberID = member.MemberID,
                PersonID = member.PersonID,
                FirstName = member.FirstName,
                SecondName = member.SecondName,
                ThirdName = member.ThirdName,
                LastName = member.LastName,
                PhoneNumber = member.PhoneNumber,
                BirthDate = member.BirthDate,
                Gender = (byte)member.Gender,
                Area = member.Area,
                EmergencyPhone = member.EmergencyPhone,
                JoinDate = member.JoinDate,
                IsActive = member.IsActive
            };
        }

        private static string ValidateMember(Member member)
        {
            if (member == null)
                return "Member data is required.";

            if (string.IsNullOrWhiteSpace(member.FirstName))
                return "First name is required.";

            if (string.IsNullOrWhiteSpace(member.SecondName))
                return "Second name is required.";

            if (string.IsNullOrWhiteSpace(member.LastName))
                return "Last name is required.";

            if (string.IsNullOrWhiteSpace(member.PhoneNumber))
                return "Phone number is required.";

            if (member.BirthDate > DateTime.Today)
                return "Birth date cannot be in the future.";

            if (!member.IsMale() && !member.IsFemale())
                return "Invalid gender.";

            if (string.IsNullOrWhiteSpace(member.EmergencyPhone))
                return "Emergency phone is required.";

            if (member.JoinDate > DateTime.Today)
                return "Join date cannot be in the future.";

            return null;
        }

        public static OperationResult<Member> GetMemberByID(int memberID)
        {
            try
            {
                MemberDTO memberDTO = MembersData.GetByID(memberID);

                if (memberDTO == null)
                {
                    return new OperationResult<Member>
                    {
                        Success = false,
                        Message = "Member not found.",
                        Data = null
                    };
                }

                Member member = MapToMember(memberDTO);

                return new OperationResult<Member>
                {
                    Success = true,
                    Message = "Member retrieved successfully.",
                    Data = member
                };
            }

            catch (SqlException)
            {
                return new OperationResult<Member>
                {
                    Success = false,
                    Message = "An error occurred while retrieving the member.",
                    Data = null
                };
            }
        }

        public static OperationResult<List<Member>> GetAllMembers()
        {
            try
            {
                List<MemberDTO> memberDTOs = MembersData.GetAll();

                List<Member> members = new List<Member>();

                foreach (MemberDTO memberDTO in memberDTOs)
                {
                    members.Add(MapToMember(memberDTO));
                }

                return new OperationResult<List<Member>>
                {
                    Success = true,
                    Message = "Members retrieved successfully.",
                    Data = members
                };
            }
            catch (SqlException)
            {
                return new OperationResult<List<Member>>
                {
                    Success = false,
                    Message = "An error occurred while retrieving members.",
                    Data = null
                };
            }
        }

        public static OperationResult<int> AddMember(Member member)
        {
            string validationMessage = ValidateMember(member);

            if (validationMessage != null)
            {
                return new OperationResult<int>
                {
                    Success = false,
                    Message = validationMessage,
                    Data = 0
                };
            }

            try
            {
                MemberDTO memberDTO = MapToDTO(member);

                int memberID = MembersData.Add(memberDTO);

                return new OperationResult<int>
                {
                    Success = true,
                    Message = "Member added successfully.",
                    Data = memberID
                };
            }
            catch (SqlException ex)
            {
                if ((ex.Number == 2601 || ex.Number == 2627) &&
                    ex.Message.Contains("UQ_People_PhoneNumber"))
                {
                    return new OperationResult<int>
                    {
                        Success = false,
                        Message = "Phone number already exists.",
                        Data = 0
                    };
                }

                return new OperationResult<int>
                {
                    Success = false,
                    Message = "An error occurred while adding the member.",
                    Data = 0
                };
            }
        }

        public static OperationResult<bool> UpdateMember(Member member)
        {
            string validationMessage = ValidateMember(member);

            if (validationMessage != null)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = validationMessage,
                    Data = false
                };
            }

            try
            {
                MemberDTO memberDTO = MapToDTO(member);

                MembersData.Update(memberDTO);

                return new OperationResult<bool>
                {
                    Success = true,
                    Message = "Member updated successfully.",
                    Data = true
                };
            }
            catch (SqlException ex)
            {
                if ((ex.Number == 2601 || ex.Number == 2627) &&
                    ex.Message.Contains("UQ_People_PhoneNumber"))
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Phone number already exists.",
                        Data = false
                    };
                }

                return new OperationResult<bool>
                {
                    Success = false,
                    Message = "An error occurred while updating the member.",
                    Data = false
                };
            }
        }

        public static OperationResult<bool> ActivateMember(int memberID)
        {
            try
            {
                MembersData.Activate(memberID);

                return new OperationResult<bool>
                {
                    Success = true,
                    Message = "Member activated successfully.",
                    Data = true
                };
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50003)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Member not found.",
                        Data = false
                    };
                }

                if (ex.Number == 50004)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Member is already active.",
                        Data = false
                    };
                }

                return new OperationResult<bool>
                {
                    Success = false,
                    Message = "An error occurred while activating the member.",
                    Data = false
                };
            }
        }

        public static OperationResult<bool> DeactivateMember(int memberID)
        {
            try
            {
                MembersData.Deactivate(memberID);

                return new OperationResult<bool>
                {
                    Success = true,
                    Message = "Member deactivated successfully.",
                    Data = true
                };
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50002)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Member not found.",
                        Data = false
                    };
                }

                if (ex.Number == 50005)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Member is already inactive.",
                        Data = false
                    };
                }

                return new OperationResult<bool>
                {
                    Success = false,
                    Message = "An error occurred while deactivating the member.",
                    Data = false
                };
            }
        }
    }
}