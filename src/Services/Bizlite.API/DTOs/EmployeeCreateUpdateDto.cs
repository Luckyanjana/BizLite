﻿using System.ComponentModel.DataAnnotations;

namespace ToDo.WebApi.DTOs
{
    public class EmployeeCreateUpdateDto
    {

        [Required]
        public string EmpName { get; set; } = null!;

        [Required]
        public string EmpGender { get; set; } = null!;

        [Required]
        public string? FatherName { get; set; }

        public int? BloodGroup { get; set; }

        [Required]
        public long StateId { get; set; }

        [Required]
        public long CityId { get; set; }

        public string? PinCode { get; set; }

        public string? DisplayName { get; set; }

        public string? Mobile { get; set; }

        public string? Phone { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public DateTime Dob { get; set; }

        public DateTime? Doj { get; set; }

        public DateTime? Dor { get; set; }

        public int? DesignationId { get; set; }

        public int? SupervisorId { get; set; }

        public int? RefferedbyId { get; set; }

        public string? RefferalName { get; set; }

        public string? RefferalMobile { get; set; }

        public string? RefferalAddress { get; set; }

        public int? WorkAreaId { get; set; }

        [Required]
        public string EmailId { get; set; } = null!;
        public string? Remark { get; set; }

        [Required]
        public string Password { get; set; }

        public bool? IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }


    }
}
