using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Android.Graphics;
using Newtonsoft.Json;

namespace Oef.Util
{
    public static class Writer
    {
        public static bool ToOef(Exam exam, string filePath, bool throwOnError = false)
        {
            if (exam == null)
                throw new NullReferenceException("The exam to be written cannot be null.");
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Empty filepath");

            IFormatter formatter = new BinaryFormatter();
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, exam);
                    return true;
                }
            }
            catch (Exception ex)
            {
                ///Logger.LogException(ex);

                if (throwOnError)
                {
                    throw;
                }

                return false;
            }
        }
        
        public static bool ToJson(Exam exam, string filePath)
        {
            try
            {
                var examJsonString = JsonConvert.SerializeObject(exam, Formatting.Indented);
                File.WriteAllText(filePath, examJsonString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ToXml(Exam exam, string filePath)
        {
            try
            {
                var examXmlStringWriter = new StringWriter();
                var serializer = new XmlSerializer(exam.GetType());
                serializer.Serialize(examXmlStringWriter, exam);
                File.WriteAllText(filePath, examXmlStringWriter.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        //private static byte[] BitmapToByteArray(Bitmap bitmap)///System.Drawing.
        //{
        //    byte[] result = null;

        //    if (bitmap != null)
        //    {
        //        using (var stream = new MemoryStream())
        //        {
        //            bitmap.Compress(Bitmap.CompressFormat.Png,70,stream);///(stream, bitmap.RawFormat
        //            result = stream.ToArray();
        //        }
        //    }
            
        //    return result;
        //}
    }
}
