using System;
using System.IO;
using System.Windows.Forms;

namespace _3D_Training
{
    public static class FileImportManager
    {
        public static void ImportFile()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = documentsFolderPath;
                openFileDialog.Filter = "obj files (*.obj)|*.obj";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        var sS = "";
                    }
                }
            }
        }
    }
}