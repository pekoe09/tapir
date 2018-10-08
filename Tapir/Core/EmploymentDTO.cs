using System;
using System.ComponentModel.DataAnnotations;

namespace Tapir.Core
{
    public class EmploymentDTO
    {
        public int? Id { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public string CompanyFullName { get; set; }
        public string CompanyShortName { get; set; }
        [Required]
        public int PersonId { get; set; }
        public string PersonFullName { get; set; }
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
        [Range(minimum: 0.0, maximum: 168.0)]
        public double WeeklyHours { get; set; }
        [Range(minimum: 0.0, maximum: 24.0)]
        public double? PartTimeDailyHours { get; set; }
        [Range(minimum: 0, maximum: 7)]
        public int? PartTimeWeeklyDays { get; set; }
        public string PartTimeEmploymentReason { get; set; }
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
    }
}