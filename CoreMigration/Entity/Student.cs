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

        public string Surname { get; set; }  

        public string TelNo { get; set; } 

        public string address { get; set; }

        #region [Bire-çok İlişki]
        public Department Department { get; set; }  //navigation Property

        public int DepartmentId { get; set; } //foreignkey - bire-çok ilişki
        #endregion


        #region [Bire-bir İlişki]

        public User User { get; set; }

        public int UserId { get; set; } //bire-bir ilişki

        #endregion
    }
}
