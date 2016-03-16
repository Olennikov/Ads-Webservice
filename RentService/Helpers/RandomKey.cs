using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentService.Helpers
{
    /// <summary>
    /// This class generate random uniq key. Provide key length(int)
    /// </summary>
    public class RandomKey
    {
        Random rnd = new Random();

        /// <summary>
        /// Generating uniq Key
        /// </summary>
        /// <param name="keySize">length of a key(16, 32, 64 chars...) you want to create</param>
        /// <returns>random key(string)</returns>
        public string GenerateKey(int keySize)
        {
            string input = Shuffle("AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789");

            var key = Enumerable.Range(0, keySize)
                    .Select(x => input[rnd.Next(0, input.Length)]); // random index of input returns the char of the random index.
            return new string(key.ToArray());
        }

        /// <summary>
        /// shuffles provided chars
        /// </summary>
        /// <param name="str">chars to shuffle</param>
        /// <returns>shuffled 64 chars arrey</returns>
        private string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }
    }
}