﻿namespace school_manager.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
