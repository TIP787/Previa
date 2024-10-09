Imports MySql.Data.MySqlClient

Public Class FrmCategoria

    ' Declarar la cadena de conexión y la conexión a nivel de clase
    Dim connString As String = "Server=192.168.1.34;Port=3306;Database=base_biblioteca;Uid=tomas;Pwd=S3gura@2024;"
    Dim conn As New MySqlConnection(connString)
    Dim cmd As New MySqlCommand()
    Dim dr As MySqlDataReader
    Dim Sql As String
    Dim CodigoABuscar As Integer

    Private Sub FrmCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CodigoABuscar = 0
        LlenarGrilla()
    End Sub

    Sub LlenarGrilla()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim strsql As String = "SELECT * FROM TABLACATEGORIAS"
        Dim adp As New MySqlDataAdapter(strsql, conn)

        ds.Tables.Add("CATEGORIA")
        adp.Fill(ds.Tables("CATEGORIA"))

        Me.GrillaRubro.DataSource = ds.Tables("CATEGORIA")

        Me.GrillaRubro.Columns(0).Visible = True
        Me.GrillaRubro.Columns(1).Visible = True

        Me.GrillaRubro.Columns(0).Width = 100
        Me.GrillaRubro.Columns(1).Width = 150
        Me.GrillaRubro.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        On Error GoTo Salir

        If CodigoABuscar <> 0 Then MsgBox("No puede ingresar estos registros porque ya existen en la base de datos, quizás usted intentó editarlo o eliminarlo", vbInformation, "SGB") : Exit Sub

        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        Sql = "SELECT * FROM TABLACATEGORIAS WHERE CATEGORIA = '" & Trim(txtrubro.Text) & "'"
        cmd.CommandText = Sql

        If dr IsNot Nothing AndAlso Not dr.IsClosed Then
            dr.Close()
        End If

        conn.Open()
        dr = cmd.ExecuteReader()
        If dr.HasRows = True Then
            MsgBox("La categoría ya se encuentra ingresada, ¡por favor ingrese otra!", vbInformation, "SGB")
            dr.Close()
            conn.Close()
            Exit Sub
        Else
            dr.Close()
            If txtrubro.Text = "" Then MsgBox("¡Ingrese la categoría para continuar!", vbInformation, "Aviso") : txtrubro.Select() : Exit Sub

            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            Sql = "INSERT INTO TABLACATEGORIAS (CATEGORIA) VALUES ('" & Trim(txtrubro.Text) & "')"
            cmd.CommandText = Sql

            cmd.ExecuteNonQuery()
            conn.Close()
            MsgBox("¡Se ingresó correctamente los datos!")
            txtrubro.Text = ""
            txtrubro.Select()
            LlenarGrilla()
            CodigoABuscar = 0
        End If
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        On Error GoTo Salir
        If (CodigoABuscar = 0) Then
            MsgBox("Seleccione una categoría de la grilla para poder editarla", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        If txtrubro.Text = "" Then MsgBox("¡Ingrese la categoría para continuar!", vbInformation, "Aviso") : txtrubro.Select() : Exit Sub

        If dr IsNot Nothing AndAlso Not dr.IsClosed Then
            dr.Close()
        End If

        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        Sql = "UPDATE TABLACATEGORIAS SET CATEGORIA = '" & Trim(txtrubro.Text) & "' WHERE ID =" & CodigoABuscar
        cmd.CommandText = Sql

        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
        MsgBox("¡Se editaron correctamente los datos!")
        txtrubro.Text = ""
        txtrubro.Select()
        LlenarGrilla()
        CodigoABuscar = 0
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Private Sub btnborrar_Click(sender As Object, e As EventArgs) Handles btnborrar.Click
        On Error GoTo Salir
        If (CodigoABuscar = 0) Then
            MsgBox("Seleccione una categoría de la grilla para poder eliminarla", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If
        If (MsgBox("¿Desea realmente eliminarla?", MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes) Then
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            Sql = "DELETE FROM TABLACATEGORIAS WHERE ID =" & CodigoABuscar
            cmd.CommandText = Sql

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            MsgBox("¡Se eliminó correctamente!")
            txtrubro.Text = ""
            txtrubro.Select()
            LlenarGrilla()
            CodigoABuscar = 0

        Else
            txtrubro.Text = ""
            txtrubro.Select()
            LlenarGrilla()
            CodigoABuscar = 0
        End If
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Private Sub GrillaRubro_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaRubro.CellContentClick
        CodigoABuscar = GrillaRubro.Rows(GrillaRubro.CurrentRow.Index).Cells(0).Value
        txtrubro.Text = GrillaRubro.Rows(GrillaRubro.CurrentRow.Index).Cells(1).Value.ToString
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        CodigoABuscar = 0
        Me.Close()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
