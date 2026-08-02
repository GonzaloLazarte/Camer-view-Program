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
        public void MenuView(string _cam_file) {
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
        private void MenuOption(string[] _lines, string _cam_file) {
            List<string> option = new List<string>();
            string[] lineas = File.ReadAllLines(_cam_file);
            foreach (string linea in lineas) {
                if (string.IsNullOrWhiteSpace(linea))
                    continue;
                string[] datos = linea.Split('/');
                option.Add(datos[0]);
            }
            if (option.Count == 0) {
                option.Add("Volver");
            }
            else {
                option.Add("Ver Todas");
                option.Add("Volver");
            }
            int selection = 0;
            while (true) {
                Console.Clear();
                Console.WriteLine("=== MENU ===\n");

                for (int i = 0; i < option.Count; i++) {
                    if (i == selection)
                        Console.WriteLine($"<< {option[i]} >>");
                    else
                        Console.WriteLine($"   {option[i]}");
                }
                Console.WriteLine();
                Console.WriteLine("===========");
                ConsoleKey tecla = Console.ReadKey(true).Key;
                switch (tecla) {
                    case ConsoleKey.UpArrow:
                        if (selection > 0)
                            selection--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selection < option.Count - 1)
                            selection++;
                        break;
                    case ConsoleKey.Enter:

                        if (option[selection] == "Volver")
                            return;
                        Console.Clear();
                        Console.WriteLine($"Elegiste: {option[selection]}");
                        validateOption(option[selection]);
                        return;
                }
            }
        }
        public void validateOption(string option) {

        }
        public void NewCamera(string _cam_file) {
            string[] option = { "Camaras Añadidas", "Añadir nueva Camara", "Salir" };
            Menu menuOption = new Menu();
            int selection = 0, comparation = menuOption.Menuview(option, selection);
            string decOption = menuOption.decOption(option, comparation);
            switch (decOption) {
                case "Camaras Añadidas":
                    MenuView(_cam_file);
                    NewCamera(_cam_file);
                    break;
                case "Añadir nueva Camara":
                    addCamera();
                    break;
                case "Salir":
                    return;
            }
        }
        public void addCamera() {
            Console.WriteLine("==========INGRESE LOS DATOS A AÑADIR DE LA CAMARA===========");

        }


        private void validaciones() {

        }
    }
}
