using Microsoft.Extensions.Configuration;
using NameSorter.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NameSorter.Business
{
    public class Sorter : ISorter
    {
        private readonly IConfiguration _config;

        public Sorter(IConfiguration config)
        {
            _config = config;
        }
        public List<string> SortingList()
        {
            var text = new List<string>();
            //you can change directory on appsettings.json
            string path = _config.GetSection("AppSettings:Path").Value;
            List<string> lines = new List<string>();
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        lines.Add(s);
                    }
                }
            }

            var fullname = new List<NameModel>();
            foreach (var name in lines)
            {
                var first = name.Split(" ").First().Trim();
                var last = name.Split(" ").Last().Trim();
                var middle = name.Replace(first, "").Replace(last, "");
                fullname.Add(new NameModel
                {
                    FirstName = first,
                    MiddleName = middle,
                    LastName = last
                });
            }
            var datas = fullname.OrderBy(x => x.LastName).ToList();
            List<string> returndata = new List<string>();
            foreach (var data in datas)
            {
                if (data.MiddleName == "" && (data.FirstName == data.LastName))
                {
                    returndata.Add(data.FirstName);
                }
                else
                {
                    returndata.Add(data.FirstName + " " + data.MiddleName + " " + data.LastName);
                }
            }

            string Newpath = _config.GetSection("AppSettings:NewPath").Value;
            // Create a file to write/overwrite to.
            File.WriteAllLines(Newpath, returndata, Encoding.UTF8);

            return returndata;
        }
    }
}
