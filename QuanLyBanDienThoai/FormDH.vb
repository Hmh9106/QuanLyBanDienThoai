Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Reflection.Emit
Imports System.Web.UI.WebControls
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Public Class FormDH

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

    Private Sub pnl_dt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label64.BackColor = Color.Transparent
        Label65.BackColor = Color.Transparent
        Label66.BackColor = Color.Transparent
        Label67.BackColor = Color.Transparent
        GroupBox14.BackColor = Color.Transparent
        pnl_ctban.Visible = False
        pnl_ctnhap.Visible = False
        pnl_dhban.Visible = False
        pnl_dhnhap.Visible = False
        pnl_donhang.Visible = True

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

        currentPanel = pnl_donhang
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
    Private Sub btn_themdhban_Click(sender As Object, e As EventArgs) Handles btn_themdhban.Click
        ' Lấy thông tin từ các TextBox
        Dim mahoadon = txt_hdban.Text.Trim
        Dim ngayban = txt_ngayban.Text.Trim
        Dim makhach = txt_mkhban.Text.Trim
        Dim manv = txt_mnvban.Text.Trim
        Dim tongtien = txt_tongtien.Text.Trim

        ' Kiểm tra dữ liệu đầu vào
        If String.IsNullOrEmpty(mahoadon) OrElse String.IsNullOrEmpty(ngayban) OrElse String.IsNullOrEmpty(makhach) OrElse String.IsNullOrEmpty(manv) OrElse String.IsNullOrEmpty(tongtien) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_dhban.DataSource, DataTable)
        If table Is Nothing Then
            ' Nếu DataTable chưa tồn tại, tạo mới
            table = New DataTable
            table.Columns.Add("MaHDB", GetType(String))
            table.Columns.Add("NgayBan", GetType(Date))
            table.Columns.Add("MaKH", GetType(String))
            table.Columns.Add("MaNV", GetType(String))
            table.Columns.Add("TongTien", GetType(String))
            dg_dhban.DataSource = table
        End If

        ' Thêm hàng mới vào DataTable
        Dim newRow = table.NewRow
        newRow("MaHDB") = mahoadon.Trim
        newRow("NgayBan") = ngayban.Trim
        newRow("MaKH") = makhach.Trim
        newRow("MaNV") = manv.Trim
        newRow("TongTien") = tongtien.Trim
        table.Rows.Add(newRow)
    End Sub
    Private Sub dg_dhban_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_dhban.CellClick
        ' Kiểm tra xem người dùng có nhấn vào một ô hợp lệ không
        If e.RowIndex >= 0 Then
            Dim selectedRow = dg_dhban.Rows(e.RowIndex)
            ' Điền dữ liệu của hàng được chọn vào các TextBox
            txt_hdban.Text = selectedRow.Cells("MaHDB").Value?.ToString.Trim
            txt_ngayban.Text = selectedRow.Cells("NgayBan").Value?.ToString.Trim
            txt_mkhban.Text = selectedRow.Cells("MaKH").Value?.ToString.Trim
            txt_mnvban.Text = selectedRow.Cells("MaNV").Value?.ToString.Trim
            txt_tongtien.Text = selectedRow.Cells("TongTien").Value?.ToString.Trim
        End If
    End Sub
    Private Sub btn_suadhban_Click(sender As Object, e As EventArgs) Handles btn_suadhban.Click
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_dhban.CurrentRow Is Nothing Then
            MessageBox.Show("Vui lòng chọn một đơn hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Lấy hàng hiện tại
        Dim selectedRow = dg_dhban.CurrentRow
        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_dhban.DataSource, DataTable)
        If table Is Nothing Then
            MessageBox.Show("Không tìm thấy DataTable!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Tìm hàng tương ứng trong DataTable
        Dim rowIndex = selectedRow.Index
        If rowIndex >= 0 AndAlso rowIndex < table.Rows.Count Then
            Dim dataRow = table.Rows(rowIndex)
            ' Cập nhật dữ liệu
            dataRow("MaHDB") = txt_hdban.Text.Trim
            dataRow("NgayBan") = txt_ngayban.Text.Trim
            dataRow("MaKH") = txt_mkhban.Text.Trim
            dataRow("MaNV") = txt_mnvban.Text.Trim
            dataRow("TongTien") = txt_tongtien.Text.Trim
        End If
    End Sub
    Private Sub btn_xoadhban_Click(sender As Object, e As EventArgs) Handles btn_xoadhban.Click
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_dhban.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hàng có đơn hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Xóa hàng được chọn
        For Each selectedRow As DataGridViewRow In dg_dhban.SelectedRows
            If Not selectedRow.IsNewRow Then
                dg_dhban.Rows.Remove(selectedRow)
            End If
        Next
    End Sub

    Private Sub btn_luudhban_Click(sender As Object, e As EventArgs) Handles btn_luudhban.Click
        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dg_dhban.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kết thúc chỉnh sửa trong DataGridView
        dg_dhban.EndEdit()

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_dhban.DataSource, DataTable)
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
                        Dim insertQuery = "INSERT INTO HoaDonBan (MaHDB, NgayBan, MaKH, MaNV, TongTien) VALUES (@MaHoaDonBan, @NgayBan, @MaKH, @MaNV, @TongTien)"
                        Using insertCommand As New SqlCommand(insertQuery, connection)
                            insertCommand.Parameters.AddWithValue("@MaHoaDonBan", row("MaHDB"))
                            insertCommand.Parameters.AddWithValue("@NgayBan", row("NgayBan"))
                            insertCommand.Parameters.AddWithValue("@MaKH", row("MaKH"))
                            insertCommand.Parameters.AddWithValue("@MaNV", row("MaNV"))
                            insertCommand.Parameters.AddWithValue("@TongTien", row("TongTien"))
                            insertCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Modified Then
                        ' Cập nhật hàng trong cơ sở dữ liệu
                        Dim updateQuery = "UPDATE HoaDonBan SET MaHDB = @MaHoaDonBan, NgayBan = @NgayBan, MaKH = @MaKH, MaNV = @MaNV, TongTien = @TongTien WHERE MaHDB = @OriginalMaHoaDonBan"
                        Using updateCommand As New SqlCommand(updateQuery, connection)
                            updateCommand.Parameters.AddWithValue("@MaHoaDonBan", row("MaHDB"))
                            updateCommand.Parameters.AddWithValue("@OriginalMaHoaDonBan", row("MaHDB", DataRowVersion.Original))
                            updateCommand.Parameters.AddWithValue("@NgayBan", row("NgayBan"))
                            updateCommand.Parameters.AddWithValue("@MaKH", row("MaKH"))
                            updateCommand.Parameters.AddWithValue("@MaNV", row("MaNV"))
                            updateCommand.Parameters.AddWithValue("@TongTien", row("TongTien"))
                            updateCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Deleted Then
                        ' Xóa hàng khỏi cơ sở dữ liệu
                        Dim deleteQuery = "DELETE FROM HoaDonBan WHERE MaHDB = @MaHoaDonBan"
                        Using deleteCommand As New SqlCommand(deleteQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@MaHoaDonBan", row("MaHDB", DataRowVersion.Original))
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
    Private Sub btn_huydhban_Click(sender As Object, e As EventArgs) Handles btn_huydhban.Click
        Dim query = "SELECT * FROM HoaDonBan"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)
                dg_dhban.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub btn_timkiemdhban_Click(sender As Object, e As EventArgs) Handles btn_timkiemdhban.Click
        ' Lấy từ khóa tìm kiếm từ TextBox
        Dim keyword = txt_timkiemdhban.Text.Trim

        ' Kiểm tra nếu từ khóa rỗng
        If String.IsNullOrEmpty(keyword) Then
            MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu với từ khóa
        Dim query = "SELECT * FROM HoaDonBan WHERE MaHDB LIKE @Keyword or NgayBan like @Keyword or MaKH like @keyword or MaNV like @keyword"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Keyword", "%" & keyword & "%")
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)

                ' Gán dữ liệu vào DataGridView
                dg_dhban.DataSource = table

                ' Kiểm tra nếu không có kết quả
                If table.Rows.Count = 0 Then
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Private Sub btn_xdldhban_Click(sender As Object, e As EventArgs) Handles btn_xdldhban.Click
        ' Lấy dữ liệu từ DataGridView
        Dim dgv As DataGridView = dg_dhban

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

    Private Sub btn_themctban_Click(sender As Object, e As EventArgs) Handles btn_themctban.Click
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
        Dim madonhang = txt_mactdhban.Text.Trim
        Dim madienthoai = txt_mactdtban.Text.Trim
        Dim soluong = txt_soluongban.Text.Trim
        Dim dongia = txt_ctdongiaban.Text.Trim
        Dim thanhtien = CDec(soluong) * CDec(dongia)
        ' Kiểm tra dữ liệu đầu vào
        If String.IsNullOrEmpty(madienthoai) OrElse String.IsNullOrEmpty(madonhang) OrElse String.IsNullOrEmpty(soluong) OrElse String.IsNullOrEmpty(dongia) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_ctban.DataSource, DataTable)
        If table Is Nothing Then
            ' Nếu DataTable chưa tồn tại, tạo mới
            table = New DataTable
            table.Columns.Add("MaHDB", GetType(String))
            table.Columns.Add("MaDT", GetType(String))
            table.Columns.Add("SoLuong", GetType(Integer))
            table.Columns.Add("DonGia", GetType(Decimal))
            table.Columns.Add("ThanhTien", GetType(Decimal))
            dg_ctban.DataSource = table
        End If

        ' Thêm hàng mới vào DataTable
        Dim newRow = table.NewRow
        newRow("MaHDB") = madonhang.Trim()
        newRow("MaDT") = madienthoai.Trim()
        newRow("SoLuong") = soluong.Trim()
        newRow("DonGia") = dongia.Trim()
        newRow("ThanhTien") = thanhtien
        table.Rows.Add(newRow)
    End Sub
    Private Sub dg_ctban_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_ctban.CellClick
        ' Kiểm tra xem người dùng có nhấn vào một ô hợp lệ không
        If e.RowIndex >= 0 Then
            Dim selectedRow = dg_ctban.Rows(e.RowIndex)
            ' Điền dữ liệu của hàng được chọn vào các TextBox
            txt_mactdhban.Text = selectedRow.Cells("MaHDB").Value?.ToString.Trim
            txt_mactdtban.Text = selectedRow.Cells("MaDT").Value?.ToString.Trim
            txt_soluongban.Text = selectedRow.Cells("SoLuong").Value?.ToString.Trim
            txt_ctdongiaban.Text = selectedRow.Cells("DonGia").Value?.ToString.Trim
        End If
    End Sub

    Private Sub btn_suactban_Click(sender As Object, e As EventArgs) Handles btn_suactban.Click
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
        If dg_ctban.CurrentRow Is Nothing Then
            MessageBox.Show("Vui lòng chọn một đơn hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy hàng hiện tại
        Dim selectedRow = dg_ctban.CurrentRow

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_ctban.DataSource, DataTable)
        If table Is Nothing Then
            MessageBox.Show("Không tìm thấy DataTable!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Tìm hàng tương ứng trong DataTable
        Dim rowIndex = selectedRow.Index
        If rowIndex >= 0 AndAlso rowIndex < table.Rows.Count Then
            Dim dataRow = table.Rows(rowIndex)

            ' Cập nhật dữ liệu

            dataRow("MaHDB") = txt_mactdhban.Text.Trim()
            dataRow("MaDT") = txt_mactdtban.Text.Trim()
            dataRow("SoLuong") = txt_soluongban.Text.Trim()
            dataRow("DonGia") = txt_ctdongiaban.Text.Trim()
            Dim soluong = txt_soluongban.Text.Trim()
            Dim dongia = txt_ctdongiaban.Text.Trim()
            Dim thanhtien = CDec(soluong) * CDec(dongia)
            dataRow("ThanhTien") = thanhtien
        End If
    End Sub
    Private Sub btn_xoactban_Click(sender As Object, e As EventArgs) Handles btn_xoactban.Click
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_ctban.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hàng có đơn hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Xóa hàng được chọn
        For Each selectedRow As DataGridViewRow In dg_ctban.SelectedRows
            If Not selectedRow.IsNewRow Then
                dg_ctban.Rows.Remove(selectedRow)
            End If
        Next
    End Sub

    Private Sub btn_luuctban_Click(sender As Object, e As EventArgs) Handles btn_luuctban.Click
        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dg_ctban.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kết thúc chỉnh sửa trong DataGridView
        dg_ctban.EndEdit()

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_ctban.DataSource, DataTable)
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
                        Dim insertQuery = "INSERT INTO ChiTietBan (MaHDB, MaDT, SoLuong, DonGia) VALUES (@MaHDB,@MaDT,@SoLuong,@DonGia)"
                        Using insertCommand As New SqlCommand(insertQuery, connection)
                            insertCommand.Parameters.AddWithValue("@MaHDB", row("MaHDB"))
                            insertCommand.Parameters.AddWithValue("@MaDT", row("MaDT"))
                            insertCommand.Parameters.AddWithValue("@SoLuong", row("SoLuong"))
                            insertCommand.Parameters.AddWithValue("@DonGia", row("DonGia"))
                            insertCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Modified Then
                        ' Cập nhật hàng trong cơ sở dữ liệu
                        Dim updateQuery = "UPDATE ChiTietBan SET MaHDB = @MaHDB, MaDT = @MaDT, SoLuong = @SoLuong, DonGia = @DonGia WHERE MaHDB = @OriginalMaHDB AND MaDT = @OriginalMaDT"
                        Using updateCommand As New SqlCommand(updateQuery, connection)
                            updateCommand.Parameters.AddWithValue("@MaHDB", row("MaHDB"))
                            updateCommand.Parameters.AddWithValue("@OriginalMaHDB", row("MaHDB", DataRowVersion.Original))
                            updateCommand.Parameters.AddWithValue("@MaDT", row("MaDT"))
                            updateCommand.Parameters.AddWithValue("@OriginalMaDT", row("MaDT", DataRowVersion.Original))
                            updateCommand.Parameters.AddWithValue("@SoLuong", row("SoLuong"))
                            updateCommand.Parameters.AddWithValue("@DonGia", row("DonGia"))
                            updateCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Deleted Then
                        ' Xóa hàng khỏi cơ sở dữ liệu
                        Dim deleteQuery = "DELETE FROM ChiTietBan WHERE MaHDB = @MaHDB AND MaDT = @MaDT"
                        Using deleteCommand As New SqlCommand(deleteQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@MaHDB", row("MaHDB", DataRowVersion.Original))
                            deleteCommand.Parameters.AddWithValue("@MaDT", row("MaDT", DataRowVersion.Original))
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

    Private Sub btn_huyctban_Click(sender As Object, e As EventArgs) Handles btn_huyctban.Click
        Dim query = "SELECT * FROM ChiTietBan"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)
                dg_ctban.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub btn_timkiemctban_Click(sender As Object, e As EventArgs) Handles btn_timkiemctban.Click
        ' Lấy từ khóa tìm kiếm từ TextBox
        Dim keyword = txt_timkiemctban.Text.Trim

        ' Kiểm tra nếu từ khóa rỗng
        If String.IsNullOrEmpty(keyword) Then
            MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu với từ khóa
        Dim query = "SELECT * FROM ChiTietBan WHERE MaHDB LIKE @Keyword OR MaDT LIKE @Keyword"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Keyword", "%" & keyword & "%")
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)

                ' Gán dữ liệu vào DataGridView
                dg_ctban.DataSource = table

                ' Kiểm tra nếu không có kết quả
                If table.Rows.Count = 0 Then
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Private Sub btn_xdlctban_Click(sender As Object, e As EventArgs) Handles btn_xdlctban.Click
        ' Lấy dữ liệu từ DataGridView
        Dim dgv As DataGridView = dg_ctban

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

    Private Sub btn_themnhap_Click(sender As Object, e As EventArgs) Handles btn_themnhap.Click
        ' Lấy thông tin từ các TextBox
        Dim mahoadon = txt_mhdnhap.Text.Trim
        Dim ngaynhap = txt_ngaynhap.Text.Trim
        Dim mancc = txt_mnccnhap.Text.Trim
        Dim manv = txt_mnvnhap.Text.Trim
        Dim tongtien = txt_tongtiennhap.Text.Trim

        ' Kiểm tra dữ liệu đầu vào
        If String.IsNullOrEmpty(mahoadon) OrElse String.IsNullOrEmpty(ngaynhap) OrElse String.IsNullOrEmpty(mancc) OrElse String.IsNullOrEmpty(manv) OrElse String.IsNullOrEmpty(tongtien) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_dhnhap.DataSource, DataTable)
        If table Is Nothing Then
            ' Nếu DataTable chưa tồn tại, tạo mới
            table = New DataTable
            table.Columns.Add("MaHDN", GetType(String))
            table.Columns.Add("NgayNhap", GetType(Date))
            table.Columns.Add("MaNCC", GetType(String))
            table.Columns.Add("MaNV", GetType(String))
            table.Columns.Add("TongTien", GetType(String))
            dg_dhnhap.DataSource = table
        End If

        ' Thêm hàng mới vào DataTable
        Dim newRow = table.NewRow
        newRow("MaHDN") = mahoadon.Trim
        newRow("NgayNhap") = ngaynhap.Trim
        newRow("MaNCC") = mancc.Trim
        newRow("MaNV") = manv.Trim
        newRow("TongTien") = tongtien.Trim
        table.Rows.Add(newRow)
    End Sub

    Private Sub dg_dhnhap_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_dhnhap.CellClick
        ' Kiểm tra xem người dùng có nhấn vào một ô hợp lệ không
        If e.RowIndex >= 0 Then
            Dim selectedRow = dg_dhnhap.Rows(e.RowIndex)
            ' Điền dữ liệu của hàng được chọn vào các TextBox
            txt_mhdnhap.Text = selectedRow.Cells("MaHDN").Value?.ToString.Trim
            txt_ngaynhap.Text = selectedRow.Cells("NgayNhap").Value?.ToString.Trim
            txt_mnccnhap.Text = selectedRow.Cells("MaNCC").Value?.ToString.Trim
            txt_mnvnhap.Text = selectedRow.Cells("MaNV").Value?.ToString.Trim
            txt_tongtiennhap.Text = selectedRow.Cells("TongTien").Value?.ToString.Trim
        End If
    End Sub
    Private Sub btn_suanhap_Click(sender As Object, e As EventArgs) Handles btn_suanhap.Click
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_dhnhap.CurrentRow Is Nothing Then
            MessageBox.Show("Vui lòng chọn một đơn hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Lấy hàng hiện tại
        Dim selectedRow = dg_dhnhap.CurrentRow
        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_dhnhap.DataSource, DataTable)
        If table Is Nothing Then
            MessageBox.Show("Không tìm thấy DataTable!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Tìm hàng tương ứng trong DataTable
        Dim rowIndex = selectedRow.Index
        If rowIndex >= 0 AndAlso rowIndex < table.Rows.Count Then
            Dim dataRow = table.Rows(rowIndex)
            ' Cập nhật dữ liệu
            dataRow("MaHDN") = txt_mhdnhap.Text.Trim
            dataRow("NgayNhap") = txt_ngaynhap.Text.Trim
            dataRow("MaNCC") = txt_mnccnhap.Text.Trim
            dataRow("MaNV") = txt_mnvnhap.Text.Trim
            dataRow("TongTien") = txt_tongtien.Text.Trim
        End If
    End Sub
    Private Sub btn_xoanhap_Click(sender As Object, e As EventArgs) Handles btn_xoanhap.Click
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_dhnhap.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hàng có đơn hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Xóa hàng được chọn
        For Each selectedRow As DataGridViewRow In dg_dhnhap.SelectedRows
            If Not selectedRow.IsNewRow Then
                dg_dhnhap.Rows.Remove(selectedRow)
            End If
        Next
    End Sub

    Private Sub btn_luunhap_Click(sender As Object, e As EventArgs) Handles btn_luunhap.Click
        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dg_dhnhap.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kết thúc chỉnh sửa trong DataGridView
        dg_dhnhap.EndEdit()

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_dhnhap.DataSource, DataTable)
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
                        Dim insertQuery = "INSERT INTO HoaDonNhap (MaHDN, NgayNhap, MaNCC, MaNV, TongTien) VALUES (@MaHoaDonNhap, @NgayNhap, @MaNCC, @MaNV, @TongTien)"
                        Using insertCommand As New SqlCommand(insertQuery, connection)
                            insertCommand.Parameters.AddWithValue("@MaHoaDonNhap", row("MaHDN"))
                            insertCommand.Parameters.AddWithValue("@NgayNhap", row("NgayNhap"))
                            insertCommand.Parameters.AddWithValue("@MaNCC", row("MaNCC"))
                            insertCommand.Parameters.AddWithValue("@MaNV", row("MaNV"))
                            insertCommand.Parameters.AddWithValue("@TongTien", row("TongTien"))
                            insertCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Modified Then
                        ' Cập nhật hàng trong cơ sở dữ liệu
                        Dim updateQuery = "UPDATE HoaDonNhap SET MaHDN = @MaHoaDonNhap, NgayNhap = @NgayNhap, MaNCC = @MaNCC, MaNV = @MaNV, TongTien = @TongTien WHERE MaHDN = @OriginalMaHoaDonNhap"
                        Using updateCommand As New SqlCommand(updateQuery, connection)
                            updateCommand.Parameters.AddWithValue("@MaHoaDonNhap", row("MaHDN"))
                            updateCommand.Parameters.AddWithValue("@OriginalMaHoaNhap", row("MaHDN", DataRowVersion.Original))
                            updateCommand.Parameters.AddWithValue("@NgayNhap", row("NgayNhap"))
                            updateCommand.Parameters.AddWithValue("@MaNCC", row("MaNCC"))
                            updateCommand.Parameters.AddWithValue("@MaNV", row("MaNV"))
                            updateCommand.Parameters.AddWithValue("@TongTien", row("TongTien"))
                            updateCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Deleted Then
                        ' Xóa hàng khỏi cơ sở dữ liệu
                        Dim deleteQuery = "DELETE FROM HoaDonNhap WHERE MaHDN = @MaHoaDonNhap"
                        Using deleteCommand As New SqlCommand(deleteQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@MaHoaDonNhap", row("MaHDN", DataRowVersion.Original))
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
    Private Sub btn_huynhap_Click(sender As Object, e As EventArgs) Handles btn_huynhap.Click
        Dim query = "SELECT * FROM HoaDonNhap"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)
                dg_dhnhap.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub btn_timkiemnhap_Click(sender As Object, e As EventArgs) Handles btn_timkiemnhap.Click
        ' Lấy từ khóa tìm kiếm từ TextBox
        Dim keyword = txt_timkiemhdnhap.Text.Trim

        ' Kiểm tra nếu từ khóa rỗng
        If String.IsNullOrEmpty(keyword) Then
            MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu với từ khóa
        Dim query = "SELECT * FROM HoaDonNhap WHERE MaHDN LIKE @Keyword or NgayNhap like @Keyword or MaNCC like @keyword or MaNV like @keyword"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Keyword", "%" & keyword & "%")
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)

                ' Gán dữ liệu vào DataGridView
                dg_dhnhap.DataSource = table

                ' Kiểm tra nếu không có kết quả
                If table.Rows.Count = 0 Then
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Private Sub btn_xdlnhap_Click(sender As Object, e As EventArgs) Handles btn_xdlnhap.Click
        ' Lấy dữ liệu từ DataGridView
        Dim dgv As DataGridView = dg_dhnhap

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

    Private Sub btn_themctnhap_Click(sender As Object, e As EventArgs) Handles btn_themctnhap.Click
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
        Dim madonhang = txt_ctmdhnhap.Text.Trim
        Dim madienthoai = txt_ctmadtnhap.Text.Trim
        Dim soluong = txt_ctsoluongnhap.Text.Trim
        Dim dongia = txt_ctdongianhap.Text.Trim
        Dim thanhtien = CDec(soluong) * CDec(dongia)
        ' Kiểm tra dữ liệu đầu vào
        If String.IsNullOrEmpty(madienthoai) OrElse String.IsNullOrEmpty(madonhang) OrElse String.IsNullOrEmpty(soluong) OrElse String.IsNullOrEmpty(dongia) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_ctnhap.DataSource, DataTable)
        If table Is Nothing Then
            ' Nếu DataTable chưa tồn tại, tạo mới
            table = New DataTable
            table.Columns.Add("MaHDN", GetType(String))
            table.Columns.Add("MaDT", GetType(String))
            table.Columns.Add("SoLuong", GetType(Integer))
            table.Columns.Add("DonGia", GetType(Decimal))
            table.Columns.Add("ThanhTien", GetType(Decimal))
            dg_ctnhap.DataSource = table
        End If

        ' Thêm hàng mới vào DataTable
        Dim newRow = table.NewRow
        newRow("MaHDN") = madonhang.Trim()
        newRow("MaDT") = madienthoai.Trim()
        newRow("SoLuong") = soluong.Trim()
        newRow("DonGia") = dongia.Trim()
        newRow("ThanhTien") = thanhtien
        table.Rows.Add(newRow)
    End Sub
    Private Sub dg_ctnhap_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_ctnhap.CellClick
        ' Kiểm tra xem người dùng có nhấn vào một ô hợp lệ không
        If e.RowIndex >= 0 Then
            Dim selectedRow = dg_ctnhap.Rows(e.RowIndex)
            ' Điền dữ liệu của hàng được chọn vào các TextBox
            txt_ctmdhnhap.Text = selectedRow.Cells("MaHDN").Value?.ToString.Trim
            txt_ctmadtnhap.Text = selectedRow.Cells("MaDT").Value?.ToString.Trim
            txt_ctsoluongnhap.Text = selectedRow.Cells("SoLuong").Value?.ToString.Trim
            txt_ctdongianhap.Text = selectedRow.Cells("DonGia").Value?.ToString.Trim
        End If
    End Sub

    Private Sub btn_suactnhap_Click(sender As Object, e As EventArgs) Handles btn_suactnhap.Click
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
        If dg_ctnhap.CurrentRow Is Nothing Then
            MessageBox.Show("Vui lòng chọn một đơn hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy hàng hiện tại
        Dim selectedRow = dg_ctnhap.CurrentRow

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_ctnhap.DataSource, DataTable)
        If table Is Nothing Then
            MessageBox.Show("Không tìm thấy DataTable!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Tìm hàng tương ứng trong DataTable
        Dim rowIndex = selectedRow.Index
        If rowIndex >= 0 AndAlso rowIndex < table.Rows.Count Then
            Dim dataRow = table.Rows(rowIndex)

            ' Cập nhật dữ liệu

            dataRow("MaHDN") = txt_ctmdhnhap.Text.Trim()
            dataRow("MaDT") = txt_ctmadtnhap.Text.Trim()
            dataRow("SoLuong") = txt_ctsoluongnhap.Text.Trim()
            dataRow("DonGia") = txt_ctdongianhap.Text.Trim()
            Dim soluong = txt_ctsoluongnhap.Text.Trim()
            Dim dongia = txt_ctdongianhap.Text.Trim()
            Dim thanhtien = CDec(soluong) * CDec(dongia)
            dataRow("ThanhTien") = thanhtien
        End If
    End Sub
    Private Sub btn_xoactnhap_Click(sender As Object, e As EventArgs) Handles btn_xoactnhap.Click
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_ctnhap.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hàng có đơn hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Xóa hàng được chọn
        For Each selectedRow As DataGridViewRow In dg_ctnhap.SelectedRows
            If Not selectedRow.IsNewRow Then
                dg_ctnhap.Rows.Remove(selectedRow)
            End If
        Next
    End Sub

    Private Sub btn_luuctnhap_Click(sender As Object, e As EventArgs) Handles btn_luuctnhap.Click
        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dg_ctnhap.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kết thúc chỉnh sửa trong DataGridView
        dg_ctnhap.EndEdit()

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_ctnhap.DataSource, DataTable)
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
                        Dim insertQuery = "INSERT INTO ChiTietNhap (MaHDN, MaDT, SoLuong, DonGia) VALUES (@MaHDN,@MaDT,@SoLuong,@DonGia)"
                        Using insertCommand As New SqlCommand(insertQuery, connection)
                            insertCommand.Parameters.AddWithValue("@MaHDN", row("MaHDN"))
                            insertCommand.Parameters.AddWithValue("@MaDT", row("MaDT"))
                            insertCommand.Parameters.AddWithValue("@SoLuong", row("SoLuong"))
                            insertCommand.Parameters.AddWithValue("@DonGia", row("DonGia"))
                            insertCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Modified Then
                        ' Cập nhật hàng trong cơ sở dữ liệu
                        Dim updateQuery = "UPDATE ChiTietNhap SET MaHDN = @MaHDN, MaDT = @MaDT, SoLuong = @SoLuong, DonGia = @DonGia WHERE MaHDN = @OriginalMaHDN AND MaDT = @OriginalMaDT"
                        Using updateCommand As New SqlCommand(updateQuery, connection)
                            updateCommand.Parameters.AddWithValue("@MaHDN", row("MaHDN"))
                            updateCommand.Parameters.AddWithValue("@OriginalMaHDN", row("MaHDN", DataRowVersion.Original))
                            updateCommand.Parameters.AddWithValue("@MaDT", row("MaDT"))
                            updateCommand.Parameters.AddWithValue("@OriginalMaDT", row("MaDT", DataRowVersion.Original))
                            updateCommand.Parameters.AddWithValue("@SoLuong", row("SoLuong"))
                            updateCommand.Parameters.AddWithValue("@DonGia", row("DonGia"))
                            updateCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Deleted Then
                        ' Xóa hàng khỏi cơ sở dữ liệu
                        Dim deleteQuery = "DELETE FROM ChiTietNhap WHERE MaHDN = @MaHDN AND MaDT = @MaDT"
                        Using deleteCommand As New SqlCommand(deleteQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@MaDT", row("MaDT", DataRowVersion.Original))
                            deleteCommand.Parameters.AddWithValue("@MaHDN", row("MaHDN", DataRowVersion.Original))
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

    Private Sub btn_huyctnhap_Click(sender As Object, e As EventArgs) Handles btn_huyctnhap.Click
        Dim query = "SELECT * FROM ChiTietNhap"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)
                dg_ctnhap.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub btn_timkiemctnhap_Click(sender As Object, e As EventArgs) Handles btn_timkiemctnhap.Click
        ' Lấy từ khóa tìm kiếm từ TextBox
        Dim keyword = txt_timkiemctnhap.Text.Trim

        ' Kiểm tra nếu từ khóa rỗng
        If String.IsNullOrEmpty(keyword) Then
            MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu với từ khóa
        Dim query = "SELECT * FROM TaiKhoanDangNhap WHERE MaHDN LIKE @Keyword OR MaDT LIKE @Keyword"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Keyword", "%" & keyword & "%")
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)

                ' Gán dữ liệu vào DataGridView
                dg_ctnhap.DataSource = table

                ' Kiểm tra nếu không có kết quả
                If table.Rows.Count = 0 Then
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Private Sub btn_xdlctnhap_Click(sender As Object, e As EventArgs) Handles btn_xdlctnhap.Click
        ' Lấy dữ liệu từ DataGridView  
        Dim dgv As DataGridView = dg_ctnhap

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

    Private Sub Label64_MouseEnter(sender As Object, e As EventArgs) Handles Label64.MouseEnter
        Label64.BackColor = Color.FromArgb(41, 128, 185)
        Label64.ForeColor = Color.White
        Label64.Font = New Font(Label64.Font, FontStyle.Bold)
    End Sub

    Private Sub Label65_MouseEnter(sender As Object, e As EventArgs) Handles Label65.MouseEnter
        Label65.BackColor = Color.FromArgb(41, 128, 185)
        Label65.ForeColor = Color.White
        Label65.Font = New Font(Label65.Font, FontStyle.Bold)
    End Sub

    Private Sub Label64_MouseLeave(sender As Object, e As EventArgs) Handles Label64.MouseLeave
        Label64.BackColor = Color.Transparent
        Label64.ForeColor = Color.Black
        Label64.Font = New Font(Label64.Font, FontStyle.Regular)
    End Sub

    Private Sub Label65_MouseLeave(sender As Object, e As EventArgs) Handles Label65.MouseLeave
        Label65.BackColor = Color.Transparent
        Label65.ForeColor = Color.Black
        Label65.Font = New Font(Label65.Font, FontStyle.Regular)
    End Sub

    Private Sub Label66_MouseEnter(sender As Object, e As EventArgs) Handles Label66.MouseEnter
        Label66.BackColor = Color.FromArgb(41, 128, 185)
        Label66.ForeColor = Color.White
        Label66.Font = New Font(Label66.Font, FontStyle.Bold)
    End Sub

    Private Sub Label67_MouseEnter(sender As Object, e As EventArgs) Handles Label67.MouseEnter
        Label67.BackColor = Color.FromArgb(41, 128, 185)
        Label67.ForeColor = Color.White
        Label67.Font = New Font(Label67.Font, FontStyle.Bold)
    End Sub

    Private Sub Label66_MouseLeave(sender As Object, e As EventArgs) Handles Label66.MouseLeave
        Label66.BackColor = Color.Transparent
        Label66.ForeColor = Color.Black
        Label66.Font = New Font(Label66.Font, FontStyle.Regular)
    End Sub

    Private Sub Label67_MouseLeave(sender As Object, e As EventArgs) Handles Label67.MouseLeave
        Label67.BackColor = Color.Transparent
        Label67.ForeColor = Color.Black
        Label67.Font = New Font(Label67.Font, FontStyle.Regular)
    End Sub

    Private Sub Label64_Click(sender As Object, e As EventArgs) Handles Label64.Click

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

        If quyen.Trim() = "Admin" Or quyen.Trim() = "Storekeeper" Then
            btn_themnhap.Enabled = True
            btn_suanhap.Enabled = True
            btn_xoanhap.Enabled = True
            btn_luunhap.Enabled = True
            btn_huynhap.Enabled = True
            btn_xdlnhap.Enabled = True
        Else
            btn_themnhap.Enabled = False
            btn_suanhap.Enabled = False
            btn_xoanhap.Enabled = False
            btn_luunhap.Enabled = False
            btn_huynhap.Enabled = False
            btn_xdlnhap.Enabled = False
        End If

        Dim dataQuery As String = "SELECT * FROM HoaDonNhap"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(dataQuery, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dg_dhnhap.DataSource = table
            End Using
        End Using

        SwitchPanel(pnl_dhnhap)
        AddHandler dg_dhnhap.CellClick, AddressOf dg_dhnhap_CellClick
    End Sub

    Private Sub Label65_Click(sender As Object, e As EventArgs) Handles Label65.Click

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
            btn_themdhban.Enabled = True
            btn_suadhban.Enabled = True
            btn_xoadhban.Enabled = True
            btn_luudhban.Enabled = True
            btn_huydhban.Enabled = True
            btn_xdldhban.Enabled = True
        Else
            btn_themdhban.Enabled = False
            btn_suadhban.Enabled = False
            btn_xoadhban.Enabled = False
            btn_luudhban.Enabled = False
            btn_huydhban.Enabled = False
            btn_xdldhban.Enabled = False
        End If

        Dim dataQuery As String = "SELECT * FROM HoaDonBan"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(dataQuery, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dg_dhban.DataSource = table
            End Using
        End Using

        SwitchPanel(pnl_dhban)
        AddHandler dg_dhban.CellClick, AddressOf dg_dhban_CellClick
    End Sub

    Private Sub Label66_Click(sender As Object, e As EventArgs) Handles Label66.Click


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

        If quyen.Trim() = "Admin" Or quyen.Trim() = "Storekeeper" Then
            btn_themctnhap.Enabled = True
            btn_suactnhap.Enabled = True
            btn_xoactnhap.Enabled = True
            btn_luuctnhap.Enabled = True
            btn_huyctnhap.Enabled = True
            btn_xdlctnhap.Enabled = True
        Else
            btn_themctnhap.Enabled = False
            btn_suactnhap.Enabled = False
            btn_xoactnhap.Enabled = False
            btn_luuctnhap.Enabled = False
            btn_huyctnhap.Enabled = False
            btn_xdlctnhap.Enabled = False
        End If

        Dim dataQuery As String = "SELECT * FROM ChiTietNhap"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(dataQuery, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dg_ctnhap.DataSource = table
            End Using
        End Using

        SwitchPanel(pnl_ctnhap)
        AddHandler dg_ctnhap.CellClick, AddressOf dg_ctnhap_CellClick
    End Sub

    Private Sub Label67_Click(sender As Object, e As EventArgs) Handles Label67.Click

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
            btn_themctban.Enabled = True
            btn_suactban.Enabled = True
            btn_xoactban.Enabled = True
            btn_luuctban.Enabled = True
            btn_huyctban.Enabled = True
            btn_xdlctban.Enabled = True
        Else
            btn_themctban.Enabled = False
            btn_suactban.Enabled = False
            btn_xoactban.Enabled = False
            btn_luuctban.Enabled = False
            btn_huyctban.Enabled = False
            btn_xdlctban.Enabled = False
        End If

        Dim dataQuery As String = "SELECT * FROM ChiTietBan"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(dataQuery, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dg_ctban.DataSource = table
            End Using
        End Using

        SwitchPanel(pnl_ctban)
        AddHandler dg_ctban.CellClick, AddressOf dg_ctban_CellClick
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

        RemoveHandler dg_ctban.CellClick, AddressOf dg_ctban_CellClick
        RemoveHandler dg_ctnhap.CellClick, AddressOf dg_ctnhap_CellClick
        RemoveHandler dg_dhban.CellClick, AddressOf dg_dhban_CellClick
        RemoveHandler dg_dhnhap.CellClick, AddressOf dg_dhnhap_CellClick
    End Sub

    Private Sub btn_thoat_Click(sender As Object, e As EventArgs) Handles btn_thoat.Click
        Application.Exit()
    End Sub

    Private Sub btn_home_Click(sender As Object, e As EventArgs) Handles btn_home.Click
        Me.Dispose()
        Me.Hide()
        Dim mainform As New MainForm(_username)
        mainform.Show()
    End Sub

End Class