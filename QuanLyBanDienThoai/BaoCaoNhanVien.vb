Imports CrystalDecisions

Public Class BaoCaoNhanVien
    Private Sub BaoCaoNhanVien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tạo DataSet và TableAdapter
        Dim ds As New dsnhanvien()
        Dim adapter As New dsnhanvienTableAdapters.NhanVienTableAdapter()
        adapter.Fill(ds.NhanVien)

        ' Tạo report và gán DataSource là DataSet đã có dữ liệu
        Dim report As New crpnhanvien()
        report.SetDataSource(ds)

        ' Gán report cho CrystalReportViewer
        CrystalReportViewer1.ReportSource = report
    End Sub
End Class