using System;
using UrlLookup.API.Data;
using Xunit;
using Moq;
using UrlLookup.API.Services;
using UrlLookup.API.Models;

namespace UrlLookup.API.UnitTests
{
    public class UrlLookupServiceTests
    {
        private readonly UrlLookupService _urlLookupService;
        private readonly Mock<IUrlInfoDatabase> _databaseMock = new Mock<IUrlInfoDatabase>();

        public UrlLookupServiceTests()
        {
            _urlLookupService = new UrlLookupService(_databaseMock.Object);
        }

        [Theory]
        [InlineData("testhost.com:80/test/path?test=query&second+query")] // normal uri
        [InlineData("test.com/test/path?test=query")] // no port
        [InlineData("h/p")] // short urls
        [InlineData("test.com")]// long Urls
        [InlineData("test.com/test/path")] //missing query string
        [InlineData("10.127.0.0:80/test/path")] // host is ipaddress
        public void FindUrl_ShouldReturnUrlInfo_WhenUrlExists(string url)
        {
            // Arrange
            UrlInfo expectedUrlInfo = new UrlInfo()
            {
                Id = "testId1",
                DateAdded = new DateTime(2020, 4, 10, 12, 30, 30, 350),
                UrlName = url
            };

            _databaseMock.Setup(x => x.ReadByUrlRequest(url)).Returns(expectedUrlInfo);

            // Act
            UrlInfo urlInfo = _urlLookupService.FindUrl(url);

            // Assert
            Assert.Equal(expectedUrlInfo, urlInfo);
        }

        [Theory]
        [InlineData("urlinfo/1/does/not/exist")]
        [InlineData(null)]
        public void FindUrl_ShouldReturnNothing_WhenUrlDoesNotExist(string url)
        {
            // Arrange
            _databaseMock.Setup(x => x.ReadByUrlRequest(It.IsAny<string>())).Returns(() => null);

            // Act
            UrlInfo urlInfo = _urlLookupService.FindUrl(url);

            // Assert
            Assert.Null(urlInfo);
        }
    }
}
