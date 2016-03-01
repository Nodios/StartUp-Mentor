using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartUpMentor.UI.Models.User
{
    public class UserFieldData
    {
        public Guid FieldId { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
}