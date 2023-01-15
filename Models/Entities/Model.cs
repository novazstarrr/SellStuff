using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Model
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public short DeviceTypeId { get; set; }

        public DeviceType DeviceType { get; set; }
    }
}
