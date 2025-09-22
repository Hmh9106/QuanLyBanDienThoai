Public Class BaoCaoNhaCungCap

    Private Sub BaoCaoNhaCungCap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tạo DataSet và TableAdapter
        Dim ds As New dsnhacungcap()
        Dim adapter As New dsnhacungcapTableAdapters.NhaCungCapTableAdapter()
        adapter.Fill(ds.NhaCungCap)

        ' Tạo report và gán DataSource là DataSet đã có dữ liệu
        Dim report As New crpnhacungcap()
        report.SetDataSource(ds)

        ' Gán report cho CrystalReportViewer
        CrystalReportViewer1.ReportSource = report
    End Sub
End Class