# URL-Lookup
Web service that responds to GET requests where the caller wants information about a Malicious URL.

## Technologies Used
**Web Service:** ASP.NET Core 3.1 Web API
**Database:** Atlas Mongo Database
**Authentication:** Request Header API Key

## Installation Instructions
1. Clone the repo to your local environment
2. Install the .NET Core SDK from https://docs.microsoft.com/en-us/dotnet/core/install/ and follow instructions for your OS
3. Build the application by navigating to the UrlLookup.API project folder and running `dotnet build`
4. To run the application, go into the UrlLookup.API project folder and run `dotnet run` from cmd prompt
5. To run the tests, go into the UrlLookup.API.UnitTests project folder and run `dotnet test` from cmd prompt

## Instructions for how to use Web Service
- Perform GET requests using https://localhost:5001 
- Momentarily disable SSL Certificate Verification on your localhost
- Use the following GET request format
  - GET /urlinfo/1/{hostname_and_port}/{original_path_and_query_string}
- API Key
  - Add a Request Header "ApiKey" for authorization (contact javierbalandran@gmail.com for api key)
  - If you do not, the service will send a 401 Unauthorized response
- Below are a few known URLs in the database to test with (request access to Atlas MongoDb for full visibility):
  - testhost.com:80/test/path?test=query&second+query
  - gnu.org/vivamus/vel/nulla.jsp?volutpat=ultrices&in=vel&congue=augue&etiam=vestibulum&justo=ante&etiam=ipsum&pretium=primis&iaculis=in&justo=faucibus&in=orci&hac=luctus&habitasse=et&platea=ultrices&dictumst=posuere&etiam=cubilia&faucibus=curae&cursus=donec&urna=pharetra&ut=magna&tellus=vestibulum&nulla=aliquet&ut=ultrices&erat=erat&id=tortor&mauris=sollicitudin&vulputate=mi&elementum=sit&nullam=amet&varius=lobortis&nulla=sapien&facilisi=sapien
  - friendfeed.com/justo/eu.aspx?eu=luctus&orci=ultricies&mauris=eu&lacinia=nibh&sapien=quisque&quis=id
  - soup.io/quis/lectus/suspendisse.png?erat=aliquet&id=maecenas&mauris=leo&vulputate=odio&elementum=condimentum&nullam=id&varius=luctus&nulla=nec&facilisi=molestie&cras=sed&non=justo&velit=pellentesque&nec=viverra&nisi=pede&vulputate=ac&nonummy=diam&maecenas=cras&tincidunt=pellentesque&lacus=volutpat&at=dui&velit=maecenas&vivamus=tristique&vel=est&nulla=et&eget=tempus&eros=semper&elementum=est&pellentesque=quam&quisque=pharetra&porta=magna&volutpat=ac&erat=consequat&quisque=metus&erat=sapien&eros=ut&viverra=nunc&eget=vestibulum&congue=ante&eget=ipsum&semper=primis&rutrum=in&nulla=faucibus&nunc=orci&purus=luctus&phasellus=et&in=ultrices&felis=posuere
  
For further questions, please email javierbalandran@gmail