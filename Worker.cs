using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targil5a
{
    class Worker
    {


        public long ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
       
        public Worker(long iD, string name, string phone, string role)
        {
            ID = iD;
            Name = name;
            Phone = phone;
            Role = role;
        }
    }

}
