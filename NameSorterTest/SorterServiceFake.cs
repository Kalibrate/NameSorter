using Microsoft.AspNetCore.Mvc;
using NameSorter.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorterTest
{
    public class SorterServiceFake : ISorter
    {
        private readonly List<string> _sorter;
        public SorterServiceFake()
        {
            _sorter = new List<string>()
            {
                "Hailey  Avie  Annakin",
                "Erna  Dorey  Battelle",
                "Selle   Bellison"
            };
        }

        public List<string> SortingList()
        {
            return _sorter;
        }
    }
}
