using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_View {
    internal class Camera {
        public string cam_name { get; set; }
        public string cam_ip { get; set; }
        public string cam_user { get; set; }
        public string cam_password { get; set; }
        public Camera(string name, string ip, string user, string password) {
            cam_name = name;
            cam_ip = ip;
            cam_user = user;
            cam_password = password;
        }

    }
}
