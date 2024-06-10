﻿namespace school_manager.DTOs.StudentDTO
{
    public class UpdateStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
    }
}
