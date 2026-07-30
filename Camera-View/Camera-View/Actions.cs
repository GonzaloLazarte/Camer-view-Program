using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_View {
    internal class Actions {

        public Actions() {
        }
        public void seleccMenu(string actionSelected) {
            switch (actionSelected) {
                case "Ver Camaras":
                    Console.WriteLine("Ver Camaras");
                    break;
                case "Añadir Camaras":
                    Console.WriteLine("Añadir Camaras");
                    break;
                case "Quitar Camaras":
                    Console.WriteLine("Quitar Camaras");
                    break;

            }
        }

    }
}
