using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Text.RegularExpressions;
using System.Linq;

namespace TestSp
{
    [TestClass]
    public class TestSanP
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
        public void SP1()
        {
            driver.Navigate().GoToUrl(baseUrl);

            //click vào trang sản phẩm
            driver.FindElement(By.Id("sanphamtest")).Click();

            //chọn sản phẩm 
            IWebElement firstButton = driver.FindElements(By.TagName("a"))[45];
            firstButton.Click();

            //lấy  giá trị bên trong thẻ p và b có id lần lượt là testtenSP và testgiaSP
            IWebElement p = driver.FindElement(By.Id("testtenSP"));
            IWebElement b = driver.FindElement(By.Id("testgiaSP"));
            string value = p.Text;
            string value2 = b.Text;

            //bó hết đấu chấm giữa các só và chuyển thành số
            string cleanedText = Regex.Replace(value2, @"[^\d,]+", "");
            int cltextnumber = int.Parse(cleanedText);

            //kết quả mông đợi
            string testten = "SAMSUNG GALAXY A32 4G 6GB/128GB";
            int giasp = 5970800;

            //nếu như tên và giá trùng nhau trên trang sản phẩm 
            if (cltextnumber == giasp && value == testten)
            {
                Assert.IsTrue(value == testten);
            }
            else
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void SP5()
        {
            driver.Navigate().GoToUrl(baseUrl);
            //đăng nhập admin
            driver.FindElement(By.Id("dntest")).Click();
            driver.FindElement(By.Id("username")).SendKeys(text: "admin");
            driver.FindElement(By.Id("password")).SendKeys(text: "admin");
            driver.FindElement(By.Id("login-btn")).Click();

            //bỏ qua thông báo
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.Navigate().Refresh();

            //nhấn vào sản phẩm
            driver.FindElement(By.Id("nhansanpham")).Click();

            //nhấn vào sửa
            IWebElement tr = driver.FindElements(By.TagName("tr"))[1];
            var tdsua = tr.FindElements(By.TagName("a"))[0];
            tdsua.Click();

            //thay đổi số lượng
            var soluong = driver.FindElement(By.Name("soluong"));
            soluong.Clear();
            soluong.SendKeys(text: "100000000100000000");

            //click vào update
            var update = driver.FindElement(By.Name("update"));
            update.Click();

            //bỏ qua thông báo
            alert.Accept();
            driver.Navigate().Refresh();

            //truy cập td hiển thị số lượng sản phẩm vừa sửa 
            IWebElement tr1 = driver.FindElements(By.TagName("tr"))[1];
            var elements = tr1.FindElements(By.TagName("td")).ToArray();
            
            //kết quả mong đợi
            string s = "100000000100000000";

            //set td hiển thị số lượng 
            for (int i = 3; i < elements.Length - 4; i++)
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
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
