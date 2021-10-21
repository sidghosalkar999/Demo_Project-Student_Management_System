using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sid.Intranet.Web.Models
{
    public class Student
    {
            public Student()
            {

            }
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(10)]
            public string FirstName { get; set; }

            [Required]
            [StringLength(10)]
            public string LastName { get; set; }

            public string Course { get; set; }

            [MaxLength(50)]
            public string Address { get; set; }
            [MaxLength(10)]
            public string PhoneNumber { get; set; }
            
           
        }
    }