﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoWPF.Models
{
    class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Genre { get; set; }
        public string Production { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public DateTime premiereDate { get; set; }
        public int Length { get; set; }
        public int NumberOfShows { get; set; }
    }
}
