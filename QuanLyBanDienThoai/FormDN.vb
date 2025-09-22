
Imports System.Drawing.Drawing2D

Public Class FormDN
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

    Private Sub FormDN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        chb_htmkdn.BackColor = Color.Transparent
        BoGocButton(btn_dn, 20)
        btn_dn.FlatStyle = FlatStyle.Flat
        btn_dn.FlatAppearance.BorderSize = 0
        BoGocButton(btn_taotk, 20)
        btn_taotk.FlatStyle = FlatStyle.Flat
        btn_taotk.FlatAppearance.BorderSize = 0
        ' Setup User TextBox
        txt_tk.ForeColor = Color.Gray
        txt_tk.Text = "Nhập tài khoản của bạn"
        txt_tk.Font = New Font("Segoe UI", 14)
        txt_tk.UseSystemPasswordChar = False
        txt_tk.BackColor = pnl_dn.BackColor
        txt_tk.BorderStyle = 1

        ' Setup Pass TextBox
        txt_mk.ForeColor = Color.Black
        txt_mk.Visible = False
        txt_mk_placeholder.ForeColor = Color.Gray
        txt_mk_placeholder.Text = "Nhập mật khẩu của bạn"
        txt_mk_placeholder.Font = New Font("Segoe UI", 14)
        txt_mk_placeholder.BackColor = pnl_dn.BackColor
        txt_mk.Font = New Font("Segoe UI", 14)
        txt_mk.UseSystemPasswordChar = False
        txt_mk.BackColor = pnl_dn.BackColor
        txt_mk.BorderStyle = 1
    End Sub

    Private Sub txt_tk_GotFocus(sender As Object, e As EventArgs) Handles txt_tk.GotFocus
        If txt_tk.Text = "Nhập tài khoản của bạn" Then
            txt_tk.Text = ""
            txt_tk.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_tk_LostFocus(sender As Object, e As EventArgs) Handles txt_tk.LostFocus
        If txt_tk.Text = "" Then
            txt_tk.Text = "Nhập tài khoản của bạn"
            txt_tk.ForeColor = Color.Gray
        End If
    End Sub

    ' Placeholder cho Pass

    ' Click vào textbox placeholder
    Private Sub txt_mk_placeholder_GotFocus(sender As Object, e As EventArgs) Handles txt_mk_placeholder.GotFocus
        txt_mk_placeholder.Visible = False
        txt_mk.Visible = True
        txt_mk.UseSystemPasswordChar = True
        txt_mk.Focus()
    End Sub

    ' Khi txt_mk mất focus
    Private Sub txt_mk_LostFocus(sender As Object, e As EventArgs) Handles txt_mk.LostFocus
        If txt_mk.Text = "" Then
            txt_mk.Visible = False
            txt_mk_placeholder.Visible = True
        End If
    End Sub

    Private Sub btn_dn_Click_1(sender As Object, e As EventArgs) Handles btn_dn.Click
        Dim username As String = txt_tk.Text.Trim()
        Dim password As String = txt_mk.Text.Trim()
        Dim dbHelper As New ThuVien()

        If dbHelper.CheckLogin(username, password) Then
            ' Mở form mới
            Dim mainForm As New MainForm(username)
            Me.Hide()
            txt_mk.Clear()
            mainForm.ShowDialog()
        Else
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_mk.Clear()
        End If
    End Sub

    Private Sub btn_taotk_Click(sender As Object, e As EventArgs) Handles btn_taotk.Click
        Me.Hide()
        Dim formdk As New FormDK()
        formdk.ShowDialog()
    End Sub

    Private Sub chb_htmkdn_CheckedChanged_1(sender As Object, e As EventArgs) Handles chb_htmkdn.CheckedChanged
        If chb_htmkdn.Checked Then
            txt_mk.UseSystemPasswordChar = False
        Else
            txt_mk.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btn_thoat_Click_1(sender As Object, e As EventArgs) Handles btn_thoat.Click
        Application.Exit()
    End Sub
End Class
