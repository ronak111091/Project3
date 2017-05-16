using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Models
{
    public class Cast
    {
        public string cast_id { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        private string _profile_path;
        public string profile_path { get
            {
                return $"{Constants.GetImageBaseURLForProfile()}{_profile_path}";
            } set
            {
                _profile_path = value;
            }
        }
    }
}
