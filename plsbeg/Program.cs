using WindowsInput;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;

namespace plsbeg
{
    class Program
    {
        static IWebElement element;

        static async Task Main()
        {
            var bot = new ClientSideDiscordBot.Program();
            var gmail = ClientSideDiscordBot.Program.gmail;
            var password = ClientSideDiscordBot.Program.password;
            var discordLink = bot.discordBegLink;

            var options = new ChromeOptions();
            options.AddArguments("--headless");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(discordLink.ToString());
                await Simulate.Events().Wait(1000).Invoke();

                if (driver.Url != discordLink.ToString())
                {
                    ClientSideDiscordBot.Program.Login(element, driver, gmail, password);
                }

                await Simulate.Events().Wait(6200).Invoke(); // Waits 6.2 seconds

                if (driver.Url == discordLink.ToString())
                {
                    while (true) // Loops the send method
                    {
                        // Send Bar element
                        var sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                        sendbar.Click();
                        sendbar.SendKeys("pls beg");
                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);
                        await Simulate.Events().Wait(30000).Invoke();
                    }
                }
            }
        }
    }
}
