using System;
using System.IO;
using System.Windows.Forms;

namespace _3D_Training.FileImporter
{
    public static class FileImportManager
    {
        public static Stream ImportFile()
        {
            var documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = documentsFolderPath;
                openFileDialog.Filter = "obj files (*.obj)|*.obj";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    return openFileDialog.OpenFile();
                return null;
            }
        }
    }
}