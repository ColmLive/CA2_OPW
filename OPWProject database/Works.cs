﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Test 7/11/2018
// Test 2 - 7/11/2018
//Test 3 - 7/11/2018
//Test 4 - 7/11/2018
//Test 5 - 7/11/2018
// Test 6 - 7/11/2018
//Test 7 - 7/11/2018




namespace OPWProject1.Pages.Models
{


    public enum Status
    {
        [Display(Name = "Pending Approval")] Pending_Approval,
        [Display(Name = "Approved")] Approved,
        [Display(Name = "Funded")] Funded,
        [Display(Name = "Closed")] Closed
    }

    public class Building_Works
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_ID { get; set; }

        [Required]
        //[ForeignKey("Property_ID")]
        public string Property_ID { get; set; }

        [Required]
        //[ForeignKey("User_ID")]
        public int User_ID { get; set; }

        [Required]
        // [ConcurrencyCheck, MaxLength(3, ErrorMessage = "Project code must be 3 Char long."), MinLength(3)]
        public string Proj_Code { get; set; }
        [Required]
        public string Project_Desc { get; set; }
        [Required]
        public double Proj_budget_Requested { get; set; }
        [Required]
        public double Proj_budget_Approved { get; set; }
        [Required]
        public double Proj_funds_issued { get; set; }
        [Required]
        public double Proj_Act_Cost { get; set; }
        [Required]
        public Status Status { get; set; }

        

        //Collective Navigation Property
        public virtual Property Property { get; set; }

        public virtual Authorisation Authorisation { get; set; }



        // Constructor for Building works
        public Building_Works(int Project_ID, string Property_ID, int User_ID, string Proj_Code, string Project_Desc,
            double Proj_budget_Requested, Status Status)
        {
            this.Project_ID = Project_ID;
            this.Property_ID = Property_ID;
            this.User_ID = User_ID;
            this.Proj_Code = Proj_Code;
            this.Project_Desc = Project_Desc;
            this.Proj_budget_Requested = Proj_budget_Requested;
            Proj_budget_Approved = 0;
            Proj_funds_issued = 0;
            Proj_Act_Cost = 0;
            this.Status = Status;
        }

    }
}