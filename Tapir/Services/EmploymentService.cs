using System.Collections.Generic;
using Tapir.Core;
using Tapir.Models;

namespace Tapir.Services
{
    public class EmploymentService : IEmploymentService
    {
        private IEmploymentRepository employmentRepository;
        private ICompaniesRepository companiesRepository;
        private IPersonsRepository personsRepository;

        public EmploymentService(
            IEmploymentRepository employmentRepository,
            ICompaniesRepository companiesRepository,
            IPersonsRepository personsRepository)
        {
            this.employmentRepository = employmentRepository;
            this.companiesRepository = companiesRepository;
            this.personsRepository = personsRepository;
        }

        public List<EmploymentDTO> GetEmployments()
        {
            IEnumerable<Employment> employments = employmentRepository.GetAll();
            List<EmploymentDTO> employmentDTOs = new List<EmploymentDTO>();
            foreach(Employment e in employments)
            {
                employmentDTOs.Add(e.GetDTO());
            }
            return employmentDTOs;
        }

        public EmploymentDTO GetEmployment(int id)
        {
            Employment employment = employmentRepository.GetById(id);
            if(employment != null)
            {
                return employment.GetDTO();
            }
            else
            {
                return null;
            }
        }

        public EmploymentDTO SaveEmployment(EmploymentDTO employment)
        {
            if(employment == null)
            {
                return null;
            }
            Employment savedEmployment = null;
            if(employment.Id.HasValue)
            {
                savedEmployment = employmentRepository.Update(Hydrate(employment));
            }
            else
            {
                savedEmployment = employmentRepository.Insert(Hydrate(employment));
            }
            if(savedEmployment != null)
            {
                return savedEmployment.GetDTO();
            }
            else
            {
                return null;
            }
        }

        public EmploymentDTO RemoveEmployment(int id)
        {
            EmploymentDTO deletedEmployment = GetEmployment(id);
            if(deletedEmployment != null)
            {
                employmentRepository.Remove(id);
            }
            return deletedEmployment;
        }

        private Employment Hydrate(EmploymentDTO dto)
        {
            Employment employment = new Employment()
            {
                ID = dto.Id,
                Company = companiesRepository.GetById(dto.CompanyId),
                Person = personsRepository.GetById(dto.PersonId),
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                PlannedEndDate = dto.PlannedEndDate,
                IsMainOccupation = dto.IsMainOccupation,
                IsFullTime = dto.IsFullTime,
                IsCalledToWork = dto.IsCalledToWork,
                WeeklyHours = dto.WeeklyHours,
                PartTimeDailyHours = dto.PartTimeDailyHours,
                PartTimeWeeklyDays = dto.PartTimeWeeklyDays,
                PartTimeEmploymentReason = dto.PartTimeEmploymentReason,
                IsStudent = dto.IsStudent,
                SchoolName = dto.SchoolName,
                IsPensioner = dto.IsPensioner,
                PensionPlan = dto.PensionPlan,
                PensionStartDate = dto.PensionStartDate,
                IsPensionAppliedFor = dto.IsPensionAppliedFor,
                PensionFundName = dto.PensionFundName,
                EntrepreneurshipStatus = dto.EntrepreneurshipStatus,
                HasOtherEmployments = dto.HasOtherEmployments,
                OtherEmployerName = dto.OtherEmployerName,
                OtherEmployerContactDetails = dto.OtherEmployerContactDetails
            };
            return employment;
        }
    }
}
