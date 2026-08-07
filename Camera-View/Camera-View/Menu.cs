using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Camera_View {
    internal class Menu {

        public Menu() {  
        }
        
        
        //muestra el menu y devuelve un valor string que seria la seleccion del usuario 
        public int Menuview( string[] option, int selection, string title) {
            while (true) {
                Console.Clear();
                Console.WriteLine($"=== {title} ===\n");
                for (int i = 0; i < option.Length; i++) {
                    if (i == selection) {
                        Console.WriteLine($"<< {option[i]} >>");
                    }
                    else {
                        Console.WriteLine($"   {option[i]}");
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("===========\n");
                ConsoleKey tecla = Console.ReadKey(true).Key;
                switch (tecla) {
                    case ConsoleKey.UpArrow:
                        if (selection > 0) {
                            selection--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selection < option.Length - 1) {
                            selection++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine($"Elegiste: {option[selection]}");

                        if (option[selection] == "Salir") {
                            return selection;
                        }
                        else {
                            return selection;
                        }
                       

                }
            }
        }

        //metodo que recibe una opcion y la decodifica en base a su posicion del arreglo, devuelve un string con la opcion seleccionada
        public string decOption(string[] option, int comparation) {
            string decOption = string.Empty;
            for (int i = 0; i <= option.Length; i++) {
                if (i == comparation) {
                    decOption = option[i];
                    break;
                }
            }
            return decOption;
        }
        
        //metodo que recibe un archivo de texto cuenta sus lineas y devuelve un arreglo de string con las opciones de camaras del archivo 
        public string[] decListOption(string _cam_file) {
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
            string[] optionConverted = option.ToArray();
            return optionConverted;
        }
    
    
    }
}
