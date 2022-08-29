using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;//AGREGAR 

namespace Pc1Laboratorio.Models
{
    public class Registro
    {
        [Required]
        [Display(Name ="First Name",Prompt ="Enter the first Name of the student to be registered")]
        public string? name {get;set;}

        [Required]
        [Display(Name ="Last Name",Prompt ="Enter the Last Name of the student")]
        public string? LastName {get;set;}

        [Required]
        [Display(Name ="Course")]
        public Course?  CourseName {get;set;}
        public List<Course>? Courses {get;set;} 
    
    }

    public class Course
    {
        public string? id {get;set;}
        public string? type {get;set;}

        public bool active {get;set;}
    }

}