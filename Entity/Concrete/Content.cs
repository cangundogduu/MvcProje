﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }

        public DateTime ContentDate { get; set; }
        public bool ContentStatus { get; set; }


        //Heading Navigation Property
        public int HeadingId { get; set; }
        public virtual Heading  Heading{ get; set; }


        //Writer Navigation Property
        public int? WriterId { get; set; }
        public virtual Writer Writer{ get; set; }

    }
}
