using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TWModManager
{
    public class Pack
    {
        // Attributes
        private string _filePath;
        private PackType _packType;
        private bool _isVanilla;
        private List<string> _fileList;
        private List<Conflict> _conflicts;

        // Constructor
        public Pack(string filePath, PackType packType, bool isVanilla, List<string> fileList)
        {
            _filePath = filePath;
            _packType = packType;
            _isVanilla = isVanilla;
            _fileList = fileList;
            _conflicts = new List<Conflict>();
        }

        // Properties
        public string Name
        {
            get
            {
                return Path.GetFileName(_filePath);
            }
        }

        public string FilePath
        {
            get
            {
                return _filePath;
            }
        }

        public PackType PackType
        {
            get
            {
                return _packType;
            }
        }

        public bool IsVanilla
        {
            get
            {
                return _isVanilla;
            }
        }

        public List<string> FileList
        {
            get
            {
                return _fileList;
            }
        }

        public List<Conflict> Conflicts
        {
            get
            {
                return _conflicts;
            }
            set
            {
                _conflicts = value;
            }
        }

        // Methods
        public bool ConvertToMod(out string complete)
        {
            bool worked = true;
            complete = "";

            try
            {
                using (FileStream fs = File.OpenWrite(_filePath))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        writer.Seek(4, SeekOrigin.Begin);
                        writer.Write(3); // 03 = Movie
                    }
                }
            }
            catch (Exception e)
            {
                complete = e.Message;
                worked = false;
            }

            _packType = PackType.Mod;
            return worked;
        }
    }

    public enum PackType
    {
        Boot = 0,
        Release = 1,
        Patch = 2,
        Mod = 3,
        Movie = 4,
        Sound = 17,
        Music = 18,
        Sound1 = 0x17,
        Music1 = 0x18,
        BootX = 0x40,
        Shader2 = 0x41,
        Shader1 = 0x42
    }

    public class PackHeader
    {
        private PackType _packType;
        private long _dataStart;
        private long _fileCount;

        public PackHeader()
        {
        }

        public PackType PackType
        {
            get
            {
                return _packType;
            }
            set
            {
                _packType = value;
            }
        }


        public long DataStart
        {
            get
            {
                return _dataStart;
            }
            set
            {
                _dataStart = value;
            }
        }


        public long FileCount
        {
            get
            {
                return _fileCount;
            }
            set
            {
                _fileCount = value;
            }
        }
    }

    public class Conflict
    {
        private string _packName;
        private string _file;

        public Conflict(string packName, string file)
        {
            _packName = packName;
            _file = file;
        }

        public string PackName
        {
            get
            {
                return _packName;
            }
        }

        public string File
        {
            get
            {
                return _file;
            }
        }
    }
}
