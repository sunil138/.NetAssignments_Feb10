using System;
using System.Collections.Generic;

namespace LibraryDetailsWithMVC_Feb10.Models
{
    public partial class TBookDetail
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int? BookPageCount { get; set; }
        public int? AuthorId { get; set; }
    }
}
