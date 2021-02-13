using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RideShare.Entity
{
    public class BaseEntity
    {
        [Key]
        public int id { get; set; }
        public long createTime { get; set; }
        public long updateTime { get; set; }
    }
}
