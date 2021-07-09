using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhamacySystemRestructure.Model
{
    public class Medicine
    {

        [Key]
        public int MId { get; set; }


        public String Name { get; set; }


        public String CompanyName { get; set; }


        public String Disease { get; set; }


        public double Amount { get; set; }

    }
}
