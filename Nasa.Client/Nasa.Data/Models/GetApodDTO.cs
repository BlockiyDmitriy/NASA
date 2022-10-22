﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Data.Models
{
    public class GetApodDTO
    {
        public string copyright { get; set; }
        public string date { get; set; }
        public string hdurl { get; set; }
        public string media_type { get; set; }
        public string service_version { get; set; }
        public string title { get; set; }
        public string url { get; set; }
    }
}
