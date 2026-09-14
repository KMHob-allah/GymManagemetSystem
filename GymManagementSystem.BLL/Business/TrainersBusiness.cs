using GymManagementSystem.DAL;
using GymManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GymManagementSystem.BLL
{
    public static class TrainersBusiness
    {
        private static Trainer MapToTrainer(TrainerDTO trainerDTO)
        {
            return new Trainer(
                trainerDTO.TrainerID,
                trainerDTO.PersonID,
                trainerDTO.FirstName,
                trainerDTO.SecondName,
                trainerDTO.ThirdName,
                trainerDTO.LastName,
                trainerDTO.PhoneNumber,
                trainerDTO.BirthDate,
                (Trainer.eGender)trainerDTO.Gender,
                trainerDTO.Area,
                trainerDTO.IsActive
            );
        }

        private static TrainerDTO MapToDTO(Trainer trainer)
        {
            return new TrainerDTO
            {
                TrainerID = trainer.TrainerID,
                PersonID = trainer.PersonID,
                FirstName = trainer.FirstName,
                SecondName = trainer.SecondName,
                ThirdName = trainer.ThirdName,
                LastName = trainer.LastName,
                PhoneNumber = trainer.PhoneNumber,
                BirthDate = trainer.BirthDate,
                Gender = (byte)trainer.Gender,
                Area = trainer.Area,
                IsActive = trainer.IsActive
            };
        }

        private static string ValidateTrainer(Trainer trainer)
        {
            if (trainer == null)
                return "Trainer data is required.";

            if (string.IsNullOrWhiteSpace(trainer.FirstName))
                return "First name is required.";

            if (string.IsNullOrWhiteSpace(trainer.SecondName))
                return "Second name is required.";

            if (string.IsNullOrWhiteSpace(trainer.LastName))
                return "Last name is required.";

            if (string.IsNullOrWhiteSpace(trainer.PhoneNumber))
                return "Phone number is required.";

            if (trainer.BirthDate > DateTime.Today)
                return "Birth date cannot be in the future.";

            if (!trainer.IsMale() && !trainer.IsFemale())
                return "Invalid gender.";

            return null;
        }

        public static OperationResult<Trainer> GetTrainerByID(int trainerID)
        {
            try
            {
                TrainerDTO trainerDTO = TrainersData.GetByID(trainerID);

                if (trainerDTO == null)
                {
                    return new OperationResult<Trainer>
                    {
                        Success = false,
                        Message = "Trainer not found.",
                        Data = null
                    };
                }

                Trainer trainer = MapToTrainer(trainerDTO);

                return new OperationResult<Trainer>
                {
                    Success = true,
                    Message = "Trainer retrieved successfully.",
                    Data = trainer
                };
            }
            catch (SqlException)
            {
                return new OperationResult<Trainer>
                {
                    Success = false,
                    Message = "An error occurred while retrieving the trainer.",
                    Data = null
                };
            }
        }

        public static OperationResult<List<Trainer>> GetAllTrainers()
        {
            try
            {
                List<TrainerDTO> trainerDTOs = TrainersData.GetAll();
                List<Trainer> trainers = new List<Trainer>();

                foreach (TrainerDTO trainerDTO in trainerDTOs)
                {
                    trainers.Add(MapToTrainer(trainerDTO));
                }

                return new OperationResult<List<Trainer>>
                {
                    Success = true,
                    Message = "Trainers retrieved successfully.",
                    Data = trainers
                };
            }
            catch (SqlException)
            {
                return new OperationResult<List<Trainer>>
                {
                    Success = false,
                    Message = "An error occurred while retrieving trainers.",
                    Data = null
                };
            }
        }

        public static OperationResult<int> AddTrainer(Trainer trainer)
        {
            string validationMessage = ValidateTrainer(trainer);

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
                TrainerDTO trainerDTO = MapToDTO(trainer);

                int trainerID = TrainersData.Add(trainerDTO);

                return new OperationResult<int>
                {
                    Success = true,
                    Message = "Trainer added successfully.",
                    Data = trainerID
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
                    Message = "An error occurred while adding the trainer.",
                    Data = 0
                };
            }
        }

        public static OperationResult<bool> UpdateTrainer(Trainer trainer)
        {
            string validationMessage = ValidateTrainer(trainer);

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
                TrainerDTO trainerDTO = MapToDTO(trainer);

                TrainersData.Update(trainerDTO);

                return new OperationResult<bool>
                {
                    Success = true,
                    Message = "Trainer updated successfully.",
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

                if (ex.Number == 50013)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Trainer not found.",
                        Data = false
                    };
                }

                return new OperationResult<bool>
                {
                    Success = false,
                    Message = "An error occurred while updating the trainer.",
                    Data = false
                };
            }
        }

        public static OperationResult<bool> ActivateTrainer(int trainerID)
        {
            try
            {
                TrainersData.Activate(trainerID);

                return new OperationResult<bool>
                {
                    Success = true,
                    Message = "Trainer activated successfully.",
                    Data = true
                };
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50016)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Trainer not found.",
                        Data = false
                    };
                }

                if (ex.Number == 50014)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Trainer is already active.",
                        Data = false
                    };
                }

                return new OperationResult<bool>
                {
                    Success = false,
                    Message = "An error occurred while activating the trainer.",
                    Data = false
                };
            }
        }

        public static OperationResult<bool> DeactivateTrainer(int trainerID)
        {
            try
            {
                TrainersData.Deactivate(trainerID);

                return new OperationResult<bool>
                {
                    Success = true,
                    Message = "Trainer deactivated successfully.",
                    Data = true
                };
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50016)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Trainer not found.",
                        Data = false
                    };
                }

                if (ex.Number == 50015)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Trainer is already inactive.",
                        Data = false
                    };
                }

                return new OperationResult<bool>
                {
                    Success = false,
                    Message = "An error occurred while deactivating the trainer.",
                    Data = false
                };
            }
        }
    }
}