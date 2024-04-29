using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.ViewModel;
using client.Model;
using Moq;
using ViewModel.Interfaces;
using FluentAssertions;

namespace Tests.ViewModelTests
{
    public class AllDistrictsViewModelTests
    {
        private IEnumerable<District> GenerateDistrictList()
        {
            IEnumerable<District> districts = new List<District>() {new District("first", 1, 1),
                                                                   new District("second", 2, 2),
                                                                   new District("third", 1, 3),};
            return districts;
        }

        [Fact]
        public async Task ConstructorLoadDistricts_Success_CorrectAmountOfDistricts()
        {
            IEnumerable<District> districts = GenerateDistrictList();
            var mockServive = new Mock<IDistrictService>();
            mockServive.Setup(s => s.GetDistricts()).ReturnsAsync(districts);

            var allDistrictsViewModel = new AllDistrictsViewModel(mockServive.Object);
            int res = allDistrictsViewModel.Districts.Count;

            res.Should().Be(3);
        }
        [Theory]
        [InlineData("first", 1, 1)]
        [InlineData("second", 2, 2)]
        [InlineData("third", 1, 3)]
        public async Task ConstructorLoadDistricts_Success_CorrectDataInObject(string name, int mainSalesmanId, int id)
        {
            IEnumerable<District> districts = GenerateDistrictList();
            var mockServive = new Mock<IDistrictService>();
            mockServive.Setup(s => s.GetDistricts()).ReturnsAsync(districts);

            var allDistrictsViewModel = new AllDistrictsViewModel(mockServive.Object);
            var res = allDistrictsViewModel.Districts.First(d => d.Id == id);

            res.Name.Should().Be(name);
            res.MainSalesmanId.Should().Be(mainSalesmanId);
        }
    }
}
