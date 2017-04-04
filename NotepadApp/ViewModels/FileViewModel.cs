using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using NotepadApp.Models;

namespace NotepadApp.ViewModels
{
    public class FileViewModel
    {
        public DocumentModel Document { get; private set; }

        /// <summary>
        /// Toolbar commands
        /// </summary>
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="document"></param>
        public FileViewModel(DocumentModel document)
        {
            Document = document;
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);

        }

        public void NewFile()
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
        }

        private void SaveFile()
        {
            File.WriteAllText(Document.FilePath, Document.Text);
        }

        private void SaveFileAs()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                SaveFile();
            }
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Using generics for open or save, both deriving from FileDialog
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dialog"></param>
        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }

    }
}
