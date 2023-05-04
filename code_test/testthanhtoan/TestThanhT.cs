using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace testthanhtoan
{
    [TestClass]
    public class TestThanhT
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
        public void TT1()
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

            //click vào "cho vỏ hàng" ở sản phẩm Samsung Galaxy A32 4G 6GB/128GB
            IWebElement btn2 = driver.FindElements(By.TagName("button"))[15];
            btn2.Click();

            //bỏ qua thông báo
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào giỏ hàng
            driver.FindElement(By.Id("testgiohang")).Click();

            //click vào thanh toán
            driver.FindElement(By.Id("thanhtoantest")).Click();

            //nhập thông tin đặt hàng
            IWebElement tenkh = driver.FindElement(By.Id("tenKHtest"));
            tenkh.Clear();
            tenkh.SendKeys(text: "Đạt Nguyễn");
            IWebElement diachi = driver.FindElement(By.Id("diachitest"));
            diachi.Clear();
            diachi.SendKeys(text: "2/6 Xóm Chiếu P9 Q10 Thành Phố Hồ Chí Minh ");
            IWebElement sdt = driver.FindElement(By.Id("sdttest"));
            sdt.Clear();
            sdt.SendKeys(text: "0938472090");
            IWebElement email = driver.FindElement(By.Id("emailtest"));
            email.Clear();
            email.SendKeys(text: "abc@gmail.com");
            IWebElement selecttk = driver.FindElement(By.Id("slphuongthuc"));
            IWebElement otk = selecttk.FindElements(By.Id("chonphuongthuc"))[3];
            otk.Click();
            driver.FindElement(By.Id("dathangtest")).Click();

            //láy nội dung thông báo test 
            IAlert thongbao = driver.SwitchTo().Alert();
            string thongtext = thongbao.Text;

            //test mông đợi
            string thongbaoMm = "Đơn Hàng Thiết Lập Thành Công.";
            if (thongtext == thongbaoMm)
            {
                Assert.IsTrue(thongtext == thongbaoMm);
            }
            else
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void TT7()
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

            //click vào "cho vỏ hàng" ở sản phẩm Samsung Galaxy A32 4G 6GB/128GB
            IWebElement btn2 = driver.FindElements(By.TagName("button"))[15];
            btn2.Click();

            //bỏ qua thông báo
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào giỏ hàng
            driver.FindElement(By.Id("testgiohang")).Click();

            //click vào thanh toán
            driver.FindElement(By.Id("thanhtoantest")).Click();

            //nhập thông tin đặt hàng
            IWebElement tenkh = driver.FindElement(By.Id("tenKHtest"));
            tenkh.Clear();
            tenkh.SendKeys(text: "Đạt Nguyễn");
            IWebElement diachi = driver.FindElement(By.Id("diachitest"));
            diachi.Clear();
            diachi.SendKeys(text: "2/6 Xóm Chiếu P9 Q10 Thành Phố Hồ Chí Minh ");
            IWebElement sdt = driver.FindElement(By.Id("sdttest"));
            sdt.Clear();
            sdt.SendKeys(text: "0938472090");
            IWebElement email = driver.FindElement(By.Id("emailtest"));
            email.Clear();
            IWebElement selecttk = driver.FindElement(By.Id("slphuongthuc"));
            IWebElement otk = selecttk.FindElements(By.Id("chonphuongthuc"))[3];
            otk.Click();
            driver.FindElement(By.Id("dathangtest")).Click();

            //láy nội dung thông báo test 
            IAlert thongbao = driver.SwitchTo().Alert();
            string thongtext = thongbao.Text;

            //test mông đợi
            string thongbaoMm = "Đơn Hàng Thiết Lập Thành Công.";
            if (thongtext != thongbaoMm)
            {
                Assert.IsTrue(thongtext == thongbaoMm);
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
