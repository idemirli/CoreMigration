using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMigration.Entity
{
    public class Lesson
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Student> Student { get; set; }

    }
}
