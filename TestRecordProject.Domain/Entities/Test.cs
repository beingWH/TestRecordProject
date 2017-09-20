using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRecordProject.Domain.Entities
{
    public class Test
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
