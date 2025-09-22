<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDN
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
        Me.pnl_dn = New System.Windows.Forms.Panel()
        Me.txt_mk_placeholder = New System.Windows.Forms.TextBox()
        Me.chb_htmkdn = New System.Windows.Forms.CheckBox()
        Me.txt_tk = New System.Windows.Forms.TextBox()
        Me.txt_mk = New System.Windows.Forms.TextBox()
        Me.btn_taotk = New System.Windows.Forms.Button()
        Me.btn_dn = New System.Windows.Forms.Button()
        Me.btn_thoat = New System.Windows.Forms.Button()
        Me.btn_home = New System.Windows.Forms.Button()
        Me.pnl_nen.SuspendLayout()
        Me.pnl_dn.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_nen
        '
        Me.pnl_nen.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.phone2
        Me.pnl_nen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnl_nen.Controls.Add(Me.btn_home)
        Me.pnl_nen.Controls.Add(Me.btn_back)
        Me.pnl_nen.Controls.Add(Me.pnl_dn)
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
        Me.btn_back.Location = New System.Drawing.Point(1218, 122)
        Me.btn_back.Name = "btn_back"
        Me.btn_back.Size = New System.Drawing.Size(73, 119)
        Me.btn_back.TabIndex = 15
        Me.btn_back.UseVisualStyleBackColor = True
        '
        'pnl_dn
        '
        Me.pnl_dn.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.Screenshot_2025_09_16_074810
        Me.pnl_dn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnl_dn.Controls.Add(Me.txt_mk_placeholder)
        Me.pnl_dn.Controls.Add(Me.chb_htmkdn)
        Me.pnl_dn.Controls.Add(Me.txt_tk)
        Me.pnl_dn.Controls.Add(Me.txt_mk)
        Me.pnl_dn.Controls.Add(Me.btn_taotk)
        Me.pnl_dn.Controls.Add(Me.btn_dn)
        Me.pnl_dn.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.pnl_dn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnl_dn.Location = New System.Drawing.Point(137, 31)
        Me.pnl_dn.Name = "pnl_dn"
        Me.pnl_dn.Size = New System.Drawing.Size(1053, 626)
        Me.pnl_dn.TabIndex = 2
        '
        'txt_mk_placeholder
        '
        Me.txt_mk_placeholder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_mk_placeholder.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_mk_placeholder.Location = New System.Drawing.Point(337, 268)
        Me.txt_mk_placeholder.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_mk_placeholder.Name = "txt_mk_placeholder"
        Me.txt_mk_placeholder.Size = New System.Drawing.Size(402, 32)
        Me.txt_mk_placeholder.TabIndex = 2
        '
        'chb_htmkdn
        '
        Me.chb_htmkdn.AutoSize = True
        Me.chb_htmkdn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chb_htmkdn.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_htmkdn.Location = New System.Drawing.Point(335, 315)
        Me.chb_htmkdn.Name = "chb_htmkdn"
        Me.chb_htmkdn.Size = New System.Drawing.Size(199, 30)
        Me.chb_htmkdn.TabIndex = 17
        Me.chb_htmkdn.Text = "Hiển thị mật khẩu"
        Me.chb_htmkdn.UseVisualStyleBackColor = True
        '
        'txt_tk
        '
        Me.txt_tk.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_tk.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.txt_tk.Location = New System.Drawing.Point(337, 216)
        Me.txt_tk.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_tk.Name = "txt_tk"
        Me.txt_tk.Size = New System.Drawing.Size(402, 32)
        Me.txt_tk.TabIndex = 1
        '
        'txt_mk
        '
        Me.txt_mk.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_mk.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.txt_mk.Location = New System.Drawing.Point(337, 268)
        Me.txt_mk.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_mk.Name = "txt_mk"
        Me.txt_mk.Size = New System.Drawing.Size(402, 32)
        Me.txt_mk.TabIndex = 2
        Me.txt_mk.UseSystemPasswordChar = True
        '
        'btn_taotk
        '
        Me.btn_taotk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_taotk.Image = Global.QuanLyBanDienThoai.My.Resources.Resources._426355997_408587568409033_1166742237866554017_n
        Me.btn_taotk.Location = New System.Drawing.Point(585, 358)
        Me.btn_taotk.Name = "btn_taotk"
        Me.btn_taotk.Size = New System.Drawing.Size(239, 56)
        Me.btn_taotk.TabIndex = 5
        Me.btn_taotk.UseVisualStyleBackColor = True
        '
        'btn_dn
        '
        Me.btn_dn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_dn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_dn.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.login1
        Me.btn_dn.Location = New System.Drawing.Point(274, 360)
        Me.btn_dn.Name = "btn_dn"
        Me.btn_dn.Size = New System.Drawing.Size(239, 54)
        Me.btn_dn.TabIndex = 3
        Me.btn_dn.UseVisualStyleBackColor = True
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
        'FormDN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1325, 687)
        Me.Controls.Add(Me.pnl_nen)
        Me.Name = "FormDN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormDN"
        Me.pnl_nen.ResumeLayout(False)
        Me.pnl_dn.ResumeLayout(False)
        Me.pnl_dn.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnl_nen As Panel
    Friend WithEvents btn_thoat As Button
    Friend WithEvents pnl_dn As Panel
    Friend WithEvents txt_mk_placeholder As TextBox
    Friend WithEvents chb_htmkdn As CheckBox
    Friend WithEvents txt_tk As TextBox
    Friend WithEvents txt_mk As TextBox
    Friend WithEvents btn_taotk As Button
    Friend WithEvents btn_dn As Button
    Friend WithEvents btn_back As Button
    Friend WithEvents btn_home As Button
End Class
