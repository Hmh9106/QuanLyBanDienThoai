Public Class BaoCaoHoaDonBan
    Private Sub BaoCaoHoaDonBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tạo DataSet và TableAdapter
        Dim ds As New dshoadonban()
        Dim adapter As New dshoadonbanTableAdapters.HoaDonBanTableAdapter()
        adapter.Fill(ds.HoaDonBan)

        ' Tạo report và gán DataSource là DataSet đã có dữ liệu
        Dim report As New crphoadonban()
        report.SetDataSource(ds)

        ' Gán report cho CrystalReportViewer
        CrystalReportViewer1.ReportSource = report
    End Sub
End Class