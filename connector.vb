Imports MySql.Data.MySqlClient
Public Class Connector
    Private Shared ConnectionString As String = "Server=localhost;Port=3306;Database=vb_sekolah;Uid=root;Pwd=;"

    Public Shared Function GetConnection() As MySqlConnection
        Dim connection As New MySqlConnection(ConnectionString)
        Return connection
    End Function
End Class
