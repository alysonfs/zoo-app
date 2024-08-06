using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooApp.WebAPI.Domain
{
    public class Zoo
    {
        public string Name { get; set; }

        public List<Animal>? Animals { get; set; }
        
        public Zoo(string Name)
        {
            this.Name = Name;
        }
    }
}