using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace testGioH
{
    [TestClass]
    public class TestGioH
    {
        private IWebDriver driver;
        private readonly string baseUrl = "http://localhost/Lopthu3_Tiet12345_Nhom8/do_an/index.php?act=sp#chihuong";
        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void Gh4()
        {
            driver.Navigate().GoToUrl(baseUrl);

            //click mua sản phẩm bất kỳ cụ thể là sản phẩm dầu tiên
            IWebElement firstButton = driver.FindElements(By.TagName("button"))[1];
            firstButton.Click();

            //bỏ qua thông báo
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào giỏ hàng
            driver.FindElement(By.Id("testgiohang")).Click();

            //thay đổi số lượng
            IWebElement slgh = driver.FindElements(By.TagName("input"))[0];
            slgh.Clear();
            slgh.SendKeys(text: "3");

            //click cập nhật
            driver.FindElement(By.Id("cnspGH")).Click();

            //lấy thông báo
            IAlert thongbao = driver.SwitchTo().Alert();
            string thongtext = thongbao.Text;

            //kết quả thông báo mông đợi
            string thongbaoMm = "cập nhật thành công";
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
        public void Gh6()
        {
            driver.Navigate().GoToUrl(baseUrl);

            //click mua sản phẩm bất kỳ cụ thể là sản phẩm dầu tiên
            IWebElement firstButton = driver.FindElements(By.TagName("button"))[1];
            firstButton.Click();

            //bỏ qua thông báo
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.Navigate().Refresh();

            //click vào giỏ hàng
            driver.FindElement(By.Id("testgiohang")).Click();

            //thay đổi số lượng
            IWebElement slgh = driver.FindElements(By.TagName("input"))[0];
            slgh.Clear();
            slgh.SendKeys(text: "-5");

            //click vào cập nhật
            driver.FindElement(By.Id("cnspGH")).Click();

            //lấy thông báo 
            IAlert thongbao = driver.SwitchTo().Alert();
            string thongtext = thongbao.Text;

            //kết quả thông báo mông đợi
            string thongbaoMm = "Giá trị nhập không hợp lệ";

            if (thongtext == thongbaoMm)
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
