Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Reflection.Emit
Imports System.Web.UI.WebControls
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Public NotInheritable Class FormTG

    Private Sub FormTG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Dim WinCounter As Integer = 0
    Dim CHeckXorO As Boolean = False

    Public Sub endmatch()
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
    End Sub

    Public Sub wincheck()
        'O win
        If (Button1.Text = "O" And Button2.Text = "O" And Button3.Text = "O") Then
            Button1.BackColor = Color.Lime
            Button2.BackColor = Color.Lime
            Button3.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(DiemO.Text)
            DiemO.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = True
            endmatch()
        End If
        If (Button4.Text = "O" And Button5.Text = "O" And Button6.Text = "O") Then
            Button4.BackColor = Color.Lime
            Button5.BackColor = Color.Lime
            Button6.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(DiemO.Text)
            DiemO.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = True
        End If
        If (Button7.Text = "O" And Button8.Text = "O" And Button9.Text = "O") Then
            Button7.BackColor = Color.Lime
            Button8.BackColor = Color.Lime
            Button9.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(DiemO.Text)
            DiemO.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = True
            endmatch()
        End If
        If (Button1.Text = "O" And Button4.Text = "O" And Button7.Text = "O") Then
            Button1.BackColor = Color.Lime
            Button4.BackColor = Color.Lime
            Button7.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(DiemO.Text)
            DiemO.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = True
            endmatch()
        End If
        If (Button2.Text = "O" And Button5.Text = "O" And Button8.Text = "O") Then
            Button2.BackColor = Color.Lime
            Button5.BackColor = Color.Lime
            Button8.BackColor = Color.Lime

            WinCounter = Convert.ToInt64(DiemO.Text)
            DiemO.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = True
            endmatch()
        End If
        If (Button3.Text = "O" And Button6.Text = "O" And Button9.Text = "O") Then
            Button3.BackColor = Color.Lime
            Button6.BackColor = Color.Lime
            Button9.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(DiemO.Text)
            DiemO.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = True
            endmatch()
        End If
        If (Button1.Text = "O" And Button5.Text = "O" And Button9.Text = "O") Then
            Button1.BackColor = Color.Lime
            Button5.BackColor = Color.Lime
            Button9.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(DiemO.Text)
            DiemO.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = True
            endmatch()
        End If
        If (Button3.Text = "O" And Button5.Text = "O" And Button7.Text = "O") Then
            Button3.BackColor = Color.Lime
            Button5.BackColor = Color.Lime
            Button7.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(DiemO.Text)
            DiemO.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = True
            endmatch()
        End If

        ' X win
        If (Button1.Text = "X" And Button2.Text = "X" And Button3.Text = "X") Then
            Button1.BackColor = Color.Lime
            Button2.BackColor = Color.Lime
            Button3.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(diemX.Text)
            diemX.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = False
            endmatch()
        End If
        If (Button4.Text = "X" And Button5.Text = "X" And Button6.Text = "X") Then
            Button4.BackColor = Color.Lime
            Button5.BackColor = Color.Lime
            Button6.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(diemX.Text)
            diemX.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = False
            endmatch()
        End If
        If (Button7.Text = "X" And Button8.Text = "X" And Button9.Text = "X") Then
            Button7.BackColor = Color.Lime
            Button8.BackColor = Color.Lime
            Button9.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(diemX.Text)
            diemX.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = False
            endmatch()
        End If
        If (Button1.Text = "X" And Button4.Text = "X" And Button7.Text = "X") Then
            Button1.BackColor = Color.Lime
            Button4.BackColor = Color.Lime
            Button7.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(diemX.Text)
            diemX.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = False
            endmatch()
        End If
        If (Button2.Text = "X" And Button5.Text = "X" And Button8.Text = "X") Then
            Button2.BackColor = Color.Lime
            Button5.BackColor = Color.Lime
            Button8.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(diemX.Text)
            diemX.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = False
            endmatch()
        End If
        If (Button3.Text = "X" And Button6.Text = "X" And Button9.Text = "X") Then
            Button3.BackColor = Color.Lime
            Button6.BackColor = Color.Lime
            Button9.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(diemX.Text)
            diemX.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = False
            endmatch()
        End If
        If (Button1.Text = "X" And Button5.Text = "X" And Button9.Text = "X") Then
            Button1.BackColor = Color.Lime
            Button5.BackColor = Color.Lime
            Button9.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(diemX.Text)
            diemX.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = False
            endmatch()
        End If
        If (Button3.Text = "X" And Button5.Text = "X" And Button7.Text = "X") Then
            Button3.BackColor = Color.Lime
            Button5.BackColor = Color.Lime
            Button7.BackColor = Color.Lime
            WinCounter = Convert.ToInt64(diemX.Text)
            diemX.Text = Convert.ToString(WinCounter + 1)
            CHeckXorO = False
            endmatch()
        End If
    End Sub

    Public Sub turn()
        If CHeckXorO = False Then
            lbl_turn.Text = "X"
        Else
            lbl_turn.Text = "O"
        End If
    End Sub


    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click
        Dim btn As System.Windows.Forms.Button = sender
        turn()
        If CHeckXorO = True Then
            btn.Text = "X"
            CHeckXorO = False
        Else
            btn.Text = "O"
            CHeckXorO = True
        End If
        btn.Enabled = False
        wincheck()
        btn.Enabled = False
    End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_next.Click
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True

        Button1.Text = ""
        Button2.Text = ""
        Button3.Text = ""
        Button4.Text = ""
        Button5.Text = ""
        Button6.Text = ""
        Button7.Text = ""
        Button8.Text = ""
        Button9.Text = ""

        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Button6.BackColor = Color.White
        Button7.BackColor = Color.White
        Button8.BackColor = Color.White
        Button9.BackColor = Color.White
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles btn_newgame.Click
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True

        Button1.Text = ""
        Button2.Text = ""
        Button3.Text = ""
        Button4.Text = ""
        Button5.Text = ""
        Button6.Text = ""
        Button7.Text = ""
        Button8.Text = ""
        Button9.Text = ""

        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Button6.BackColor = Color.White
        Button7.BackColor = Color.White
        Button8.BackColor = Color.White
        Button9.BackColor = Color.White
        DiemO.Text = "0"
        diemX.Text = "0"

        CHeckXorO = False
    End Sub
End Class
