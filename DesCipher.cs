using System;
using System.Windows;
using System.Security.Cryptography;
using System.Text;
using System.IO;
  
namespace CSharp_TP2
{
    public class DesCipher {

        private static DES DesGen = DES.Create();
        private static byte[] IV = DesGen.IV;
 
        public static string Exec(string input, string type, string key) 
        {
            string result;
            DES DESalg = DES.Create();

            if(type == "Encrypt") {             
                result = new ASCIIEncoding().GetString(DesCipher.Encrypt(input, new ASCIIEncoding().GetBytes(key), IV));
            } else {
                result = DesCipher.Decrypt(new ASCIIEncoding().GetBytes(input), new ASCIIEncoding().GetBytes(key), IV);
            } 
            return result;
        }

        public static string GenerateDesKey() {
            DES DESalg = DES.Create();
            return new ASCIIEncoding().GetString(DESalg.Key);
        }

        public static byte[] Encrypt(string Data,  byte[] Key, byte[] IV) 
        {
            try
            {
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
                // return new ASCIIEncoding().GetString(ret);
                return ret;
            }

            catch(Exception e)
            {
                MessageBox.Show("Error : " + e);
                return null;
            }
        }

        public static string Decrypt(byte[] Data,  byte[] Key, byte[] IV)
        {
            try
            {
                // Create a new MemoryStream using the passed
                // array of encrypted data.
                // byte[] newData = new ASCIIEncoding().GetBytes(nData);
                MemoryStream msDecrypt = new MemoryStream(Data);

                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the MemoryStream
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    DESalg.CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                // return new ASCIIEncoding().GetString(fromEncrypt);
                 return new ASCIIEncoding().GetString(fromEncrypt);
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e);
                return "Error";
            }
        }
    }
}