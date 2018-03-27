using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
    }
}
