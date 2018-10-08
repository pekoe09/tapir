using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tapir.Core;

namespace Tapir.Models
{
    public class Employment : EntityBase
    {
        [Required]
        public Company Company { get; set; }
        [Required]
        public Person Person { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        [Required]
        public bool IsMainOccupation { get; set; }
        [Required]
        public bool IsFullTime { get; set; }
        [Required]
        public bool IsCalledToWork { get; set; }
        [Required]
        [Range(minimum:0.0, maximum:168.0)]
        public double WeeklyHours { get; set; }
        [Range(minimum: 0.0, maximum: 24.0)]
        public double? PartTimeDailyHours { get; set; }
        [Range(minimum: 0, maximum: 7)]
        public int? PartTimeWeeklyDays { get; set; }
        public string  PartTimeEmploymentReason { get; set; }
        [Required]
        public bool? IsStudent { get; set; }
        public string SchoolName { get; set; }
        [Required]
        public bool? IsPensioner { get; set; }
        public string PensionPlan { get; set; }
        public DateTime? PensionStartDate { get; set; }
        public bool? IsPensionAppliedFor { get; set; }
        public string PensionFundName { get; set; }
        public string EntrepreneurshipStatus { get; set; }
        [Required]
        public bool? HasOtherEmployments { get; set; }
        public string OtherEmployerName { get; set; }
        public string OtherEmployerContactDetails { get; set; }

        internal EmploymentDTO GetDTO()
        {
            return new EmploymentDTO()
            {
                Id = this.ID,
                CompanyId = (int)this.Company.ID,
                CompanyFullName = this.Company.FullName,
                CompanyShortName = this.Company.ShortName,
                PersonId = (int)this.Person.ID,
                PersonFullName = this.Person.FullName,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                PlannedEndDate = this.PlannedEndDate,
                IsMainOccupation = this.IsMainOccupation,
                IsFullTime = this.IsFullTime,
                IsCalledToWork = this.IsCalledToWork,
                WeeklyHours = this.WeeklyHours,
                PartTimeDailyHours = this.PartTimeDailyHours,
                PartTimeWeeklyDays = this.PartTimeWeeklyDays,
                PartTimeEmploymentReason = this.PartTimeEmploymentReason,
                IsStudent = this.IsStudent,
                SchoolName = this.SchoolName,
                IsPensioner = this.IsPensioner,
                PensionPlan = this.PensionPlan,
                PensionStartDate = this.PensionStartDate,
                IsPensionAppliedFor = this.IsPensionAppliedFor,
                PensionFundName = this.PensionFundName,
                EntrepreneurshipStatus = this.EntrepreneurshipStatus,
                HasOtherEmployments = this.HasOtherEmployments,
                OtherEmployerName = this.OtherEmployerName,
                OtherEmployerContactDetails = this.OtherEmployerContactDetails
            };
        }
    }    
}
