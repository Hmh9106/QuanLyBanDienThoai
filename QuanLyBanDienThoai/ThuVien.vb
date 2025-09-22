Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Public Class ThuVien
    Dim dbPath As String = IO.Path.Combine(Application.StartupPath, "QuanLyBanDienThoai.mdf")
    Private connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & dbPath & ";Integrated Security=True;Encrypt=False;Connect Timeout=30"

    ' Hàm kết nối đến cơ sở dữ liệu
    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function

    Public LoggedInUser As String = String.Empty

        ' Hàm kiểm tra đăng nhập
        Public Function CheckLogin(username As String, password As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM TaiKhoanDangNhap WHERE TaiKhoan = @Username AND MatKhau = @Password"

        Using connection As SqlConnection = GetConnection()
            Using command As New SqlCommand(query, connection)
                ' Thêm tham số để tránh SQL Injection
                command.Parameters.AddWithValue("@Username", username)
                command.Parameters.AddWithValue("@Password", password)

                connection.Open()
                Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return result > 0
            End Using
        End Using
    End Function
End Class
