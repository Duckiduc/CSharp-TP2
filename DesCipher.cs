using System;
using System.Windows;
using System.Security.Cryptography;
using System.Text;
using System.IO;
  
namespace CSharp_TP2
{
    public class DesCipher {


        public static string Exec(string input, string type, string key, string iv) 
        {
            string result;
            DES DESalg = DES.Create();

            if(type == "Encrypt") {              
                result = DesCipher.Encrypt(input, Convert.FromBase64String(key), Convert.FromBase64String(iv));
            } else {
                result = DesCipher.Encrypt(input, DESalg.Key, DESalg.IV); // to be changed
            } 
            return result;
        }

        public static string GenerateDesKey() {
            DES DESalg = DES.Create();
            return Convert.ToBase64String(DESalg.Key);
        }

        public static string GenerateDesIV() {
            DES DESalg = DES.Create();
            return Convert.ToBase64String(DESalg.IV);
        }

        public static string Encrypt(string Data,  byte[] Key, byte[] IV) 
        {
            try
            {

                MessageBox.Show(Key.GetType().FullName);
                MessageBox.Show(IV.GetType().FullName);
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the MemoryStream
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    DESalg.CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the
                // MemoryStream that holds the
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the converted encrypted buffer.
                return Convert.ToBase64String(ret);
            }

            catch(CryptographicException e)
            {
                MessageBox.Show("Error : " + e);
                return "Error";
            }
        }

        // public static string Decrypt(string Data,  byte[] Key, byte[] IV)
        // {

        // }


    }
}