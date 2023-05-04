using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MySql.Data.MySqlClient;
using System.Threading;
using System;

namespace testDk
{
    [TestClass]
    public class TestDangK
    {
        private IWebDriver driver;
        private readonly string baseUrl = "http://localhost/Lopthu3_Tiet12345_Nhom8/do_an/index.php?act=dk#chihuong";

        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void Dk1()
        {
            driver.Navigate().GoToUrl(baseUrl);
            //nhập đúng đăng ký
            driver.FindElement(By.Id("tendnhap")).SendKeys(text: "nhom06");
            driver.FindElement(By.Id("tennguoidung")).SendKeys(text: "nhom06");
            driver.FindElement(By.Id("matkhau")).SendKeys(text: "nhom06");
            driver.FindElement(By.Id("nhaplaimatkhau")).SendKeys(text: "nhom06");
            driver.FindElement(By.Id("ngaysinh")).SendKeys(text: "09/08/2002");
            driver.FindElement(By.Id("email")).SendKeys(text: "nhom06@gmail.com");
            driver.FindElement(By.Id("dienthoai")).SendKeys(text: "0917171717");
            driver.FindElement(By.Id("diachi")).SendKeys("6 nguyễn trãi quận 5");
            driver.FindElement(By.Id("btn_dangky")).Click();

            //lấy kết quả thông báo trả về 
            IAlert thongbao = driver.SwitchTo().Alert();
            string thongtext = thongbao.Text;

            //kết quả mông đợi
            string thongbaoMm = "Bạn đã đăng ký thành công";

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

        [TestMethod]
        public void Dk9()
        {
            //truy cập xampp
            string connectionString = "Server=localhost;Database=do_an;User Id=root";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            //thay đổi mật khẩu
            string passtest = "th2";
            string query = "UPDATE `khachhang` SET `password` = '" + passtest + "' WHERE `khachhang`.`id_kh` = 111;";
            MySqlCommand commandud = new MySqlCommand(query, connection);
            commandud.ExecuteNonQuery();

            //chọn tài khoản có id 111 vừa đổi ở trên
            MySqlCommand command = new MySqlCommand("SELECT password FROM khachhang WHERE id_kh = '111'", connection);

            // thực hiện kiểm tra nếu như đởi thành công mà mật kẩu ko được mã hóa thì fail
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string password = reader.GetString(0);
                    if (password != passtest)
                    {
                        Assert.IsTrue(password != passtest);
                    }
                    else
                    {
                        Assert.Fail();
                    }
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

