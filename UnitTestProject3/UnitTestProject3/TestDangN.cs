using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace testDn
{
    [TestClass]

    public class TestDangN
    {
        private IWebDriver driver;
        private readonly string baseUrl = "http://localhost/Lopthu3_Tiet12345_Nhom8/do_an/index.php?act=dn#chihuong";
        [TestInitialize ]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void Dn1() {
            driver.Navigate().GoToUrl(baseUrl);

            //đăng nhập admin đúng 
            driver.FindElement(By.Id("username")).SendKeys(text: "admin");
            driver.FindElement(By.Id("password")).SendKeys(text: "admin");
            driver.FindElement(By.Id("login-btn")).Click();

            //lấy thông báo trả về 
            IAlert thongbao = driver.SwitchTo().Alert();
            string thongtext = thongbao.Text;

            //kết quả mông đợi
            string thongbaoMm = "Đăng nhập vào trang quản trị thành công";

            //so sánh kết quả
            if (thongtext == thongbaoMm)
            {
                Assert.IsTrue(thongtext==thongbaoMm);
            }
            else
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void Dn5()
        {
            driver.Navigate().GoToUrl(baseUrl);

            //đăng nhập không nhập tài khoản
            driver.FindElement(By.Id("username")).SendKeys(text: "");
            driver.FindElement(By.Id("password")).SendKeys(text: "admin");
            driver.FindElement(By.Id("login-btn")).Click();

            //lấy thông báo trả về 
            IAlert thongbao = driver.SwitchTo().Alert();
            string thongtext = thongbao.Text;

            //kết quả mông đợi 
            string thongbaoMm = "Tài khoản không được bỏ trống";

            //so sánh
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

