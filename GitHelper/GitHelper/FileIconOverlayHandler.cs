using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using SharpShell.Attributes;
using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;

namespace GitHelper.FileIconOverlayHandler.Handlers
{
    [ComVisible(true)]
    [DisplayName("Git Folder Overlay Handler")]
    [COMServerAssociation(AssociationType.Directory)]
    public class FileIconOverlayHandler : SharpIconOverlayHandler
    {
        /// <summary>
        /// Called by the system to get the priority, which is used to determine
        /// which icon overlay to use if there are multiple handlers. The priority
        /// must be between 0 and 100, where 0 is the highest priority.
        /// </summary>
        /// <returns>
        /// A value between 0 and 100, where 0 is the highest priority.
        /// </returns>
        protected override int GetPriority()
        {
            //  We're very low priority.
            return 20;
        }

        /// <summary>
        /// Determines whether an overlay should be shown for the shell item with the path 'path' and
        /// the shell attributes 'attributes'.
        /// </summary>
        /// <param name="path">The path for the shell item. This is not necessarily the path
        /// to a physical file or folder.</param>
        /// <param name="attributes">The attributes of the shell item.</param>
        /// <returns>
        ///   <c>true</c> if this an overlay should be shown for the specified item; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            string git_path = Path.Combine(path, ".git");
            if (Directory.Exists(git_path))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Called to get the icon to show as the overlay icon.
        /// </summary>
        /// <returns>
        /// The overlay icon.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override System.Drawing.Icon GetOverlayIcon()
        {
            return Properties.GitFolderIcon;
        }

 
    }

}
