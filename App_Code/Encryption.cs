using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Encryption
/// </summary>
public static class Encryption
{
    static private string mKey = ConfigurationManager.AppSettings["EncryptionKey"];
    static private string mSalt = ConfigurationManager.AppSettings["mSalt"];

    // This constant is used to determine the keysize of the encryption algorithm in bits.
    // We divide this by 8 within the code below to get the equivalent number of bytes.
    private const int Keysize = 128;

    // This constant determines the number of iterations for the password bytes generation function.
    private const int DerivationIterations = 1000;

    public static string Encrypt(string text)
    {
        System.Security.Cryptography.SHA1 sha = System.Security.Cryptography.SHA1.Create();
        byte[] preHash = System.Text.Encoding.UTF32.GetBytes(text + mKey + mSalt);
        byte[] hash = sha.ComputeHash(preHash);
        string password = System.Convert.ToBase64String(hash);

        return password;
    }
}