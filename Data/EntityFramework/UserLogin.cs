using System;
using System.Collections.Generic;

namespace Data.EntityFramework
{
    public partial class UserLogin
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActice { get; set; }
        public TimeSpan? ModifiedOn { get; set; }
    }
}
