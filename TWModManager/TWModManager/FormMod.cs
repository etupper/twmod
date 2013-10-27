using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

namespace TWModManager
{
    public partial class FormMod : Form
    {
        private Pack pack;

        public FormMod(Pack _pack)
        {
            InitializeComponent();
            pack = _pack;
        }

        private void FormMod_Load(object sender, EventArgs e)
        {
            labelName.Text = Path.GetFileName(pack.FilePath);

            string pngPath = Path.GetDirectoryName(pack.FilePath) + "\\" + Path.GetFileNameWithoutExtension(pack.FilePath) + ".png";

            if (File.Exists(pngPath))
            {
                imgMod.Image = Bitmap.FromFile(pngPath);
            }


            FileInfo fI = new FileInfo(pack.FilePath);
            long fileSize = fI.Length / (1024*1024);

            labelDesc.Text = "Filesize: " + fileSize.ToString(".0#") + "mb\n"
                + "File Count: " + pack.FileList.Count + "\n"
                + "Pack Type: " + pack.PackType.ToString() + "\n"
                + "Conflicts: " + pack.Conflicts.Count;
        }

        private string GetAuthorName(string steamID, out bool found)
        {
            string author = "";
            found = false;

            WebClient client = new WebClient();
            string htmlCode = client.DownloadString("http://steamcommunity.com/profiles/" + steamID);

            string title = Regex.Match(htmlCode, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;

            if (title.Contains("Steam Community :: "))
            {
                author = title.Replace("Steam Community :: ", "");
                found = true;
            }
            else
            {
                author = "Unknown";
            }

            return author;
        }

        private void FormMod_Shown(object sender, EventArgs e)
        {
            bool found;
            string authorName = GetAuthorName("76561197989900707", out found);
            
            labelAuthor.Text = "Author: " + authorName;
        }
    }
}
