using System;
using System.Collections.Generic;
using System.Text;

namespace TWModManager
{
    public class PublishedMod
    {
        private string _filename;
        private string _fileID;
        private string _title;
        private string _author;
        private string _description;
        private string _tags;

        public PublishedMod()
        {
        }
        public PublishedMod(string filename, string fileID, string title, string author, string desc, string tags)
        {
            _filename = filename;
            _fileID = fileID;
            _title = title;
            _author = author;
            _description = desc;
            _tags = tags;
        }

        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
            }
        }

        public string FileID
        {
            get
            {
                return _fileID;
            }
            set
            {
                _fileID = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public string Tags
        {
            get
            {
                return _tags;
            }
            set
            {
                _tags = value;
            }
        }
    }
}
