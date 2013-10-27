using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TWModManager
{
    public partial class FormMain : Form
    {
        #region CA Packs
        /// <summary>
        /// List of pack files provided by Creative Assembly
        /// </summary>
        private readonly static List<string> caPackList = new List<string>()
        {
            "boot.pack",
            "data.pack",
            "data_rome2.pack",
            "local_en.pack",
            "local_en_rome2.pack",
            "local_fr.pack",
            "local_fr_rome2.pack",
            "models.pack",
            "models_rome2.pack",
            "models2.pack",
            "models2_rome2.pack",
            "movies.pack",
            "movies_rome2.pack",
            "music.pack",
            "music_en.pack",
            "music_en_rome2.pack",
            "music_rome2.pack",
            "sound.pack",
            "sound_rome2.pack",
            "terrain.pack",
            "terrain_rome2.pack",
            "terrain2.pack",
            "terrain2_rome2.pack",
            "tiles.pack",
            "tiles_rome2.pack",
            "tiles2.pack",
            "tiles2_rome2.pack",
            "tiles3.pack",
            "tiles3_rome2.pack",
            "tiles4.pack",
            "tiles4_rome2.pack"
        };
        #endregion

        private static string applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string scriptPath = Path.Combine(applicationDataPath, @"The Creative Assembly\Rome2\scripts");
        private static string userScriptFilepath = Path.Combine(scriptPath, "user.script.txt");
        private static string settingsFilepath = Path.Combine(scriptPath, "mod_manager_settings.txt");

        private string rtw2Path;
        private string rtw2DataPath;

        private List<Pack> modPacks = new List<Pack>();
        private List<PublishedMod> workshop = new List<PublishedMod>();

        public FormMain(string[] args)
        {
            InitializeComponent();
            this.Size = new Size(604, 538);

            foreach (string arg in args)
            {
                if (arg == "noob")
                {
                    groupBoxConvert.Enabled = false;
                }
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            CheckScriptDirectory();
            LoadSettings();

            if (String.IsNullOrEmpty(rtw2Path) ||
                !Directory.Exists(rtw2Path))
            {
                rtw2Path = GetRome2Directory();

                if (String.IsNullOrEmpty(rtw2Path) ||
                    !Directory.Exists(rtw2Path))
                {
                    while (findR2TWPathFolderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(Path.Combine(findR2TWPathFolderBrowserDialog.SelectedPath, "Rome2.exe")))
                        {
                            rtw2Path = findR2TWPathFolderBrowserDialog.SelectedPath;

                            WriteSettings();
                            break;
                        }
                        MessageBox.Show("Rome2.exe not found in that directory, please try again.", "Invalid directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (String.IsNullOrEmpty(rtw2Path))
                    {
                        MessageBox.Show("Mod Manager can't work without the path to Rome2.exe, exiting!", "Unable to continue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                        return;
                    }
                }
            }

            rtw2DataPath = Path.Combine(rtw2Path, "data");
            
            labelModCount.Text = "Data Path:  " + rtw2DataPath;

            if (Directory.Exists(rtw2DataPath) == false)
            {
                launchGameButton.Enabled = false;
                MessageBox.Show("Unable to locate data directory at game path.\n\n" + rtw2DataPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] foundPacks = Directory.GetFiles(rtw2DataPath, "*.pack");
            
            int vanillaCount = 0;
            int modCount = 0;

            foreach (string file in foundPacks)
            {
                string filePath = file;
                PackType packType = GetPackType(file);
                bool isVanilla = IsPackVanilla(file, packType);
                List<string> packContents = new List<string>();

                if (isVanilla)
                {
                    vanillaCount++;
                }
                else
                {
                    packContents = GetPackContents(file);
                    modCount++;
                }

                Pack newPack = new Pack(filePath, packType, isVanilla, packContents);
                modPacks.Add(newPack);
            }

            int fileCount = 0;

            foreach (Pack pack in modPacks)
            {
                if (pack.IsVanilla == false)
                {
                    fileCount += pack.FileList.Count;
                }
            }

            foreach (Pack pack in modPacks)
            {
                if (pack.IsVanilla == false)
                {
                    foreach (Pack otherPack in modPacks)
                    {
                        if (otherPack.IsVanilla == false)
                        {
                            if (otherPack.Name != pack.Name)
                            {
                                foreach (string file in pack.FileList)
                                {
                                    if (otherPack.FileList.Contains(file))
                                    {
                                        // Conflict found
                                        Conflict newConflict = new Conflict(otherPack.Name, file);
                                        pack.Conflicts.Add(newConflict);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            ListAllMods();
            ColourListViewConflicts();
            LoadProfiles();
            //FindSubscribedMods();
        }
        
        private string GetRome2Directory()
        {
            string rtw2Path = null;

            // 32-bit: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall
            // 64-bit: HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall
            // Steam App Key: \Steam App 214950

            if (String.IsNullOrEmpty(rtw2Path))
            {
                rtw2Path = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 214950", "InstallLocation", "");
            }
            if (String.IsNullOrEmpty(rtw2Path))
            {
                rtw2Path = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 214950", "InstallLocation", "");
            }
            if (String.IsNullOrEmpty(rtw2Path))
            {
                rtw2Path = Path.Combine(FindSteamInstall(), "steamapps\\common\\Total War Rome II");

                if (File.Exists(rtw2Path + "\\Rome2.exe") == false)
                {
                    rtw2Path = null;
                }
            }

            return rtw2Path;
        }

        private void CheckScriptDirectory()
        {
            if (Directory.Exists(scriptPath) == false)
            {
                Directory.CreateDirectory(scriptPath);
            }
        }
        
        private PackType GetPackType(string path)
        {
            int packType = 0;

            using (FileStream fs = File.OpenRead(path))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    reader.ReadChars(4);
                    packType = reader.ReadInt32();
                }
            }
            return (PackType)packType;
        }

        private bool IsPackVanilla(string file, PackType packType)
        {
            bool isVanilla = caPackList.Contains(Path.GetFileName(file));

            if (isVanilla == false)
            {
                if (packType != PackType.Mod && packType != PackType.Movie)
                {
                    isVanilla = true;
                }
            }

            return isVanilla;
        }

        private List<string> GetPackContents(string file)
        {
            List<string> contents = new List<string>();

            using (var reader = new BinaryReader(new FileStream(file, FileMode.Open), Encoding.ASCII))
            {
                PackHeader header = ReadHeader(reader);

                long offset = header.DataStart;
                for (int i = 0; i < header.FileCount; i++)
                {
                    uint size = reader.ReadUInt32();

                    switch (header.PackType)
                    {
                        case PackType.BootX:
                        case PackType.Shader1:
                        case PackType.Shader2:
                            long additionalInfo = reader.ReadInt64();
                            break;
                        default:
                            break;
                    }

                    string packedFileName = ReadZeroTerminatedAscii(reader);
                    packedFileName = packedFileName.Replace('\\', Path.DirectorySeparatorChar);
                    contents.Add(packedFileName);
                }
            }

            return contents;
        }

        public PackHeader ReadHeader(BinaryReader reader)
        {
            PackHeader header = new PackHeader();

            string packIdentifier = new string(reader.ReadChars(4));
            int packType = reader.ReadInt32();
            bool validType = false;

            foreach (PackType type in Enum.GetValues(typeof(PackType)))
            {
                if (packType == (int)type)
                {
                    validType = true;
                    break;
                }
            }

            if (!validType)
            {
                throw new InvalidDataException("Unknown pack type " + packType);
            }

            header.PackType = (PackType)packType;
            int version = reader.ReadInt32();
            int replacedPackFilenameLength = reader.ReadInt32();
            reader.BaseStream.Seek(0x10L, SeekOrigin.Begin);
            header.FileCount = reader.ReadUInt32();
            UInt32 indexSize = reader.ReadUInt32();
            header.DataStart = 0x1C + indexSize;
            UInt32 unknown = reader.ReadUInt32();

            reader.BaseStream.Seek(0x1C, SeekOrigin.Begin);
            for (int i = 0; i < version; i++)
            {
                ReadZeroTerminatedAscii(reader);
            }

            header.DataStart += replacedPackFilenameLength;

            return header;
        }

        public static string ReadZeroTerminatedAscii(BinaryReader reader)
        {
            StringBuilder builder = new StringBuilder();
            byte ch = reader.ReadByte();
            while (ch != '\0')
            {
                builder.Append((char)ch);
                ch = reader.ReadByte();
            }
            return builder.ToString();
        }

        private void listViewMod_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListViewItem item = listViewMod.GetItemAt(e.X, e.Y);

                if (item != null)
                {
                    ListViewItem.ListViewSubItem subitem = item.GetSubItemAt(e.X, e.Y);
                    if (subitem == item.SubItems[1] && subitem.Text.Length > 0 && subitem.Text != "None")
                    {
                        int modIndex = -1;

                        for (int i = 0; i < modPacks.Count; i++)
                        {
                            if (modPacks[i].Name == item.Text)
                            {
                                modIndex = i;
                                break;
                            }
                        }

                        if (modIndex > -1)
                        {
                            FormConflict form = new FormConflict(modPacks[modIndex].Conflicts);
                            form.Text = item.Text + ".pack Conflicts";
                            form.ShowDialog();
                        }
                    }
                }
            }
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total War: Rome 2 - Mod Manager\n\nVersion " + Application.ProductVersion + "\n\nMitchell Heastie © Copyright 2013\n\nTesters:\nIlluminatiRex\n'Gunny", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listViewMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMovie.SelectedItems.Count > 0)
            {
                buttonConvertMovie.Enabled = true;
                listViewMod.SelectedIndices.Clear();
            }
            else
            {
                buttonConvertMovie.Enabled = false;
            }
        }

        private void listViewMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMod.SelectedItems.Count > 0)
            {
                moveUpButton.Enabled = true;
                moveDownButton.Enabled = true;
                listViewMovie.SelectedIndices.Clear();
            }
            else
            {
                moveUpButton.Enabled = false;
                moveDownButton.Enabled = false;
            }
        }

        private void profilesComboBox_Click(object sender, EventArgs e)
        {
            listViewMod.SelectedIndices.Clear();
            listViewMovie.SelectedIndices.Clear();
        }

        private bool PackContainsLocalizationFiles(Pack pack)
        {
            foreach (string file in pack.FileList)
            {
                if (Path.GetExtension(file) == ".loc")
                {
                    return true;
                }
            }

            return false;
        }

        private void buttonConvertMovie_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This option should be used by advanced users only!\n\nThis change will be irreversable by Mod Manager and may have undesired effects.\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;
            
            int modIndex = -1;

            for (int i = 0; i < modPacks.Count; i++)
            {
                if (modPacks[i].Name == listViewMovie.SelectedItems[0].Text)
                {
                    modIndex = i;
                    break;
                }
            }

            if (PackContainsLocalizationFiles(modPacks[modIndex]) == true)
            {
                DialogResult result2 = MessageBox.Show("This pack file contains localization files that must be kept in a movie format pack to work!\nIt is highly suggested you keep this pack in its current format.\n\nAre you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (result2 == DialogResult.No) return;
            }

            if (modIndex > -1)
            {
                string error = "";
                bool worked = modPacks[modIndex].ConvertToMod(out error);

                if (worked == false)
                {
                    MessageBox.Show("Conversion Failed!\n\nError: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show(modPacks[modIndex].Name + " successfully convert to Mod format!", "Done", MessageBoxButtons.OK);

            listViewMod.Items.Clear();
            listViewMovie.Items.Clear();

            foreach (Pack pack in modPacks)
            {
                if (pack.IsVanilla == false)
                {
                    string[] itemContent = new string[2];
                    itemContent[0] = pack.Name;
                    //itemContent[0] = Path.GetFileNameWithoutExtension(pack.Name);

                    if (pack.Conflicts.Count > 0)
                    {
                        itemContent[1] = pack.Conflicts.Count + " conflicts";
                    }
                    else
                    {
                        itemContent[1] = "None";
                    }

                    ListViewItem newItem = new ListViewItem(itemContent);
                    newItem.UseItemStyleForSubItems = false;

                    if (pack.PackType == PackType.Mod)
                    {
                        listViewMod.Items.Add(newItem);
                    }
                    else if (pack.PackType == PackType.Movie || pack.PackType == PackType.Sound || pack.PackType == PackType.Sound1 || pack.PackType == PackType.Music || pack.PackType == PackType.Music1)
                    {
                        listViewMovie.Items.Add(newItem);
                    }
                }
            }

            ColourListViewConflicts();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            if (listViewMod.SelectedIndices.Count > 0)
            {
                int selectedIndex = listViewMod.SelectedIndices[0];
                ListViewItem selectedItem = listViewMod.SelectedItems[0];
                bool wasChecked = listViewMod.Items[selectedIndex].Checked;
                listViewMod.Items.RemoveAt(selectedIndex);
                listViewMod.Items.Insert(selectedIndex - 1, (ListViewItem)selectedItem);
                listViewMod.Items[selectedIndex - 1].Checked = wasChecked;
                listViewMod.Items[selectedIndex - 1].Selected = true;
                listViewMod.Focus();
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            if (listViewMod.SelectedIndices.Count > 0)
            {
                int selectedIndex = listViewMod.SelectedIndices[0];
                ListViewItem selectedItem = listViewMod.SelectedItems[0];
                bool wasChecked = listViewMod.Items[selectedIndex].Checked;
                listViewMod.Items.Insert(selectedIndex + 2, (ListViewItem)selectedItem.Clone());
                listViewMod.Items.RemoveAt(selectedIndex);
                listViewMod.Items[selectedIndex + 1].Selected = true;
                listViewMod.Items[selectedIndex + 1].Checked = wasChecked;
                listViewMod.Focus();
            }
        }

        private void ListAllMods()
        {
            foreach (Pack pack in modPacks)
            {
                if (pack.IsVanilla == false)
                {
                    string[] itemContent = new string[2];
                    itemContent[0] = pack.Name;
                    //itemContent[0] = Path.GetFileNameWithoutExtension(pack.Name);

                    if (pack.Conflicts.Count > 0)
                    {
                        itemContent[1] = pack.Conflicts.Count + " conflicts";
                    }
                    else
                    {
                        itemContent[1] = "None";
                    }

                    ListViewItem newItem = new ListViewItem(itemContent);
                    newItem.UseItemStyleForSubItems = false;

                    if (pack.PackType == PackType.Mod)
                    {
                        listViewMod.Items.Add(newItem);
                    }
                    else if (pack.PackType == PackType.Movie || pack.PackType == PackType.Sound || pack.PackType == PackType.Sound1 || pack.PackType == PackType.Music || pack.PackType == PackType.Music1)
                    {
                        listViewMovie.Items.Add(newItem);
                    }
                }
            }
        }

        private void ColourListViewConflicts()
        {
            foreach (ListViewItem pack in listViewMod.Items)
            {
                if (pack.SubItems[1].Text != "None")
                {
                    ListViewItem.ListViewSubItem conflictItem = pack.SubItems[1];
                    conflictItem.Font = new Font(listViewMod.Font, FontStyle.Underline);
                    conflictItem.ForeColor = Color.FromKnownColor(KnownColor.HotTrack);
                }
            }
            foreach (ListViewItem pack in listViewMovie.Items)
            {
                if (pack.SubItems[1].Text != "None")
                {
                    ListViewItem.ListViewSubItem conflictItem = pack.SubItems[1];
                    conflictItem.Font = new Font(listViewMovie.Font, FontStyle.Underline);
                    conflictItem.ForeColor = Color.FromKnownColor(KnownColor.HotTrack);
                }
            }
        }

        private void timerForm_Tick(object sender, EventArgs e)
        {
            // Normal Size = 604, 538

            if (this.Height > 538)
            {
                this.Height--;
            }
            else
            {
                timerForm.Enabled = false;
            }
        }

        private void listViewMovie_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listViewMovie.GetItemAt(e.X, e.Y);

            if (item != null)
            {
                ListViewItem.ListViewSubItem subitem = item.GetSubItemAt(e.X, e.Y);
                if (subitem == item.SubItems[1] && subitem.Text.Length > 0 && subitem.Text != "None")
                {
                    int modIndex = -1;

                    for (int i = 0; i < modPacks.Count; i++)
                    {
                        if (modPacks[i].Name == item.Text)
                        {
                            modIndex = i;
                            break;
                        }
                    }

                    if (modIndex > -1)
                    {
                        FormConflict form = new FormConflict(modPacks[modIndex].Conflicts);
                        form.Text = item.Text + ".pack Conflicts";
                        form.ShowDialog();
                    }
                }
            }
        }

        private void launchGameButton_Click(object sender, EventArgs e)
        {
            LaunchGame();
            //launchGameButton.Enabled = false;
        }

        private void LaunchGame()
        {
            string exe = rtw2Path + "\\Rome2.exe";
            
            WriteUserScript();

            WriteProfile("last used mods");

            if (File.Exists(exe))
            {
                Process proc = new Process();
                proc.StartInfo.FileName = exe;
                proc.StartInfo.Arguments = "1";
                proc.Start();
            }

            //timerLauncher.Enabled = true;
        }

        private void CheckForGameLaunch()
        {
            Process[] processes = Process.GetProcessesByName("Rome2");

            if (processes.Length > 0)
            {
                // There is a Rome2 process running, write script!
                PostLaunchEvent();
                timerLaunch.Enabled = true;
            }
        }

        private void WaitForLauncher()
        {
            Process[] processes = Process.GetProcessesByName("launcher");

            if (processes.Length > 0)
            {
                if (processes[0].MainWindowTitle == "Total War Launcher")
                {
                    // There is a launcher process running
                    timerLaunch.Enabled = true;
                    timerLauncher.Enabled = false;
                }
            }
        }

        private void PostLaunchEvent()
        {
            // Game was just launched!
            WriteUserScript();

            WriteProfile("last used mods");
        }

        private void WriteUserScript()
        {
            List<string> mods = ListActivatedMods();

            if (mods.Count > 0)
            {
                using (StreamWriter writer = new StreamWriter(userScriptFilepath, false, Encoding.Unicode))
                {
                    foreach (string mod in mods)
                    {
                        writer.WriteLine("mod \"" + mod + "\";");
                    }
                }
            }
        }

        private List<string> ListActivatedMods()
        {
            List<string> mods = new List<string>();

            for (int i = 0; i < listViewMod.Items.Count; i++)
            {
                if (listViewMod.Items[i].Checked == true)
                {
                    mods.Add(listViewMod.Items[i].Text);
                }
            }

            return mods;
        }

        private void WriteProfile(string profileName)
        {
            List<string> mods = ListActivatedMods();

            if (string.IsNullOrEmpty(profilesComboBox.Text) == false)
            {
                string profilePath = scriptPath + "\\profile." + profileName + ".txt";

                using (StreamWriter writer = new StreamWriter(profilePath, false, Encoding.Unicode))
                {
                    foreach (ListViewItem item in listViewMod.Items)
                    {
                        writer.Write("{1}{0}\n", Path.GetFileNameWithoutExtension(item.Text), item.Checked ? "" : "#");
                    }
                }
            }
        }

        private void LoadProfiles()
        {
            foreach (string profileFilepath in Directory.GetFiles(scriptPath, "profile.*.txt"))
            {
                profilesComboBox.Items.Add(Regex.Match(profileFilepath, @"profile\.(.+)\.txt").Groups[1].ToString());
            }

            if (profilesComboBox.Items.Contains("last used mods"))
            {
                profilesComboBox.SelectedIndex = profilesComboBox.Items.IndexOf("last used mods");
            }
        }

        private void ActivateProfile(string profileName)
        {
            string profilePath = scriptPath + "\\profile." + profileName + ".txt";

            if (File.Exists(profilePath))
            {
                List<string> profileMods = new List<string>(File.ReadAllLines(profilePath));

                for (int i = 0; i < listViewMod.Items.Count; i++)
                {
                    if (profileMods.Contains(Path.GetFileNameWithoutExtension(listViewMod.Items[i].Text)))
                    {
                        listViewMod.Items[i].Checked = true;
                    }
                    else
                    {
                        listViewMod.Items[i].Checked = false;
                    }
                }
            }
        }

        private void WriteSettings()
        {
            if (File.Exists(settingsFilepath))
            {
                File.Delete(settingsFilepath);
            }

            using (StreamWriter file = new StreamWriter(settingsFilepath))
            {
                file.WriteLine("GamePath=" + rtw2Path);
            }
        }

        private void LoadSettings()
        {
            if (File.Exists(settingsFilepath))
            {
                string[] lines = File.ReadAllLines(settingsFilepath);

                foreach (string line in lines)
                {
                    if ((line.StartsWith("#") == false) && (line != ""))
                    {
                        if (line.StartsWith("GamePath=") == true)
                        {
                            rtw2Path = StripText(line, "GamePath=");
                        }
                    }
                }
            }
        }

        private void FindSubscribedMods()
        {
            string steamPath = FindSteamInstall();

            if (steamPath != null) // If we can't find the steam path easily then don't bother
            {
                string userdata = Path.Combine(steamPath, "userdata");

                string[] folders = Directory.GetDirectories(userdata);

                foreach (string folder in folders)
                {
                    // This is a Steam user, read their /ugc/publishedfiledetails.vdf
                    string vdfPath = Path.Combine(folder, "ugc/publishedfiledetails.vdf");

                    if (File.Exists(vdfPath))
                    {
                        ParseVDF(vdfPath);
                    }
                }
            }

            foreach (PublishedMod pb in workshop)
            {
                MessageBox.Show(pb.Filename + "\n" + pb.Description);
            }
        }

        private string FindSteamInstall()
        {
            string steamPath = null;

            // HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam

            if (String.IsNullOrEmpty(steamPath))
            {
                steamPath = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", "");
            }
            if (String.IsNullOrEmpty(steamPath))
            {
                steamPath = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", "");
            }

            return steamPath;
        }

        private void ParseVDF(string file)
        {
            string[] lines = File.ReadAllLines(file);

            int modCount = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("\t\"" + modCount + "\"")) // Start of mod
                {
                    string appID = "";
                    PublishedMod mod = new PublishedMod();

                    while (lines[i].StartsWith("\t\"" + (modCount + 1) + "\"") == false) // Reached next mod
                    {
                        if (lines[i].Contains("publishedfileid"))
                        {
                            mod.FileID = lines[i].Replace("\"publishedfileid\"\t\t\"", "");
                            mod.FileID = mod.FileID.Replace("\"", "");
                            mod.FileID = mod.FileID.Replace("\t", "");
                        }
                        else if (lines[i].Contains("consumerappid"))
                        {
                            appID = lines[i].Replace("\"consumerappid\"\t\t\"", "");
                            appID = appID.Replace("\"", "");
                            appID = appID.Replace("\t", "");
                        }
                        else if (lines[i].Contains("filename"))
                        {
                            mod.Filename = lines[i].Replace("\"filename\"\t\t\"", "");
                            mod.Filename = mod.Filename.Replace("\"", "");
                            mod.Filename = mod.Filename.Replace("\t", "");
                            mod.Filename = mod.Filename.Replace("mods/", "");
                        }
                        else if (lines[i].Contains("description"))
                        {
                            mod.Description = lines[i].Replace("\"description\"\t\t\"", "");
                            mod.Description = mod.Description.Replace("\"", "");
                            mod.Description = mod.Description.Replace("\t", "");
                        }
                        else if (lines[i].Contains("tags"))
                        {
                            mod.Tags = lines[i].Replace("\"tags\"\t\t\"", "");
                            mod.Tags = mod.Tags.Replace("\"", "");
                            mod.Tags = mod.Tags.Replace("\t", "");
                        }
                        else if (lines[i].Contains("title"))
                        {
                            mod.Title = lines[i].Replace("\"title\"\t\t\"", "");
                            mod.Title = mod.Title.Replace("\"", "");
                            mod.Title = mod.Title.Replace("\t", "");
                        }
                        else if (lines[i].Contains("steamid_owner"))
                        {
                            mod.Author = lines[i].Replace("\"steamid_owner\"\t\t\"", "");
                            mod.Author = mod.Author.Replace("\"", "");
                            mod.Author = mod.Author.Replace("\t", "");
                        }

                        if ((i + 1) >= lines.Length)
                            break;

                        i++;
                    }

                    modCount++;

                    if (appID.Contains("214950"))
                    {
                        workshop.Add(mod);
                    }

                    i--;
                }
            }
        }

        private string StripText(string text, string remove)
        {
            if (text.Trim().StartsWith(remove))
            {
                int lastLocation = text.IndexOf(remove);

                if (lastLocation >= 0)
                {
                    text = text.Substring(lastLocation + remove.Length);
                }
            }

            return text;
        }

        private void saveProfileButton_Click(object sender, EventArgs e)
        {
            WriteProfile(profilesComboBox.Text);
        }

        private void deleteProfileButton_Click(object sender, EventArgs e)
        {
            string profilePath = scriptPath + "\\profile." + profilesComboBox.Text + ".txt";

            if (File.Exists(profilePath))
            {
                File.Delete(profilePath);
            }

            profilesComboBox.Text = "";
        }

        private void profilesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string profilePath = scriptPath + "\\profile." + profilesComboBox.Text + ".txt";

            if (File.Exists(profilePath))
            {
                ActivateProfile(profilesComboBox.Text);
                deleteProfileButton.Enabled = true;
            }
            else
            {
                deleteProfileButton.Enabled = false;
            }
        }

        private void launchGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchGame();
        }

        private void revertToVanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(userScriptFilepath))
            {
                File.Delete(userScriptFilepath);
            }

            Directory.CreateDirectory(rtw2DataPath + "\\MyMods");

            foreach (Pack mod in modPacks)
            {
                if (mod.IsVanilla == false)
                {
                    try
                    {
                        File.Move(mod.FilePath, rtw2DataPath + "\\MyMods\\" + mod.Name);
                    }
                    catch(Exception)
                    {
                        revertToVanillaToolStripMenuItem.Enabled = false;
                    }
                }
            }

            MessageBox.Show("Your game is now in a Vanilla state!\n\nNote:\nYour mods have not been deleted.\nYou can find them in the MyMods folder in your data folder.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerLaunch_Tick(object sender, EventArgs e)
        {
            CheckForGameLaunch();
        }

        private void timerLauncher_Tick(object sender, EventArgs e)
        {
            WaitForLauncher();
        }

        private void listViewMod_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            return;

            ListViewItem item = listViewMod.GetItemAt(e.X, e.Y);

            if (item != null)
            {
                ListViewItem.ListViewSubItem subitem = item.GetSubItemAt(e.X, e.Y);
                if (subitem == item.SubItems[1] && subitem.Text.Length > 0 && subitem.Text != "None")
                {
                    // Conflicts was clicked, ignore
                }
                else
                {
                    int modIndex = -1;

                    for (int i = 0; i < modPacks.Count; i++)
                    {
                        if (modPacks[i].Name == item.Text)
                        {
                            modIndex = i;
                            break;
                        }
                    }

                    if (modIndex > -1)
                    {
                        FormMod formMod = new FormMod(modPacks[modIndex]);
                        formMod.ShowDialog();
                    }
                }
            }
        }

        private void viewContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = listViewMod.SelectedItems[0];

            if (item != null)
            {
                int modIndex = -1;

                for (int i = 0; i < modPacks.Count; i++)
                {
                    if (modPacks[i].Name == item.Text)
                    {
                        modIndex = i;
                        break;
                    }
                }

                if (modIndex > -1)
                {
                    Form form = new Form();
                    form.Text = "File list for " + item.Text;
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.WindowState = FormWindowState.Normal;
                    DataGridView listView = new DataGridView();
                    listView.Columns.Add("filepathColumn", "File");
                    listView.Dock = DockStyle.Fill;
                    listView.AllowUserToAddRows = false;
                    listView.AllowUserToDeleteRows = false;
                    listView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    listView.RowHeadersVisible = false;
                    form.Controls.Add(listView);

                    foreach (string f in modPacks[modIndex].FileList)
                    {
                        listView.Rows.Add(f);
                    }

                    form.Show();
                }
            }
        }

        private void labelModCount_DoubleClick(object sender, EventArgs e)
        {
            while (findR2TWPathFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(Path.Combine(findR2TWPathFolderBrowserDialog.SelectedPath, "Rome2.exe")))
                {
                    rtw2Path = findR2TWPathFolderBrowserDialog.SelectedPath;

                    WriteSettings();
                    break;
                }
                MessageBox.Show("Rome2.exe not found in that directory, please try again.", "Invalid directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}