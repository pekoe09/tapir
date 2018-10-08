using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tapir.Models
{
    public class EmploymentRepository : IEmploymentRepository
    {
        private readonly TapirContext context;

        public EmploymentRepository(TapirContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employment> GetAll()
        {
            return context.Employments
                .Include(e => e.Company)
                .Include(e => e.Person)
                .AsEnumerable();
        }

        public Employment GetById(int id)
        {
            return context.Employments
                .Include(e => e.Company)
                .Include(e => e.Person)
                .Single(e => e.ID == id);
        }

        public Employment Insert(Employment employment)
        {
            context.Employments.Add(employment);
            context.SaveChanges();
            return employment;
        }

        public Employment Update(Employment employment)
        {
            Employment updatedEmployment = GetById((int)employment.ID);
            if(updatedEmployment == null)
            {
                return null;
            }
            updatedEmployment.Company = employment.Company;
            updatedEmployment.Person = employment.Person;
            updatedEmployment.StartDate = employment.StartDate;
            updatedEmployment.EndDate = employment.EndDate;
            updatedEmployment.PlannedEndDate = employment.PlannedEndDate;
            updatedEmployment.IsMainOccupation = employment.IsMainOccupation;
            updatedEmployment.IsFullTime = employment.IsFullTime;
            updatedEmployment.IsCalledToWork = employment.IsCalledToWork;
            updatedEmployment.WeeklyHours = employment.WeeklyHours;
            updatedEmployment.PartTimeDailyHours = employment.PartTimeDailyHours;
            updatedEmployment.PartTimeWeeklyDays = employment.PartTimeWeeklyDays;
            updatedEmployment.PartTimeEmploymentReason = employment.PartTimeEmploymentReason;
            updatedEmployment.IsStudent = employment.IsStudent;
            updatedEmployment.SchoolName = employment.SchoolName;
            updatedEmployment.IsPensioner = employment.IsPensioner;
            updatedEmployment.PensionPlan = employment.PensionPlan;
            updatedEmployment.PensionStartDate = employment.PensionStartDate;
            updatedEmployment.IsPensionAppliedFor = employment.IsPensionAppliedFor;
            updatedEmployment.PensionFundName = employment.PensionFundName;
            updatedEmployment.EntrepreneurshipStatus = employment.EntrepreneurshipStatus;
            updatedEmployment.HasOtherEmployments = employment.HasOtherEmployments;
            updatedEmployment.OtherEmployerName = employment.OtherEmployerName;
            updatedEmployment.OtherEmployerContactDetails = employment.OtherEmployerContactDetails;

            context.Employments.Update(updatedEmployment);
            context.SaveChanges();
            return updatedEmployment;
        }

        public Employment Remove (int id)
        {
            Employment deletedEmployment = GetById(id);
            if(deletedEmployment != null)
            {
                context.Employments.Remove(deletedEmployment);
                context.SaveChanges();
                return deletedEmployment;
            }
            else
            {
                return null;
            }
        }
    }
}
