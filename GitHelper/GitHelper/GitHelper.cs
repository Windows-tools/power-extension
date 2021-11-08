using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System.Collections.Generic;

using System.Linq;
using GitHelper;

namespace GitHelper.ContextMenu.GitHelper
{

    [ComVisible(true)]
    [COMServerAssociation(AssociationType.Directory)]
    public class GitHelper : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            if(SelectedItemPaths.Count() == 1)
            {
                foreach (var dirpath in SelectedItemPaths)
                {
                    string git_path =  Path.Combine(dirpath, ".git");
                    if(Directory.Exists(git_path))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected override ContextMenuStrip CreateMenu()
        {
            //  Create the menu strip.
            var menu = new ContextMenuStrip();

            //  Create a 'count lines' item.
            var itemCountLines = new ToolStripMenuItem
            {
                Text = "Git Status Stack Copy" ,
                ToolTipText = "git status stack all files will be copy",
                Image = Properties.git
            };

            //  When we click, we'll count the lines.
            itemCountLines.Click += (sender, args) => CopyGitStatus();

            //  Add the item to the context menu.
            menu.Items.Add(itemCountLines);

            //  Return the menu.
            return menu;
        }

        private void CopyGitStatus()
        {
            try
            {
                string working_dir = SelectedItemPaths.ToArray()[0];

                var res = PowerCore.Library.Git.git_diff_Status_files_copy(working_dir);

                if(res.status)
                {
                    MessageBox.Show("Successfully copy total " + res.data.Rows.Count.ToString() + " files." , "Successfully copy git stack",MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
                else
                {
                    MessageBox.Show("Error ", res.msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (System.Exception  e)
            {
                MessageBox.Show("Error ", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }

}
