using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TWModManager
{
    public partial class FormConflict : Form
    {
        List<Conflict> _conflicts;

        public FormConflict(List<Conflict> conflicts)
        {
            InitializeComponent();
            _conflicts = conflicts;
        }

        private void FormConflict_Load(object sender, EventArgs e)
        {
            foreach (Conflict conflict in _conflicts)
            {
                dataGridView.Rows.Add(new string[] { conflict.File, conflict.PackName });
            }
        }
    }
}
