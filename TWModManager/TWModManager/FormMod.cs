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
using System.Diagnostics;

namespace TWModManager
{
    public partial class FormMod : Form
    {
        private Pack pack;
        private List<PublishedMod> workshop = new List<PublishedMod>();
        private int pmIndex = -1;
        private bool foundAuthor = false;

        public FormMod(Pack _pack, List<PublishedMod> _workshop)
        {
            InitializeComponent();
            pack = _pack;
            workshop = _workshop;
        }

        private void FormMod_Load(object sender, EventArgs e)
        {
            labelName.Text = Path.GetFileName(pack.FilePath);

            int i = 0;

            foreach (PublishedMod pMod in workshop)
            {
                if (pMod.Filename == pack.Name)
                {
                    if (!string.IsNullOrEmpty(pMod.Title))
                    {
                        labelName.Text = pMod.Title;
                    }

                    pmIndex = i;
                }
                i++;
            }

            string pngPath = Path.GetDirectoryName(pack.FilePath) + "\\" + Path.GetFileNameWithoutExtension(pack.FilePath) + ".png";

            if (File.Exists(pngPath))
            {
                imgMod.Image = Bitmap.FromFile(pngPath);
            }

            FileInfo fI = new FileInfo(pack.FilePath);
            float fileSize = (float)fI.Length / (float)(1024 * 1024);

            labelDesc.Text = "Filename:\n'" + pack.Name + "'\n"
                + "Filesize: " + fileSize.ToString("N2") + "mb\n"
                + "Internal File Count: " + pack.FileList.Count + "\n"
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
            if (pmIndex > -1)
            {
                bool found;
                string authorName = GetAuthorName(workshop[pmIndex].Author, out found);

                if (found)
                {
                    labelAuthor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack);
                    foundAuthor = true;
                }

                labelAuthor.Text = "Author: " + authorName;
            }
            else
            {
                labelAuthor.Text = "Author: Unknown";
            }
        }

        private void labelAuthor_Click(object sender, EventArgs e)
        {
            if (foundAuthor == true)
            {
                Process.Start("http://steamcommunity.com/profiles/" + workshop[pmIndex].Author);// + "/myworkshopfiles/?appid=214950");
            }
        }

        private void labelAuthor_MouseEnter(object sender, EventArgs e)
        {
            if (foundAuthor == true)
            {
                labelAuthor.Font = new Font(labelAuthor.Font, FontStyle.Underline);
            }
        }

        private void labelAuthor_MouseLeave(object sender, EventArgs e)
        {
            if (foundAuthor == true)
            {
                labelAuthor.Font = new Font(labelAuthor.Font, FontStyle.Regular);
            }
        }
    }
}
