using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_View {
    internal class Menu {

        public Menu() {
           
        }

        public int Menuview( string[] option, int selection) {
            while (true) {
                Console.Clear();
                Console.WriteLine("=== MENU ===\n");
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



    }
}
