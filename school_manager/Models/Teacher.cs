﻿using System.Diagnostics;
using System.Security.Claims;

namespace school_manager.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Manager Manager { get; set; }
        public List<Class> Classes { get; set; }
        public List<Grade> Grades { get; set; }
        public Salary Salary { get; set; }
        public List<ClassSchedule> ClassSchedules { get; set; }
    }
}
