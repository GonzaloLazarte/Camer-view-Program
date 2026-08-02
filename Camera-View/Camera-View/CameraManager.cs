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
                string[] datos = line.Split('|');
                Console.WriteLine("==================================");
                Console.WriteLine("ID: " + datos[0]);
                Console.WriteLine("Usuario: " + datos[1]);
                Console.WriteLine("Hora Inicio: " + datos[2]);
                Console.WriteLine("Precio/Hora: $" + datos[3]);
            }
            MenuOption(lines, _cam_file);
        }
        private void MenuOption(string[] _lines, string _cam_file) {
            List<string> option = new List<string>();
            string[] lineas = File.ReadAllLines(_cam_file);
            foreach (string linea in lineas) {
                if (string.IsNullOrWhiteSpace(linea))
                    continue;
                string[] datos = linea.Split('|');
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
        private void validateOption(string _option) {
            switch(_option){
                case "Ver Todas":
                    // INSTRUCCIONES DE MOSTRAR TODAS LAS CAMARAS
                    break;
                default:
                    selectCamera();
                    break;
            }
        }
        private void selectCamera() {

        }

    }
}
