using Divarcheh.Domain.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divarcheh.Domain.Core.Entities.Advertisement
{
    public class GetAdvertisementDto
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateAt { get; set; }
        public AdvertisementStatusEnum Status { get; set; }
    }
}
