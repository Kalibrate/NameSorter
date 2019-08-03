using NameSorter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NameSorter.Business
{
    public interface ISorter
    {
        List<string> SortingList();
    }
}
