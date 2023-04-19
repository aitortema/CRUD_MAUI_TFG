using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTFG.Modelo
{
    public class DescifradorTXT
    {
        // Morse
        public static string DescifrarMorse(string mensajeCifrado)
        {
            string mensajeDescifrado = "";
            string[] alfabetoMorse = new string[36] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "-----" };
            string[] abc123 = new string[36] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            string[] palabrasCifradas = mensajeCifrado.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string palabraCifrada in palabrasCifradas)
            {
                for (int j = 0; j < alfabetoMorse.Length; j++)
                {
                    if (palabraCifrada == alfabetoMorse[j])
                    {
                        mensajeDescifrado += abc123[j];
                    }
                }
            }

            return mensajeDescifrado;
        }

        // Base64
        public static string DescifrarBase64(string mensajeCifrado)
        {
            byte[] bytes = Convert.FromBase64String(mensajeCifrado);
            string mensajeDescifrado = Encoding.UTF8.GetString(bytes);
            return mensajeDescifrado;
        }

        // Binario
        public static string DescifrarBinario(string mensajeCifrado)
        {
            string mensajeDescifrado = "";
            for (int i = 0; i < mensajeCifrado.Length; i += 8)
            {
                string ochoBits = mensajeCifrado.Substring(i, 8);
                int letraASCII = Convert.ToInt32(ochoBits, 2);
                mensajeDescifrado += (char)letraASCII;
            }
            return mensajeDescifrado;
        }

        // Cesar
        public static string DescifrarCesar(string mensajeCifrado, int cifradoEscogido)
        {
            string mensajeDescifrado = "";
            int indiceROT;
            int indiceASCII;

            foreach (char letraCifrada in mensajeCifrado)
            { // Total letras y números = 59
                if (letraCifrada >= 48 && letraCifrada <= 57) // Números (caracteres ASCII 48-57)
                {
                    indiceASCII = letraCifrada - 48;
                    indiceROT = (indiceASCII - cifradoEscogido + 10) % 10;
                    char letraDescifrada = (char)(indiceROT + 48);
                    mensajeDescifrado += letraDescifrada;
                }
                else if (letraCifrada >= 65 && letraCifrada <= 90) // Mayúsculas (caracteres ASCII 65-90)
                {
                    indiceASCII = letraCifrada - 65;
                    indiceROT = (indiceASCII - cifradoEscogido + 26) % 26;
                    char letraDescifrada = (char)(indiceROT + 65);
                    mensajeDescifrado += letraDescifrada;
                }
                else if (letraCifrada >= 97 && letraCifrada <= 122) // Minúsculas (caracteres ASCII 97-122)
                {
                    indiceASCII = letraCifrada - 97;
                    indiceROT = (indiceASCII - cifradoEscogido + 26) % 26;
                    char letraDescifrada = (char)(indiceROT + 97);
                    mensajeDescifrado += letraDescifrada;
                }
                else // Caracteres especiales
                {
                    mensajeDescifrado += letraCifrada;
                }
            }
            return mensajeDescifrado;
        }

        // Vigenere
        public static string DescifrarVigenere(string mensajeCifrado, string clave)
        {
            string mensajeDescifrado = "";
            int claveIndice = 0;
            int longitudClave = clave.Length;

            foreach (char letraCifrada in mensajeCifrado)
            {
                if (letraCifrada >= 65 && letraCifrada <= 90) // Mayúsculas (caracteres ASCII 65-90)
                {
                    char letraClave = clave[claveIndice % longitudClave].ToString().ToUpper()[0];
                    int indiceDescifrado = (letraCifrada - letraClave + 26) % 26;
                    mensajeDescifrado += (char)(indiceDescifrado + 65);
                    claveIndice++;
                }
                else if (letraCifrada >= 97 && letraCifrada <= 122) // Minúsculas (caracteres ASCII 97-122)
                {
                    char letraClave = clave[claveIndice % longitudClave].ToString().ToLower()[0];
                    int indiceDescifrado = (letraCifrada - letraClave + 26) % 26;
                    mensajeDescifrado += (char)(indiceDescifrado + 97);
                    claveIndice++;
                }
                else // Caracteres especiales que no se cifran
                {
                    mensajeDescifrado += letraCifrada;
                }
            }

            return mensajeDescifrado;
        }

    }
}
