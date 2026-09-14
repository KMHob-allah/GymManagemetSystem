using GymManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GymManagementSystem.BLL
{
    public static class MembershipsBusiness
    {
        private static MembershipDTO MapToDTO(Membership membership)
        {
            return new MembershipDTO
            {
                MembershipID = membership.MembershipID,
                MemberID = membership.MemberID,
                PlanID = membership.PlanID,
                StartDate = membership.StartDate,
                EndDate = membership.EndDate,
                TotalAmount = membership.TotalAmount
            };
        }

        private static Membership MapToMembership(MembershipDTO dto)
        {
            if (dto == null)
                return null;

            return new Membership(
                dto.MembershipID,
                dto.MemberID,
                dto.PlanID,
                dto.StartDate,
                dto.EndDate,
                dto.TotalAmount
            );
        }

        private static bool ValidateMembership(Membership membership)
        {
            if (membership == null)
                return false;

            if (membership.MemberID <= 0)
                return false;

            if (membership.PlanID <= 0)
                return false;

            if (membership.StartDate == DateTime.MinValue)
                return false;

            if (membership.EndDate < membership.StartDate)
                return false;

            if (membership.TotalAmount < 0)
                return false;

            return true;
        }

        public static Membership GetMembershipByID(int membershipID)
        {
            if (membershipID <= 0)
                return null;

            MembershipDTO dto =
                DAL.MembershipsData.GetByID(membershipID);

            return MapToMembership(dto);
        }

        public static List<Membership> GetAllMemberships()
        {
            List<MembershipDTO> dtos =
                DAL.MembershipsData.GetAll();

            List<Membership> memberships =
                new List<Membership>();

            foreach (MembershipDTO dto in dtos)
            {
                memberships.Add(
                    MapToMembership(dto)
                );
            }

            return memberships;
        }

        public static OperationResult<int> AddMembership(
            Membership membership)
        {
            if (membership == null)
            {
                return new OperationResult<int>
                {
                    Success = false,
                    Message = "Membership is required.",
                    Data = 0
                };
            }

            if (membership.MemberID <= 0 ||
                membership.PlanID <= 0)
            {
                return new OperationResult<int>
                {
                    Success = false,
                    Message = "Invalid membership data.",
                    Data = 0
                };
            }

            try
            {
                int membershipID =
                    DAL.MembershipsData.Add(
                        MapToDTO(membership));

                return new OperationResult<int>
                {
                    Success = true,
                    Message = "Membership added successfully.",
                    Data = membershipID
                };
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50008)
                {
                    return new OperationResult<int>
                    {
                        Success = false,
                        Message = "Member not found.",
                        Data = 0
                    };
                }

                if (ex.Number == 50004)
                {
                    return new OperationResult<int>
                    {
                        Success = false,
                        Message = "Plan not found or inactive.",
                        Data = 0
                    };
                }

                return new OperationResult<int>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = 0
                };
            }
        }

        public static OperationResult<bool> UpdateMembership(
            Membership membership)
        {
            if (!ValidateMembership(membership))
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = "Invalid membership data.",
                    Data = false
                };
            }

            try
            {
                DAL.MembershipsData.Update(
                    MapToDTO(membership));

                return new OperationResult<bool>
                {
                    Success = true,
                    Message = "Membership updated successfully.",
                    Data = true
                };
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50005)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Membership not found.",
                        Data = false
                    };
                }

                if (ex.Number == 50006)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Cannot update a membership that has payments.",
                        Data = false
                    };
                }

                if (ex.Number == 50007)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Plan not found or inactive.",
                        Data = false
                    };
                }

                return new OperationResult<bool>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = false
                };
            }
        }
    }
}