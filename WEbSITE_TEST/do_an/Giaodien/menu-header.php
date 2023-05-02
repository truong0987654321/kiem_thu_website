<?php

?>

<div id="menu">
	<ul>
		<li><a href="index.php">TRANG CHỦ</a></li>
		<li><a href="index.php?act=gt">GIỚI THIỆU</a></li>
		<li><a id="sanphamtest" href="index.php?act=sp#chihuong">SẢN PHẨM</a></li>
		<li><a href="index.php?act=pk">PHỤ KIỆN</a></li>
		<li><a href="index.php?act=ht">HỖ TRỢ</a></li>
		<?php if(isset($_SESSION['username'])){	
		?>
		<div id="dndk">
			<li id="xinchao">
				
				<?php 
					if(isset($_SESSION['idnd'])){
				$sql=mysqli_query($con,"select * from khachhang where id_kh='".$_SESSION['idnd']."'");
				$row=mysqli_fetch_array($sql);
				?>
				<a id="lichsuhoadon_a" href="index.php?act=lsdh&idnd=<?php echo $row['id_kh']; ?>" title="lịch sử mua hàng"><?php echo $_SESSION['username'] ?>
				<?php }?>
				
				</a>
			</li>
			<li id="logout"><p><a id="thoattest" href="Logout.php">Thoát</a></p></li>
		</div>
		<?php 
			}else{?>
		<div id="dndk">	
			<li><a id="dntest" href="index.php?act=dn#chihuong">ĐĂNG NHẬP</a></li>
			<li><a  href="index.php?act=dk#chihuong">ĐĂNG KÝ</a></li>
		
		</div>

	</ul>
			<?php  }?>
			
		

</div>