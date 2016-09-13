using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Intermoda.Common
{
    public class Tools
    {
        // Encriptar - Desencriptar

        public static string Encriptar(string texto)
        {
            try
            {
                const string key = "PepeRevolutionIntermoda";

                byte[] arrayToCipher = Encoding.UTF32.GetBytes(texto);

                var hashMd5 = new MD5CryptoServiceProvider();
                var keyArray = hashMd5.ComputeHash(Encoding.UTF32.GetBytes(key));
                hashMd5.Clear();

                var tDes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };


                var cTransform = tDes.CreateEncryptor();

                var arrayResult = cTransform.TransformFinalBlock(arrayToCipher, 0, arrayToCipher.Length);

                tDes.Clear();

                texto = Convert.ToBase64String(arrayResult, 0, arrayResult.Length);

                return texto;
            }
            catch (Exception exception)
            {
                throw new Exception("Tools / Encriptar", exception);
            }
        }

        public static string Desencriptar(string texto)
        {
            try
            {
                const string key = "PepeRevolutionIntermoda";
                var arrayToDecypher = Convert.FromBase64String(texto);

                //algoritmo MD5
                var hashmd5 = new MD5CryptoServiceProvider();

                var keyArray = hashmd5.ComputeHash(Encoding.UTF32.GetBytes(key));

                hashmd5.Clear();

                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                var cTransform = tdes.CreateDecryptor();

                var resultArray = cTransform.TransformFinalBlock(arrayToDecypher, 0, arrayToDecypher.Length);

                tdes.Clear();
                texto = Encoding.UTF32.GetString(resultArray);
                return texto;
            }
            catch (Exception exception)
            {
                throw new Exception("Tools / Desencriptar", exception);
            }
        }

        public static string Encrypt(string entrada)
        {
            try
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(entrada);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);

                return System.Text.Encoding.ASCII.GetString(data);
            }
            catch (Exception exception)
            {
                throw new Exception("Tools / Encrypt", exception);
            }
        }

        [SuppressMessage("ReSharper", "RedundantTypeArgumentsOfMethod")]
        public static void PropertyMap<T, TU>(T source, TU destination)
            where T : class, new()
            where TU : class
        {
            var sourceProperties = source.GetType().GetProperties().ToList<PropertyInfo>();
            var destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty.Name);

                if (destinationProperty != null)
                {
                    try
                    {
                        destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                    }
                    catch (ArgumentException)
                    {

                    }
                }
            }
        }

        public static string LoremIpsun()
        {
            var lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod " +
                        "tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, " +
                        "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu " +
                        "fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa " +
                        "qui officia deserunt mollit anim id est laborum.";
            return lorem;
        }

        public static string ExceptionMessage(Exception exception)
        {
            try
            {
                return ExceptionToString(exception);
            }
            catch (Exception ex)
            {
                throw new Exception("Tools / ExceptionToString", ex);
            }
        }


        // Files

        public static byte[] FileToByteArray(string filename)
        {
            try
            {
                var bytes = File.ReadAllBytes(filename);
                return bytes;
            }
            catch (Exception exception)
            {
                throw new Exception("Tools / FileToByteArray", exception);
            }
        }

        private static string ExceptionToString(Exception exception)
        {
            try
            {
                var message = exception.Message;

                if (exception.InnerException != null)
                    message = message + "\r\n" + ExceptionToString(exception.InnerException);

                return message;
            }
            catch (Exception ex)
            {
                throw new Exception("Tools / ExceptionToString", ex);
            }
        }
    }
}