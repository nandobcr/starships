using Moq;
using Xunit;
using Domain;
using System.IO;
using System.Linq;
using App.StarShips;
using Newtonsoft.Json;
using Infra.Exceptions;
using System.Reflection;

namespace Test.App
{
    public class StarShipServiceTest
    {
        private readonly StarShipService starShipService;

        public StarShipServiceTest()
        {
            IStarShip starShipMock = CriarMockStarShip();
            this.starShipService = new StarShipService(starShipMock);
        }

        [Fact]
        public void ShouldReturnY_wingAnd74StopsWhenTheDistanceEqual1MillionWhenPageEquals1()
        {
            string url = GetUrl("page1.json");
            StarShipDTO starShipDTOExpected = CreateStarShip("page2.json", "Y-wing", 74);
            StarShipItemDTO starShipItemDTOExpected = starShipDTOExpected.StarShipItemDTO.First();

            StarShipDTO starShipDTO = this.starShipService.GetStopsRequired("1000000", url);

            StarShipItemDTO starShipItemDTO = starShipDTO.StarShipItemDTO
                .Where(s => s.Name.Equals(starShipItemDTOExpected.Name)).FirstOrDefault();
            
            Assert.Equal(starShipDTOExpected.NextPage, starShipDTO.NextPage);
            Assert.Equal(starShipItemDTOExpected.Name, starShipItemDTO.Name);
            Assert.Equal(starShipItemDTOExpected.StopsRequired, starShipItemDTO.StopsRequired);
        }

        [Fact]
        public void ShouldReturnMilleniumFalconAnd9StopsWhenTheDistanceEqual1MillionWhenPageEquals1()
        {
            string url = GetUrl("page1.json");
            StarShipDTO starShipDTOExpected = CreateStarShip("page2.json", "Millennium Falcon", 9);
            StarShipItemDTO starShipItemDTOExpected = starShipDTOExpected.StarShipItemDTO.First();

            StarShipDTO starShipDTO = this.starShipService.GetStopsRequired("1000000", url);

            StarShipItemDTO starShipItemDTO = starShipDTO.StarShipItemDTO
                .Where(s => s.Name.Equals(starShipItemDTOExpected.Name)).FirstOrDefault();
            
            Assert.Equal(starShipDTOExpected.NextPage, starShipDTO.NextPage);
            Assert.Equal(starShipItemDTOExpected.Name, starShipItemDTO.Name);
            Assert.Equal(starShipItemDTOExpected.StopsRequired, starShipItemDTO.StopsRequired);
        }

        [Fact]
        public void ShouldReturnRebelTransportAnd11StopsWhenTheDistanceEqual1MillionWhenPageEquals1()
        {
            string url = GetUrl("page1.json");
            StarShipDTO starShipDTOExpected = CreateStarShip("page2.json", "Rebel transport", 11);
            StarShipItemDTO starShipItemDTOExpected = starShipDTOExpected.StarShipItemDTO.First();

            StarShipDTO starShipDTO = this.starShipService.GetStopsRequired("1000000", url);

            StarShipItemDTO starShipItemDTO = starShipDTO.StarShipItemDTO
                .Where(s => s.Name.Equals(starShipItemDTOExpected.Name)).FirstOrDefault();
            
            Assert.Equal(starShipDTOExpected.NextPage, starShipDTO.NextPage);
            Assert.Equal(starShipItemDTOExpected.Name, starShipItemDTO.Name);
            Assert.Equal(starShipItemDTOExpected.StopsRequired, starShipItemDTO.StopsRequired);
        }

        [Fact]
        public void ShouldReturnSlave1TransportAnd49StopsWhenTheDistanceEqual2MillionAnd500ThousandWhenPageEquals2()
        {
            string url = GetUrl("page2.json");
            StarShipDTO starShipDTOExpected = CreateStarShip("page3.json", "Slave 1", 49);
            StarShipItemDTO starShipItemDTOExpected = starShipDTOExpected.StarShipItemDTO.First();

            StarShipDTO starShipDTO = this.starShipService.GetStopsRequired("2500000", url);

            StarShipItemDTO starShipItemDTO = starShipDTO.StarShipItemDTO
                .Where(s => s.Name.Equals(starShipItemDTOExpected.Name)).FirstOrDefault();
            
            Assert.Equal(starShipDTOExpected.NextPage, starShipDTO.NextPage);
            Assert.Equal(starShipItemDTOExpected.Name, starShipItemDTO.Name);
            Assert.Equal(starShipItemDTOExpected.StopsRequired, starShipItemDTO.StopsRequired);
        }

        [Fact]
        public void ShouldReturnB_wingTransportAnd163StopsWhenTheDistanceEqual2MillionAnd500ThousandWhenPageEquals2()
        {
            string url = GetUrl("page2.json");
            StarShipDTO starShipDTOExpected = CreateStarShip("page3.json", "B-wing", 163);
            StarShipItemDTO starShipItemDTOExpected = starShipDTOExpected.StarShipItemDTO.First();

            StarShipDTO starShipDTO = this.starShipService.GetStopsRequired("2500000", url);

            StarShipItemDTO starShipItemDTO = starShipDTO.StarShipItemDTO
                .Where(s => s.Name.Equals(starShipItemDTOExpected.Name)).FirstOrDefault();
            
            Assert.Equal(starShipDTOExpected.NextPage, starShipDTO.NextPage);
            Assert.Equal(starShipItemDTOExpected.Name, starShipItemDTO.Name);
            Assert.Equal(starShipItemDTOExpected.StopsRequired, starShipItemDTO.StopsRequired);
        }        

        [Fact]
        public void ShouldReturnRepublicAttackCruiserTransportAndNegative1StopsWhenTheDistanceEqual150ThousandAndMgltUnknowWhenPageEquals3()
        {
            string url = GetUrl("page3.json");
            StarShipDTO starShipDTOExpected = CreateStarShip("page4.json", "Republic attack cruiser", -1);
            StarShipItemDTO starShipItemDTOExpected = starShipDTOExpected.StarShipItemDTO.First();

            StarShipDTO starShipDTO = this.starShipService.GetStopsRequired("150000", url);

            StarShipItemDTO starShipItemDTO = starShipDTO.StarShipItemDTO
                .Where(s => s.Name.Equals(starShipItemDTOExpected.Name)).FirstOrDefault();
            
            Assert.Equal(starShipDTOExpected.NextPage, starShipDTO.NextPage);
            Assert.Equal(starShipItemDTOExpected.Name, starShipItemDTO.Name);
            Assert.Equal(starShipItemDTOExpected.StopsRequired, starShipItemDTO.StopsRequired);
        }

        [Fact]
        public void ShouldReturnNabooStarSkiffTransportAndNegative1StopsWhenTheDistanceEqual150ThousandAndConsumablesUnknowWhenPageEquals4()
        {
            string url = GetUrl("page4.json");
            StarShipDTO starShipDTOExpected = CreateStarShip(null, "Naboo star skiff", -1);
            StarShipItemDTO starShipItemDTOExpected = starShipDTOExpected.StarShipItemDTO.First();

            StarShipDTO starShipDTO = this.starShipService.GetStopsRequired("150000", url);

            StarShipItemDTO starShipItemDTO = starShipDTO.StarShipItemDTO
                .Where(s => s.Name.Equals(starShipItemDTOExpected.Name)).FirstOrDefault();
            
            Assert.Equal(starShipDTOExpected.NextPage, starShipDTO.NextPage);
            Assert.Equal(starShipItemDTOExpected.Name, starShipItemDTO.Name);
            Assert.Equal(starShipItemDTOExpected.StopsRequired, starShipItemDTO.StopsRequired);
        }

        [Fact]
        public void ShouldThrowsDistanceInvalidExceptionWhenDistanceIsNotOnlyNumbers()
        {
            string url = GetUrl("page4.json");
            Assert.Throws<DistanceInvalidException>(() => this.starShipService.GetStopsRequired("123million", url));
        }

        private IStarShip CriarMockStarShip()
        {
            var mock = new Mock<IStarShip>();
            mock.Setup(starshipMock => starshipMock.GetStarShips(It.IsAny<string>()))
                .Returns<string>(url => GetStarShips(url));

            return mock.Object;
        }

        private StarShip GetStarShips(string url)
        {
            StarShip starShip = JsonConvert.DeserializeObject<StarShip>(File.ReadAllText(url));
            return starShip;
        }

        private string GetUrl(string fileName)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(path, "Resource", fileName);
        }

        private StarShipDTO CreateStarShip(string nextPage, string starShipName, int stopsRequired)
        {
            StarShipDTO starShipDTO = new StarShipDTO();
            starShipDTO.NextPage = nextPage;
            
            StarShipItemDTO starShipItemDTO = new StarShipItemDTO();
            starShipItemDTO.Name = starShipName;
            starShipItemDTO.StopsRequired = stopsRequired;

            starShipDTO.StarShipItemDTO.Add(starShipItemDTO);

            return starShipDTO;
        }
    }
}