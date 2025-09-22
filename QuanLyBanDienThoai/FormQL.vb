Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports System.Windows.Forms
Public Class FormQL

    Dim dbPath As String = IO.Path.Combine(Application.StartupPath, "QuanLyBanDienThoai.mdf")
    Private connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & dbPath & ";Integrated Security=True;Encrypt=False;Connect Timeout=30"
    Private Sub MakeRoundButton(btn As System.Windows.Forms.Button)
        Dim path As New Drawing.Drawing2D.GraphicsPath()
        path.AddEllipse(0, 0, btn.Width, btn.Height)
        btn.Region = New Region(path)
    End Sub

    Public Sub BoGocButton(btn As System.Windows.Forms.Button, radius As Integer)
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(New Rectangle(0, 0, radius, radius), 180, 90)
        path.AddArc(New Rectangle(btn.Width - radius, 0, radius, radius), -90, 90)
        path.AddArc(New Rectangle(btn.Width - radius, btn.Height - radius, radius, radius), 0, 90)
        path.AddArc(New Rectangle(0, btn.Height - radius, radius, radius), 90, 90)
        path.CloseFigure()
        btn.Region = New Region(path)
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private panelHistory As New Stack(Of System.Windows.Forms.Panel)

    Private currentPanel As System.Windows.Forms.Panel = Nothing

    Private _username As String

    ' Constructor nhận tham số
    Public Sub New(username As String)
        InitializeComponent()
        _username = username
    End Sub

    Private Sub FormQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label60.BackColor = Color.Transparent
        Label61.BackColor = Color.Transparent
        Label62.BackColor = Color.Transparent
        GroupBox13.BackColor = Color.Transparent
        pnl_quanly.Visible = True
        pnl_ncc.Visible = False
        pnl_nhanvien.Visible = False
        pnl_khachhang.Visible = False

        btn_thoat.FlatStyle = FlatStyle.Flat
        btn_thoat.FlatAppearance.BorderSize = 0
        btn_thoat.BackColor = Color.Transparent

        btn_back.FlatStyle = FlatStyle.Flat
        btn_back.FlatAppearance.BorderSize = 0
        btn_back.BackColor = Color.Transparent

        btn_home.FlatStyle = FlatStyle.Flat
        btn_home.FlatAppearance.BorderSize = 0
        btn_home.BackColor = Color.Transparent

        BoGocButton(btn_thoat, 20)
        BoGocButton(btn_back, 20)
        BoGocButton(btn_home, 20)

        Dim quyen As String = String.Empty
        Dim query As String = "SELECT Quyen FROM TaiKhoanDangNhap WHERE TaiKhoan = @TaiKhoan"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@TaiKhoan", _username)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        quyen = result.ToString()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End Using
        End Using

        If quyen.Trim() = "Admin" Then
            Label60.Visible = True
            Label61.Visible = True
            Label62.Visible = True
        ElseIf quyen.Trim() = "Seller" Then
            Label60.Visible = False
            Label61.Visible = False
            Label62.Visible = True
        Else
            Label60.Visible = False
            Label61.Visible = True
            Label62.Visible = False
        End If

        currentPanel = pnl_quanly
    End Sub

    Private Sub SwitchPanel(newPanel As System.Windows.Forms.Panel)
        If newPanel Is Nothing Then Return

        If currentPanel IsNot Nothing AndAlso Not Object.ReferenceEquals(currentPanel, newPanel) Then
            ' Xóa dữ liệu nặng trước khi ẩn panel
            ClearPanelResources(currentPanel)

            ' Lưu panel hiện tại vào history
            panelHistory.Push(currentPanel)
            currentPanel.Visible = False
        End If

        ' Chuyển sang panel mới
        currentPanel = newPanel
        currentPanel.Visible = True
        currentPanel.BringToFront()
    End Sub

    Private Sub ClearPanelResources(pnl As System.Windows.Forms.Panel)
        For Each ctrl As Control In pnl.Controls
            If TypeOf ctrl Is DataGridView Then
                Dim dgv = DirectCast(ctrl, DataGridView)
                dgv.DataSource = Nothing
                dgv.Rows.Clear()
            ElseIf TypeOf ctrl Is PictureBox Then
                Dim pb = DirectCast(ctrl, PictureBox)
                If pb.Image IsNot Nothing Then
                    pb.Image.Dispose()
                    pb.Image = Nothing
                End If
            ElseIf TypeOf ctrl Is CrystalDecisions.Windows.Forms.CrystalReportViewer Then
                Dim crv = DirectCast(ctrl, CrystalDecisions.Windows.Forms.CrystalReportViewer)
                crv.ReportSource = Nothing
                crv.Dispose()
            End If
        Next
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    Private Sub btn_themncc_Click(sender As Object, e As EventArgs)
        ' Lấy thông tin từ các TextBox
        Dim manhacc = txt_mancc.Text.Trim
        Dim tennhacc = txt_tenncc.Text.Trim
        Dim diachincc = txt_diachincc.Text.Trim
        Dim sdtncc = txt_sdtncc.Text.Trim
        Dim emailncc = txt_emailncc.Text.Trim

        ' Kiểm tra dữ liệu đầu vào
        If String.IsNullOrEmpty(manhacc) OrElse String.IsNullOrEmpty(tennhacc) OrElse String.IsNullOrEmpty(sdtncc) OrElse String.IsNullOrEmpty(diachincc) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_ncc.DataSource, DataTable)
        If table Is Nothing Then
            ' Nếu DataTable chưa tồn tại, tạo mới
            table = New DataTable
            table.Columns.Add("MaNCC", GetType(String))
            table.Columns.Add("TenNCC", GetType(String))
            table.Columns.Add("DiaChi", GetType(String))
            table.Columns.Add("SoDienThoai", GetType(String))
            table.Columns.Add("Email", GetType(String))
            dg_ncc.DataSource = table
        End If

        ' Thêm hàng mới vào DataTable
        Dim newRow = table.NewRow
        newRow("MaNCC") = manhacc.Trim
        newRow("TenNCC") = tennhacc.Trim
        newRow("DiaChi") = diachincc.Trim
        newRow("SoDienThoai") = sdtncc.Trim
        newRow("Email") = emailncc.Trim
        table.Rows.Add(newRow)
    End Sub
    Private Sub dg_ncc_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        ' Kiểm tra xem người dùng có nhấn vào một ô hợp lệ không
        If e.RowIndex >= 0 Then
            Dim selectedRow = dg_ncc.Rows(e.RowIndex)

            ' Điền dữ liệu của hàng được chọn vào các TextBox
            txt_mancc.Text = selectedRow.Cells("MaNCC").Value?.ToString.Trim
            txt_tenncc.Text = selectedRow.Cells("TenNCC").Value?.ToString.Trim
            txt_diachincc.Text = selectedRow.Cells("DiaChi").Value?.ToString.Trim
            txt_sdtncc.Text = selectedRow.Cells("SoDienThoai").Value?.ToString.Trim
            txt_emailncc.Text = selectedRow.Cells("Email").Value?.ToString.Trim
        End If
    End Sub

    Private Sub btn_suancc_Click(sender As Object, e As EventArgs)
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_ncc.CurrentRow Is Nothing Then
            MessageBox.Show("Vui lòng chọn một nhà cung cấp để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            ' Lấy hàng hiện tại
            Dim selectedRow = dg_ncc.CurrentRow

            ' Lấy DataTable từ DataGridView
            Dim table = TryCast(dg_ncc.DataSource, DataTable)
            If table Is Nothing Then
                MessageBox.Show("Không tìm thấy DataTable!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Tìm hàng tương ứng trong DataTable
            Dim rowIndex = selectedRow.Index
            If rowIndex >= 0 AndAlso rowIndex < table.Rows.Count Then
                Dim dataRow = table.Rows(rowIndex)

                ' Cập nhật dữ liệu
                dataRow("MaNCC") = txt_mancc.Text.Trim
                dataRow("TenNCC") = txt_tenncc.Text.Trim
                dataRow("DiaChi") = txt_diachincc.Text.Trim
                dataRow("SoDienThoai") = txt_sdtncc.Text.Trim
                dataRow("Email") = txt_emailncc.Text.Trim
            End If
        End If
    End Sub
    Private Sub btn_xoancc_Click(sender As Object, e As EventArgs)
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_ncc.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hàng có nhà cung cấp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Xóa hàng được chọn
        For Each selectedRow As DataGridViewRow In dg_ncc.SelectedRows
            If Not selectedRow.IsNewRow Then
                dg_ncc.Rows.Remove(selectedRow)
            End If
        Next
    End Sub

    Private Sub btn_luuncc_Click(sender As Object, e As EventArgs)
        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dg_ncc.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kết thúc chỉnh sửa trong DataGridView
        dg_ncc.EndEdit()

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_ncc.DataSource, DataTable)
        If table Is Nothing Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Duyệt qua từng hàng trong DataTable
            For Each row As DataRow In table.Rows
                Try
                    If row.RowState = DataRowState.Added Then
                        ' Thêm mới hàng vào cơ sở dữ liệu
                        Dim insertQuery = "INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai, Email) VALUES (@MaNhaCungCap, @TenNhaCungCap, @DiaChi, @SoDienThoai, @Email)"
                        Using insertCommand As New SqlCommand(insertQuery, connection)
                            insertCommand.Parameters.AddWithValue("@MaNhaCungCap", row("MaNCC"))
                            insertCommand.Parameters.AddWithValue("@TenNhaCungCap", row("TenNCC"))
                            insertCommand.Parameters.AddWithValue("@DiaChi", row("DiaChi"))
                            insertCommand.Parameters.AddWithValue("@SoDienThoai", row("SoDienThoai"))
                            insertCommand.Parameters.AddWithValue("@Email", row("Email"))
                            insertCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Modified Then
                        ' Cập nhật hàng trong cơ sở dữ liệu
                        Dim updateQuery = "UPDATE NhaCungCap SET MaNCC = @MaNhaCungCap, TenNCC = @TenNhaCungCap,DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email WHERE MaNCC = @OriginalNhaCungCap"
                        Using updateCommand As New SqlCommand(updateQuery, connection)
                            updateCommand.Parameters.AddWithValue("@MaNhaCungCap", row("MaNCC"))
                            updateCommand.Parameters.AddWithValue("@OriginalNhaCungCap", row("MaNCC", DataRowVersion.Original))
                            updateCommand.Parameters.AddWithValue("@TenNhaCungCap", row("TenNCC"))
                            updateCommand.Parameters.AddWithValue("@DiaChi", row("DiaChi"))
                            updateCommand.Parameters.AddWithValue("@SoDienThoai", row("SoDienThoai"))
                            updateCommand.Parameters.AddWithValue("@Email", row("Email"))
                            updateCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Deleted Then
                        ' Xóa hàng khỏi cơ sở dữ liệu
                        Dim deleteQuery = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNhaCungCap"
                        Using deleteCommand As New SqlCommand(deleteQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@MaNhaCungCap", row("MaNCC", DataRowVersion.Original))
                            deleteCommand.ExecuteNonQuery()
                        End Using
                    End If
                Catch ex As Exception
                    MessageBox.Show("Lỗi khi lưu thay đổi: " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next
            ' Xác nhận lưu thành công
            table.AcceptChanges()
            MessageBox.Show("Lưu thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub
    Private Sub btn_huyncc_Click(sender As Object, e As EventArgs)
        Dim query = "SELECT * FROM NhaCungCap"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)
                dg_ncc.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub btn_timkiemncc_Click(sender As Object, e As EventArgs)
        ' Lấy từ khóa tìm kiếm từ TextBox
        Dim keyword = txt_timkiemncc.Text.Trim

        ' Kiểm tra nếu từ khóa rỗng
        If String.IsNullOrEmpty(keyword) Then
            MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu với từ khóa
        Dim query = "SELECT * FROM NhaCungCap WHERE MaNCC LIKE @Keyword"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Keyword", "%" & keyword & "%")
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)

                ' Gán dữ liệu vào DataGridView
                dg_ncc.DataSource = table

                ' Kiểm tra nếu không có kết quả
                If table.Rows.Count = 0 Then
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Private Sub btn_xdlncc_Click(sender As Object, e As EventArgs)
        ' Lấy dữ liệu từ DataGridView
        Dim dgv As DataGridView = dg_ncc

        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dgv.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Tạo ứng dụng Excel
        Dim excelApp As New Microsoft.Office.Interop.Excel.Application()
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excelApp.Workbooks.Add()
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = workbook.Sheets(1)

        ' Xuất tiêu đề cột
        For col As Integer = 0 To dgv.Columns.Count - 1
            worksheet.Cells(1, col + 1).Value = dgv.Columns(col).HeaderText
        Next

        ' Xuất dữ liệu
        For row As Integer = 0 To dgv.Rows.Count - 1
            For col As Integer = 0 To dgv.Columns.Count - 1
                Dim cellValue = dgv.Rows(row).Cells(col).Value
                worksheet.Cells(row + 2, col + 1).Value = If(cellValue IsNot Nothing, cellValue.ToString(), "")
            Next
        Next
        ' Xác định vùng dữ liệu (bao gồm cả tiêu đề)
        Dim lastRow As Integer = dgv.Rows.Count + 1
        Dim lastCol As Integer = dgv.Columns.Count
        Dim dataRange As Microsoft.Office.Interop.Excel.Range = worksheet.Range(worksheet.Cells(1, 1), worksheet.Cells(lastRow, lastCol))

        ' Thêm Table vào worksheet
        Dim table As Microsoft.Office.Interop.Excel.ListObject = worksheet.ListObjects.Add(
    SourceType:=Microsoft.Office.Interop.Excel.XlListObjectSourceType.xlSrcRange,
    Source:=dataRange,
    XlListObjectHasHeaders:=Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes)

        table.Name = "ExportedTable"
        table.TableStyle = "TableStyleMedium9" ' Có thể đổi sang style khác nếu muốn

        worksheet.Rows.AutoFit()
        worksheet.Columns.AutoFit()

        ' Hiển thị hộp thoại lưu file
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Excel Files|*.xlsx"
        saveFileDialog.Title = "Lưu file Excel"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                workbook.SaveAs(saveFileDialog.FileName)
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Không thể lưu tệp. Vui lòng đóng tệp nếu đang mở hoặc chọn tên tệp khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        ' Đóng ứng dụng Excel
        workbook.Close(False)
        excelApp.Quit()

        ' Giải phóng tài nguyên
        ReleaseObject(worksheet)
        ReleaseObject(workbook)
        ReleaseObject(excelApp)
    End Sub

    Private Sub btn_themnv_Click(sender As Object, e As EventArgs)
        ' Truy vấn quyền từ cơ sở dữ liệu
        Dim quyen = String.Empty
        Dim query = "SELECT Quyen FROM TaiKhoanDangNhap WHERE TaiKhoan = @TaiKhoan"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@TaiKhoan", _username)
                connection.Open()
                Dim result = command.ExecuteScalar
                If result IsNot Nothing Then
                    quyen = result.ToString
                End If
            End Using
        End Using
        ' Lấy thông tin từ các TextBox
        Dim manhanvien = txt_mnv.Text.Trim
        Dim tennhanvien = txt_tennv.Text.Trim
        Dim diachinhanvien = txt_dcnv.Text.Trim
        Dim sodienthoai = txt_sdtnv.Text.Trim
        Dim chucvu = txt_cvnv.Text.Trim
        Dim luong = txt_luong.Text.Trim
        Dim gioitinh = cb_gt.Text.Trim


        ' Kiểm tra dữ liệu đầu vào
        If String.IsNullOrEmpty(manhanvien) OrElse String.IsNullOrEmpty(tennhanvien) OrElse String.IsNullOrEmpty(diachinhanvien) OrElse String.IsNullOrEmpty(sodienthoai) OrElse String.IsNullOrEmpty(luong) OrElse String.IsNullOrEmpty(gioitinh) OrElse String.IsNullOrEmpty(chucvu) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_nhanvien.DataSource, DataTable)
        If table Is Nothing Then
            ' Nếu DataTable chưa tồn tại, tạo mới
            table = New DataTable
            table.Columns.Add("MaNV", GetType(String))
            table.Columns.Add("TenNV", GetType(String))
            table.Columns.Add("DiaChi", GetType(String))
            table.Columns.Add("SoDienThoai", GetType(String))
            table.Columns.Add("Luong", GetType(String))
            table.Columns.Add("GioiTinh", GetType(String))
            table.Columns.Add("ChucVu", GetType(String))
            dg_nhanvien.DataSource = table
        End If

        ' Thêm hàng mới vào DataTable
        Dim newRow = table.NewRow
        newRow("MaNV") = manhanvien.Trim
        newRow("TenNV") = tennhanvien.Trim
        newRow("DiaChi") = diachinhanvien.Trim
        newRow("SoDienThoai") = sodienthoai.Trim
        newRow("GioiTinh") = gioitinh.Trim
        newRow("Luong") = luong.Trim
        newRow("ChucVu") = chucvu.Trim
        table.Rows.Add(newRow)
    End Sub
    Private Sub dg_nv_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        ' Kiểm tra xem người dùng có nhấn vào một ô hợp lệ không
        If e.RowIndex >= 0 Then
            Dim selectedRow = dg_nhanvien.Rows(e.RowIndex)
            ' Điền dữ liệu của hàng được chọn vào các TextBox
            txt_mnv.Text = selectedRow.Cells("MaNV").Value?.ToString.Trim
            txt_tennv.Text = selectedRow.Cells("TenNV").Value?.ToString.Trim
            txt_dcnv.Text = selectedRow.Cells("DiaChi").Value?.ToString.Trim
            txt_sdtnv.Text = selectedRow.Cells("SoDienThoai").Value?.ToString.Trim
            txt_luong.Text = selectedRow.Cells("Luong").Value?.ToString.Trim
            txt_cvnv.Text = selectedRow.Cells("ChucVu").Value?.ToString.Trim
            cb_gt.Text = selectedRow.Cells("GioiTinh").Value?.ToString.Trim
        End If
    End Sub
    Private Sub btn_suanv_Click(sender As Object, e As EventArgs)
        ' Truy vấn quyền từ cơ sở dữ liệu
        Dim quyen = String.Empty
        Dim query = "SELECT Quyen FROM TaiKhoanDangNhap WHERE TaiKhoan = @TaiKhoan"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@TaiKhoan", _username)
                connection.Open()
                Dim result = command.ExecuteScalar
                If result IsNot Nothing Then
                    quyen = result.ToString
                End If
            End Using
        End Using
        ' Lấy hàng hiện tại
        Dim selectedRow = dg_nhanvien.CurrentRow

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_nhanvien.DataSource, DataTable)
        If table Is Nothing Then
            MessageBox.Show("Không tìm thấy DataTable!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Tìm hàng tương ứng trong DataTable
        Dim rowIndex = selectedRow.Index
        If rowIndex >= 0 AndAlso rowIndex < table.Rows.Count Then
            Dim dataRow = table.Rows(rowIndex)

            ' Cập nhật dữ liệu
            dataRow("MaNv") = txt_mnv.Text.Trim
            dataRow("TenNV") = txt_tennv.Text.Trim
            dataRow("DiaChi") = txt_dcnv.Text.Trim
            dataRow("SoDienThoai") = txt_sdtnv.Text.Trim
            dataRow("GioiTInh") = cb_gt.Text.Trim
            dataRow("ChucVu") = txt_cvnv.Text.Trim
            dataRow("Luong") = txt_luong.Text.Trim
        End If
    End Sub

    Private Sub btn_xoanv_Click(sender As Object, e As EventArgs)
        ' Truy vấn quyền từ cơ sở dữ liệu
        Dim quyen = String.Empty
        Dim query = "SELECT Quyen FROM TaiKhoanDangNhap WHERE TaiKhoan = @TaiKhoan"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@TaiKhoan", _username)
                connection.Open()
                Dim result = command.ExecuteScalar
                If result IsNot Nothing Then
                    quyen = result.ToString
                End If
            End Using
        End Using
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_nhanvien.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hàng có nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Xóa hàng được chọn
        For Each selectedRow As DataGridViewRow In dg_nhanvien.SelectedRows
            If Not selectedRow.IsNewRow Then
                dg_nhanvien.Rows.Remove(selectedRow)
            End If
        Next
    End Sub

    Private Sub btn_luunv_Click(sender As Object, e As EventArgs)
        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dg_nhanvien.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kết thúc chỉnh sửa trong DataGridView
        dg_nhanvien.EndEdit()

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_nhanvien.DataSource, DataTable)
        If table Is Nothing Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Duyệt qua từng hàng trong DataTable
            For Each row As DataRow In table.Rows
                Try
                    If row.RowState = DataRowState.Added Then
                        ' Thêm mới hàng vào cơ sở dữ liệu
                        Dim insertQuery = "INSERT INTO NhanVien (MaNV,TenNV, GioiTInh, SoDienThoai, DiaChi, ChucVu, Luong) VALUES (@MaNhanVien,@HoTen, @GioiTinh,@SoDienThoai,@DiaChi, @ChucVu, @Luong)"
                        Using insertCommand As New SqlCommand(insertQuery, connection)
                            insertCommand.Parameters.AddWithValue("@MaNhanVien", row("MaNV"))
                            insertCommand.Parameters.AddWithValue("@HoTen", row("TenNV"))
                            insertCommand.Parameters.AddWithValue("@SoDienThoai", row("SoDienThoai"))
                            insertCommand.Parameters.AddWithValue("@DiaChi", row("DiaChi"))
                            insertCommand.Parameters.AddWithValue("@ChucVu", row("ChucVu"))
                            insertCommand.Parameters.AddWithValue("@Luong", row("Luong"))
                            insertCommand.Parameters.AddWithValue("@GioiTinh", row("GioiTInh"))
                            insertCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Modified Then
                        ' Cập nhật hàng trong cơ sở dữ liệu
                        Dim updateQuery = "UPDATE NhanVien SET MaNV = @MaNhanVien, TenNV = @HoTen, GioiTinh = @GioiTinh, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, ChucVu = @ChucVu, Luong = @Luong WHERE MaNV = @OriginalMaNhanVien"
                        Using updateCommand As New SqlCommand(updateQuery, connection)
                            updateCommand.Parameters.AddWithValue("@MaNhanVien", row("MaNV"))
                            updateCommand.Parameters.AddWithValue("@OriginalMaNhanVien", row("MaNV", DataRowVersion.Original))
                            updateCommand.Parameters.AddWithValue("@HoTen", row("TenNV"))
                            updateCommand.Parameters.AddWithValue("@SoDienThoai", row("SoDienThoai"))
                            updateCommand.Parameters.AddWithValue("@DiaChi", row("DiaChi"))
                            updateCommand.Parameters.AddWithValue("@ChucVu", row("ChucVu"))
                            updateCommand.Parameters.AddWithValue("@GioiTinh", row("GioiTinh"))
                            updateCommand.Parameters.AddWithValue("@Luong", row("Luong"))
                            updateCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Deleted Then
                        ' Xóa hàng khỏi cơ sở dữ liệu
                        Dim deleteQuery = "DELETE FROM NhanVien WHERE MaNV = @MaNhanVien"
                        Using deleteCommand As New SqlCommand(deleteQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@MaNhanVien", row("MaNV", DataRowVersion.Original))
                            deleteCommand.ExecuteNonQuery()
                        End Using
                    End If
                Catch ex As Exception
                    MessageBox.Show("Lỗi khi lưu thay đổi: " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next
            ' Xác nhận lưu thành công
            table.AcceptChanges()
            MessageBox.Show("Lưu thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Private Sub btn_huynv_Click(sender As Object, e As EventArgs)
        Dim query = "SELECT * FROM NhanVien"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)
                dg_nhanvien.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub btn_tknv_Click(sender As Object, e As EventArgs)
        ' Lấy từ khóa tìm kiếm từ TextBox
        Dim keyword = txt_timkiemnv.Text.Trim

        ' Kiểm tra nếu từ khóa rỗng
        If String.IsNullOrEmpty(keyword) Then
            MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu với từ khóa
        Dim query = "SELECT * FROM NhanVien WHERE MaNV LIKE @Keyword"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Keyword", "%" & keyword & "%")
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)

                ' Gán dữ liệu vào DataGridView
                dg_nhanvien.DataSource = table

                ' Kiểm tra nếu không có kết quả
                If table.Rows.Count = 0 Then
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Private Sub btn_xdlnv_Click(sender As Object, e As EventArgs)
        ' Lấy dữ liệu từ DataGridView
        Dim dgv As DataGridView = dg_nhanvien

        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dgv.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Tạo ứng dụng Excel
        Dim excelApp As New Microsoft.Office.Interop.Excel.Application()
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excelApp.Workbooks.Add()
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = workbook.Sheets(1)

        ' Xuất tiêu đề cột
        For col As Integer = 0 To dgv.Columns.Count - 1
            worksheet.Cells(1, col + 1).Value = dgv.Columns(col).HeaderText
        Next

        ' Xuất dữ liệu
        For row As Integer = 0 To dgv.Rows.Count - 1
            For col As Integer = 0 To dgv.Columns.Count - 1
                Dim cellValue = dgv.Rows(row).Cells(col).Value
                worksheet.Cells(row + 2, col + 1).Value = If(cellValue IsNot Nothing, cellValue.ToString(), "")
            Next
        Next
        ' Xác định vùng dữ liệu (bao gồm cả tiêu đề)
        Dim lastRow As Integer = dgv.Rows.Count + 1
        Dim lastCol As Integer = dgv.Columns.Count
        Dim dataRange As Microsoft.Office.Interop.Excel.Range = worksheet.Range(worksheet.Cells(1, 1), worksheet.Cells(lastRow, lastCol))

        ' Thêm Table vào worksheet
        Dim table As Microsoft.Office.Interop.Excel.ListObject = worksheet.ListObjects.Add(
    SourceType:=Microsoft.Office.Interop.Excel.XlListObjectSourceType.xlSrcRange,
    Source:=dataRange,
    XlListObjectHasHeaders:=Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes)

        table.Name = "ExportedTable"
        table.TableStyle = "TableStyleMedium9" ' Có thể đổi sang style khác nếu muốn

        worksheet.Rows.AutoFit()
        worksheet.Columns.AutoFit()

        ' Hiển thị hộp thoại lưu file
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Excel Files|*.xlsx"
        saveFileDialog.Title = "Lưu file Excel"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                workbook.SaveAs(saveFileDialog.FileName)
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Không thể lưu tệp. Vui lòng đóng tệp nếu đang mở hoặc chọn tên tệp khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        ' Đóng ứng dụng Excel
        workbook.Close(False)
        excelApp.Quit()

        ' Giải phóng tài nguyên
        ReleaseObject(worksheet)
        ReleaseObject(workbook)
        ReleaseObject(excelApp)
    End Sub

    Private Sub btn_themkh_Click(sender As Object, e As EventArgs)
        ' Lấy thông tin từ các TextBox
        Dim makh = txt_makh.Text.Trim
        Dim tenkh = txt_tenkh.Text.Trim
        Dim diachikh = txt_diachikh.Text.Trim
        Dim sodienthoai = txt_sdtkh.Text.Trim
        Dim email = txt_emailkh.Text.Trim

        ' Kiểm tra dữ liệu đầu vào
        If String.IsNullOrEmpty(makh) OrElse String.IsNullOrEmpty(tenkh) OrElse String.IsNullOrEmpty(diachikh) OrElse String.IsNullOrEmpty(sodienthoai) OrElse String.IsNullOrEmpty(email) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_khachhang.DataSource, DataTable)
        If table Is Nothing Then
            ' Nếu DataTable chưa tồn tại, tạo mới
            table = New DataTable
            table.Columns.Add("MaKH", GetType(String))
            table.Columns.Add("TenKH", GetType(String))
            table.Columns.Add("DiaChi", GetType(String))
            table.Columns.Add("SoDienThoai", GetType(String))
            table.Columns.Add("Email", GetType(String))
            dg_khachhang.DataSource = table
        End If

        ' Thêm hàng mới vào DataTable
        Dim newRow = table.NewRow
        newRow("MaKH") = makh.Trim
        newRow("TenKH") = tenkh.Trim
        newRow("DiaChi") = diachikh.Trim
        newRow("SoDienThoai") = sodienthoai.Trim
        table.Rows.Add(newRow)
    End Sub
    Private Sub dg_kh_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        ' Kiểm tra xem người dùng có nhấn vào một ô hợp lệ không
        If e.RowIndex >= 0 Then
            Dim selectedRow = dg_khachhang.Rows(e.RowIndex)
            ' Điền dữ liệu của hàng được chọn vào các TextBox
            txt_makh.Text = selectedRow.Cells("MaKH").Value?.ToString.Trim
            txt_tenkh.Text = selectedRow.Cells("TenKH").Value?.ToString.Trim
            txt_diachikh.Text = selectedRow.Cells("DiaChi").Value?.ToString.Trim
            txt_sdtkh.Text = selectedRow.Cells("SoDienThoai").Value?.ToString.Trim
            txt_emailkh.Text = selectedRow.Cells("Email").Value?.ToString.Trim
        End If
    End Sub

    Private Sub btn_suakh_Click(sender As Object, e As EventArgs)
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_khachhang.CurrentRow Is Nothing Then
            MessageBox.Show("Vui lòng chọn một khách hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy hàng hiện tại
        Dim selectedRow = dg_khachhang.CurrentRow

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_khachhang.DataSource, DataTable)
        If table Is Nothing Then
            MessageBox.Show("Không tìm thấy DataTable!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Tìm hàng tương ứng trong DataTable
        Dim rowIndex = selectedRow.Index
        If rowIndex >= 0 AndAlso rowIndex < table.Rows.Count Then
            Dim dataRow = table.Rows(rowIndex)

            ' Cập nhật dữ liệu
            dataRow("MaKH") = txt_makh.Text.Trim
            dataRow("TenKH") = txt_tenkh.Text.Trim
            dataRow("DiaChi") = txt_diachikh.Text.Trim
            dataRow("SoDienThoai") = txt_sdtkh.Text.Trim
            dataRow("Email") = txt_emailkh.Text.Trim
        End If
    End Sub
    Private Sub btn_xoakh_Click(sender As Object, e As EventArgs)
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_khachhang.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hàng có khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Xóa hàng được chọn
        For Each selectedRow As DataGridViewRow In dg_khachhang.SelectedRows
            If Not selectedRow.IsNewRow Then
                dg_khachhang.Rows.Remove(selectedRow)
            End If
        Next
    End Sub

    Private Sub btn_luukh_Click(sender As Object, e As EventArgs)
        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dg_khachhang.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kết thúc chỉnh sửa trong DataGridView
        dg_khachhang.EndEdit()

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_khachhang.DataSource, DataTable)
        If table Is Nothing Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Duyệt qua từng hàng trong DataTable
            For Each row As DataRow In table.Rows
                Try
                    If row.RowState = DataRowState.Added Then
                        ' Thêm mới hàng vào cơ sở dữ liệu
                        Dim insertQuery = "INSERT INTO KhachHang (MaKH,TenKH, DiaChi, SoDienThoai, Email) VALUES (@MaKhachHang,@TenKhachHang,@DiaChi,@SoDienThoai,@Email)"
                        Using insertCommand As New SqlCommand(insertQuery, connection)
                            insertCommand.Parameters.AddWithValue("@MaKhachHang", row("MaKH"))
                            insertCommand.Parameters.AddWithValue("@TenKhachHang", row("TenKH"))
                            insertCommand.Parameters.AddWithValue("@DiaChi", row("DiaChi"))
                            insertCommand.Parameters.AddWithValue("@SoDienThoai", row("SoDienThoai"))
                            insertCommand.Parameters.AddWithValue("@Email", row("Email"))
                            insertCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Modified Then
                        ' Cập nhật hàng trong cơ sở dữ liệu
                        Dim updateQuery = "UPDATE KhachHang SET MaKH = @MaKhachHang, TenKH = @TenKhachHang, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email WHERE MaKH = @OriginalMaKhachHang"
                        Using updateCommand As New SqlCommand(updateQuery, connection)
                            updateCommand.Parameters.AddWithValue("@MaKhachHang", row("MaKH"))
                            updateCommand.Parameters.AddWithValue("@OriginalMaKhachHang", row("MaKH", DataRowVersion.Original))
                            updateCommand.Parameters.AddWithValue("@TenKhachHang", row("TenKH"))
                            updateCommand.Parameters.AddWithValue("@DiaChi", row("DiaChi"))
                            updateCommand.Parameters.AddWithValue("@SoDienThoai", row("SoDienThoai"))
                            updateCommand.Parameters.AddWithValue("@Email", row("Email"))
                            updateCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Deleted Then
                        ' Xóa hàng khỏi cơ sở dữ liệu
                        Dim deleteQuery = "DELETE FROM KhachHang WHERE MaKH = @MaKhachHang"
                        Using deleteCommand As New SqlCommand(deleteQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@MaKhachHang", row("MaKH", DataRowVersion.Original))
                            deleteCommand.ExecuteNonQuery()
                        End Using
                    End If
                Catch ex As Exception
                    MessageBox.Show("Lỗi khi lưu thay đổi: " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next
        End Using
        ' Xác nhận lưu thành công
        table.AcceptChanges()
        MessageBox.Show("Lưu thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btn_huykh_Click(sender As Object, e As EventArgs)
        Dim query = "SELECT * FROM KhachHang"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)
                dg_khachhang.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub btn_timkiemkh_Click(sender As Object, e As EventArgs)
        ' Lấy từ khóa tìm kiếm từ TextBox
        Dim keyword As String = txt_timkiemkh.Text.Trim()

        ' Kiểm tra nếu từ khóa rỗng
        If String.IsNullOrEmpty(keyword) Then
            MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu với từ khóa
        Dim query As String = "SELECT * FROM KhachHang WHERE MaKH LIKE @Keyword"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Keyword", "%" & keyword & "%")
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)

                ' Gán dữ liệu vào DataGridView
                dg_khachhang.DataSource = table

                ' Kiểm tra nếu không có kết quả
                If table.Rows.Count = 0 Then
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Private Sub btn_xdlkh_Click(sender As Object, e As EventArgs)
        ' Lấy dữ liệu từ DataGridView
        Dim dgv As DataGridView = dg_khachhang

        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dgv.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Tạo ứng dụng Excel
        Dim excelApp As New Microsoft.Office.Interop.Excel.Application()
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excelApp.Workbooks.Add()
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = workbook.Sheets(1)

        ' Xuất tiêu đề cột
        For col As Integer = 0 To dgv.Columns.Count - 1
            worksheet.Cells(1, col + 1).Value = dgv.Columns(col).HeaderText
        Next

        ' Xuất dữ liệu
        For row As Integer = 0 To dgv.Rows.Count - 1
            For col As Integer = 0 To dgv.Columns.Count - 1
                Dim cellValue = dgv.Rows(row).Cells(col).Value
                worksheet.Cells(row + 2, col + 1).Value = If(cellValue IsNot Nothing, cellValue.ToString(), "")
            Next
        Next
        ' Xác định vùng dữ liệu (bao gồm cả tiêu đề)
        Dim lastRow As Integer = dgv.Rows.Count + 1
        Dim lastCol As Integer = dgv.Columns.Count
        Dim dataRange As Microsoft.Office.Interop.Excel.Range = worksheet.Range(worksheet.Cells(1, 1), worksheet.Cells(lastRow, lastCol))

        ' Thêm Table vào worksheet
        Dim table As Microsoft.Office.Interop.Excel.ListObject = worksheet.ListObjects.Add(
    SourceType:=Microsoft.Office.Interop.Excel.XlListObjectSourceType.xlSrcRange,
    Source:=dataRange,
    XlListObjectHasHeaders:=Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes)

        table.Name = "ExportedTable"
        table.TableStyle = "TableStyleMedium9" ' Có thể đổi sang style khác nếu muốn

        worksheet.Rows.AutoFit()
        worksheet.Columns.AutoFit()

        ' Hiển thị hộp thoại lưu file
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Excel Files|*.xlsx"
        saveFileDialog.Title = "Lưu file Excel"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                workbook.SaveAs(saveFileDialog.FileName)
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Không thể lưu tệp. Vui lòng đóng tệp nếu đang mở hoặc chọn tên tệp khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        ' Đóng ứng dụng Excel
        workbook.Close(False)
        excelApp.Quit()

        ' Giải phóng tài nguyên
        ReleaseObject(worksheet)
        ReleaseObject(workbook)
        ReleaseObject(excelApp)
    End Sub

    Private Sub Label60_MouseEnter(sender As Object, e As EventArgs) Handles Label60.MouseEnter
        Label60.BackColor = Color.FromArgb(41, 128, 185)
        Label60.ForeColor = Color.White
        Label60.Font = New Font(Label60.Font, FontStyle.Bold)
    End Sub

    Private Sub Label61_MouseEnter(sender As Object, e As EventArgs) Handles Label61.MouseEnter
        Label61.BackColor = Color.FromArgb(41, 128, 185)
        Label61.ForeColor = Color.White
        Label61.Font = New Font(Label61.Font, FontStyle.Bold)
    End Sub

    Private Sub Label60_MouseLeave(sender As Object, e As EventArgs) Handles Label60.MouseLeave
        Label60.BackColor = Color.Transparent
        Label60.ForeColor = Color.Black
        Label60.Font = New Font(Label60.Font, FontStyle.Regular)
    End Sub

    Private Sub Label61_MouseLeave(sender As Object, e As EventArgs) Handles Label61.MouseLeave
        Label61.BackColor = Color.Transparent
        Label61.ForeColor = Color.Black
        Label61.Font = New Font(Label61.Font, FontStyle.Regular)
    End Sub

    Private Sub Label62_MouseEnter(sender As Object, e As EventArgs) Handles Label62.MouseEnter
        Label62.BackColor = Color.FromArgb(41, 128, 185)
        Label62.ForeColor = Color.White
        Label62.Font = New Font(Label62.Font, FontStyle.Bold)
    End Sub

    Private Sub Label62_MouseLeave(sender As Object, e As EventArgs) Handles Label62.MouseLeave
        Label62.BackColor = Color.Transparent
        Label62.ForeColor = Color.Black
        Label62.Font = New Font(Label62.Font, FontStyle.Regular)
    End Sub

    Private Sub Label60_Click(sender As Object, e As EventArgs) Handles Label60.Click

        Dim quyen As String = String.Empty
        Dim query As String = "SELECT Quyen FROM TaiKhoanDangNhap WHERE TaiKhoan = @TaiKhoan"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@TaiKhoan", _username)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        quyen = result.ToString()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End Using
        End Using

        If quyen.Trim() = "Admin" Then
            btn_themnv.Enabled = True
            btn_suanv.Enabled = True
            btn_xoanv.Enabled = True
            btn_luunv.Enabled = True
            btn_huynv.Enabled = True
            btn_xdlnv.Enabled = True
        Else
            btn_themnv.Enabled = False
            btn_suanv.Enabled = False
            btn_xoanv.Enabled = False
            btn_luunv.Enabled = False
            btn_huynv.Enabled = False
            btn_xdlnv.Enabled = False
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu
        Dim dataQuery As String = "SELECT * FROM NhanVien"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(dataQuery, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dg_nhanvien.DataSource = table
            End Using
        End Using

        SwitchPanel(pnl_nhanvien)
        AddHandler dg_nhanvien.CellClick, AddressOf dg_nv_CellClick
    End Sub

    Private Sub Label61_Click(sender As Object, e As EventArgs) Handles Label61.Click

        Dim quyen As String = String.Empty
        Dim query As String = "SELECT Quyen FROM TaiKhoanDangNhap WHERE TaiKhoan = @TaiKhoan"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@TaiKhoan", _username)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        quyen = result.ToString()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End Using
        End Using

        If quyen.Trim() = "Admin" Then
            btn_themncc.Enabled = True
            btn_suancc.Enabled = True
            btn_xoancc.Enabled = True
            btn_luuncc.Enabled = True
            btn_huyncc.Enabled = True
            btn_xdlncc.Enabled = True
        Else
            btn_themncc.Enabled = False
            btn_suancc.Enabled = False
            btn_xoancc.Enabled = False
            btn_luuncc.Enabled = False
            btn_huyncc.Enabled = False
            btn_xdlncc.Enabled = False
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu
        Dim dataQuery As String = "SELECT * FROM NhaCungCap"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(dataQuery, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dg_ncc.DataSource = table
            End Using
        End Using

        SwitchPanel(pnl_ncc)
        AddHandler dg_ncc.CellClick, AddressOf dg_ncc_CellClick
    End Sub

    Private Sub Label62_Click(sender As Object, e As EventArgs) Handles Label62.Click

        Dim quyen As String = String.Empty
        Dim query As String = "SELECT Quyen FROM TaiKhoanDangNhap WHERE TaiKhoan = @TaiKhoan"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@TaiKhoan", _username)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        quyen = result.ToString()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End Using
        End Using

        If quyen.Trim() = "Admin" Or quyen.Trim() = "Seller" Then
            btn_themkh.Enabled = True
            btn_suakh.Enabled = True
            btn_xoakh.Enabled = True
            btn_luukh.Enabled = True
            btn_huykh.Enabled = True
            btn_xdlkh.Enabled = True
        Else
            btn_themkh.Enabled = False
            btn_suakh.Enabled = False
            btn_xoakh.Enabled = False
            btn_luukh.Enabled = False
            btn_huykh.Enabled = False
            btn_xdlkh.Enabled = False
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu
        Dim dataQuery As String = "SELECT * FROM KhachHang"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(dataQuery, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dg_khachhang.DataSource = table
            End Using
        End Using

        SwitchPanel(pnl_khachhang)

        AddHandler dg_khachhang.CellClick, AddressOf dg_kh_CellClick
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        If panelHistory.Count > 0 Then
            ' ẩn panel hiện tại
            If currentPanel IsNot Nothing Then
                currentPanel.Visible = False
            End If
            ' lấy panel cũ từ stack
            currentPanel = panelHistory.Pop()
            currentPanel.Visible = True
            currentPanel.BringToFront()
        Else
            Dim mainform As New MainForm(_username)
            mainform.Show()
            Me.Close()
            Me.Dispose()
        End If

        RemoveHandler dg_khachhang.CellClick, AddressOf dg_kh_CellClick
        RemoveHandler dg_ncc.CellClick, AddressOf dg_ncc_CellClick
        RemoveHandler dg_nhanvien.CellClick, AddressOf dg_nv_CellClick
    End Sub

    Private Sub btn_home_Click(sender As Object, e As EventArgs) Handles btn_home.Click
        Me.Dispose()
        Me.Hide()
        Dim mainform As New MainForm(_username)
        mainform.Show()
    End Sub

    Private Sub btn_thoat_Click(sender As Object, e As EventArgs) Handles btn_thoat.Click
        Application.Exit()
    End Sub

End Class