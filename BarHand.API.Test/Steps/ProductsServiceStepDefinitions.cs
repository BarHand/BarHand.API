using System.Net;
using System.Net.Mime;
using System.Text;
using BarHand.API.Inventory.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace BarHand.API.Test.Steps;

[Binding]
public class ProductsServiceStepDefinitions : WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ProductsServiceStepDefinitions(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    private Task<HttpResponseMessage> Response { get; set; }
    [Given(@"the EndPoint https://localhost:(.*)/api/v(.*)/products is available")]
    public void GivenTheEndPointHttpsLocalhostApiVProductsIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/{version}/products");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }

    [When(@"a Post Request is sent")]
    public void WhenAPostRequestIsSent(Table saveProductResource)
    {
        var resource = saveProductResource.CreateSet<SaveProductResource>();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"A Response is received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"a Product Resource is included in Response Body")]
    public async void ThenAProductResourceIsIncludedInResponseBody(Table expectedProductResource)
    {
        var expectedResource = expectedProductResource.CreateSet<ProductResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<ProductResource>(responseData);
        Assert.Equal(expectedResource.Name, resource.Name);
    }

    [Given(@"A Product is already stored")]
    public async void GivenAProductIsAlreadyStored(Table saveProductResource)
    {
        var resource = saveProductResource.CreateSet<SaveProductResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var responseResource = new ProductResource();
        try
        {
            responseResource = JsonConvert.DeserializeObject<ProductResource>(responseData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        Assert.Equal(resource.Name, responseResource.Name);
    }


    [Then(@"Error Message is returned with value ""(.*)""")]
    public void ThenErrorMessageIsReturnedWithValue(string expectedMessage)
    {
        var message = Response.Result.Content.ReadAsStringAsync().Result;
        Assert.Equal(expectedMessage, message);
    }
}