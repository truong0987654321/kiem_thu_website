using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;

namespace timkiem
{
    [TestClass]
    public class TesttimK
    {
        private IWebDriver driver;
        private readonly string baseUrl = "http://localhost/Lopthu3_Tiet12345_Nhom8/do_an/index.php";

        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void Tk8()
        {
            
            driver.Navigate().GoToUrl(baseUrl);
            //thao tác nhập và nhấn tìm kiếm
            string d = "iphone";
            driver.FindElement(By.Id("timkiemsp")).SendKeys(text: d);
            IWebElement selecttk = driver.FindElement(By.Id("stimkiem"));
            IWebElement otk = selecttk.FindElements(By.Id("otkiem"))[2];
            otk.Click();
            driver.FindElement(By.Id("btn_timkiem")).Click();
            
            //láy kết quả kiếm từ thể div có id là timkiemtest dưới dạng số
            IWebElement kqtk = driver.FindElement(By.Id("timkiemsp"));
            string sokqtk = kqtk.Text;
            int number = int.Parse(sokqtk);

            IList<IWebElement> divElements = driver.FindElements(By.TagName("div"));

            // Lặp qua danh sách các phần tử div và tìm tất cả các phần tử h4 con của chúng
            foreach (IWebElement divElement in divElements)
            {
                IList<IWebElement> h4Elements = divElement.FindElements(By.Id("giasanphamtk"));

                // Lặp qua tất cả các phần tử h4 và lấy văn bản bên trong của chúng
                foreach (IWebElement h4Element in h4Elements)
                {
                    string text = h4Element.Text;
                    string cleanedText = Regex.Replace(text, @"[^\d,]+", "");
                    int cltextnumber = int.Parse(cleanedText);
                    //kiẻm tra xem nó có sản phẩm ko có nằm trong giá trị đã chọn không
                    if (number>0 && cltextnumber > 1000000 && cltextnumber < 3000000)
                    {
                        Assert.IsTrue(number != 0);
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }




            
        }
        [TestMethod]
        public void Tk2()
        {
            driver.Navigate().GoToUrl(baseUrl);
            //thao tác tìm kiếm
            string d = "@#$";
            driver.FindElement(By.Id("timkiemsp")).SendKeys(text: d);
            driver.FindElement(By.Id("btn_timkiem")).Click();

            //láy kết quả kiếm từ thể div có id là timkiemtest dưới dạng số
            IWebElement psadas = driver.FindElement(By.Id("timkiemsp"));
            string dsds = psadas.Text;
            int number = int.Parse(dsds);
            //nếu nó bằng 0
            if (number == 0)
            {
                Assert.IsTrue(number == 0);
            }
            else
            {
                Assert.Fail();
            }

        }

        [TestCleanup]
        public void TestCleanup()
        {

           driver.Quit();
        }
    }
}
