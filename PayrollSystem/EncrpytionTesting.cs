namespace PayrollSystem
{

    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.Crypto.Modes;
    using Org.BouncyCastle.Crypto.Paddings;
    using Org.BouncyCastle.Crypto.Parameters;

    using Org.BouncyCastle.Security;
    using System;

	public class bsShite
	{
        public byte[] BullshitFix(string hexString)
        {
            byte[] bytes = new byte[hexString.Length / 2];

            for (int i = 0; i < hexString.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
			return bytes;
        }

        public string BytesToHexString(byte[] bytes)
        {
            char[] hexChars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int v = bytes[i] & 0xFF;
                hexChars[i * 2] = GetHexChar(v >> 4);
                hexChars[i * 2 + 1] = GetHexChar(v & 0xF);
            }
            return new string(hexChars);
        }

        private char GetHexChar(int value)
        {
            if (value < 10)
            {
                return (char)('0' + value);
            }
            return (char)('A' + (value - 10));
        }
    }

    class ProgramZingus
	{

        public void Main(string[] args)
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
				bsShite ass = new bsShite();
				Array.Copy(ass.BullshitFix(iv), nonce, 16);

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


                string output = "";

                output += string.Format("=== {0} ==\n", cipher.AlgorithmName);
                output += string.Format("Message:\t\t{0}\n", msg);
                output += string.Format("Block size:\t\t{0} bits\n", cipher.GetBlockSize() * 8);
                output += string.Format("Mode:\t\t\t{0}\n", mode);
                output += string.Format("IV:\t\t\t{0}\n", iv);
                output += string.Format("Key size:\t\t{0} bits\n", size);
                output += string.Format("Key:\t\t\t{0} [{1}]\n", ass.BytesToHexString(keyParam.GetKey()), Convert.ToBase64String(keyParam.GetKey()));

                output += string.Format("\nCipher (hex):\t\t{0}\n", ass.BytesToHexString(rtn));
                output += string.Format("Cipher (Base64):\t{0}\n", Convert.ToBase64String(rtn));
                output += string.Format("\nPlain:\t\t\t{0}\n", System.Text.Encoding.ASCII.GetString(pln).TrimEnd('\0'));

				Console.WriteLine(output);

            }
            catch (Exception e)
			{
				Console.WriteLine($"Error: {0} { e.Message}");
			}
		}
	}
}