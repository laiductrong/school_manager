﻿namespace school_manager.DTOs.TeacherDTO
{
    public class AddTeacher
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int SubjectId { get; set; }
    }
}