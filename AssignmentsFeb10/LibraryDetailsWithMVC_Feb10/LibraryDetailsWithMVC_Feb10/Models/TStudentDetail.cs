using System;
using System.Collections.Generic;

namespace LibraryDetailsWithMVC_Feb10.Models
{
    public partial class TStudentDetail
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
    }
}
