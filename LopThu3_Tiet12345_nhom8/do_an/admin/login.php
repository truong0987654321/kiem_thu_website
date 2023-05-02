<?php
session_start();
if	(isset($_SESSION['username'])){
	if($_SESSION['phanquyen']==1){
		header("location:../index.php");
	}
	if($_SESSION['phanquyen']==0){
		header("location:trang1.php");
	}
}
?>
<link rel="stylesheet" href="css/admin.css">

<?php
include("../db/ketnoi.php");

if(isset($_POST['login']))
{
    $username = $_POST['user'];
    $password = md5($_POST['pass']);
    $sql_check = mysqli_query($con,"select * from khachhang where tentaikhoan = '$username'");
    $dem = mysqli_num_rows($sql_check);
    if($dem == 0)
    {
        echo "
            <script language='javascript'>
                alert('Tài khoản không tồn tại');
            </script>
        ";
    }
    else
    {
        $sql_check2 = "select * from khachhang where tentaikhoan = '$username' and password = '$password'";
		$row=mysqli_query($con,$sql_check2);	
        $dem2 = mysqli_num_rows($row);
        if($dem2 == 0)
            echo "
                <script language='javascript'>
                    alert('Mật khẩu không chính xác');
                </script>
            ";
        else
        {
	
		 while($rows = mysqli_fetch_array($row))
            {
              	$_SESSION['username'] = $username;
				$_SESSION['phanquyen'] = $rows['phanquyen'];
				$_SESSION['idnd'] = $rows['id_kh'];
                if($rows['phanquyen'] == 0)
                {
                    
					echo "
							<script language='javascript'>
								alert('Đăng nhập quản trị thành công');
								window.open('trang1.php','_self', 1);
							</script>
						";
                }
                else
                {
                    
					header('location:../index.php');
                }
            }
        }
    }
}
?>
<section>
    <div class="leaves">
        <img src="../anh/background_login.jpg" class="bg_login">
        <div class="login">
			<h2>Đăng nhập quản trị</h2>
		
            <form action="" method="post">
                <div class="inputbox">
                    <input type="text" name="user" placeholder=" Username" autofocus>
                </div>
                <div class="inputbox">
                    <input type="password" name="pass" placeholder=" Password">
                </div>
                <div class="inputbox">
                    <button name="login" class="dangnhap">Đăng nhập</button>
                </div>
                <div class="group">
                    <div class="thoat">
                        <a href="../index.php">Thoát</a>
                    </div>
                </div>
            </form>
        </div>
    </div>
</section>