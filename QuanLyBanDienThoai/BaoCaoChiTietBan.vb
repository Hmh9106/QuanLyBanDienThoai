Imports CrystalDecisions.CrystalReports.Engine

Public Class BaoCaoChiTietBan
    Private report As ReportDocument

    Private Sub BaoCaoChiTietBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Tạo DataSet và đổ dữ liệu
            Dim ds As New dschitietban()
            Dim adapter As New dschitietbanTableAdapters.ChiTietBanTableAdapter()
            adapter.Fill(ds.ChiTietBan)
            ' Gắn dataset vào report
            report = New crpchitietban()
            report.SetDataSource(ds)

            ' Gán cho viewer
            CrystalReportViewer1.ReportSource = report
            CrystalReportViewer1.Refresh()

        Catch ex As Exception
            MessageBox.Show("Lỗi Crystal Report: " & ex.Message)
        End Try
    End Sub

    Private Sub BaoCaoChiTietBan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If report IsNot Nothing Then
            report.Close()
            report.Dispose()
        End If
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.Dispose()
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub
End Class
