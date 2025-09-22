Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Reflection.Emit
Imports System.Web.UI.WebControls
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class MainForm

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

    Private _username As String

    Public Sub New(username As String)
        ' Bắt buộc gọi hàm này để khởi tạo form designer
        InitializeComponent()

        ' Lưu username vào biến cục bộ
        _username = username
    End Sub

    Private panelHistory As New Stack(Of System.Windows.Forms.Panel)

    Private currentPanel As System.Windows.Forms.Panel = Nothing

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnl_nen.Visible = True
        pnl_trangchu.Visible = True
        pnl_doimk.Visible = False
        pnl_quanlytaikhoan.Visible = False
        pnl_hethong.Visible = False

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

        If quyen.Trim() = "User" Then
            ptb_baocao.Visible = False
            ptb_donhang.Visible = False
            ptb_quanly.Visible = False

            Label54.Visible = False
            Label63.Visible = False
            Label55.Visible = False
        End If

        currentPanel = pnl_trangchu
    End Sub
    Private Sub SwitchPanel(newPanel As System.Windows.Forms.Panel)
        If newPanel Is Nothing Then Return

        If currentPanel IsNot Nothing AndAlso Not Object.ReferenceEquals(currentPanel, newPanel) Then
            '' Xóa dữ liệu nặng trước khi ẩn panel
            'ClearPanelResources(currentPanel)

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

    Private Sub dg_taikhoan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_taikhoan.CellClick
        ' Kiểm tra xem người dùng có nhấn vào một ô hợp lệ không
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dg_taikhoan.Rows(e.RowIndex)

            ' Điền dữ liệu của hàng được chọn vào các TextBox
            txt_qltk.Text = selectedRow.Cells("TaiKhoan").Value?.ToString().Trim()
            txt_qlmk.Text = selectedRow.Cells("MatKhau").Value?.ToString().Trim()
            cb_quyen.Text = selectedRow.Cells("Quyen").Value?.ToString().Trim()
        End If
    End Sub

    Private Sub btn_themtk_Click(sender As Object, e As EventArgs) Handles btn_themtk.Click
        ' Lấy thông tin từ các TextBox
        Dim tenDangNhap As String = txt_qltk.Text.Trim()
        Dim matKhau As String = txt_qlmk.Text.Trim()
        Dim quyen As String = cb_quyen.Text.Trim()

        ' Kiểm tra dữ liệu đầu vào
        If String.IsNullOrEmpty(tenDangNhap) OrElse String.IsNullOrEmpty(matKhau) OrElse String.IsNullOrEmpty(quyen) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy DataTable từ DataGridView
        Dim table As DataTable = TryCast(dg_taikhoan.DataSource, DataTable)
        If table Is Nothing Then
            ' Nếu DataTable chưa tồn tại, tạo mới
            table = New DataTable()
            table.Columns.Add("TaiKhoan", GetType(String))
            table.Columns.Add("MatKhau", GetType(String))
            table.Columns.Add("Quyen", GetType(String))
            dg_taikhoan.DataSource = table
        End If

        ' Thêm hàng mới vào DataTable
        Dim newRow As DataRow = table.NewRow()
        newRow("TaiKhoan") = tenDangNhap.Trim()
        newRow("MatKhau") = matKhau.Trim()
        newRow("Quyen") = quyen.Trim()
        table.Rows.Add(newRow)
    End Sub

    Private Sub btn_suatk_Click(sender As Object, e As EventArgs) Handles btn_suatk.Click
        ' Kiểm tra xem có hàng nào được chọn trong DataGridView không
        If dg_taikhoan.CurrentRow Is Nothing Then
            MessageBox.Show("Vui lòng chọn một tài khoản để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            ' Lấy hàng hiện tại
            Dim selectedRow As DataGridViewRow = dg_taikhoan.CurrentRow

            ' Lấy DataTable từ DataGridView
            Dim table As DataTable = TryCast(dg_taikhoan.DataSource, DataTable)

            ' Tìm hàng tương ứng trong DataTable
            Dim rowIndex As Integer = selectedRow.Index
            If rowIndex >= 0 AndAlso rowIndex < table.Rows.Count Then
                Dim dataRow As DataRow = table.Rows(rowIndex)

                ' Cập nhật dữ liệu
                dataRow("TaiKhoan") = txt_qltk.Text.Trim()
                dataRow("MatKhau") = txt_qlmk.Text.Trim()
                dataRow("Quyen") = cb_quyen.Text.Trim()
            End If
        End If
    End Sub

    Private Sub btn_xoatk_Click(sender As Object, e As EventArgs) Handles btn_xoatk.Click
        ' Xóa hàng được chọn
        For Each selectedRow As DataGridViewRow In dg_taikhoan.SelectedRows
            If Not selectedRow.IsNewRow Then
                dg_taikhoan.Rows.Remove(selectedRow)
            End If
        Next
    End Sub

    Private Sub btn_luutk_Click(sender As Object, e As EventArgs) Handles btn_luutk.Click
        ' Kiểm tra nếu DataGridView không có dữ liệu
        If dg_taikhoan.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kết thúc chỉnh sửa trong DataGridView
        dg_taikhoan.EndEdit()

        ' Lấy DataTable từ DataGridView
        Dim table = TryCast(dg_taikhoan.DataSource, DataTable)
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
                        Dim insertQuery = "INSERT INTO TaiKhoanDangNhap (TaiKhoan, MatKhau, Quyen) VALUES (@TaiKhoan, @MatKhau, @Quyen)"
                        Using insertCommand As New SqlCommand(insertQuery, connection)
                            insertCommand.Parameters.AddWithValue("@TaiKhoan", row("TaiKhoan"))
                            insertCommand.Parameters.AddWithValue("@MatKhau", row("MatKhau"))
                            insertCommand.Parameters.AddWithValue("@Quyen", row("Quyen"))
                            insertCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Modified Then
                        ' Cập nhật hàng trong cơ sở dữ liệu
                        Dim updateQuery = "UPDATE TaiKhoanDangNhap SET MatKhau = @MatKhau, Quyen = @Quyen WHERE TaiKhoan = @TaiKhoan"
                        Using updateCommand As New SqlCommand(updateQuery, connection)
                            updateCommand.Parameters.AddWithValue("@TaiKhoan", row("TaiKhoan"))
                            updateCommand.Parameters.AddWithValue("@MatKhau", row("MatKhau"))
                            updateCommand.Parameters.AddWithValue("@Quyen", row("Quyen"))
                            updateCommand.ExecuteNonQuery()
                        End Using
                    ElseIf row.RowState = DataRowState.Deleted Then
                        ' Xóa hàng khỏi cơ sở dữ liệu
                        Dim deleteQuery = "DELETE FROM TaiKhoanDangNhap WHERE TaiKhoan = @TaiKhoan"
                        Using deleteCommand As New SqlCommand(deleteQuery, connection)
                            deleteCommand.Parameters.AddWithValue("@TaiKhoan", row("TaiKhoan", DataRowVersion.Original))
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

    Private Sub btn_huytk_Click(sender As Object, e As EventArgs) Handles btn_huytk.Click
        Dim query As String = "SELECT * FROM TaiKhoanDangNhap"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dg_taikhoan.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub btn_timkiemtk_Click(sender As Object, e As EventArgs) Handles btn_timkiemtk.Click
        ' Lấy từ khóa tìm kiếm từ TextBox
        Dim keyword = txt_timkiemtk.Text.Trim

        ' Kiểm tra nếu từ khóa rỗng
        If String.IsNullOrEmpty(keyword) Then
            MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Truy vấn dữ liệu từ cơ sở dữ liệu với từ khóa
        Dim query = "SELECT * FROM TaiKhoanDangNhap WHERE TaiKhoan LIKE @Keyword OR Quyen LIKE @Keyword"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Keyword", "%" & keyword & "%")
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)

                ' Gán dữ liệu vào DataGridView
                dg_taikhoan.DataSource = table

                ' Kiểm tra nếu không có kết quả
                If table.Rows.Count = 0 Then
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Private Sub btn_xdltkexcel_Click(sender As Object, e As EventArgs) Handles btn_xdltkexcel.Click
        ' Lấy dữ liệu từ DataGridView  
        Dim dgv As DataGridView = dg_taikhoan

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

    Private Sub pnl_nen_Paint(sender As Object, e As PaintEventArgs) Handles pnl_nen.Paint
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
    End Sub

    Private Sub pnl_trangchu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ptb_dienthoai.BackColor = Color.Transparent
        ptb_quanly.BackColor = Color.Transparent
        ptb_baocao.BackColor = Color.Transparent
        ptb_hethong.BackColor = Color.Transparent
        ptb_tacgia.BackColor = Color.Transparent
        ptb_baocao.BackColor = Color.Transparent
        Label53.BackColor = Color.Transparent
        Label54.BackColor = Color.Transparent
        Label55.BackColor = Color.Transparent
        Label56.BackColor = Color.Transparent
        Label57.BackColor = Color.Transparent
        Label63.BackColor = Color.Transparent
    End Sub

    Private Sub ptb_dienthoai_Click(sender As Object, e As EventArgs) Handles ptb_dienthoai.Click
        Me.Hide()
        Dim formdt As New FormDT(_username)
        formdt.ShowDialog()
    End Sub

    Private Sub ptb_quanly_Click(sender As Object, e As EventArgs) Handles ptb_quanly.Click
        Me.Hide()
        Dim formql As New FormQL(_username)
        formql.ShowDialog()
    End Sub

    Private Sub ptb_donhang_Click(sender As Object, e As EventArgs) Handles ptb_donhang.Click
        Me.Hide()
        Dim formdh As New FormDH(_username)
        formdh.ShowDialog()
    End Sub

    Private Sub ptb_baocao_Click(sender As Object, e As EventArgs) Handles ptb_baocao.Click
        Me.Hide()
        Dim formbc As New FormBC(_username)
        formbc.ShowDialog()
    End Sub

    Private Sub ptb_tacgia_Click(sender As Object, e As EventArgs) Handles ptb_tacgia.Click
        Dim formtg As New FormTG()
        formtg.ShowDialog()
    End Sub

    Private Sub ptb_hethong_Click(sender As Object, e As EventArgs) Handles ptb_hethong.Click
        'Truy vấn quyền từ cơ sở dữ liệu
        Dim quyen As String = String.Empty
        Dim dbHelper As New ThuVien
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
            Label3.Visible = True
        Else
            Label3.Visible = False
        End If
        SwitchPanel(pnl_hethong)
    End Sub

    Private Sub pnl_hethong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.BackColor = Color.Transparent
        Label2.BackColor = Color.Transparent
        Label3.BackColor = Color.Transparent
    End Sub

    Private Sub btn_thoat_Click_1(sender As Object, e As EventArgs) Handles btn_thoat.Click
        Application.Exit()
    End Sub

    Private Sub btn_back_Click_1(sender As Object, e As EventArgs) Handles btn_back.Click
        If panelHistory.Count > 0 Then
            ' ẩn panel hiện tại
            If currentPanel IsNot Nothing Then
                currentPanel.Visible = False
            End If

            ' lấy panel cũ từ stack
            currentPanel = panelHistory.Pop()
            currentPanel.Visible = True
            currentPanel.BringToFront()
        End If

        RemoveHandler dg_taikhoan.CellClick, AddressOf dg_taikhoan_CellClick
    End Sub

    Private Sub btn_home_Click_1(sender As Object, e As EventArgs) Handles btn_home.Click
        pnl_nen.Visible = True
        pnl_trangchu.Visible = True
        pnl_doimk.Visible = False
        pnl_quanlytaikhoan.Visible = False
        RemoveHandler dg_taikhoan.CellClick, AddressOf dg_taikhoan_CellClick
    End Sub

    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles Label1.MouseEnter
        Label1.BackColor = Color.FromArgb(41, 128, 185)
        Label1.ForeColor = Color.White
        Label1.Font = New Font(Label1.Font, FontStyle.Bold)
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.BackColor = Color.Transparent
        Label1.ForeColor = Color.Black
        Label1.Font = New Font(Label1.Font, FontStyle.Regular)
    End Sub

    Private Sub Label2_MouseEnter(sender As Object, e As EventArgs) Handles Label2.MouseEnter
        Label2.BackColor = Color.FromArgb(41, 128, 185)
        Label2.ForeColor = Color.White
        Label2.Font = New Font(Label2.Font, FontStyle.Bold)
    End Sub

    Private Sub Label2_MouseLeave(sender As Object, e As EventArgs) Handles Label2.MouseLeave
        Label2.BackColor = Color.Transparent
        Label2.ForeColor = Color.Black
        Label2.Font = New Font(Label2.Font, FontStyle.Regular)
    End Sub

    Private Sub Label3_MouseEnter(sender As Object, e As EventArgs) Handles Label3.MouseEnter
        Label3.BackColor = Color.FromArgb(41, 128, 185)
        Label3.ForeColor = Color.White
        Label3.Font = New Font(Label3.Font, FontStyle.Bold)
    End Sub

    Private Sub Label3_MouseLeave(sender As Object, e As EventArgs) Handles Label3.MouseLeave
        Label3.BackColor = Color.Transparent
        Label3.ForeColor = Color.Black
        Label3.Font = New Font(Label3.Font, FontStyle.Regular)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        SwitchPanel(pnl_doimk)
    End Sub

    Private Sub pnl_doimk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chb_mkcu.BackColor = Color.Transparent
        chb_mkmoi.BackColor = Color.Transparent
        chb_mkmoi2.BackColor = Color.Transparent

        btn_xacnhan.FlatStyle = FlatStyle.Flat
        btn_xacnhan.FlatAppearance.BorderSize = 0
        BoGocButton(btn_xacnhan, 20)

        txt_mkcu.ForeColor = Color.Black
        txt_mkcu.Visible = False
        txt_mkcu_placeholder.ForeColor = Color.Gray
        txt_mkcu_placeholder.Text = "Nhập mật khẩu cũ của bạn"
        txt_mkcu_placeholder.Font = New Font("Segoe UI", 14)
        txt_mkcu_placeholder.BackColor = pnl_doimk.BackColor
        txt_mkcu.Font = New Font("Segoe UI", 14)
        txt_mkcu.UseSystemPasswordChar = False
        txt_mkcu.BorderStyle = 1

        txt_mkmoi.ForeColor = Color.Black
        txt_mkmoi.Visible = False
        txt_mkmoi_placeholder.ForeColor = Color.Gray
        txt_mkmoi_placeholder.Text = "Nhập mật khẩu mới"
        txt_mkmoi_placeholder.Font = New Font("Segoe UI", 14)
        txt_mkmoi_placeholder.BackColor = pnl_doimk.BackColor
        txt_mkmoi.Font = New Font("Segoe UI", 14)
        txt_mkmoi.UseSystemPasswordChar = False
        txt_mkmoi.BorderStyle = 1

        txt_mkmoi2.ForeColor = Color.Black
        txt_mkmoi2.Visible = False
        txt_mkmoi2_placeholder.ForeColor = Color.Gray
        txt_mkmoi2_placeholder.Text = "Nhập lại mật khẩu mới"
        txt_mkmoi2_placeholder.Font = New Font("Segoe UI", 14)
        txt_mkmoi2_placeholder.BackColor = pnl_doimk.BackColor
        txt_mkmoi2.Font = New Font("Segoe UI", 14)
        txt_mkmoi2.UseSystemPasswordChar = False
        txt_mkmoi2.BorderStyle = 1
    End Sub

    Private Sub txt_mkcu_placeholder_GotFocus(sender As Object, e As EventArgs) Handles txt_mkcu_placeholder.GotFocus
        txt_mkcu_placeholder.Visible = False
        txt_mkcu.Visible = True
        txt_mkcu.UseSystemPasswordChar = True
        txt_mkcu.Focus()
    End Sub

    Private Sub txt_mkcu_LostFocus(sender As Object, e As EventArgs) Handles txt_mkcu.LostFocus
        If txt_mkcu.Text = "" Then
            txt_mkcu.Visible = False
            txt_mkcu_placeholder.Visible = True
        End If
    End Sub

    Private Sub txt_mkmoi_placeholder_GotFocus(sender As Object, e As EventArgs) Handles txt_mkmoi_placeholder.GotFocus
        txt_mkmoi_placeholder.Visible = False
        txt_mkmoi.Visible = True
        txt_mkmoi.UseSystemPasswordChar = True
        txt_mkmoi.Focus()
    End Sub

    Private Sub txt_mkmoi_LostFocus(sender As Object, e As EventArgs) Handles txt_mkmoi.LostFocus
        If txt_mkmoi.Text = "" Then
            txt_mkmoi.Visible = False
            txt_mkmoi_placeholder.Visible = True
        End If
    End Sub

    Private Sub txt_mkmoi2_placeholder_GotFocus(sender As Object, e As EventArgs) Handles txt_mkmoi2_placeholder.GotFocus
        txt_mkmoi2_placeholder.Visible = False
        txt_mkmoi2.Visible = True
        txt_mkmoi2.UseSystemPasswordChar = True
        txt_mkmoi2.Focus()
    End Sub

    Private Sub txt_mkmoi2_LostFocus(sender As Object, e As EventArgs) Handles txt_mkmoi2.LostFocus
        If txt_mkmoi2.Text = "" Then
            txt_mkmoi2.Visible = False
            txt_mkmoi2_placeholder.Visible = True
        End If
    End Sub

    Private Sub btn_xacnhan_Click(sender As Object, e As EventArgs) Handles btn_xacnhan.Click
        Dim matkhaucu As String = txt_mkcu.Text.Trim()
        Dim matkhaumoi As String = txt_mkmoi.Text.Trim()
        Dim nhaplaimatkhau As String = txt_mkmoi2.Text.Trim()

        If String.IsNullOrEmpty(matkhaucu) OrElse String.IsNullOrEmpty(matkhaumoi) OrElse String.IsNullOrEmpty(nhaplaimatkhau) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If matkhaumoi <> nhaplaimatkhau Then
            MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim updateQuery As String = "UPDATE TaiKhoanDangNhap SET MatKhau = @MatKhau WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhauCu"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(updateQuery, connection)
                ' Thêm các tham số vào SqlCommand
                command.Parameters.AddWithValue("@TaiKhoan", _username)
                command.Parameters.AddWithValue("@MatKhauCu", matkhaucu)
                command.Parameters.AddWithValue("@MatKhau", matkhaumoi)
                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Tài khoản hoặc mật khẩu cũ không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Lỗi khi đổi mật khẩu: " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub chb_mkcu_CheckedChanged_1(sender As Object, e As EventArgs) Handles chb_mkcu.CheckedChanged
        If chb_mkcu.Checked Then
            txt_mkcu.UseSystemPasswordChar = False
        Else
            txt_mkcu.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub chb_mkmoi_CheckedChanged_1(sender As Object, e As EventArgs) Handles chb_mkmoi.CheckedChanged
        If chb_mkmoi.Checked Then
            txt_mkmoi.UseSystemPasswordChar = False
        Else
            txt_mkmoi.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub chb_mkmoi2_CheckedChanged_1(sender As Object, e As EventArgs) Handles chb_mkmoi2.CheckedChanged
        If chb_mkmoi2.Checked Then
            txt_mkmoi2.UseSystemPasswordChar = False
        Else
            txt_mkmoi2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Hide()
        Me.Dispose()
        Dim formdn As New FormDN()
        formdn.ShowDialog()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        SwitchPanel(pnl_quanlytaikhoan)
        Dim dataQuery As String = "SELECT * FROM TaiKhoanDangNhap"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(dataQuery, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dg_taikhoan.DataSource = table
            End Using
        End Using
    End Sub

End Class

