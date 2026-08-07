using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_View {
    internal class Actions {
        private readonly string cam_file = Path.Combine("Datacamera", "cams.txt");
        public Actions() {
            InitDoc();
        }
        private void InitDoc() {
            Directory.CreateDirectory("DataCamera");             //iniciamos el directorio "Data"
            if (!File.Exists(cam_file)) {               //verificamos si existe el archivo de texto, si no existe lo creamos
                File.Create(cam_file).Close();
            }
        }
        public void seleccMenu(string actionSelected, CameraManager _cameras) {     //metodo que compara la opcion seleccionada 
            switch (actionSelected) {
                case "Ver Camaras":
                    Console.WriteLine("Ver Camaras");
                    _cameras.MenuView(cam_file);
                    break;
                case "Añadir Camaras":
                    Console.WriteLine("Añadir Camaras");
                    _cameras.NewCamera(cam_file);
                    break;
                case "Quitar Camaras":
                    Console.WriteLine("Quitar Camaras");
                    _cameras.removeCamera(cam_file);
                    break;
                case "Salir":
                    return;
            }
        }

    }
}
