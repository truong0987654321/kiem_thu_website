<!DOCTYPE>
<html >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Thêm Sản Phẩm</title>
<link rel="stylesheet" href="css/them_sanpham.css" />
</head>

<body>
<?php
	include '../db/ketnoi.php';

	if(isset($_POST['submit']))
	{
		$ten_sanpham=$_POST['tensp'];
		$gia=$_POST['gia'];
		$chitiet=$_POST['chitiet'];
		$soluong=$_POST['soluong'];
		$khuyenmai1=$_POST['khuyenmai1'];
		
	//	$hinhanh=$_POST['hinhanh'];
		$upload_image="../uploads/";
		$file_tmp= isset($_FILES['hinhanh']['tmp_name']) ?$_FILES['hinhanh']['tmp_name'] :"";
		$file_name=isset($_FILES['hinhanh']['name']) ?$_FILES['hinhanh']['name'] :"";
		$file_type=isset($_FILES['hinhanh']['type']) ?$_FILES['hinhanh']['type'] :"";
		$file_size=isset($_FILES['hinhanh']['size']) ?$_FILES['hinhanh']['size'] :"";
		$file_error=isset($_FILES['hinhanh']['error']) ?$_FILES['hinhanh']['error'] :"";
		//Lay gio cua he thong
		$dmyhis= date("Y").date("m").date("d").date("H").date("i").date("s");
		//Lay ngay cua he thong
		$ngay=date("Y").":".date("m").":".date("d").":".date("H").":".date("i").":".date("s");
		
		$file__name__=$dmyhis.$file_name;
		move_uploaded_file($file_tmp,$upload_image.$file__name__);
		$madm=$_POST['madm'];
		$insert="INSERT INTO sanpham(id_tl,ten_sp,chitiet_sp,gia_sp,giakhuyenmai_sp,soluong_sp,anh_sp,daban) VALUES( '$madm', '$ten_sanpham', '$chitiet','$gia' , '$khuyenmai1','$soluong','$file__name__','0')";
		$query=mysqli_query($con,$insert);
		if($query) {
			echo "<script language='javascript'>
			alert('Bạn đã đăng ký thành công');
			window.open('trang1.php?act=sp','_self', 1);
			</script>";
		}
		else { echo "<script language='javascript'>
			alert('thất bại');
			window.open('trang1.php?act=sp','_self', 1);
			</script>";
		}
}


		
?>
<form action="" method="post" enctype="multipart/form-data" name="frm" onsubmit="return kiemtra()">
	
      <table>
			<tr class="tieude_themsp">
				<td colspan=2>Thêm Sản Phẩm </td>
			</tr>
    		<tr>
            	<td>Tên SP</td><td><input type="text" name="tensp"/></td>
            </tr>
            <tr>
            	<td>Hình ảnh</td><td><input type="file" name="hinhanh"/></td>
            </tr> 
            <tr>
            	<td>Chi tiết</td><td><textarea name="chitiet" id="chitiet"></textarea></td>
            </tr>
			<tr>
            	<td>Số lượng</td><td><input type="text" name="soluong" size="5"/></td>
            </tr>
            <tr>
            	<td>Giá</td><td><input type="text" name="gia"/></td>
            </tr>
			<tr>
            	<td>Giảm giá </td><td><input type="text" name="khuyenmai1" size="1"/> &nbsp %</td>
            </tr>
            <tr>
            	<td>Mã DM</td><td>
                	<select name="madm">
                	<option value="">Chọn danh muc</option>
                    <?php
						$show = mysqli_query($con,"SELECT * FROM theloai WHERE dequi");
						while($show1 = mysqli_fetch_array($show))
						{
							$madm1 = $show1['id_tl'];	
							$tendm1 = $show1['ten_tl'];
							echo "<option value='".$madm1."'>".$tendm1."</option>";	
								
						}
                	?>
                
                
                </td>
            </tr>
            <tr>
                <td colspan=2 class="input"> <input type="submit" name="submit" value="Thêm" />
                <input type="reset" name="" value="Hủy" /></td>
            </tr>
         </table>  
</form>

<script type="text/javascript" language="javascript">
 
  CKEDITOR.replace( 'chitiet', {
	uiColor: '#d1d1d1'
});

</script>

</body>
</html>

<script language="javascript">
 	function  kiemtra()
	{
	    
		if(frm.tensp.value=="")
	 	{
			alert("Bạn chưa nhập tên SP. Vui lòng kiểm tra lại");
			frm.tensp.focus();
			return false;	
		}
		if(frm.hinhanh.value=="")
		{
			alert("Bạn chưa chọn hình ảnh");	
			frm.hinhanh.focus();
			return false;
		}
		if(frm.soluong.value=="")
		{
			alert("Bạn chưa nhập số lượng");	
			frm.soluong.focus();
			return false;
		}
		if(frm.madm.value=="")
		{
			alert("Bạn chưa chọn danh mục");	
			frm.madm.focus();
			return false;
		}
	}
 </script>