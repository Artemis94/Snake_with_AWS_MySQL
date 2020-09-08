using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Snake_with_AWS_MySQL {

    /// <summary>
    /// The class used for password encryption.
    /// </summary>
    static class PasswordHash 
    {
        private const int saltSize = 24;
        private const int hashSize = 20;
        private const int Iterations = 1200;

        /// <summary>
        /// Encrypts the input string. 
        /// </summary>
        /// <param name="pwd">A string containing a password.</param>
        /// <returns>A string containing the salt and the hashed password.</returns>
        public static string Hash(string pwd) 
        {
            var crypto = new RNGCryptoServiceProvider();
            byte[] salt = new byte[saltSize];
            crypto.GetBytes(salt);
            var hash = GenerateKey(pwd, salt);
            return Convert.ToBase64String(salt) + ":" +Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Decides whether or not the encrypted and the unencrypted passwords received are macthing.
        /// </summary>
        /// <param name="password">A string, the encrypted password from the database.</param>
        /// <param name="input_password">A string, the password entered by the user.</param>
        /// <returns>A bool value representing whether or not the two passwords are the same. </returns>
        public static bool Validate(string password, string input_password ) {

            string[] s = password.Split(':');

            byte[] salt = Convert.FromBase64String(s[0]);
            byte[] pwd = Convert.FromBase64String(s[1]);
            byte[] input_pwd= GenerateKey(input_password, salt);

            var diff = (uint)pwd.Length ^ (uint)input_pwd.Length;

            for (int i = 0; i < pwd.Length && i < input_pwd.Length; i++) 
            {
                diff |= (uint)(pwd[i] ^ input_pwd[i]);
            }

            return diff == 0;
        }

        private static byte[] GenerateKey(string pwd, byte[] salt) 
        {
            var pbkdf2 = new Rfc2898DeriveBytes(pwd, salt);
            pbkdf2.IterationCount = Iterations;

            return pbkdf2.GetBytes(hashSize);
        }
    }




}

