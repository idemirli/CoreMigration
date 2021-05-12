using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMigration.Entity
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }  //surname

        public string TelNo { get; set; } //telno

        public string address { get; set; } //yeni eklendi
    }
}
