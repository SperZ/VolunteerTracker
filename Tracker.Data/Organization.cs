﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class Organization
    {
        public Organization()
        {
            this.OrganizationPrograms = new HashSet<OrganizationProgram>();
            this.Volunteers = new HashSet<Volunteer>();
        }
        [Key]
        public int OrganizationId { get; set; }
        [Required]
        public string OrganizationName { get; set; }
        [MaxLength(500)]
        public string OrganizatinonDescription { get; set; }
        public string Address { get; set; }
        [Required]
        public string WebUrl { get; set; }
        [Required]
        public virtual ICollection<OrganizationProgram> OrganizationPrograms { get; set; }
        [Required]
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
