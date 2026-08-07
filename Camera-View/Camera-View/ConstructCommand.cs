using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_View {
    internal class ConstructCommand {
        public ConstructCommand() { 
        }
        public string createCommand(string ip, string user, string password) {
            string protocol = $"rtsp://{user}:{password}@{ip}:554/stream1"; //ernesto123:ernesto123@10.0.0.43:554/stream1
            return protocol;
        }
        public void Ejecutar(string argumentos) {
            ProcessStartInfo info = new ProcessStartInfo();
            
            info.FileName = @"..\..\toolls\ffmpeg\ffplay.exe";
            info.Arguments = argumentos;
            
            Process.Start(info);
        }

    }
}
