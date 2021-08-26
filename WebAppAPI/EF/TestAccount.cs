using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppAPI.EF
{
    public partial class TestAccount
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
