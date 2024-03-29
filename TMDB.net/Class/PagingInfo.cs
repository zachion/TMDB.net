﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDB.net.Class
{
    //I am also using the PagingInfo class to create the paging links for the View.
    public class PagingInfo
    {
        public int totalItems { get; set; }
        public int itemsPerPage { get; set; }
        public int currentPage { get; set; }
        public int totalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)totalItems / itemsPerPage);
            }
        }
    }
}