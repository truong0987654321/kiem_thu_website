using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Text.RegularExpressions;

namespace testlichsudonhang
{
    [TestClass]
    public class TestLichSuDonH
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
        public void LSDH1()
        {
            // Mở trang web cần đọc
            driver.Navigate().GoToUrl(baseUrl);

            //các bước đăng nhập tài khoản khách hàng
            driver.FindElement(By.Id("username")).SendKeys(text: "truong123");
            driver.FindElement(By.Id("password")).SendKeys(text: "truong");
            driver.FindElement(By.Id("login-btn")).Click();

            //bỏ qua thông báo
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào trang sản phẩm
            driver.FindElement(By.Id("sanphamtest")).Click();

            //click vào "cho vỏ hàng" ở sản phẩm có tên "Samsung Galaxy A32 4G 6GB/128GB"
            IWebElement firstButton = driver.FindElements(By.TagName("button"))[15];
            firstButton.Click();

            //bỏ qua thông báo
            alert.Accept();
            driver.Navigate().Refresh();

            //click giỏ hàng
            driver.FindElement(By.Id("testgiohang")).Click();

            //click tiêp tục mua hàng
            driver.FindElement(By.Id("tieptucmuahang")).Click();

            //click vào trang sản phẩm
            driver.FindElement(By.Id("sanphamtest")).Click();

            //click vào "cho vỏ hàng" ở sản phẩm có tên "iPhone 13 Pro Max 128GB"
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

            //click tên tài khoản khi đăng nhập
            driver.FindElement(By.Id("lichsuhoadon_a")).Click();

            //dọc thẻ td lưu vào mảng
            IWebElement tr = driver.FindElements(By.TagName("tr"))[1];
            var elements = tr.FindElements(By.TagName("td")).ToArray();

            //mông đợi hiển thị  tên khách hàng đã nhập lúc nãy 
            string s = "test test";
            for (int i = 2; i < elements.Length - 2; i++)
            {

                var ht = elements[i].Text;
                if (ht == s)
                {
                    Assert.IsTrue(ht == s);
                }
                else
                {

                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        public void LSDH3()
        {
            // Mở trang web cần đọc
            driver.Navigate().GoToUrl(baseUrl);
            //các bước đăng nhập
            driver.FindElement(By.Id("username")).SendKeys(text: "truong123");
            driver.FindElement(By.Id("password")).SendKeys(text: "truong");
            driver.FindElement(By.Id("login-btn")).Click();

            //bỏ qua thông báo
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào trang sản phẩm
            driver.FindElement(By.Id("sanphamtest")).Click();

            //click vào "cho vỏ hàng" ở sản phẩm có tên "Samsung Galaxy A32 4G 6GB/128GB"
            IWebElement firstButton = driver.FindElements(By.TagName("button"))[15];
            firstButton.Click();

            //bỏ qua thông báo
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào giỏ hàng
            driver.FindElement(By.Id("testgiohang")).Click();

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

            //click tên tài khoản khi đăng nhập
            driver.FindElement(By.Id("lichsuhoadon_a")).Click();

            //dọc thẻ td lưu vào mảng
            IWebElement tr = driver.FindElements(By.TagName("tr"))[1];
            var elements = tr.FindElements(By.TagName("td")).ToArray();

            //click vào td cụ thể là CHI TIẾT 
            for (int i = 1; i < elements.Length; i++)
            {
                elements[4].Click();
                break;
            }
            //dọc thẻ td lưu vào mảng
            var trchitietsp = driver.FindElements(By.TagName("tr")).ToArray();
            string str2 = "hủy đơn hàng";

            int count = 0;
            for (int i = 1; i < trchitietsp.Length; i++)
            {
                var tdchitietsp = trchitietsp[i].FindElements(By.TagName("td")).ToArray();

                for (int j = 0; j < tdchitietsp.Length; j++)
                {
                    var ht = Regex.Replace(tdchitietsp[j].Text, @"\.", "");
                    if (ht.Contains(str2))
                    {
                        count++;
                    }
                }
            }
            if (count != 0)
            {
                Assert.IsTrue(count != 0);  
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
