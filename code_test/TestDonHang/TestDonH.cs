using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

using System.Threading;
using System.Text.RegularExpressions;
using System.Linq;

namespace TestDonHang
{
    [TestClass]
    public class TestDonH
    {
        private IWebDriver driver;
        private readonly string baseUrl = "http://localhost/Lopthu3_Tiet12345_Nhom8/do_an/index.php?act=dn#chihuong";
        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void DH1()
        {
            driver.Navigate().GoToUrl(baseUrl);

            //đăng nhập khách hàng
            driver.FindElement(By.Id("username")).SendKeys(text: "truong123");
            driver.FindElement(By.Id("password")).SendKeys(text: "truong");
            driver.FindElement(By.Id("login-btn")).Click();

            //bỏ thông báo
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.Navigate().Refresh();

            //click trang sản phẩm
            driver.FindElement(By.Id("sanphamtest")).Click();

            //click vào sẳm phẩm bất kỳ ,cụ thể là Samsung Galaxy A32 4G 6GB/128GB
            IWebElement firstButton = driver.FindElements(By.TagName("button"))[15];
            firstButton.Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào sẳm phẩm bất kỳ ,cụ thể là iPhone 13 Pro Max 128GB
            IWebElement btn2 = driver.FindElements(By.TagName("button"))[1];
            btn2.Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào giỏ hàng
            driver.FindElement(By.Id("testgiohang")).Click();

            //thay đổi số lượng
            IWebElement slgh = driver.FindElements(By.TagName("input"))[0];
            slgh.Clear();
            slgh.SendKeys(text: "2");

            //click update
            IWebElement clickcn = driver.FindElements(By.TagName("input"))[2];
            clickcn.Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //click thanh toán 
            driver.FindElement(By.Id("thanhtoantest")).Click();

            //nhập thông tin đặt hàng
            IWebElement tenkh = driver.FindElement(By.Id("tenKHtest"));
            tenkh.Clear();
            tenkh.SendKeys(text: "test test");
            IWebElement diachi = driver.FindElement(By.Id("diachitest"));
            diachi.Clear();
            diachi.SendKeys(text: "88 address, city");
            IWebElement sdt = driver.FindElement(By.Id("sdttest"));
            sdt.Clear();
            sdt.SendKeys(text: "0123456789");
            IWebElement email = driver.FindElement(By.Id("emailtest"));
            email.Clear();
            email.SendKeys(text: "test@test.ts");
            IWebElement selecttk = driver.FindElement(By.Id("slphuongthuc"));
            IWebElement otk = selecttk.FindElements(By.Id("chonphuongthuc"))[3];
            otk.Click();
            driver.FindElement(By.Id("dathangtest")).Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //thoát đăng nhập
            driver.FindElement(By.Id("thoattest")).Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //đăng nhập vào admin
            driver.FindElement(By.Id("dntest")).Click();
            driver.FindElement(By.Id("username")).SendKeys(text: "admin");
            driver.FindElement(By.Id("password")).SendKeys(text: "admin");
            driver.FindElement(By.Id("login-btn")).Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào đơn hàng
            driver.FindElement(By.Id("donghangtest")).Click();

            //truy cập vào bảo hiển thị
            IWebElement tr = driver.FindElements(By.TagName("tr"))[1];
            var elements = tr.FindElements(By.TagName("td")).ToArray();

            //test mông đợi
            string testmd1 = "test test";
            string testmd2 = "88 address, city";
            string testmd3 = "0123456789";
            string testmd4 = "test@test.ts";
            string testmd5 = "Đang xử lý";
            string testmd6 = "Thanh toán trực tiếp";
            string[] str2 = { testmd1, testmd2, testmd3, testmd4, testmd5 ,testmd6};

            int cout = 0;
            for (int i = 2; i < elements.Length - 1; i++)
            {

                var ht = elements[i].Text;

                bool containsString = str2.Any(s => ht.Contains(s));
                if (containsString)
                {
                    cout++;
                }
            }
            if (cout == str2.Length)
            {
                Assert.IsTrue(cout==str2.Length);
            }
            else
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void DH2()
        {
            driver.Navigate().GoToUrl(baseUrl);

            //đăng nhập khách hàng
            driver.FindElement(By.Id("username")).SendKeys(text: "truong123");
            driver.FindElement(By.Id("password")).SendKeys(text: "truong");
            driver.FindElement(By.Id("login-btn")).Click();

            //bỏ qua thông báo 
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào trang sản phẩm
            driver.FindElement(By.Id("sanphamtest")).Click();

            //click vào sẳm phẩm bất kỳ ,cụ thể là Samsung Galaxy A32 4G 6GB/128GB
            IWebElement firstButton = driver.FindElements(By.TagName("button"))[15];
            firstButton.Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào sẳm phẩm bất kỳ ,cụ thể là iPhone 13 Pro Max 128GB
            IWebElement btn2 = driver.FindElements(By.TagName("button"))[1];
            btn2.Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào giỏ hàng
            driver.FindElement(By.Id("testgiohang")).Click();

            //đổi số lượng
            IWebElement slgh = driver.FindElements(By.TagName("input"))[0];
            slgh.Clear();
            slgh.SendKeys(text: "2");

            //click cập nhật 
            IWebElement clickcn = driver.FindElements(By.TagName("input"))[2];
            clickcn.Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //click thanh toán
            driver.FindElement(By.Id("thanhtoantest")).Click();

            //nhập thông tin đặt hàng
            IWebElement tenkh = driver.FindElement(By.Id("tenKHtest"));
            tenkh.Clear();
            tenkh.SendKeys(text: "test test");
            IWebElement diachi = driver.FindElement(By.Id("diachitest"));
            diachi.Clear();
            diachi.SendKeys(text: "88 address, city");
            IWebElement sdt = driver.FindElement(By.Id("sdttest"));
            sdt.Clear();
            sdt.SendKeys(text: "0123456789");
            IWebElement email = driver.FindElement(By.Id("emailtest"));
            email.Clear();
            email.SendKeys(text: "test@test.ts");
            IWebElement selecttk = driver.FindElement(By.Id("slphuongthuc"));
            IWebElement otk = selecttk.FindElements(By.Id("chonphuongthuc"))[3];
            otk.Click();
            driver.FindElement(By.Id("dathangtest")).Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //thoát đăng nhập
            driver.FindElement(By.Id("thoattest")).Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //đăng nhập admin
            driver.FindElement(By.Id("dntest")).Click();
            driver.FindElement(By.Id("username")).SendKeys(text: "admin");
            driver.FindElement(By.Id("password")).SendKeys(text: "admin");
            driver.FindElement(By.Id("login-btn")).Click();

            //bỏ qua thông báo 
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào đơn hàng
            driver.FindElement(By.Id("donghangtest")).Click();

            //click vào xem chi tiết đơn hàng
            IWebElement tr = driver.FindElements(By.TagName("tr"))[1];
            IWebElement td6 = tr.FindElements(By.TagName("td"))[7];
            td6.Click();

            //kết quả mông đợi
            string textmd0 = "Samsung Galaxy A32 4G 6GB/128GB";
            string textmd1 = "2";
            string textmd2 = "5970800";
            string textmd3 = "11941600";
            string textmd20 = "iPhone 13 Pro Max 128GB";
            string textmd21 = "1";
            string textmd22 = "29571300";
            string textmd23 = "29571300";
            string textmd30 = "41512900";
            string[] str2 = { textmd0, textmd1, textmd2, textmd3, textmd20, textmd21, textmd22, textmd23, textmd30 };
            var trchitietsp = driver.FindElements(By.TagName("tr")).ToArray();


            int cout = 0;
            for (int i = 1; i < trchitietsp.Length; i++)
            {
                var tdchitietsp = trchitietsp[i].FindElements(By.TagName("td")).ToArray();
                for (int j = 1; j < tdchitietsp.Length; j++)
                {
                    string text = Regex.Replace(tdchitietsp[j].Text, @"\.", "").Replace("\r\n<< Về", "").Replace("Tổng: ", "");

                    bool containsString = str2.Any(s => text.SequenceEqual(s));

                    if (containsString)
                    {
                        cout++;
                    }
                }
            }
            if (cout == str2.Length)
            {
                Assert.IsTrue(cout == str2.Length);
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
