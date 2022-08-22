using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CrimeMgmnt.Models;
using CrimeMgmnt.Controllers;
using FluentAssertions;
using Xunit.Abstractions;

namespace Crime.xUnitTestProject
{
    public partial class CyberCellsApiTests
    {
        [Fact]
        public void GetControllRoom_OkResult()
        {
            // 1. ARRANGE
            var dbName = nameof(CyberCellsApiTests.GetControllRoom_OkResult);
            var logger = Mock.Of<ILogger<CyberCellsController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!

            var controller = new CyberCellsController(dbContext, logger);

            // 2. ACT
            IActionResult actionResultGet = controller.GetControlRoom().Result;

            // 3. ASSERT
            // ---- Check if the IActionResult is OK (HTTP 200)
            Assert.IsType<OkObjectResult>(actionResultGet);

            // ---- If the Status Cose is HTTP 200 "OK"
            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
            var actualStatusCode = (actionResultGet as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }


        [Fact]
        public void GetControllRoom_CheckCorrectResult()
        {
            // ARRANGE
            var dbName = nameof(CyberCellsApiTests.GetControllRoom_CheckCorrectResult);
            var logger = Mock.Of<ILogger<CyberCellsController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!

            var controller = new CyberCellsController(dbContext, logger);

            // ACT
            IActionResult actionResultGet = controller.GetControlRoom().Result;

            // ASSERT if the IActionResult is OK (HTTP 200)
            Assert.IsType<OkObjectResult>(actionResultGet);

            // Extract the result from the IActionResut object
            var okResult = actionResultGet.Should().BeOfType<OkObjectResult>().Subject;

            // ASSERT if OkResult contains an object of the correct type
            Assert.IsAssignableFrom<List<CyberCell>>(okResult.Value);

            // Extract the ControllRoom from the result of the action.
            var ControllRoom = okResult.Value.Should().BeAssignableTo<List<CyberCell>>().Subject;

            // ASSERT if ControllRoom is NOT NULL
            Assert.NotNull(ControllRoom);

            // ASEERT if number of ControllRoom matches with the TEST Data
            Assert.Equal(expected: DbContextMocker.TestData_ControllRoom.Length,
                         actual: ControllRoom.Count);

            // ASSERT if data is correct
            int ndx = 0;
            foreach (CyberCell cybercell in DbContextMocker.TestData_ControllRoom)
            {
                Assert.Equal<int>(expected: cybercell.ControlRoomId,
                                  actual: ControllRoom[ndx].ControlRoomId);
                _testOutputHelper.WriteLine($"Row # {ndx} OKAY");
                ndx++;
            }
        }

    }
}
