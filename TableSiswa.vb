Public Class TableSiswa
    Private id As String

    Private Sub ClearText()
        txtNisn.Clear()
        txtNama.Clear()
        txtKelas.Clear()
        txtAlamat.Clear()
        Update.Enabled = False
        Delete.Enabled = False
        id = ""
    End Sub

    Private Sub TableSiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SiswaController.GetData(DataGridView1)
        Update.Enabled = False
        Delete.Enabled = False
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then
            Return
        End If
        Dim rows As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        If Not IsDBNull(rows.Cells(0).Value) Then
            txtNisn.Text = rows.Cells(1).Value
            txtNama.Text = rows.Cells(2).Value
            txtKelas.Text = rows.Cells(3).Value
            txtAlamat.Text = rows.Cells(4).Value
            Update.Enabled = True
            Delete.Enabled = True
            id = rows.Cells(0).Value
        End If
    End Sub

    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        ClearText()
    End Sub

    Private Sub Tambah_Click(sender As Object, e As EventArgs) Handles Tambah.Click
        If String.IsNullOrWhiteSpace(txtNisn.Text) Then
            MessageBox.Show("Nisn harus diisi!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        SiswaController.InsertData(DataGridView1, txtNisn.Text, txtNama.Text, txtKelas.Text, txtAlamat.Text)
        ClearText()
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        If String.IsNullOrWhiteSpace(id) Then
            MessageBox.Show("Anda harus memilih data terlebih dahulu!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        SiswaController.DeleteData(DataGridView1, id)
        ClearText()
    End Sub

    Private Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
        If String.IsNullOrWhiteSpace(id) Then
            MessageBox.Show("Anda harus memilih data terlebih dahulu!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        SiswaController.UpdateData(DataGridView1, id, txtNisn.Text, txtNama.Text, txtKelas.Text, txtAlamat.Text)
        ClearText()
    End Sub
End Class
