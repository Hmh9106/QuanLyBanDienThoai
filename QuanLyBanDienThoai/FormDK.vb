Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Drawing.Drawing2D

Public Class FormDK

    Dim dbPath As String = IO.Path.Combine(Application.StartupPath, "QuanLyBanDienThoai.mdf")
    Private connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & dbPath & ";Integrated Security=True;Encrypt=False;Connect Timeout=30"

    Private isPasswordVisible As Boolean = False
    Private Sub MakeRoundButton(btn As Button)
        Dim path As New Drawing.Drawing2D.GraphicsPath()
        path.AddEllipse(0, 0, btn.Width, btn.Height)
        btn.Region = New Region(path)
    End Sub

    Public Sub BoGocButton(btn As Button, radius As Integer)
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(New Rectangle(0, 0, radius, radius), 180, 90)
        path.AddArc(New Rectangle(btn.Width - radius, 0, radius, radius), -90, 90)
        path.AddArc(New Rectangle(btn.Width - radius, btn.Height - radius, radius, radius), 0, 90)
        path.AddArc(New Rectangle(0, btn.Height - radius, radius, radius), 90, 90)
        path.CloseFigure()
        btn.Region = New Region(path)
    End Sub

    Private Sub FormDK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        chb_dkmk.BackColor = Color.Transparent
        chb_dkmk2.BackColor = Color.Transparent
        BoGocButton(btn_dk, 20)
        btn_dk.FlatStyle = FlatStyle.Flat
        btn_dk.FlatAppearance.BorderSize = 0
        BoGocButton(btn_dangnhap, 20)
        btn_dangnhap.FlatStyle = FlatStyle.Flat
        btn_dangnhap.FlatAppearance.BorderSize = 0
        ' Setup User TextBox
        txt_dktk.ForeColor = Color.Gray
        txt_dktk.Text = "Nhập tài khoản của bạn"
        txt_dktk.Font = New Font("Segoe UI", 14)
        txt_dktk.UseSystemPasswordChar = False
        txt_dktk.BackColor = pnl_dk.BackColor
        txt_dktk.BorderStyle = 1

        ' Setup Pass TextBox
        txt_dkmk.ForeColor = Color.Black
        txt_dkmk.Visible = False
        txt_dkmk_placeholder.ForeColor = Color.Gray
        txt_dkmk_placeholder.Text = "Nhập mật khẩu của bạn"
        txt_dkmk_placeholder.Font = New Font("Segoe UI", 14)
        txt_dkmk_placeholder.BackColor = pnl_dk.BackColor
        txt_dkmk.Font = New Font("Segoe UI", 14)
        txt_dkmk.UseSystemPasswordChar = False
        txt_dkmk.BorderStyle = 1

        ' Setup Pass2 TextBox
        txt_dkmk2.ForeColor = Color.Black
        txt_dkmk2.Visible = False
        txt_dkmk_placeholder2.ForeColor = Color.Gray
        txt_dkmk_placeholder2.Text = "Nhập lại mật khẩu của bạn"
        txt_dkmk_placeholder2.Font = New Font("Segoe UI", 14)
        txt_dkmk_placeholder2.BackColor = pnl_dk.BackColor
        txt_dkmk2.Font = New Font("Segoe UI", 14)
        txt_dkmk2.UseSystemPasswordChar = False
        txt_dkmk2.BorderStyle = 1
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim dbHelper As New ThuVien()
        Dim formdn As New FormDN()
        Me.Hide()
        formdn.ShowDialog()
    End Sub
    Private Sub txt_dktk_GotFocus(sender As Object, e As EventArgs) Handles txt_dktk.GotFocus
        If txt_dktk.Text = "Nhập tài khoản của bạn" Then
            txt_dktk.Text = ""
            txt_dktk.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_dktk_LostFocus(sender As Object, e As EventArgs) Handles txt_dktk.LostFocus
        If txt_dktk.Text = "" Then
            txt_dktk.Text = "Nhập tài khoản của bạn"
            txt_dktk.ForeColor = Color.Gray
        End If
    End Sub

    ' Placeholder cho Pass
    Private Sub txt_dkmk_placeholder_GotFocus(sender As Object, e As EventArgs) Handles txt_dkmk_placeholder.GotFocus
        txt_dkmk_placeholder.Visible = False
        txt_dkmk.Visible = True
        txt_dkmk.UseSystemPasswordChar = True
        txt_dkmk.Focus()
    End Sub

    Private Sub txt_dkmk2_placeholder_GotFocus(sender As Object, e As EventArgs) Handles txt_dkmk_placeholder2.GotFocus
        txt_dkmk_placeholder2.Visible = False
        txt_dkmk2.Visible = True
        txt_dkmk2.UseSystemPasswordChar = True
        txt_dkmk2.Focus()
    End Sub

    ' Khi txt_mk mất focus
    Private Sub txt_dkmk_LostFocus(sender As Object, e As EventArgs) Handles txt_dkmk.LostFocus
        If txt_dkmk.Text = "" Then
            txt_dkmk.Visible = False
            txt_dkmk_placeholder.Visible = True
        End If
    End Sub

    Private Sub txt_dkmk2_LostFocus(sender As Object, e As EventArgs) Handles txt_dkmk2.LostFocus
        If txt_dkmk2.Text = "" Then
            txt_dkmk2.Visible = False
            txt_dkmk_placeholder2.Visible = True
        End If
    End Sub

    Private Sub btn_dk_Click(sender As Object, e As EventArgs) Handles btn_dk.Click
        Dim tenDangNhap As String = txt_dktk.Text.Trim()
        Dim matkhau As String = txt_dkmk.Text.Trim()
        Dim matkhaumoi As String = txt_dkmk2.Text.Trim()
        Dim quyen As String = "User"

        If String.IsNullOrEmpty(tenDangNhap) OrElse String.IsNullOrEmpty(matkhau) Then
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Kiểm tra xem mật khẩu mới và nhập lại mật khẩu có khớp nhau không
        If matkhau <> matkhaumoi Then
            MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Kiểm tra tài khoản đã tồn tại chưa
        Dim checkQuery As String = "SELECT COUNT(*) FROM TaiKhoanDangNhap WHERE TaiKhoan = @TaiKhoan"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(checkQuery, connection)
                command.Parameters.AddWithValue("@TaiKhoan", tenDangNhap)
                connection.Open()
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End Using
        End Using

        ' Thêm tài khoản mới vào database
        Dim insertQuery = "INSERT INTO TaiKhoanDangNhap (TaiKhoan, MatKhau, Quyen) VALUES (@TaiKhoan, @MatKhau, @Quyen)"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(insertQuery, connection)
                command.Parameters.AddWithValue("@TaiKhoan", tenDangNhap)
                command.Parameters.AddWithValue("@MatKhau", matkhau)
                command.Parameters.AddWithValue("@Quyen", quyen)
                connection.Open()
                Try
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Lỗi khi lưu vào database: " & ex.Message)
                End Try
            End Using
        End Using

        MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim dbHelper As New ThuVien()
        Dim formdn As New FormDN()
        Me.Hide()
        formdn.ShowDialog()
    End Sub

    Private Sub chb_dkmk_CheckedChanged_1(sender As Object, e As EventArgs) Handles chb_dkmk.CheckedChanged
        If chb_dkmk.Checked Then
            txt_dkmk.UseSystemPasswordChar = False
        Else
            txt_dkmk.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub chb_dkmk2_CheckedChanged_1(sender As Object, e As EventArgs) Handles chb_dkmk2.CheckedChanged
        If chb_dkmk2.Checked Then
            txt_dkmk2.UseSystemPasswordChar = False
        Else
            txt_dkmk2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btn_dangnhap_Click(sender As Object, e As EventArgs) Handles btn_dangnhap.Click
        Me.Hide()
        Dim formdn As New FormDN()
        formdn.ShowDialog()
    End Sub

    Private Sub btn_thoat_Click_1(sender As Object, e As EventArgs) Handles btn_thoat.Click
        Application.Exit()
    End Sub
End Class