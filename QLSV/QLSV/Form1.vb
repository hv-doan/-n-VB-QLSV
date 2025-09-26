Imports Microsoft.Data.SqlClient
Imports System.Data
Public Class Form1
	Dim connectionString As String = "Data Source=NGUYENHUUANH\SQLEXPRESS;Initial Catalog=QuanLySinhVienDoAnVb;Integrated Security=True;TrustServerCertificate=True"



	Private Sub LoadData(Optional gioiTinh As String = "All", Optional keyword As String = Nothing)
		Dim sql As String = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, Lop, Nganh FROM SinhVien WHERE 1=1"
		If Not String.IsNullOrWhiteSpace(gioiTinh) AndAlso gioiTinh <> "All" Then sql &= " AND GioiTinh = @GioiTinh"
		If Not String.IsNullOrWhiteSpace(keyword) Then
			' Tìm theo nhiều cột: MaSV, HoTen, GioiTinh, Nganh, Lop, DiaChi
			sql &= " AND (MaSV LIKE @kw OR HoTen LIKE @kw OR GioiTinh LIKE @kw OR Nganh LIKE @kw OR Lop LIKE @kw OR DiaChi LIKE @kw)"
		End If
		Using conn As New SqlConnection(connectionString)
			Using da As New SqlDataAdapter(sql, conn)
				If sql.Contains("@GioiTinh") Then da.SelectCommand.Parameters.AddWithValue("@GioiTinh", gioiTinh)
				If sql.Contains("@kw") Then da.SelectCommand.Parameters.AddWithValue("@kw", "%" & keyword & "%")
				Dim dt As New DataTable()
				da.Fill(dt)
				Dtgrv_sinhvien.DataSource = dt
			End Using
		End Using
	End Sub

	Private Sub LoadGioiTinhCombo()
		Cb_sinhvien.Items.Clear()
		Cb_sinhvien.Items.Add("All")
		Using conn As New SqlConnection(connectionString)
			Using cmd As New SqlCommand("SELECT DISTINCT GioiTinh FROM SinhVien WHERE GioiTinh IS NOT NULL ORDER BY GioiTinh", conn)
				conn.Open()
				Using r = cmd.ExecuteReader()
					While r.Read()
						Cb_sinhvien.Items.Add(r.GetString(0))
					End While
				End Using
			End Using
		End Using
		If Cb_sinhvien.Items.Count > 0 Then Cb_sinhvien.SelectedIndex = 0
	End Sub
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Try
			LoadData()
			LoadGioiTinhCombo()
		Catch ex As Exception
			MessageBox.Show("Lỗi kết nối/Load dữ liệu: " & ex.Message)
		End Try
	End Sub
	Private Sub Bt_add_Click(sender As Object, e As EventArgs) Handles Bt_add.Click
		Try
			Dim ma = InputBox("Nhập Mã SV (tối đa 10 ký tự):")
			If String.IsNullOrWhiteSpace(ma) Then Return
			Dim ten = InputBox("Nhập Họ Tên:")
			If String.IsNullOrWhiteSpace(ten) Then Return
			Dim ngayStr = InputBox("Nhập Ngày Sinh (yyyy-MM-dd):")
			Dim ngay As Date
			If Not Date.TryParse(ngayStr, ngay) Then
				MessageBox.Show("Ngày sinh không hợp lệ.")
				Return
			End If
			Dim gt = InputBox("Nhập Giới Tính (M/F, có thể để trống):")
			If Not String.IsNullOrWhiteSpace(gt) Then
				gt = gt.Trim().ToUpperInvariant()
				If gt <> "M" AndAlso gt <> "F" Then
					MessageBox.Show("Giới tính chỉ nhận 'M' hoặc 'F' theo ràng buộc CHECK.")
					Return
				End If
			End If
			Dim diachi = InputBox("Nhập Địa Chỉ (có thể để trống):")
			Dim lop = InputBox("Nhập Lớp (có thể để trống):")
			Dim nganh = InputBox("Nhập Ngành (có thể để trống):")

			Dim sql = "INSERT INTO SinhVien(MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, Lop, Nganh)
					   VALUES(@MaSV,@HoTen,@NgaySinh,@GioiTinh,@DiaChi,@Lop,@Nganh)"
			Using conn As New SqlConnection(connectionString)
				conn.Open()
				Using cmd As New SqlCommand(sql, conn)
					cmd.Parameters.AddWithValue("@MaSV", ma)
					cmd.Parameters.AddWithValue("@HoTen", ten)
					cmd.Parameters.AddWithValue("@NgaySinh", ngay.Date)
					If String.IsNullOrWhiteSpace(gt) Then
						cmd.Parameters.AddWithValue("@GioiTinh", DBNull.Value)
					Else
						cmd.Parameters.AddWithValue("@GioiTinh", gt)
					End If
					If String.IsNullOrWhiteSpace(diachi) Then cmd.Parameters.AddWithValue("@DiaChi", DBNull.Value) Else cmd.Parameters.AddWithValue("@DiaChi", diachi)
					If String.IsNullOrWhiteSpace(lop) Then cmd.Parameters.AddWithValue("@Lop", DBNull.Value) Else cmd.Parameters.AddWithValue("@Lop", lop)
					If String.IsNullOrWhiteSpace(nganh) Then cmd.Parameters.AddWithValue("@Nganh", DBNull.Value) Else cmd.Parameters.AddWithValue("@Nganh", nganh)
					cmd.ExecuteNonQuery()
				End Using
			End Using

			LoadData(If(Cb_sinhvien.SelectedItem?.ToString(), "All"), Txt_search.Text)
			LoadGioiTinhCombo()
		Catch ex As Exception
			MessageBox.Show("Lỗi thêm: " & ex.Message)
		End Try
	End Sub
	Private Sub Bt_edit_Click(sender As Object, e As EventArgs) Handles Bt_edit.Click
		Dim row = TryCast(Dtgrv_sinhvien.CurrentRow, DataGridViewRow)
		If row Is Nothing Then
			MessageBox.Show("Chọn 1 dòng để sửa.")
			Return
		End If

		Try
			Dim ma = row.Cells("MaSV").Value.ToString()
			Dim ten = InputBox("Sửa Họ Tên:", "Edit", row.Cells("HoTen").Value.ToString())
			If ten = "" Then Return
			Dim ngayStrDefault As String = CDate(row.Cells("NgaySinh").Value).ToString("yyyy-MM-dd")
			Dim ngayStr = InputBox("Sửa Ngày Sinh (yyyy-MM-dd):", "Edit", ngayStrDefault)
			Dim ngay As Date
			If Not Date.TryParse(ngayStr, ngay) Then
				MessageBox.Show("Ngày sinh không hợp lệ.")
				Return
			End If
			Dim gtDefault = If(row.Cells("GioiTinh").Value Is Nothing OrElse IsDBNull(row.Cells("GioiTinh").Value), "", row.Cells("GioiTinh").Value.ToString())
			Dim gt = InputBox("Sửa Giới Tính (M/F hoặc để trống):", "Edit", gtDefault).Trim().ToUpperInvariant()
			If gt <> "" AndAlso gt <> "M" AndAlso gt <> "F" Then
				MessageBox.Show("Giới tính chỉ nhận 'M' hoặc 'F'.")
				Return
			End If
			Dim diachi = InputBox("Sửa Địa Chỉ:", "Edit", If(IsDBNull(row.Cells("DiaChi").Value), "", row.Cells("DiaChi").Value.ToString()))
			Dim lop = InputBox("Sửa Lớp:", "Edit", If(IsDBNull(row.Cells("Lop").Value), "", row.Cells("Lop").Value.ToString()))
			Dim nganh = InputBox("Sửa Ngành:", "Edit", If(IsDBNull(row.Cells("Nganh").Value), "", row.Cells("Nganh").Value.ToString()))

			Dim sql = "UPDATE SinhVien
					   SET HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, DiaChi=@DiaChi, Lop=@Lop, Nganh=@Nganh
					   WHERE MaSV=@MaSV"
			Using conn As New SqlConnection(connectionString)
				conn.Open()
				Using cmd As New SqlCommand(sql, conn)
					cmd.Parameters.AddWithValue("@HoTen", ten)
					cmd.Parameters.AddWithValue("@NgaySinh", ngay.Date)
					If gt = "" Then cmd.Parameters.AddWithValue("@GioiTinh", DBNull.Value) Else cmd.Parameters.AddWithValue("@GioiTinh", gt)
					If String.IsNullOrWhiteSpace(diachi) Then cmd.Parameters.AddWithValue("@DiaChi", DBNull.Value) Else cmd.Parameters.AddWithValue("@DiaChi", diachi)
					If String.IsNullOrWhiteSpace(lop) Then cmd.Parameters.AddWithValue("@Lop", DBNull.Value) Else cmd.Parameters.AddWithValue("@Lop", lop)
					If String.IsNullOrWhiteSpace(nganh) Then cmd.Parameters.AddWithValue("@Nganh", DBNull.Value) Else cmd.Parameters.AddWithValue("@Nganh", nganh)
					cmd.Parameters.AddWithValue("@MaSV", ma)
					cmd.ExecuteNonQuery()
				End Using
			End Using

			LoadData(If(Cb_sinhvien.SelectedItem?.ToString(), "All"), Txt_search.Text)
			LoadGioiTinhCombo()
		Catch ex As Exception
			MessageBox.Show("Lỗi sửa: " & ex.Message)
		End Try
	End Sub
	Private Sub Bt_delete_Click(sender As Object, e As EventArgs) Handles Bt_delete.Click
		Dim row = TryCast(Dtgrv_sinhvien.CurrentRow, DataGridViewRow)
		If row Is Nothing Then
			MessageBox.Show("Chọn 1 dòng để xóa.")
			Return
		End If
		Dim ma = row.Cells("MaSV").Value.ToString()
		If MessageBox.Show("Xóa sinh viên " & ma & "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

		Try
			Using conn As New SqlConnection(connectionString)
				conn.Open()
				Using cmd As New SqlCommand("DELETE FROM SinhVien WHERE MaSV=@MaSV", conn)
					cmd.Parameters.AddWithValue("@MaSV", ma)
					cmd.ExecuteNonQuery()
				End Using
			End Using
			LoadData(If(Cb_sinhvien.SelectedItem?.ToString(), "All"), Txt_search.Text)
			LoadGioiTinhCombo()
		Catch ex As Exception
			MessageBox.Show("Lỗi xóa: " & ex.Message & vbCrLf & "Lưu ý: Có thể đang bị ràng buộc khóa ngoại bảng Diem.")
		End Try
	End Sub
	Private Sub Bt_search_Click(sender As Object, e As EventArgs) Handles Bt_search.Click
		Dim keyword As String = Txt_search.Text.Trim()
		Dim sql As String =
		"SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, Lop, Nganh " &
		"FROM SinhVien " &
		"WHERE (@kw = '' OR " &
		"       MaSV    LIKE @like OR " &
		"       HoTen   LIKE @like OR " &
		"       GioiTinh LIKE @like OR " &
		"       DiaChi  LIKE @like OR " &
		"       Lop     LIKE @like OR " &
		"       Nganh   LIKE @like) " &
		"AND (@gt = 'All' OR GioiTinh = @gt);"
		Using conn As New SqlConnection(connectionString)
			Using da As New SqlDataAdapter(sql, conn)
				da.SelectCommand.Parameters.AddWithValue("@kw", keyword)
				da.SelectCommand.Parameters.AddWithValue("@like", "%" & keyword & "%")
				da.SelectCommand.Parameters.AddWithValue("@gt", If(Cb_sinhvien.SelectedItem?.ToString(), "All"))
				Dim dt As New DataTable()
				da.Fill(dt)
				Dtgrv_sinhvien.DataSource = dt
			End Using
		End Using
	End Sub

	Private Sub Cb_sinhvien_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_sinhvien.SelectedIndexChanged
		LoadData(If(Cb_sinhvien.SelectedItem?.ToString(), "All"), Txt_search.Text)
	End Sub
	Private Sub Dtgrv_sinhvien_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dtgrv_sinhvien.CellClick
	End Sub

End Class