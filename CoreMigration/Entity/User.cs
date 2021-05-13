using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMigration.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TcNo { get; set; }

        #region[Bire-bir İlişki]
        public Student Student { get; set; }
        #endregion
    }
}
