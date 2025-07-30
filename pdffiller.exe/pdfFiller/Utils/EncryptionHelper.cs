// Decompiled with JetBrains decompiler
// Type: pdfFiller.Utils.EncryptionHelper
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace pdfFiller.Utils;

public class EncryptionHelper
{
  private const int Keysize = 256 /*0x0100*/;
  private const int DerivationIterations = 1000;

  public static string Encrypt(string plainText, string passPhrase)
  {
    byte[] numArray1 = EncryptionHelper.Generate256BitsOfRandomEntropy();
    byte[] numArray2 = EncryptionHelper.Generate256BitsOfRandomEntropy();
    byte[] bytes1 = Encoding.UTF8.GetBytes(plainText);
    using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passPhrase, numArray1, 1000))
    {
      byte[] bytes2 = rfc2898DeriveBytes.GetBytes(32 /*0x20*/);
      using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
      {
        rijndaelManaged.BlockSize = 256 /*0x0100*/;
        rijndaelManaged.Mode = CipherMode.CBC;
        rijndaelManaged.Padding = PaddingMode.PKCS7;
        using (ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(bytes2, numArray2))
        {
          using (MemoryStream memoryStream = new MemoryStream())
          {
            using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
            {
              cryptoStream.Write(bytes1, 0, bytes1.Length);
              cryptoStream.FlushFinalBlock();
              byte[] array = ((IEnumerable<byte>) ((IEnumerable<byte>) numArray1).Concat<byte>((IEnumerable<byte>) numArray2).ToArray<byte>()).Concat<byte>((IEnumerable<byte>) memoryStream.ToArray()).ToArray<byte>();
              memoryStream.Close();
              cryptoStream.Close();
              return Convert.ToBase64String(array);
            }
          }
        }
      }
    }
  }

  public static string Decrypt(string cipherText, string passPhrase)
  {
    byte[] source = Convert.FromBase64String(cipherText);
    byte[] array1 = ((IEnumerable<byte>) source).Take<byte>(32 /*0x20*/).ToArray<byte>();
    byte[] array2 = ((IEnumerable<byte>) source).Skip<byte>(32 /*0x20*/).Take<byte>(32 /*0x20*/).ToArray<byte>();
    byte[] array3 = ((IEnumerable<byte>) source).Skip<byte>(64 /*0x40*/).Take<byte>(source.Length - 64 /*0x40*/).ToArray<byte>();
    using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passPhrase, array1, 1000))
    {
      byte[] bytes = rfc2898DeriveBytes.GetBytes(32 /*0x20*/);
      using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
      {
        rijndaelManaged.BlockSize = 256 /*0x0100*/;
        rijndaelManaged.Mode = CipherMode.CBC;
        rijndaelManaged.Padding = PaddingMode.PKCS7;
        using (ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(bytes, array2))
        {
          using (MemoryStream memoryStream = new MemoryStream(array3))
          {
            using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
            {
              byte[] numArray = new byte[array3.Length];
              int count = cryptoStream.Read(numArray, 0, numArray.Length);
              memoryStream.Close();
              cryptoStream.Close();
              return Encoding.UTF8.GetString(numArray, 0, count);
            }
          }
        }
      }
    }
  }

  private static byte[] Generate256BitsOfRandomEntropy()
  {
    byte[] data = new byte[32 /*0x20*/];
    using (RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider())
      cryptoServiceProvider.GetBytes(data);
    return data;
  }
}
