<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDK
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnl_nen = New System.Windows.Forms.Panel()
        Me.btn_back = New System.Windows.Forms.Button()
        Me.pnl_dk = New System.Windows.Forms.Panel()
        Me.txt_dkmk_placeholder2 = New System.Windows.Forms.TextBox()
        Me.txt_dkmk_placeholder = New System.Windows.Forms.TextBox()
        Me.chb_dkmk2 = New System.Windows.Forms.CheckBox()
        Me.chb_dkmk = New System.Windows.Forms.CheckBox()
        Me.btn_dangnhap = New System.Windows.Forms.Button()
        Me.btn_dk = New System.Windows.Forms.Button()
        Me.txt_dkmk2 = New System.Windows.Forms.TextBox()
        Me.txt_dkmk = New System.Windows.Forms.TextBox()
        Me.txt_dktk = New System.Windows.Forms.TextBox()
        Me.btn_thoat = New System.Windows.Forms.Button()
        Me.btn_home = New System.Windows.Forms.Button()
        Me.pnl_nen.SuspendLayout()
        Me.pnl_dk.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_nen
        '
        Me.pnl_nen.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.phone2
        Me.pnl_nen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnl_nen.Controls.Add(Me.btn_home)
        Me.pnl_nen.Controls.Add(Me.btn_back)
        Me.pnl_nen.Controls.Add(Me.pnl_dk)
        Me.pnl_nen.Controls.Add(Me.btn_thoat)
        Me.pnl_nen.Location = New System.Drawing.Point(0, 0)
        Me.pnl_nen.Name = "pnl_nen"
        Me.pnl_nen.Size = New System.Drawing.Size(1326, 688)
        Me.pnl_nen.TabIndex = 16
        '
        'btn_back
        '
        Me.btn_back.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.chevron_left
        Me.btn_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_back.Location = New System.Drawing.Point(1218, 107)
        Me.btn_back.Name = "btn_back"
        Me.btn_back.Size = New System.Drawing.Size(73, 119)
        Me.btn_back.TabIndex = 15
        Me.btn_back.UseVisualStyleBackColor = True
        '
        'pnl_dk
        '
        Me.pnl_dk.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.Screenshot_2025_09_16_074810
        Me.pnl_dk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnl_dk.Controls.Add(Me.txt_dkmk_placeholder2)
        Me.pnl_dk.Controls.Add(Me.txt_dkmk_placeholder)
        Me.pnl_dk.Controls.Add(Me.chb_dkmk2)
        Me.pnl_dk.Controls.Add(Me.chb_dkmk)
        Me.pnl_dk.Controls.Add(Me.btn_dangnhap)
        Me.pnl_dk.Controls.Add(Me.btn_dk)
        Me.pnl_dk.Controls.Add(Me.txt_dkmk2)
        Me.pnl_dk.Controls.Add(Me.txt_dkmk)
        Me.pnl_dk.Controls.Add(Me.txt_dktk)
        Me.pnl_dk.Location = New System.Drawing.Point(133, 33)
        Me.pnl_dk.Name = "pnl_dk"
        Me.pnl_dk.Size = New System.Drawing.Size(1053, 625)
        Me.pnl_dk.TabIndex = 2
        '
        'txt_dkmk_placeholder2
        '
        Me.txt_dkmk_placeholder2.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dkmk_placeholder2.Location = New System.Drawing.Point(294, 288)
        Me.txt_dkmk_placeholder2.Name = "txt_dkmk_placeholder2"
        Me.txt_dkmk_placeholder2.Size = New System.Drawing.Size(357, 38)
        Me.txt_dkmk_placeholder2.TabIndex = 21
        '
        'txt_dkmk_placeholder
        '
        Me.txt_dkmk_placeholder.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dkmk_placeholder.Location = New System.Drawing.Point(294, 227)
        Me.txt_dkmk_placeholder.Name = "txt_dkmk_placeholder"
        Me.txt_dkmk_placeholder.Size = New System.Drawing.Size(357, 38)
        Me.txt_dkmk_placeholder.TabIndex = 20
        '
        'chb_dkmk2
        '
        Me.chb_dkmk2.AutoSize = True
        Me.chb_dkmk2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chb_dkmk2.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_dkmk2.Location = New System.Drawing.Point(677, 293)
        Me.chb_dkmk2.Name = "chb_dkmk2"
        Me.chb_dkmk2.Size = New System.Drawing.Size(196, 30)
        Me.chb_dkmk2.TabIndex = 19
        Me.chb_dkmk2.Text = "hiển thị mật khẩu"
        Me.chb_dkmk2.UseVisualStyleBackColor = True
        '
        'chb_dkmk
        '
        Me.chb_dkmk.AutoSize = True
        Me.chb_dkmk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chb_dkmk.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_dkmk.Location = New System.Drawing.Point(677, 231)
        Me.chb_dkmk.Name = "chb_dkmk"
        Me.chb_dkmk.Size = New System.Drawing.Size(196, 30)
        Me.chb_dkmk.TabIndex = 18
        Me.chb_dkmk.Text = "hiển thị mật khẩu"
        Me.chb_dkmk.UseVisualStyleBackColor = True
        '
        'btn_dangnhap
        '
        Me.btn_dangnhap.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_dangnhap.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.tologin
        Me.btn_dangnhap.Location = New System.Drawing.Point(499, 350)
        Me.btn_dangnhap.Name = "btn_dangnhap"
        Me.btn_dangnhap.Size = New System.Drawing.Size(213, 56)
        Me.btn_dangnhap.TabIndex = 14
        Me.btn_dangnhap.UseVisualStyleBackColor = True
        '
        'btn_dk
        '
        Me.btn_dk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_dk.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.registerbtn1
        Me.btn_dk.Location = New System.Drawing.Point(249, 349)
        Me.btn_dk.Name = "btn_dk"
        Me.btn_dk.Size = New System.Drawing.Size(213, 57)
        Me.btn_dk.TabIndex = 12
        Me.btn_dk.UseVisualStyleBackColor = True
        '
        'txt_dkmk2
        '
        Me.txt_dkmk2.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dkmk2.Location = New System.Drawing.Point(294, 289)
        Me.txt_dkmk2.Name = "txt_dkmk2"
        Me.txt_dkmk2.Size = New System.Drawing.Size(357, 38)
        Me.txt_dkmk2.TabIndex = 11
        Me.txt_dkmk2.UseSystemPasswordChar = True
        '
        'txt_dkmk
        '
        Me.txt_dkmk.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dkmk.Location = New System.Drawing.Point(294, 227)
        Me.txt_dkmk.Name = "txt_dkmk"
        Me.txt_dkmk.Size = New System.Drawing.Size(357, 38)
        Me.txt_dkmk.TabIndex = 10
        Me.txt_dkmk.UseSystemPasswordChar = True
        '
        'txt_dktk
        '
        Me.txt_dktk.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dktk.Location = New System.Drawing.Point(294, 170)
        Me.txt_dktk.Name = "txt_dktk"
        Me.txt_dktk.Size = New System.Drawing.Size(357, 38)
        Me.txt_dktk.TabIndex = 9
        '
        'btn_thoat
        '
        Me.btn_thoat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_thoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_thoat.Location = New System.Drawing.Point(1218, 286)
        Me.btn_thoat.Name = "btn_thoat"
        Me.btn_thoat.Size = New System.Drawing.Size(73, 119)
        Me.btn_thoat.TabIndex = 1
        Me.btn_thoat.UseVisualStyleBackColor = True
        '
        'btn_home
        '
        Me.btn_home.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.house
        Me.btn_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_home.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_home.Location = New System.Drawing.Point(1218, 472)
        Me.btn_home.Name = "btn_home"
        Me.btn_home.Size = New System.Drawing.Size(73, 119)
        Me.btn_home.TabIndex = 19
        Me.btn_home.UseVisualStyleBackColor = True
        '
        'FormDK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1325, 687)
        Me.Controls.Add(Me.pnl_nen)
        Me.Name = "FormDK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormDK"
        Me.pnl_nen.ResumeLayout(False)
        Me.pnl_dk.ResumeLayout(False)
        Me.pnl_dk.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnl_nen As Panel
    Friend WithEvents pnl_dk As Panel
    Friend WithEvents txt_dkmk_placeholder2 As TextBox
    Friend WithEvents txt_dkmk_placeholder As TextBox
    Friend WithEvents chb_dkmk2 As CheckBox
    Friend WithEvents chb_dkmk As CheckBox
    Friend WithEvents btn_dangnhap As Button
    Friend WithEvents btn_dk As Button
    Friend WithEvents txt_dkmk2 As TextBox
    Friend WithEvents txt_dkmk As TextBox
    Friend WithEvents txt_dktk As TextBox
    Friend WithEvents btn_thoat As Button
    Friend WithEvents btn_back As Button
    Friend WithEvents btn_home As Button
End Class
