Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports System.Windows.Forms
Public Class FormBC
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

    ' Constructor nhận tham số
    Public Sub New(username As String)
        InitializeComponent()
        _username = username
    End Sub

    Private Sub pnl_baocao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label68.BackColor = Color.Transparent
        Label69.BackColor = Color.Transparent
        Label70.BackColor = Color.Transparent
        Label71.BackColor = Color.Transparent
        Label72.BackColor = Color.Transparent
        Label73.BackColor = Color.Transparent
        Label74.BackColor = Color.Transparent
        GroupBox15.BackColor = Color.Transparent

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

    Private Sub Label68_MouseEnter(sender As Object, e As EventArgs) Handles Label68.MouseEnter
        Label68.BackColor = Color.FromArgb(41, 128, 185)
        Label68.ForeColor = Color.White
        Label68.Font = New Font(Label68.Font, FontStyle.Bold)
    End Sub
    Private Sub Label69_MouseEnter(sender As Object, e As EventArgs) Handles Label69.MouseEnter
        Label69.BackColor = Color.FromArgb(41, 128, 185)
        Label69.ForeColor = Color.White
        Label69.Font = New Font(Label69.Font, FontStyle.Bold)
    End Sub
    Private Sub Label70_MouseEnter(sender As Object, e As EventArgs) Handles Label70.MouseEnter
        Label70.BackColor = Color.FromArgb(41, 128, 185)
        Label70.ForeColor = Color.White
        Label70.Font = New Font(Label70.Font, FontStyle.Bold)
    End Sub
    Private Sub Label71_MouseEnter(sender As Object, e As EventArgs) Handles Label71.MouseEnter
        Label71.BackColor = Color.FromArgb(41, 128, 185)
        Label71.ForeColor = Color.White
        Label71.Font = New Font(Label71.Font, FontStyle.Bold)
    End Sub
    Private Sub Label72_MouseEnter(sender As Object, e As EventArgs) Handles Label72.MouseEnter
        Label72.BackColor = Color.FromArgb(41, 128, 185)
        Label72.ForeColor = Color.White
        Label72.Font = New Font(Label72.Font, FontStyle.Bold)
    End Sub
    Private Sub Label73_MouseEnter(sender As Object, e As EventArgs) Handles Label73.MouseEnter
        Label73.BackColor = Color.FromArgb(41, 128, 185)
        Label73.ForeColor = Color.White
        Label73.Font = New Font(Label73.Font, FontStyle.Bold)
    End Sub
    Private Sub Label74_MouseEnter(sender As Object, e As EventArgs) Handles Label74.MouseEnter
        Label74.BackColor = Color.FromArgb(41, 128, 185)
        Label74.ForeColor = Color.White
        Label74.Font = New Font(Label74.Font, FontStyle.Bold)
    End Sub
    Private Sub Label68_MouseLeave(sender As Object, e As EventArgs) Handles Label68.MouseLeave
        Label68.BackColor = Color.Transparent
        Label68.ForeColor = Color.Black
        Label68.Font = New Font(Label68.Font, FontStyle.Regular)
    End Sub
    Private Sub Label69_MouseLeave(sender As Object, e As EventArgs) Handles Label69.MouseLeave
        Label69.BackColor = Color.Transparent
        Label69.ForeColor = Color.Black
        Label69.Font = New Font(Label69.Font, FontStyle.Regular)
    End Sub
    Private Sub Label70_MouseLeave(sender As Object, e As EventArgs) Handles Label70.MouseLeave
        Label70.BackColor = Color.Transparent
        Label70.ForeColor = Color.Black
        Label70.Font = New Font(Label70.Font, FontStyle.Regular)
    End Sub
    Private Sub Label71_MouseLeave(sender As Object, e As EventArgs) Handles Label71.MouseLeave
        Label71.BackColor = Color.Transparent
        Label71.ForeColor = Color.Black
        Label71.Font = New Font(Label71.Font, FontStyle.Regular)
    End Sub
    Private Sub Label72_MouseLeave(sender As Object, e As EventArgs) Handles Label72.MouseLeave
        Label72.BackColor = Color.Transparent
        Label72.ForeColor = Color.Black
        Label72.Font = New Font(Label72.Font, FontStyle.Regular)
    End Sub
    Private Sub Label73_MouseLeave(sender As Object, e As EventArgs) Handles Label73.MouseLeave
        Label73.BackColor = Color.Transparent
        Label73.ForeColor = Color.Black
        Label73.Font = New Font(Label73.Font, FontStyle.Regular)
    End Sub
    Private Sub Label74_MouseLeave(sender As Object, e As EventArgs) Handles Label74.MouseLeave
        Label74.BackColor = Color.Transparent
        Label74.ForeColor = Color.Black
        Label74.Font = New Font(Label74.Font, FontStyle.Regular)
    End Sub
    Private Sub Label74_Click(sender As Object, e As EventArgs) Handles Label74.Click
        Using f As New BaoCaoNhanVien()
            f.ShowDialog()
        End Using
    End Sub
    Private Sub Label72_Click(sender As Object, e As EventArgs) Handles Label72.Click
        Using f As New BaoCaoKhachHang()
            f.ShowDialog()
        End Using
    End Sub
    Private Sub Label73_Click(sender As Object, e As EventArgs) Handles Label73.Click
        Using f As New BaoCaoNhaCungCap()
            f.ShowDialog()
        End Using
    End Sub
    Private Sub Label70_Click(sender As Object, e As EventArgs) Handles Label70.Click
        Using f As New BaoCaoHoaDonBan()
            f.ShowDialog()
        End Using
    End Sub
    Private Sub Label68_Click(sender As Object, e As EventArgs) Handles Label68.Click
        Using f As New BaoCaoChiTietBan()
            f.ShowDialog()
        End Using
    End Sub

    Private Sub Label71_Click(sender As Object, e As EventArgs) Handles Label71.Click
        Using f As New BaoCaoHoaDonNhap()
            f.ShowDialog()
        End Using
    End Sub
    Private Sub Label69_Click(sender As Object, e As EventArgs) Handles Label69.Click
        Using f As New BaoCaoChiTietNhap()
            f.ShowDialog()
        End Using
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Me.Dispose()
        Me.Hide()
        Dim mainform As New MainForm(_username)
        mainform.ShowDialog()
    End Sub

    Private Sub btn_home_Click(sender As Object, e As EventArgs) Handles btn_home.Click
        Me.Dispose()
        Me.Hide()
        Dim mainform As New MainForm(_username)
        mainform.ShowDialog()
    End Sub

    Private Sub btn_thoat_Click(sender As Object, e As EventArgs) Handles btn_thoat.Click
        Application.Exit()
    End Sub
End Class