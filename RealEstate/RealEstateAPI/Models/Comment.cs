﻿using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstateAPI.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? IssueId { get; set; }
        public int? UserId { get; set; }
        public string CommentText { get; set; }
        public DateTime? DatePosted { get; set; }

        public virtual Issue Issue { get; set; }
        public virtual User User { get; set; }
    }
}
