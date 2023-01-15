using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class DeviceType
    {
        //max value of 250 id's
        public byte Id { get; set; }

        public string Name { get; set; }

        public short BrandId { get; set; }

        public Brand Brand { get; set; }
    }
}
