using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PowerCore.Class
{



    public class Result
    {

        public bool status = false;
        public string msg = "";

        public List<string> List = new List<string>();

        public DataTable data = new DataTable();

        public Result()
        {
            data.Columns.Add("File Name");
            data.Columns.Add("Status");
        }

    }


}
