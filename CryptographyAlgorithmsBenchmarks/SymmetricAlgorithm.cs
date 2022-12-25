namespace CryptographyAlgorithmsBenchmarks
{
    public class SymmetricAlgorithm : System.Object
    {
        public static readonly string PlainText = "Hello, I'm Hamed Banaei!";
        public static readonly System.Security.Cryptography.Aes AesAlgorithm = System.Security.Cryptography.Aes.Create();
        public static readonly byte[] AesCypherByte = Encrypt(AesAlgorithm.CreateEncryptor(), PlainText);

        public static readonly System.Security.Cryptography.Aes AesCngAlgorithm = System.Security.Cryptography.AesCng.Create();
        public static readonly byte[] AesCngCypherByte = Encrypt(AesCngAlgorithm.CreateEncryptor(), PlainText);

        public static readonly System.Security.Cryptography.DES DesAlgorithm = System.Security.Cryptography.DES.Create();
        public static readonly byte[] DesCypherByte = Encrypt(DesAlgorithm.CreateEncryptor(), PlainText);

        public static readonly System.Security.Cryptography.TripleDES TripleDesAlgorithm = System.Security.Cryptography.TripleDES.Create();
        public static readonly byte[] TripleDesCypherByte = Encrypt(TripleDesAlgorithm.CreateEncryptor(), PlainText);

        public static readonly System.Security.Cryptography.TripleDES TripleDesCngAlgorithm = System.Security.Cryptography.TripleDESCng.Create();
        public static readonly byte[] TripleDesCngCypherByte = Encrypt(TripleDesCngAlgorithm.CreateEncryptor(), PlainText);


        internal static byte[] Encrypt(System.Security.Cryptography.ICryptoTransform encryptorAlgorithm, string message)
        {
            using var ms = new MemoryStream();
            using var cs = new System.Security.Cryptography.CryptoStream(ms, encryptorAlgorithm, System.Security.Cryptography.CryptoStreamMode.Write);
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(message); // Write all data to the stream.
            }

            return ms.ToArray();
        }

        internal static string Decrypt(System.Security.Cryptography.ICryptoTransform decryptorAlgorithm, byte[] cipherByte)
        {
            using var ms = new MemoryStream(cipherByte);
            using var cs = new System.Security.Cryptography.CryptoStream(ms, decryptorAlgorithm, System.Security.Cryptography.CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }
    }
}
