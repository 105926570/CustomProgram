using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PayrollSystem.UsefullUniversalCommands;

namespace PayrollSystem
{

    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.Crypto.Modes;
    using Org.BouncyCastle.Crypto.Paddings;
    using Org.BouncyCastle.Crypto.Parameters;

    using Org.BouncyCastle.Security;

    class Program
    {

        static void Main(string[] args)
        {



            var msg = "Hello";

            var iv = "00112233445566778899AABBCCDDEEFF00";
            var size = 128;
            var mode = "CBC";

            if (args.Length > 0) msg = args[0];
            if (args.Length > 1) iv = args[1];
            if (args.Length > 2) size = Convert.ToInt32(args[2]);
            if (args.Length > 3) mode = args[3];



            try
            {

                var plainTextData = System.Text.Encoding.UTF8.GetBytes(msg);
                var cipher = new DesEdeEngine();


                byte[] nonce = new byte[16];
                Array.Copy(Convert.FromHexString(iv), nonce, 16);

                PaddedBufferedBlockCipher cipherMode = new PaddedBufferedBlockCipher(new CbcBlockCipher(cipher), new Pkcs7Padding());

                if (mode == "ECB") cipherMode = new PaddedBufferedBlockCipher(new EcbBlockCipher(cipher), new Pkcs7Padding());
                else if (mode == "CFB") cipherMode = new PaddedBufferedBlockCipher(new CfbBlockCipher(cipher, 128), new Pkcs7Padding());


                CipherKeyGenerator keyGen = new CipherKeyGenerator();
                keyGen.Init(new KeyGenerationParameters(new SecureRandom(), size));
                KeyParameter keyParam = keyGen.GenerateKeyParameter();
                ICipherParameters keyParamIV = new ParametersWithIV(keyParam, nonce);
                if (mode == "ECB")
                {
                    cipherMode.Init(true, keyParam);
                }
                else
                {
                    cipherMode.Init(true, keyParamIV);
                }
                int outputSize = cipherMode.GetOutputSize(plainTextData.Length);
                byte[] cipherTextData = new byte[outputSize];
                int result = cipherMode.ProcessBytes(plainTextData, 0, plainTextData.Length, cipherTextData, 0);
                cipherMode.DoFinal(cipherTextData, result);
                var rtn = cipherTextData;


                // Decrypt
                cipherMode.Init(false, keyParam);

                outputSize = cipherMode.GetOutputSize(cipherTextData.Length);
                plainTextData = new byte[outputSize];

                result = cipherMode.ProcessBytes(cipherTextData, 0, cipherTextData.Length, plainTextData, 0);

                cipherMode.DoFinal(plainTextData, result);

                var pln = plainTextData;


                Console.WriteLine("=== {0} ==", cipher.AlgorithmName);
                Console.WriteLine("Message:\t\t{0}", msg);
                Console.WriteLine("Block size:\t\t{0} bits", cipher.GetBlockSize() * 8);
                Console.WriteLine("Mode:\t\t\t{0}", mode);
                Console.WriteLine("IV:\t\t\t{0}", iv);
                Console.WriteLine("Key size:\t\t{0} bits", size);
                Console.WriteLine("Key:\t\t\t{0} [{1}]", Convert.ToHexString(keyParam.GetKey()), Convert.ToBase64String(keyParam.GetKey()));


                Console.WriteLine("\nCipher (hex):\t\t{0}", Convert.ToHexString(rtn));
                Console.WriteLine("Cipher (Base64):\t{0}", Convert.ToBase64String(rtn));
                Console.WriteLine("\nPlain:\t\t\t{0}", System.Text.Encoding.ASCII.GetString(pln).TrimEnd('\0'));



            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }



}
