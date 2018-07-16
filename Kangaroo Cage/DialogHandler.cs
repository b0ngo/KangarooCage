using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kangaroo_Cage
{
    public static class DialogHandler
    {
        public static void ShowMessage(string content, string headline)
        {
            MessageBox.Show(content, headline, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string content, string headline)
        {
            headline = "Error: " + headline;
            MessageBox.Show(content, headline, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowAbout()
        {
            AboutBox about = new AboutBox();
            about.StartPosition = FormStartPosition.CenterScreen;
            about.ShowDialog();
        }
    }
}
