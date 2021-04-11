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
        public void findUrl_ShouldReturnUrlInfo_WhenUrlExists(string url)
        {
            // Arrange
            UrlInfo expectedUrlInfo = new UrlInfo()
            {
                Id = "testId1",
                DateAdded = new DateTime(2020, 4, 10, 12, 30, 30, 350),
                Url = url
            };

            _databaseMock.Setup(x => x.ReadByUrlRequest(url)).Returns(expectedUrlInfo);

            // Act
            UrlInfo urlInfo = _urlLookupService.findUrl(url);

            // Assert
            Assert.Equal(expectedUrlInfo, urlInfo);
        }

        [Theory]
        [InlineData("urlinfo/1/does/not/exist")]
        [InlineData(null)]
        public void findUrl_ShouldReturnNothing_WhenUrlDoesNotExist(string url)
        {
            // Arrange
            _databaseMock.Setup(x => x.ReadByUrlRequest(It.IsAny<string>())).Returns(() => null);

            // Act
            UrlInfo urlInfo = _urlLookupService.findUrl(url);

            // Assert
            Assert.Null(urlInfo);
        }

        [Theory]
        [InlineData(1, null)]
        [InlineData(1, "")] // string with empty host
        [InlineData(0, null)]
        [InlineData(0, "validHost")]
        [InlineData(null, null)]
        [InlineData(2, "validHost")]
        public void isRequestInvalid_ShouldReturnTrue_WhenInvalid(int version, string host)
        {
            // Arrange
            UrlInfoRequest request = new UrlInfoRequest() { Version = version, Host = host };

            // Act
            bool result = _urlLookupService.isRequestInvalid(request);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(1, "validHost")] 
        [InlineData(1.0, "h")]
        [InlineData(1, "host.com:8080")]
        public void isRequestInvalid_ShouldReturnFalse_WhenValid(int version, string host)
        {
            // Arrange
            UrlInfoRequest request = new UrlInfoRequest() { Version = version, Host = host };

            // Act
            bool result = _urlLookupService.isRequestInvalid(request);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(1, "http://testsite.com:8080/urlinfo/1/test/path?test=query", "test/path?test=query")]
        [InlineData(1, "https://testsite.com:8080/urlinfo/1/test/path?test=query", "test/path?test=query")]
        [InlineData(1, "https://testsite.com:8080/urlinfo/1/urlinfo/1/urlinfo/1", "urlinfo/1/urlinfo/1")]
        [InlineData(1, "testsite.com:8080/urlinfo/1/test/path?test=query", "test/path?test=query")]
        [InlineData(1, "www.testsite.com:8080/urlinfo/1/test/path?test=query", "test/path?test=query")]
        [InlineData(1, "http://testsite.com/urlinfo/1/test/path?test=query", "test/path?test=query")]
        public void getUriFromRequest_ShouldReturnUri_WhenGivenRawRequests(int version, string rawRequest, string url)
        {
            // Arrange
            UrlInfoRequest request = new UrlInfoRequest() { Version = version, RawRequest = rawRequest };

            // Act
            string result = _urlLookupService.getUriFromRequest(request);

            // Assert
            Assert.Equal(url, result);
        }
    }
}
