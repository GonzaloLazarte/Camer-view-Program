using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Camera_View {
    internal class CameraManager {
        public CameraManager() {

        }

        //metodo encargado de mostrar las camaras añadidas en el archivo de texto
        public void MenuView(string _cam_file) { // metodo encargado de mostrar las camaras añadidas en el archivo de texto
            Console.Clear();
            string[] lines = File.ReadAllLines(_cam_file);

            if (lines.Length == 0) {
                Console.WriteLine("NO EXISTEN CAMARAS AÑADIDAS");
            }
            foreach (string line in lines) {
                string[] datos = line.Split('/');
                Console.WriteLine("__________________________________");
                Console.WriteLine(" " + datos[0] + " - " + datos[1]);
            }
            MenuOption(lines, _cam_file);
        }

        // metodo encargado la funcionalidad de seleccionar opciones del menu de camaras añadidas y la opcion de volver 
        private void MenuOption(string[] _lines, string _cam_file) {
            Menu menuOption = new Menu();
            string decOption = string.Empty, title = "Opciones de Cámara";
            string[] option = menuOption.decListOption(_cam_file);
            int selection = 0, comparation = menuOption.Menuview(option, selection, title);
            decOption = menuOption.decOption(option, comparation);
            switch (decOption) {
                case "Todas":
                    watchAllCams(_cam_file);
                    break;
                case "Salir":
                    return;
                default:
                    watchCams(decOption, _cam_file);
                    return;
            }
        }

        //metodo encargado de ejecutar el comando para ver la camara seleccionada
        private void watchCams(string option, string _cam_file) {
            ConstructCommand  newLine = new ConstructCommand();
            string[] lineas = File.ReadAllLines(_cam_file);
            foreach (string linea in lineas) {
                string[] datos = linea.Split('/');
                if (datos[0] == option) {
                    string protocol = newLine.createCommand(datos[1], datos[2], datos[3]);
                    newLine.Ejecutar(protocol);
                }
            }
        }
        // metodo encargado de ejecutar el comando para ver todas las camaras añadidas
        private void watchAllCams(string _cam_file) {
            ConstructCommand newLine = new ConstructCommand();
            string[] lineas = File.ReadAllLines(_cam_file);
            foreach (string linea in lineas) {
                string[] datos = linea.Split('/');
                string protocol = newLine.createCommand(datos[1], datos[2], datos[3]);
                newLine.Ejecutar(protocol);
            }
        }

        //metodos encargado de añadir nuevas camaras al archivo de texto
        public void NewCamera(string _cam_file) {
            string title = "Opciones de Añadir Camara", decOption = string.Empty;
            string[] option = { "Camaras Añadidas", "Añadir nueva Camara", "Salir" };
            Menu menuOption = new Menu();
            int selection = 0, comparation = menuOption.Menuview(option, selection, title);
            decOption = menuOption.decOption(option, comparation);
            switch (decOption) {
                case "Camaras Añadidas":
                    MenuView(_cam_file);
                    NewCamera(_cam_file);
                    break;
                case "Añadir nueva Camara":
                    addCamera(_cam_file);
                    NewCamera(_cam_file);
                    break;
                case "Salir":
                    return;
            }
        }
        public void addCamera(string _cam_file) {
            string name,user,password, ip;
            Console.WriteLine("==========INGRESE LOS DATOS A AÑADIR DE LA CAMARA===========");
            Console.WriteLine("");
            Console.WriteLine("Ingrese el nombre de la camara: ");
            name = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección IP de la camara: ");
            ip = Console.ReadLine();    
            Console.WriteLine("Ingrese el Nombre de usuario de la camara: ");
            user = Console.ReadLine();
            Console.WriteLine("Ingrese la Contraseña de la camara: ");
            password = Console.ReadLine();

            Camera NewCamera = new Camera(name, ip, user, password);

            StreamWriter sw = new StreamWriter(_cam_file, true);

            sw.WriteLine(NewCamera.cam_name + "/" + NewCamera.cam_ip + "/" + NewCamera.cam_user + "/" + NewCamera.cam_password); //escribe en el archivo los datos ingresados
            sw.Close();

            Console.WriteLine();
            Console.WriteLine("Cámara añadida correctamente.");
            Console.ReadKey();
        }

        //metodos encargado de quitar camaras del archivo de texto
        public void removeCamera(string _cam_file) {
            string title = "Opciones de Quitar Camara", decOption = string.Empty;
            string[] option = { "Quitar camara", "Quitar todas", "Salir" };
            Menu menuOption = new Menu();
            int selection = 0, comparation = menuOption.Menuview(option, selection, title);
            decOption = menuOption.decOption(option, comparation);
            switch (decOption) {
                case "Quitar camara":
                    quitCamera(_cam_file, title);
                    break;
                case "Quitar todas":
                    QuitAllCameras(_cam_file);
                    break;
                case "Salir":
                    return;
            }
        }
        private void quitCamera(string _cam_file, string title) {
            Menu menuOption = new Menu();
            string[] option = menuOption.decListOption(_cam_file);
            int selection = 0, comparation = menuOption.Menuview(option, selection, title);
            string decOption = menuOption.decOption(option, comparation);
            string[] lineas = File.ReadAllLines(_cam_file);
            List<string> nuevasLineas = new List<string>();
            foreach (string linea in lineas) {
                string[] datos = linea.Split('/');
                if (datos[0] != decOption) {
                    nuevasLineas.Add(linea);
                }
            }
            File.WriteAllLines(_cam_file, nuevasLineas);
        }
        public void QuitAllCameras(string _cam_file) {
            File.WriteAllText(_cam_file, string.Empty);
        }
        

    }
}
