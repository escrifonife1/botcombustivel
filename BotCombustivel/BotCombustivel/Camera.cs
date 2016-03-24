using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCombustivel
{
    public class Camera
    {
        public string _name { get; set;}
        public string _urlCamera { get; set; }
        public Array _coordinates { get; set; }
        public string _address { get; set; }
        public string _queryString { get; set; }

        public Camera(string name, string address, string queryString, string urlCamera)
        {
            _name = name;
            _urlCamera = urlCamera;
            _address = address;
            _queryString = queryString;
        }

        public Camera()
        {
        }
    }
}
