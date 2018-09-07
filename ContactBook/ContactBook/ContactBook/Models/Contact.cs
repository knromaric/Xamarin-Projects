﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBook.Models
{
    public class Contact
    { 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }

        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}