using System;
using System.IO;
namespace Console_08082022
{
    public class Program{
        public static void Main(){
            var file = @"C:\Users\Ragil\Documents\Test Workbook.xlsx";
            var fileRead = file.GetFileStream();
            var base64 = Convert.ToBase64String(fileRead);
            Console.ReadLine();
        }
    }

    public static class FileHelper{
        public static byte[] GetFileStream(this string path){
            try
            {
                byte[] fileContent = null;
                if(!File.Exists(path)){
                    throw new Exception(path);
                }
                using (var _fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (var _br = new BinaryReader(_fs))
                    {
                        var length = new FileInfo(path).Length;
                        fileContent = _br.ReadBytes(Convert.ToInt32(length));
                    }
                }
                return fileContent;  
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        /*
        public static byte[] GetBytes(HttpPostedFileBase result)
        {
            var length = result.InputStream.Length; //Length: 103050706
            MemoryStream target = new MemoryStream();
            result.InputStream.CopyTo(target); // generates problem in this line
            byte[] data = target.ToArray(); 
            return data;
        }
        */
    }
}