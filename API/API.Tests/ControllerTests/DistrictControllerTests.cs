using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Controllers;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace API.Tests.ControllerTests
{
    public class DistrictControllerTests
    {
        [Fact]
        public async Task GetDistricts_ReturnsOk_ReturnsDistrictsIEnumerable()
        {
            var mockRepository = new Mock<IDistrictRepository>();
            var districtController = new DistrictController(mockRepository.Object);
            IEnumerable<District> districts = new List<District>
            {
                new District(1, "test", 1),
                new District(2, "test", 2)
            };
            mockRepository.Setup(mock => mock.GetAllDistrics()).ReturnsAsync(districts);

            var res = await districtController.GetDistricts();

            res.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetDistricts_ReturnsBadRequest_ThrowsExpection()
        {
            var mockRepository = new Mock<IDistrictRepository>();
            var districtController = new DistrictController(mockRepository.Object);

            mockRepository.Setup(mock => mock.GetAllDistrics()).Throws(new Exception());

            var res = await districtController.GetDistricts();

            res.Should().BeOfType<BadRequestObjectResult>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(Int32.MinValue)]
        public async Task AddSalesmanToDistrict_ReturnsBadResult_RowsAffectedIsZeroOrLess(int value)
        {
            var mockRepository = new Mock<IDistrictRepository>();
            var districtController = new DistrictController(mockRepository.Object);
            mockRepository.Setup(mock => mock.AddSalesManToDistrict(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(value);

            var res = await districtController.AddSalesManToDistrict(1, "test", true);

            res.Should().BeOfType<BadRequestObjectResult>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(Int32.MaxValue)]
        public async Task AddSalesmanToDistrict_ReturnsOkResult_RowsAffectedIsGreaterThanZero(int value)
        {
            var mockRepository = new Mock<IDistrictRepository>();
            var districtController = new DistrictController(mockRepository.Object);
            mockRepository.Setup(mock => mock.AddSalesManToDistrict(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(value);

            var res = await districtController.AddSalesManToDistrict(1, "test", true);

            res.Should().BeOfType<OkResult>();
        }
           
        // Test Infrastructure with Database Fixture

    }
}
