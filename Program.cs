using System;
using WindowsInput;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace ClientSideDiscordBot
{
    public class Program
    {
        public static string gmail = @""; // Username / Gmail
        public static string password = @""; // Password

        public string discordBegLink = @"https://discordapp.com/channels/676916182653206548/676922973835493396"; // The link for the begbot
        
        static IWebElement element;

        static async Task Main()
        {
            var start = true;

            var rand = new Random();
            var correctGuess = rand.Next(1, 11);

            var discordLink = @"https://discordapp.com/channels/676916182653206548/686009518639153152"; // main discord link
            var discordCountLink = @"https://discordapp.com/channels/676916182653206548/686786013154115654"; // the count link for the command ;count

            var restart = @"F:\VSRepos\VSStudio\C#\ClientSideDiscordBot\bin\Debug\" + "ClientSideDiscordBot.exe"; // Path for discord bot
            var plsbeg = @"F:\VSRepos\VSStudio\C#\ClientSideDiscordBot\bin\Debug\" + "plsbeg.exe"; // path for beg bot

            var options = new ChromeOptions();
            options.AddArguments("--headless");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(discordLink.ToString());
                await Simulate.Events().Wait(1000).Invoke();

                if (driver.Url != discordLink.ToString())
                {
                    Login(element, driver, gmail, password);
                }

                await Simulate.Events().Wait(6200).Invoke(); // Wait 6.2 seconds, not needed but used for releasing stress on CPU

                if (driver.Url == discordLink.ToString() || driver.Url == discordCountLink.ToString())
                {
                    while (start)
                    {
                        try
                        {
                            // Message Box Container
                            element = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > div.messagesWrapper-3lZDfY.group-spacing-16 > div > div"));
                            // Messages in the message box
                            var elementCount = element.FindElements(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > div.messagesWrapper-3lZDfY.group-spacing-16 > div > div > div"));
                            // Send Bar element
                            var sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));

                            for (int i = elementCount.Count; i < elementCount.Count + 1; i++) // Takes the element count and gets the newest messgae
                            {
                                // The newest messages in a loop
                                element = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > div.messagesWrapper-3lZDfY.group-spacing-16 > div > div > div:nth-child(" + i.ToString() + ")"));

                                try
                                {
                                    // Taking the inner text of the elements
                                    var commands = element.Text.ToString();

                                    if (commands.Contains(";cmds") || commands.Contains(";help"))
                                    {
                                        sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                        sendbar.Click();
                                        sendbar.SendKeys("Commands: ");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Enter); // Makes a new line in discord

                                        sendbar.SendKeys("Remove spaces to execute commands! ");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Enter);

                                        sendbar.SendKeys("; test // This command anyone can use!");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Enter);

                                        /*sendBar.SendKeys("; start begbot // this only work for the main users acc!");
                                        sendBar.SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Enter);

                                        sendBar.SendKeys("; stop begbot // this only works for the main users acc!");
                                        sendBar.SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Enter);*/

                                        sendbar.SendKeys("; ping // this works for anyone *pings the user*");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Enter);

                                        sendbar.SendKeys("; date // this works for anyone shows the date");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Enter);

                                        sendbar.SendKeys("; restart // this works for anyone restarts the bot");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Enter);

                                        sendbar.SendKeys("; game (guessNumber) - 1-10 // this works for anyone starts game to put my pc to sleep gl!");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Enter);

                                        sendbar.SendKeys("; msg (message) // this works for anyone prints out a custom message");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Enter);

                                        sendbar.SendKeys("; count Min, Max // this works for anyone switches to the counting channel and counts");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);
                                    }

                                    if (commands.Contains(";test"))
                                    {
                                        sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                        sendbar.Click();
                                        sendbar.SendKeys("Test");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);
                                    }

                                    if (commands.Contains(";start begbot"))
                                    {
                                        sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                        sendbar.Click();
                                        sendbar.SendKeys("BOT: Beg Bot Started");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);

                                        Process.Start(plsbeg); // Starts the beg bot process
                                    }

                                    if (commands.Contains(";stop begbot"))
                                    {
                                        sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                        sendbar.Click();
                                        sendbar.SendKeys("BOT: Beg Bot Stopped");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);

                                        ProcessID.EndProcess(@"plsbeg"); // Ends the process
                                    }

                                    if (commands.Contains(";withdraw"))
                                    {
                                        sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                        sendbar.Click();
                                        sendbar.SendKeys("pls share @Xenial.-#6404 250");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);
                                    }

                                    if (commands.Contains(";ping"))
                                    {
                                        sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                        sendbar.Click();
                                        sendbar.SendKeys("BOT: PINGED");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);

                                        Console.Beep(); // Uses the console to send a beep noise to the hosts pc
                                    }

                                    if (commands.Contains(";date"))
                                    {
                                        var time = DateTime.Today.ToLongDateString();
                                        sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                        sendbar.Click();
                                        sendbar.SendKeys(time.ToString());
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);
                                    }

                                    if (commands.Contains(";ans")) // Gets the answer for the game
                                    {
                                        Console.WriteLine("Answer: " + correctGuess);
                                        sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                        sendbar.Click();
                                        sendbar.SendKeys("Ans printed to console!");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);
                                    }

                                    if (commands.Contains(";msg")) // Sends back user messages
                                    {
                                        var msg = commands.Substring(commands.IndexOf((";"))); // Starts a new string at the index of ; << /0
                                        msg = msg.Remove(0, 5); // removes the ;msg + the space

                                        sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                        sendbar.Click();
                                        sendbar.SendKeys("Sending!");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);
                                        sendbar.Click();
                                        sendbar.SendKeys(msg); // Sends the new string out to the user
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);
                                    }

                                    if (commands.Contains(";count"))
                                    {
                                        var msg = commands.Substring(commands.IndexOf((";"))); // Starts a new string at the index of ; << /0
                                        msg = msg.Remove(0, 7); // removes the ;count + the space

                                        // Starts at the other side of the number and removes the rest of the string
                                        var minNum = int.Parse(msg.Remove(msg.IndexOf(","), commands.Substring(commands.IndexOf(",")).Length));

                                        msg = commands.Substring(commands.IndexOf(",")); // Starts a new string at the index of , << /0
                                        var maxNum = int.Parse(msg.Remove(0, 2)); // Removes the space and only uses the numbers in the string

                                        sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                        sendbar.Click();
                                        sendbar.SendKeys("Counting!");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);

                                        driver.Navigate().GoToUrl(discordCountLink.ToString()); // It first goes to the counting channel in the discord then begins counting

                                        if (driver.Url == discordCountLink.ToString()) // Only works if its in the Counting Channel
                                        {
                                            await Simulate.Events().Wait(4000).Invoke(); // Waits 4 secs to make sure the site is fully loaded

                                            for (int x = minNum; x < maxNum + 1; x++)
                                            {
                                                sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                                sendbar.Click();
                                                sendbar.SendKeys(x.ToString());
                                                sendbar.SendKeys(OpenQA.Selenium.Keys.Enter);
                                                await Simulate.Events().Wait(800).Invoke();
                                            }

                                            driver.Navigate().GoToUrl(discordLink.ToString()); // Once it ends it goes back to the main discord channel
                                        }
                                    }

                                    if (commands.Contains(";game"))
                                    {
                                        if (commands.Contains(";game " + correctGuess))
                                        {
                                            sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                            sendbar.Click();
                                            sendbar.SendKeys("Correct!");
                                            sendbar.SendKeys(OpenQA.Selenium.Keys.Return);

                                            correctGuess = rand.Next(1, 11);
                                            Sleep();
                                            break;
                                        }
                                        else
                                        {
                                            sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                            sendbar.Click();
                                            sendbar.SendKeys("Wrong! Game Ended");
                                            sendbar.SendKeys(OpenQA.Selenium.Keys.Return);

                                            correctGuess = rand.Next(1, 11);
                                            break;
                                        }
                                    }

                                    if (commands.Contains(";restart"))
                                    {
                                        sendbar = driver.FindElement(By.CssSelector(@"#app-mount > div.app-1q1i1E > div > div.layers-3iHuyZ.layers-3q14ss > div > div > div > div.content-98HsJk > div.chat-3bRxxu > div.content-yTz4x3 > div.chatContent-a9vAAp > form > div > div > div > div.textArea-12jD-V.textAreaSlate-1ZzRVj.slateContainer-3Qkn2x > div.markup-2BOw-j.slateTextArea-1Mkdgw.fontSize16Padding-3Wk7zP"));
                                        sendbar.Click();
                                        sendbar.SendKeys("Restarting Bot!");
                                        sendbar.SendKeys(OpenQA.Selenium.Keys.Return);

                                        Process.Start(restart); // Starts a new process of the bot
                                        ProcessID.EndProcess("ClientSideDiscordBot"); // Ends the old process
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Error");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Failed");
                        }
                    }
                }
            }
        }

        public static void Sleep()
        {
            Application.SetSuspendState(PowerState.Suspend, true, false);
        }

        public static async void Login(IWebElement element, IWebDriver driver, string gmail, string password)
        {
            element = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/form/div/div/div[1]/div[3]/div[1]/div/input")); // Username / Gmail Box Element
            element.Click();
            element.SendKeys(gmail); // Username / Gamil
            await Simulate.Events().Wait(1000).Invoke(); // Wait 1 second
            element = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/form/div/div/div[1]/div[3]/div[2]/div/input")); // Password Box Element
            element.Click();
            element.SendKeys(password); // Password
            element.Submit();
        }
    }
}
