using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;
using PowerCore.Class;

namespace PowerCore.Library
{
    public class Git
    {

        public static Result git_diff_Status_files_copy(string localRepoFolder , string localRepoStatusDirname = "git_diff_status_files" )
        {
            Result res = new Result();

            if( Directory.Exists(localRepoFolder) == false )
            {
                res.msg = "Folder does not exist " + localRepoFolder;
                return res;
            }


            String dest_path = Path.Combine(localRepoFolder, localRepoStatusDirname);

            Repository repo = new Repository(localRepoFolder);


            if ( Directory.Exists(dest_path) == true )
            {
                Directory.Delete(dest_path, true);
            }
            Directory.CreateDirectory(dest_path);

            
            List<StatusEntry> files = repo.RetrieveStatus(new StatusOptions() { }).ToList< StatusEntry>();

            foreach (var item in files )
            {
                string source_file = Path.Combine(repo.Info.WorkingDirectory, item.FilePath);
                string dest = Path.Combine(dest_path, item.FilePath);

                res.data.Rows.Add(item.FilePath, item.State);

                string directoryPath = Path.GetDirectoryName(dest);

                // If directory doesn't exist create one
                if (!Directory.Exists(directoryPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(directoryPath);
                }

                File.Copy(source_file, dest, true);
            }

            res.status = true;

            return res;
        }


    }

}
