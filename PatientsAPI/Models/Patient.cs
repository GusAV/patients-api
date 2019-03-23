using System;
using System.ComponentModel.DataAnnotations;

namespace CmdApi.Models
{
    public class Patient
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime birthdate { get; set; }
    }
}
