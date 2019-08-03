using Microsoft.AspNetCore.Mvc;
using NameSorter.Business;
using NameSorter.Controllers;
using System;
using Xunit;

namespace NameSorterTest
{
    public class SorterTest
    {
        private SorterController _controller;
        private ISorter _service;
        public SorterTest()
        {
            _service = new SorterServiceFake();
            _controller = new SorterController(_service);
        }

        [Fact]
        public void Test1()
        {
            // Ack
            var okresult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okresult.Result);
        }
    }
}
