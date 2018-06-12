using System;
using System.IO;
using Xamarin.Forms;
using DoggaLogg.Database;
using DoggaLogg.Droid;

[assembly: Dependency(typeof(FileHelper))]
namespace DoggaLogg.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocaLFilePath(string _fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, _fileName);
        }
    }
}