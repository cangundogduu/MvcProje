﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        public bool HeadingStatus { get; set; }



        //Category Navigation Property
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        //Content Navigation Property
        public ICollection<Content> Contents { get; set; }


        //Writer Navigation Property
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}

