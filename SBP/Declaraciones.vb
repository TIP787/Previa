Imports System.Data.OleDb

Module Declaraciones

    Public Conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Base.mdb; User Id=admin;Password=;")

    Public cmd As New OleDbCommand
    Public da As New OleDbDataAdapter
    Public ds As New DataSet
    Public dr As OleDbDataReader
    Public CodigoABuscar As Integer
    Public Sql As String = ""

    Sub Conectarse()
        On Error GoTo Salir
        Conn.Open()
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)

    End Sub
End Module
