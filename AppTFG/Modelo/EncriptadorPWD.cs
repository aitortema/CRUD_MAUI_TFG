using System.Text;
using System.Security.Cryptography;
using System;

namespace AppTFG.Modelo
{
    public class EncriptadorPWD
    {
        public static string GranitoDeSal()
        {
            var generarNumRan = new RNGCryptoServiceProvider();
            byte[] granito = new byte[16];
            generarNumRan.GetBytes(granito);
            return Convert.ToBase64String(granito);
        }
        public static string HashearPWD(string pwd, string granito2)
        {
            using (var hasheador = SHA256.Create())
            {
                var pwdHasheado = pwd + granito2;
                byte[] hashBytes = hasheador.ComputeHash(Encoding.UTF8.GetBytes(pwdHasheado));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
