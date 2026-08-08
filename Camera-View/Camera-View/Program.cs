using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_View {
    internal class Program {
        static Actions menuAction = new Actions();
        static CameraManager cameras = new CameraManager();
        static Menu menu = new Menu();
        static void Main(string[] args) {
            
            string[] option = {"Ver Camaras", "Añadir Camaras", "Quitar Camaras", "Salir"};
            int selection = 0, comparation = 0;
            string title = "Menu principal", selected = string.Empty;
            while (true) {                  //bucle encargado de mostrar el menu y recibir la seleccion del usuario
                comparation = menu.Menuview(option, selection, title);
                selected = menu.decOption(option, comparation);
                string result = menuAction.seleccMenu(selected, cameras);
                if (result == "Salir") {
                    return;
                }
            }

            //aqui llamamos al metodo para la salida del programa
        }
    }
}
