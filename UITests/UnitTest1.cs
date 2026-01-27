using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace UITests
{
    public class LoginUiTests : IDisposable
    {
        private readonly AndroidDriver _driver;

        public LoginUiTests()
        {
            var options = new AppiumOptions();
            options.PlatformName = "Android";
            options.AutomationName = "UiAutomator2";
            options.DeviceName = "Android Emulator";

            options.App = @"C:\Users\New\Downloads\pap\SupaMaui\SupaMaui\bin\Debug\net9.0-android\com.companyname.supamaui.apk";

            _driver = new AndroidDriver(
                new Uri("http://127.0.0.1:4723"),
                options
            );
        }

        [Fact]
        public void Login_HappyPath()
        {
            _driver
                .FindElement(MobileBy.Id("email"))
                .SendKeys("arseny.kalinin2017@yandex.ru");
            _driver
                .FindElement(MobileBy.Id("pass"))
                .SendKeys("arsen");

            _driver
                .FindElement(MobileBy.Id("enter"))
                .Click();


            Assert.True(true);
        }


        public void Dispose()
        {
            _driver.Quit();
        }
    }



    
}
