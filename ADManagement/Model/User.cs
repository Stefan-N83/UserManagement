using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADManagement.Model
{
    public class User
    {
        public string Cn { get; set; }
        public string Mail { get; set; }
        public Group MemberOf { get; set; } = new Group();


    }
}
