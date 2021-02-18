using System;
using System.Text;
using System.Security.Cryptography;

namespace sha256Generate
{
    class Program
    {
        static void Main(string[] args)
        {
            //set strings
            string str1 = "aad28e85f31ae79339b49d114d7c1811d2c667681a1904ebbc326842a0a81985";
            string str2 = "b963d3426088217357b146d5600817c54f93c2ea1a23126988e36460015ffc0e";
            string str3 = "82498f4da1e1b662b02e95150dc9fd64307ee96b35657f75c7abd82530168ce3";
            string str4 = "ceecfd37686a3ed1759d3cef25e412a800fc8e8846154dbe2a2d72b2af3e3b64";

            //concatinate the strings together
            string str12 = str1 + str2;
            string str34 = str3 + str4;

            //converts the string into bytes
            byte[] str12Bytes = Encoding.UTF8.GetBytes(str12);
            byte[] str34Bytes = Encoding.UTF8.GetBytes(str34);

            //creates the hashed bytes, must be done twice per request
            byte[] hash12Bytes = SHA256.Create().ComputeHash(str12Bytes);
            hash12Bytes = SHA256.Create().ComputeHash(hash12Bytes);

            //do the same for 34
            byte[] hash34Bytes = SHA256.Create().ComputeHash(str34Bytes);
            hash34Bytes = SHA256.Create().ComputeHash(hash34Bytes);

            //coverts the hash into a hexhash
            string hexHash12 = BitConverter.ToString(hash12Bytes).Replace("-","");
            string hexHash34 = BitConverter.ToString(hash34Bytes).Replace("-", "");

            //the combined string of them
            string strTotal = hexHash12 + hexHash34;

            //creating the byte sequence for hashing
            byte[] strTotalBytes = Encoding.UTF8.GetBytes(strTotal);

            //hash the sequence twice
            byte[] hashTotalBytes = SHA256.Create().ComputeHash(strTotalBytes);
            hashTotalBytes = SHA256.Create().ComputeHash(hashTotalBytes);

            //convert the hash into a string
            string hexHashTotal = BitConverter.ToString(hash34Bytes).Replace("-", "").ToLowerInvariant();

            //printing the hash
            Console.WriteLine(hexHashTotal);
        }
    }
}
