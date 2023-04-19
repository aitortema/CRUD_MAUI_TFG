using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTFG.Modelo
{
    public class CifradorTXT
    {
        // Morse
        public static string CifrarMorse(string mensaje)
        {
            string mensajeCifrado = "";
            string[] alfabetoMorse = new string[36] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "-----" };
            string[] abc123 = new string[36] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            for (int i = 0; i < mensaje.Length; i++)
            {
                for (int j = 0; j < abc123.Length; j++)
                {
                    if (mensaje[i].ToString().ToUpper() == abc123[j])
                    {
                        mensajeCifrado += alfabetoMorse[j] + " ";
                    }
                }
            }
            return mensajeCifrado;
        }

        // Base64
        public static string CifrarBase64(string mensaje)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(mensaje);
            string mensajeCifrado = Convert.ToBase64String(bytes);
            return mensajeCifrado;
        }

        // Binario
        public static string CifrarBinario(string mensaje)
        {
            string mensajeCifrado = "";
            for (int i = 0; i < mensaje.Length; i++)
            {
                mensajeCifrado += Convert.ToString(mensaje[i], 2);
            }
            return mensajeCifrado;
        }

        // Cesar
        public static string CifrarCesar(string mensaje, int cifradoEscogido)
        {
            string mensajeCifrado = "";
            int indiceROT;
            int indiceASCII;

            foreach (char letraMensaje in mensaje)
            { // Total letras y números = 59
                if (letraMensaje >= 48 && letraMensaje <= 57) // Números (caracteres ASCII 48-57)
                {
                    indiceASCII = letraMensaje - 48;
                    indiceROT = (indiceASCII + cifradoEscogido) % 10;
                    char letraCifrada = (char)(indiceROT + 48);
                    mensajeCifrado += letraCifrada;
                }
                else if (letraMensaje >= 65 && letraMensaje <= 90) // Letras mayúsculas (caracteres ASCII 65-90)
                {
                    indiceASCII = letraMensaje - 65;
                    indiceROT = (indiceASCII + cifradoEscogido) % 26;
                    char letraCifrada = (char)(indiceROT + 65);
                    mensajeCifrado += letraCifrada;
                }
                else if (letraMensaje >= 97 && letraMensaje <= 122) // Letras minúsculas (caracteres ASCII 97-122)
                {
                    indiceASCII = letraMensaje - 97;
                    indiceROT = (indiceASCII + cifradoEscogido) % 26;
                    char letraCifrada = (char)(indiceROT + 97);
                    mensajeCifrado += letraCifrada;
                }
                else
                {
                    mensajeCifrado += letraMensaje;
                }
            }

            return mensajeCifrado;
        }

        // Vigenere
        public static string CifrarVigenere(string mensaje, string clave)
        {
            string mensajeCifrado = "";
            int claveIndice = 0;
            int claveLength = clave.Length;

            foreach (char letraMensaje in mensaje)
            {
                if (letraMensaje >= 65 && letraMensaje <= 90) // Mayúsculas (caracteres ASCII 65-90)
                {
                    char letraClave = clave[claveIndice % claveLength].ToString().ToUpper()[0];
                    int indiceCifrado = (letraMensaje + letraClave) % 26;
                    mensajeCifrado += (char)(indiceCifrado + 65);
                    claveIndice++;
                }
                else if (letraMensaje >= 97 && letraMensaje <= 122) // Minúsculas (caracteres ASCII 97-122)
                {
                    char letraClave = clave[claveIndice % claveLength].ToString().ToLower()[0];
                    int indiceCifrado = (letraMensaje + letraClave) % 26;
                    mensajeCifrado += (char)(indiceCifrado + 97);
                    claveIndice++;
                }
                else
                {
                    mensajeCifrado += letraMensaje;
                }
            }

            return mensajeCifrado;
        }

    }
}
