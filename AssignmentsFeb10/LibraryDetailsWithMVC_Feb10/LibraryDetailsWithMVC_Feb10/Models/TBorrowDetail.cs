using System;
using System.Collections.Generic;

namespace LibraryDetailsWithMVC_Feb10.Models
{
    public partial class TBorrowDetail
    {
        public int BorrowId { get; set; }
        public DateTime? Takendate { get; set; }
        public DateTime? Broughtdate { get; set; }
        public int? StudentId { get; set; }
        public int? BookId { get; set; }
    }
}
