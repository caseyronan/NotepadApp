using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadApp.Models
{
    public class DocumentModel : ObservableObject
    {
        private string _text;
        private string _fileName;
        private string _filePath;

        /// <summary>
        /// Document text
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                // New and improved method
                // that sets the value for us
                OnPropertyChanged(ref _text, value);

                // Older method with dirty magic string
                // _text = value;
                // OnPropertyChanged("Text");
            }
        }

        /// <summary>
        /// File path to save / open from
        /// </summary>
        public string FilePath
        {
            get { return _filePath; }
            set { OnPropertyChanged(ref _filePath, value); }
        }

        /// <summary>
        /// The name of the document we are working with
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { OnPropertyChanged(ref _fileName, value); }
        }

        /// <summary>
        /// For checking if file path / name are in use
        /// </summary>
        public bool isEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath))
                {
                    return true;
                }
                return false;
            }
        }


    }
}
