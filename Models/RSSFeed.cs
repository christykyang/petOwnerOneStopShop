﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace petOwnerOneStopShop.Models
{
    public class RSSFeed
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string PubDate { get; set; }
        //[ForeignKey("NewsFeed")]
        //public int? NewsFeedId { get; set; }
        //public NewsFeed NewsFeed { get; set; }
    }
}