Imports MySql.Data.MySqlClient
Public Class SiswaController

    Public Shared Sub GetData(DataGridView As DataGridView)
        Using connection As MySqlConnection = Connector.GetConnection()
            connection.Open()

            Dim query As String = "SELECT * FROM tb_siswa"
            Using cmd As New MySqlCommand(query, connection)
                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    ' Bind DataTable ke DataGridView
                    DataGridView.DataSource = dt
                End Using
            End Using
        End Using
    End Sub

    Public Shared Sub InsertData(DataGridView As DataGridView, nisn As String, nama As String, kelas As String, alamat As String)
        Using connection As MySqlConnection = Connector.GetConnection()

            Try
                connection.Open()

                Dim query As String = "INSERT INTO tb_siswa (Id, Nisn, Nama, Kelas, Alamat) VALUES(NULL, @nisn, @nama, @kelas, @alamat)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@nisn", nisn)
                    cmd.Parameters.AddWithValue("@nama", nama)
                    cmd.Parameters.AddWithValue("@kelas", kelas)
                    cmd.Parameters.AddWithValue("@alamat", alamat)
                    cmd.ExecuteNonQuery()
                End Using
                GetData(DataGridView)
            Catch ex As Exception
                MessageBox.Show("Gagal menyimpan data: " & ex.Message)
            End Try
        End Using
    End Sub

    Public Shared Sub UpdateData(DataGridView As DataGridView, id As String, nisn As String, nama As String, kelas As String, alamat As String)
        Using connection As MySqlConnection = Connector.GetConnection()

            Try
                connection.Open()

                Dim query As String = "UPDATE tb_siswa set Nisn = @nisn, Nama = @nama, Kelas = @kelas, Alamat = @alamat WHERE id=@id"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@nisn", nisn)
                    cmd.Parameters.AddWithValue("@nama", nama)
                    cmd.Parameters.AddWithValue("@kelas", kelas)
                    cmd.Parameters.AddWithValue("@alamat", alamat)
                    cmd.ExecuteNonQuery()
                End Using
                GetData(DataGridView)
            Catch ex As Exception
                MessageBox.Show("Gagal menyimpan data: " & ex.Message)
            End Try
        End Using
    End Sub

    Public Shared Sub DeleteData(DataGridView As DataGridView, id As String)
        Using connection As MySqlConnection = Connector.GetConnection()

            Try
                connection.Open()

                Dim query As String = "DELETE FROM tb_siswa WHERE id=@id"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                End Using
                GetData(DataGridView)
            Catch ex As Exception
                MessageBox.Show("Gagal menyimpan data: " & ex.Message)
            End Try
        End Using
    End Sub
End Class
