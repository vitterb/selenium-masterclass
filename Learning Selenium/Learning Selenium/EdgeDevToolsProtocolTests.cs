using Learning_Selenium.Configuration;
using Learning_Selenium.Utils;
using OpenQA.Selenium;
using System.Text;

namespace Learning_Selenium
{
    internal class EdgeDevToolsProtocolTests : BaseTest
    {
        private OpenQA.Selenium.DevTools.DevToolsSession session;

        [SetUp]
        public override void Setup()
        {
            SetDriver(CreateDriver(ConfigurationProvider.Configuration["browser"]));
            var devtools = GetDriver() as OpenQA.Selenium.DevTools.IDevTools;
            session = devtools.GetDevToolsSession();
        }

        [Test]
        [Category("Tests without assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public async Task EmulateDeviceModeTest()
        {
            var deviceModeSetting = new OpenQA.Selenium.DevTools.V117.Emulation.SetDeviceMetricsOverrideCommandSettings
            {
                Width = 400,
                Height = 600,
                DeviceScaleFactor = 2,
                Mobile = true
            };
            await session.GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V117.DevToolsSessionDomains>()
                .Emulation
                .SetDeviceMetricsOverride(deviceModeSetting);
            GetDriver().Navigate().GoToUrl("http://localhost:4200");
            Thread.Sleep(5000);
        }

        [Test]
        [Category("Tests without assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public async Task EmulateNetworkConditionTest()
        {
            var networkConditions = new OpenQA.Selenium.DevTools.V117.Network.EmulateNetworkConditionsCommandSettings()
            {
                DownloadThroughput = 1000
            };
            await session.GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V117.DevToolsSessionDomains>()
                .Network
                .EmulateNetworkConditions(networkConditions);

            GetDriver().Navigate().GoToUrl("https://selenium.dev");
        }

        [Test]
        [Category("Tests without assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public async Task EmulateGeolocation()
        {
            var geolocation = new OpenQA.Selenium.DevTools.V117.Emulation.SetGeolocationOverrideCommandSettings()
            {
                Latitude = 51.07492,
                Longitude = 4.83430,
                Accuracy = 1
            };
            await session.GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V117.DevToolsSessionDomains>()
                .Emulation
                .SetGeolocationOverride(geolocation);
            GetDriver().Navigate().GoToUrl("https://maps.google.com");
            IWebElement acceptAllButton = GetDriver().FindElement(By.CssSelector("[aria-label='Alles accepteren']"));
            acceptAllButton.Click();
            var element = new Wait(GetDriver())
                .WaitForTheElementToBecomeVisible(By.CssSelector("#mylocation #sVuEFc"), TimeSpan.FromSeconds(10));
            element.Click();
            Thread.Sleep(10000);
        }

        [Test]
        [Category("Tests without assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public async Task InterceptNetworkRequestsTest()
        {
            var fetch = session.GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V117.DevToolsSessionDomains>()
                .Fetch;

            var enableCommandSettings = new OpenQA.Selenium.DevTools.V117.Fetch.EnableCommandSettings();

            var requestPattern = new OpenQA.Selenium.DevTools.V117.Fetch.RequestPattern
            {
                RequestStage = OpenQA.Selenium.DevTools.V117.Fetch.RequestStage.Request,
                ResourceType = OpenQA.Selenium.DevTools.V117.Network.ResourceType.XHR,
                UrlPattern = "*/workshops.json"
            };

            enableCommandSettings.Patterns = new OpenQA.Selenium.DevTools.V117.Fetch.RequestPattern[] { requestPattern };

            await fetch.Enable(enableCommandSettings);

            async void requestIntercepted(object sender, OpenQA.Selenium.DevTools.V117.Fetch.RequestPausedEventArgs e)
            {
                await fetch.FulfillRequest(new OpenQA.Selenium.DevTools.V117.Fetch.FulfillRequestCommandSettings()
                {
                    RequestId = e.RequestId,
                    Body = Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    """
                    [
                        { "id": 1, "name": "Workshop 1", "price": 400, "checked": false },
                        { "id": 2, "name": "Workshop 2", "price": 200, "checked": false },
                        { "id": 3, "name": "Workshop 3", "price": 300, "checked": false }
                    ]
                    """)),
                    ResponseCode = 200
                });
            }

            fetch.RequestPaused += requestIntercepted;

            GetDriver().Navigate().GoToUrl("http://localhost:4200");

            Thread.Sleep(10000);
        }
    }
}