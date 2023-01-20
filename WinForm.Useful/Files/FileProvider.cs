using System.Collections.Generic;
using System.IO;

namespace WinForm.Useful.Files
{
   public class FileProvider
   {
      public static void Write(string path, string value, int bufferSize = 10)
      {
         using (var buffer = new BufferedStream(File.OpenWrite(path), bufferSize * 1024 * 1024))
         using (var stream = new StreamWriter(buffer))
         {
            stream.WriteLine(value);
         }
      }

      public static IEnumerable<string> Read(string path, int bufferSize = 10)
      {
         using (var buffer = new BufferedStream(File.OpenRead(path), bufferSize * 1024 * 1024))
         using (var stream = new StreamReader(buffer))
         {
            while (!stream.EndOfStream)
            {
               yield return stream.ReadLine();
            }
         }
      }
   }
}