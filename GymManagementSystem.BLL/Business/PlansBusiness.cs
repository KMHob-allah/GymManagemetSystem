using GymManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GymManagementSystem.BLL
{
    public static class PlansBusiness
    {
        private static Plan MapToPlan(PlanDTO dto)
        {
            if (dto == null) return null;

            return new Plan(dto.PlanID, dto.PlanName, dto.DurationInDays, dto.Price, dto.IsActive);
        }

        private static PlanDTO MapToDTO(Plan plan)
        {
            if (plan == null) return null;

            return new PlanDTO
            {
                PlanID = plan.PlanID,
                PlanName = plan.PlanName,
                DurationInDays = plan.DurationInDays,
                Price = plan.Price,
                IsActive = plan.IsActive
            };
        }

        private static bool ValidatePlan(Plan plan)
        {
            if (plan == null) return false;

            if (string.IsNullOrWhiteSpace(plan.PlanName)) return false;

            if (plan.DurationInDays <= 0) return false;

            if (plan.Price < 0) return false;

            return true;
        }

        public static OperationResult<Plan> GetPlanByID(int planID)
        {
            try
            {
                PlanDTO dto = DAL.PlansData.GetByID(planID);

                if (dto == null)
                {
                    return new OperationResult<Plan>
                    {
                        Success = false,
                        Message = "Plan not found.",
                        Data = null
                    };
                }

                return new OperationResult<Plan>
                {
                    Success = true,
                    Message = "Plan retrieved successfully.",
                    Data = MapToPlan(dto)
                };
            }
            catch (SqlException ex)
            {
                return new OperationResult<Plan>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public static OperationResult<List<Plan>> GetAllPlans()
        {
            try
            {
                List<PlanDTO> dtos = DAL.PlansData.GetAll();

                List<Plan> plans = new List<Plan>();

                foreach (PlanDTO dto in dtos)
                {
                    plans.Add(MapToPlan(dto));
                }

                return new OperationResult<List<Plan>>
                {
                    Success = true,
                    Message = "Plans retrieved successfully.",
                    Data = plans
                };
            }
            catch (SqlException ex)
            {
                return new OperationResult<List<Plan>>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public static OperationResult<int> AddPlan(Plan plan)
        {
            if (!ValidatePlan(plan))
            {
                return new OperationResult<int>
                {
                    Success = false,
                    Message = "Invalid plan data.",
                    Data = 0
                };
            }

            try
            {
                int planID = DAL.PlansData.Add(MapToDTO(plan));

                return new OperationResult<int>
                {
                    Success = true,
                    Message = "Plan added successfully.",
                    Data = planID
                };
            }
            catch (SqlException ex)
            {
                if ((ex.Number == 2601 || ex.Number == 2627) &&
                    ex.Message.Contains("UQ_Plans_PlanName"))
                {
                    return new OperationResult<int>
                    {
                        Success = false,
                        Message = "Plan name already exists.",
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

        public static OperationResult<bool> UpdatePlan(Plan plan)
        {
            if (!ValidatePlan(plan))
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = "Invalid plan data.",
                    Data = false
                };
            }

            try
            {
                DAL.PlansData.Update(MapToDTO(plan));

                return new OperationResult<bool>
                {
                    Success = true,
                    Message = "Plan updated successfully.",
                    Data = true
                };
            }
            catch (SqlException ex)
            {
                if ((ex.Number == 2601 || ex.Number == 2627) &&
                    ex.Message.Contains("UQ_Plans_PlanName"))
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Plan name already exists.",
                        Data = false
                    };
                }

                if (ex.Number == 50021)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Plan not found.",
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

        public static OperationResult<bool> ActivatePlan(int planID)
        {
            try
            {
                DAL.PlansData.Activate(planID);

                return new OperationResult<bool>
                {
                    Success = true,
                    Message = "Plan activated successfully.",
                    Data = true
                };
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50024)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Plan not found.",
                        Data = false
                    };
                }

                if (ex.Number == 50022)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Plan is already active.",
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

        public static OperationResult<bool> DeactivatePlan(int planID)
        {
            try
            {
                DAL.PlansData.Deactivate(planID);

                return new OperationResult<bool>
                {
                    Success = true,
                    Message = "Plan deactivated successfully.",
                    Data = true
                };
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50024)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Plan not found.",
                        Data = false
                    };
                }

                if (ex.Number == 50023)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Plan is already inactive.",
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