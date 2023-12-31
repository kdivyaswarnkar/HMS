﻿using HMS.Entities;
using HMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Areas.Dashboard.ViewModels
{
    public class AccomodationTypesListingModel
    {
        public IEnumerable<AccomodationType> AccomodationTypes { get; set; }
        public int? AccomodationTypeID { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }

    public class AccomodationTypeActionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}