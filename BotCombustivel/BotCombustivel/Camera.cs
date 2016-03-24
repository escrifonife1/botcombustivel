using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCombustivel
{
    public class Camera
    {
        private string _name { get; set;}
        private string _url { get; set; }
        private Array _coordinates { get; set; }
        private string _address { get; set; }

        public Camera(string name, string url, string address)
        {
            _name = name;
            _url = url;
            _address = address;
        }

        
    }
}
