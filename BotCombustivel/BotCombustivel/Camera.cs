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
        private string _urlCamera { get; set; }
        private Array _coordinates { get; set; }
        private string _address { get; set; }
        private string _queryString { get; set; }

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
