Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports System.Windows.Forms
Public Class FormDT

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
        Label58.BackColor = Color.Transparent
        Label59.BackColor = Color.Transparent
        GroupBox12.BackColor = Color.Transparent
        pnl_dienthoai.Visible = False
        pnl_loaidt.Visible = False
        pnl_nen.Visible = True
        pnl_dt.Visible = True

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

        currentPanel = pnl_dt
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

    Private Sub btn_themldt_Click(sender As Object, e As EventArgs) Handles btn_themldt.Click
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
        Dim maloaidt = txt_maloai.Text.Trim
        Dim tenloaidt = txt_tenloai.Text.Trim
        Dim mota = txt_mota.Text.Trim
        ' Kiểm tra dữ liệu đầu vào
        If String.IsNullOrEmpty(maloaidt) OrElse String.IsNullOrEmpty(tenloaidt) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_loaidt.DataSource, DataTable)
        If table Is Nothing Then
            ' Nếu DataTable chưa tồn tại, tạo mới
            table = New DataTable
            table.Columns.Add("MaLoai", GetType(String))
            table.Columns.Add("TenLoai", GetType(String))
            table.Columns.Add("MoTa", GetType(String))
            dg_loaidt.DataSource = table
        End If
        ' Thêm hàng mới vào DataTable
        Dim newRow = table.NewRow
        newRow("MaLoai") = maloaidt.Trim()
        newRow("TenLoai") = tenloaidt.Trim()
        newRow("MoTa") = mota.Trim()
        table.Rows.Add(newRow)
    End Sub
    Private Sub dg_loaidt_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_loaidt.CellClick
        ' Kiểm tra xem người dùng có nhấn vào một ô hợp lệ không
        If e.RowIndex >= 0 Then
            Dim selectedRow = dg_loaidt.Rows(e.RowIndex)
            ' Điền dữ liệu của hàng được chọn vào các TextBox
            txt_maloai.Text = selectedRow.Cells("MaLoai").Value?.ToString.Trim
            txt_tenloai.Text = selectedRow.Cells("TenLoai").Value?.ToString.Trim
            txt_mota.Text = selectedRow.Cells("MoTa").Value?.ToString.Trim
        End If
    End Sub

    Private Sub btn_sualdt_Click(sender As Object, e As EventArgs) Handles btn_sualdt.Click
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
        If dg_loaidt.CurrentRow Is Nothing Then
            MessageBox.Show("Vui lòng chọn một đơn hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy hàng hiện tại
        Dim selectedRow = dg_loaidt.CurrentRow

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_loaidt.DataSource, DataTable)
        If table Is Nothing Then
            MessageBox.Show("Không tìm thấy DataTable!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Tìm hàng tương ứng trong DataTable
        Dim rowIndex = selectedRow.Index
        If rowIndex >= 0 AndAlso rowIndex < table.Rows.Count Then
            Dim dataRow = table.Rows(rowIndex)

            ' Cập nhật dữ liệu
            dataRow("MaLoai") = txt_maloai.Text.Trim()
            dataRow("TenLoai") = txt_tenloai.Text.Trim()
            dataRow("MoTa") = txt_mota.Text.Trim()
        End If
    End Sub
    Private Sub btn_xoaldt_Click(sender As Object, e As EventArgs) Handles btn_xoaldt.Click
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_loaidt.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hàng có đơn hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Xóa hàng được chọn
        For Each selectedRow As DataGridViewRow In dg_loaidt.SelectedRows
            If Not selectedRow.IsNewRow Then
                dg_loaidt.Rows.Remove(selectedRow)
            End If
        Next
    End Sub

    Private Sub btn_luuldt_Click(sender As Object, e As EventArgs) Handles btn_luuldt.Click
        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dg_loaidt.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kết thúc chỉnh sửa trong DataGridView
        dg_loaidt.EndEdit()

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_loaidt.DataSource, DataTable)
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
                        Dim insertQuery = "INSERT INTO LoaiDienThoai (MaLoai, TenLoai, MoTa) VALUES (@MaLoai,@TenLoai,@MoTa)"
                        Using insertCommand As New SqlCommand(insertQuery, connection)
                            insertCommand.Parameters.AddWithValue("@MaLoai", row("MaLoai"))
                            insertCommand.Parameters.AddWithValue("@TenLoai", row("TenLoai"))
                            insertCommand.Parameters.AddWithValue("@MoTa", row("MoTa"))
                            insertCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Modified Then
                        ' Cập nhật hàng trong cơ sở dữ liệu
                        Dim updateQuery = "UPDATE LoaiDienThoai SET MaLoai = @MaLoai, TenLoai = @TenLoai, MoTa = @MoTa WHERE MaLoai = @OriginalMaLoai"
                        Using updateCommand As New SqlCommand(updateQuery, connection)
                            updateCommand.Parameters.AddWithValue("@MaLoai", row("MaLoai"))
                            updateCommand.Parameters.AddWithValue("@OriginalMaLoai", row("MaLoai", DataRowVersion.Original))
                            updateCommand.Parameters.AddWithValue("@TenLoai", row("TenLoai"))
                            updateCommand.Parameters.AddWithValue("@MoTa", row("MoTa"))
                            updateCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Deleted Then
                        ' Xóa hàng khỏi cơ sở dữ liệu
                        Dim deleteQuery = "DELETE FROM LoaiDienThoai WHERE MaLoai = @MaLoai"
                        Using deleteCommand As New SqlCommand(deleteQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@MaLoai", row("MaLoai", DataRowVersion.Original))
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
    Private Sub btn_huyldt_Click(sender As Object, e As EventArgs) Handles btn_huyldt.Click
        Dim query = "SELECT * FROM LoaiDienThoai"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)
                dg_loaidt.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub btn_timkiemloaidt_Click(sender As Object, e As EventArgs) Handles btn_timkiemloaidt.Click
        ' Lấy từ khóa tìm kiếm từ TextBox
        Dim keyword = txt_timkiemloaidt.Text.Trim

        ' Kiểm tra nếu từ khóa rỗng
        If String.IsNullOrEmpty(keyword) Then
            MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu với từ khóa
        Dim query = "SELECT * FROM LoaiDienThoai WHERE MaLoai LIKE @Keyword"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Keyword", "%" & keyword & "%")
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)

                ' Gán dữ liệu vào DataGridView
                dg_loaidt.DataSource = table

                ' Kiểm tra nếu không có kết quả
                If table.Rows.Count = 0 Then
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Private Sub btn_xdlloaidt_Click(sender As Object, e As EventArgs) Handles btn_xdlloaidt.Click
        ' Lấy dữ liệu từ DataGridView  
        Dim dgv As DataGridView = dg_loaidt

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
        table.TableStyle = "TableStyleMedium9"

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

    Private Sub Label58_MouseEnter(sender As Object, e As EventArgs) Handles Label58.MouseEnter
        Label58.BackColor = Color.FromArgb(41, 128, 185)
        Label58.ForeColor = Color.White
        Label58.Font = New Font(Label58.Font, FontStyle.Bold)
    End Sub

    Private Sub Label59_MouseEnter(sender As Object, e As EventArgs) Handles Label59.MouseEnter
        Label59.BackColor = Color.FromArgb(41, 128, 185)
        Label59.ForeColor = Color.White
        Label59.Font = New Font(Label59.Font, FontStyle.Bold)
    End Sub

    Private Sub Label58_MouseLeave(sender As Object, e As EventArgs) Handles Label58.MouseLeave
        Label58.BackColor = Color.Transparent
        Label58.ForeColor = Color.Black
        Label58.Font = New Font(Label58.Font, FontStyle.Regular)
    End Sub

    Private Sub Label59_MouseLeave(sender As Object, e As EventArgs) Handles Label59.MouseLeave
        Label59.BackColor = Color.Transparent
        Label59.ForeColor = Color.Black
        Label59.Font = New Font(Label59.Font, FontStyle.Regular)
    End Sub

    Private Sub Label58_Click(sender As Object, e As EventArgs) Handles Label58.Click
        'Truy vấn quyền từ cơ sở dữ liệu
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
        Dim dataQuery As String = "SELECT * FROM LoaiDienThoai"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(dataQuery, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dg_loaidt.DataSource = table
            End Using
        End Using
        If quyen.Trim() = "Admin" Or quyen.Trim() = "Storekeeper" Then
            btn_themldt.Enabled = True
            btn_sualdt.Enabled = True
            btn_xoaldt.Enabled = True
            btn_luuldt.Enabled = True
            btn_huyldt.Enabled = True
            btn_xdlloaidt.Enabled = True
            btn_timkiemloaidt.Enabled = True
        Else
            btn_themldt.Enabled = False
            btn_sualdt.Enabled = False
            btn_xoaldt.Enabled = False
            btn_luuldt.Enabled = False
            btn_huyldt.Enabled = False
            btn_xdlloaidt.Enabled = False
            btn_timkiemloaidt.Enabled = True
        End If
        SwitchPanel(pnl_loaidt)
        AddHandler dg_loaidt.CellClick, AddressOf dg_loaidt_CellClick
    End Sub
    Private Sub Label59_Click(sender As Object, e As EventArgs) Handles Label59.Click
        'Truy vấn quyền từ cơ sở dữ liệu
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
            btn_themdt.Enabled = True
            btn_suadt.Enabled = True
            btn_xoadt.Enabled = True
            btn_luudt.Enabled = True
            btn_huydt.Enabled = True
            btn_xdldt.Enabled = True
            btn_timkiemdt.Enabled = True
        Else
            btn_themdt.Enabled = False
            btn_suadt.Enabled = False
            btn_xoadt.Enabled = False
            btn_luudt.Enabled = False
            btn_huydt.Enabled = False
            btn_xdldt.Enabled = False
            btn_timkiemdt.Enabled = True
        End If

        pnl_dt.Visible = False
        Dim dataQuery As String = "SELECT * FROM DienThoai"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(dataQuery, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dg_dt.DataSource = table
            End Using
        End Using
        AddHandler dg_dt.CellClick, AddressOf dg_dt_CellClick
        SwitchPanel(pnl_dienthoai)
    End Sub
    Private Sub btn_themdt_Click(sender As Object, e As EventArgs) Handles btn_themdt.Click
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
        Dim madt = txt_madt.Text.Trim
        Dim tendt = txt_tendt.Text.Trim
        Dim maloai = txt_maloaidt.Text.Trim
        Dim hangsx = txt_hangsx.Text.Trim
        Dim gianhap = txt_gianhap.Text.Trim
        Dim giaban = txt_giaban.Text.Trim
        Dim soluong = txt_soluongdt.Text.Trim
        Dim mota = txt_motadt.Text.Trim
        ' Kiểm tra dữ liệu đầu vào
        If String.IsNullOrEmpty(madt) OrElse String.IsNullOrEmpty(tendt) OrElse String.IsNullOrEmpty(maloai) OrElse String.IsNullOrEmpty(hangsx) OrElse String.IsNullOrEmpty(gianhap) OrElse String.IsNullOrEmpty(giaban) OrElse String.IsNullOrEmpty(soluong) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_dt.DataSource, DataTable)
        If table Is Nothing Then
            ' Nếu DataTable chưa tồn tại, tạo mới
            table = New DataTable
            table.Columns.Add("MaDT", GetType(String))
            table.Columns.Add("TenDT", GetType(String))
            table.Columns.Add("MaLoai", GetType(String))
            table.Columns.Add("HangSX", GetType(String))
            table.Columns.Add("GiaNhap", GetType(Decimal))
            table.Columns.Add("GiaBan", GetType(Decimal))
            table.Columns.Add("MoTa", GetType(String))
            dg_dt.DataSource = table
        End If
        ' Thêm hàng mới vào DataTable
        Dim newRow = table.NewRow
        newRow("MaDT") = madt.Trim()
        newRow("TenDT") = tendt.Trim()
        newRow("MaLoai") = maloai.Trim()
        newRow("HangSX") = hangsx.Trim()
        newRow("GiaNhap") = CDec(gianhap)
        newRow("GiaBan") = CDec(giaban)
        newRow("MoTa") = mota.Trim()
        table.Rows.Add(newRow)
    End Sub

    Private Sub dg_dt_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_dt.CellClick
        ' Kiểm tra xem người dùng có nhấn vào một ô hợp lệ không
        If e.RowIndex >= 0 Then
            Dim selectedRow = dg_dt.Rows(e.RowIndex)
            ' Điền dữ liệu của hàng được chọn vào các TextBox
            txt_madt.Text = selectedRow.Cells("MaDT").Value?.ToString.Trim
            txt_tendt.Text = selectedRow.Cells("TenDT").Value?.ToString.Trim
            txt_maloaidt.Text = selectedRow.Cells("MaLoai").Value?.ToString.Trim
            txt_hangsx.Text = selectedRow.Cells("HangSX").Value?.ToString.Trim
            txt_gianhap.Text = selectedRow.Cells("GiaNhap").Value?.ToString.Trim
            txt_giaban.Text = selectedRow.Cells("GiaBan").Value?.ToString.Trim
            txt_soluongdt.Text = selectedRow.Cells("SoLuongTon").Value?.ToString.Trim
            txt_motadt.Text = selectedRow.Cells("MoTa").Value?.ToString.Trim
        End If
    End Sub

    Private Sub btn_suadt_Click(sender As Object, e As EventArgs) Handles btn_suadt.Click
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
        If dg_dt.CurrentRow Is Nothing Then
            MessageBox.Show("Vui lòng chọn một đơn hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy hàng hiện tại
        Dim selectedRow = dg_dt.CurrentRow

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_dt.DataSource, DataTable)
        If table Is Nothing Then
            MessageBox.Show("Không tìm thấy DataTable!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Tìm hàng tương ứng trong DataTable
        Dim rowIndex = selectedRow.Index
        If rowIndex >= 0 AndAlso rowIndex < table.Rows.Count Then
            Dim dataRow = table.Rows(rowIndex)

            ' Cập nhật dữ liệu
            dataRow("MaDT") = txt_madt.Text.Trim()
            dataRow("TenDT") = txt_tendt.Text.Trim()
            dataRow("MaLoai") = txt_maloaidt.Text.Trim()
            dataRow("HangSX") = txt_hangsx.Text.Trim()
            dataRow("GiaNhap") = CDec(txt_gianhap.Text.Trim())
            dataRow("GiaBan") = CDec(txt_giaban.Text.Trim())
            dataRow("SoLuongTon") = CInt(txt_soluongdt.Text.Trim())
            dataRow("MoTa") = txt_motadt.Text.Trim()
        End If
    End Sub
    Private Sub btn_xoadt_Click(sender As Object, e As EventArgs) Handles btn_xoadt.Click
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_dt.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn hàng có đơn hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Xóa hàng được chọn
        For Each selectedRow As DataGridViewRow In dg_dt.SelectedRows
            If Not selectedRow.IsNewRow Then
                dg_dt.Rows.Remove(selectedRow)
            End If
        Next
    End Sub

    Private Sub btn_luudt_Click(sender As Object, e As EventArgs) Handles btn_luudt.Click
        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dg_loaidt.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kết thúc chỉnh sửa trong DataGridView
        dg_loaidt.EndEdit()

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_loaidt.DataSource, DataTable)
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
                        Dim insertQuery = "INSERT INTO DienThoai (MaDT, TenDT, MaLoai, HangSX, GiaNhap, GiaBan, SoLuongTon, MoTa) VALUES (@MaDT,@TenDT,@MaLoai,@HangSX,@GiaNhap,@GiaBan,@SoLuongTon,@MoTa)"
                        Using insertCommand As New SqlCommand(insertQuery, connection)
                            insertCommand.Parameters.AddWithValue("@MaDT", row("MaDT"))
                            insertCommand.Parameters.AddWithValue("@TenDT", row("TenDT"))
                            insertCommand.Parameters.AddWithValue("@MaLoai", row("MaLoai"))
                            insertCommand.Parameters.AddWithValue("@HangSX", row("HangSX"))
                            insertCommand.Parameters.AddWithValue("@GiaNhap", row("GiaNhap"))
                            insertCommand.Parameters.AddWithValue("@GiaBan", row("GiaBan"))
                            insertCommand.Parameters.AddWithValue("@SoLuongTon", row("SoLuongTon"))
                            insertCommand.Parameters.AddWithValue("@MoTa", row("MoTa"))
                            insertCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Modified Then
                        ' Cập nhật hàng trong cơ sở dữ liệu
                        Dim updateQuery = "UPDATE DienThoai SET MaDT = @MaDT, TenDT = @TenDT, MaLoai = @MaLoai, HangSX = @HangSX, GiaNhap = @GiaNhap, GiaBan = @GiaBan, SoLuongTon = @SoLuongTon, MoTa = @MoTa WHERE MaDT = @OriginalMaDT"
                        Using updateCommand As New SqlCommand(updateQuery, connection)
                            updateCommand.Parameters.AddWithValue("@MaDT", row("MaDT"))
                            updateCommand.Parameters.AddWithValue("@OriginalMaDT", row("MaDT", DataRowVersion.Original))
                            updateCommand.Parameters.AddWithValue("@TenDT", row("TenDT"))
                            updateCommand.Parameters.AddWithValue("@MaLoai", row("MaLoai"))
                            updateCommand.Parameters.AddWithValue("@HangSX", row("HangSX"))
                            updateCommand.Parameters.AddWithValue("@GiaNhap", row("GiaNhap"))
                            updateCommand.Parameters.AddWithValue("@GiaBan", row("GiaBan"))
                            updateCommand.Parameters.AddWithValue("@SoLuongTon", row("SoLuongTon"))
                            updateCommand.Parameters.AddWithValue("@MoTa", row("MoTa"))
                            updateCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Deleted Then
                        ' Xóa hàng khỏi cơ sở dữ liệu
                        Dim deleteQuery = "DELETE FROM DienThoai WHERE MaDT = @MaDT"
                        Using deleteCommand As New SqlCommand(deleteQuery, connection)
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
    Private Sub btn_huydt_Click(sender As Object, e As EventArgs) Handles btn_huydt.Click
        Dim query = "SELECT * FROM DienThoai"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)
                dg_dt.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub btn_timkiemdt_Click(sender As Object, e As EventArgs) Handles btn_timkiemdt.Click
        ' Lấy từ khóa tìm kiếm từ TextBox
        Dim keyword = txt_timkiemdt.Text.Trim

        ' Kiểm tra nếu từ khóa rỗng
        If String.IsNullOrEmpty(keyword) Then
            MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu với từ khóa
        Dim query = "SELECT * FROM TaiKhoanDangNhap WHERE MaDT LIKE @Keyword OR TenDT LIKE @Keyword OR MaLoai LIKE @Keyword OR HangSX LIKE @Keyword"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Keyword", "%" & keyword & "%")
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)

                ' Gán dữ liệu vào DataGridView
                dg_dt.DataSource = table

                ' Kiểm tra nếu không có kết quả
                If table.Rows.Count = 0 Then
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Private Sub btn_xdldt_Click(sender As Object, e As EventArgs) Handles btn_xdldt.Click
        ' Lấy dữ liệu từ DataGridView  
        Dim dgv As DataGridView = dg_dt

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

    Private Sub btn_home_Click(sender As Object, e As EventArgs) Handles btn_home.Click
        Me.Dispose()
        Me.Hide()
        Dim mainform As New MainForm(_username)
        mainform.Show()
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

        RemoveHandler dg_dt.CellClick, AddressOf dg_dt_CellClick
        RemoveHandler dg_loaidt.CellClick, AddressOf dg_loaidt_CellClick
    End Sub

    Private Sub btn_thoat_Click(sender As Object, e As EventArgs) Handles btn_thoat.Click
        Application.Exit()
    End Sub

End Class
