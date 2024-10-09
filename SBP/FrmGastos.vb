Imports MySql.Data.MySqlClient

Public Class FrmGastos
    ' Definir la conexión y el comando MySQL
    Dim conn As New MySqlConnection("Server=192.168.1.34;Port=3306;Database=base_biblioteca;Uid=tomas;Pwd=S3gura@2024;")
    Dim cmd As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim Sql As String

    Private Sub FrmGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtpFecha.Value = Date.Now
        DTPInicio.Value = Date.Now
        DTPFinal.Value = Date.Now
        TxtMonto.Text = FormatCurrency(TxtMonto.Text, 2)
        LlenarGrilla()
    End Sub

    Sub SumarTotal()
        Dim Monto As Decimal
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        Sql = "SELECT * FROM TABLAGASTOS WHERE FECHA BETWEEN @inicio AND @final"
        cmd.CommandText = Sql
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@inicio", DTPInicio.Value)
        cmd.Parameters.AddWithValue("@final", DTPFinal.Value)
        conn.Open()
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read()
                Monto += CDec(dr("MONTO"))
            End While
            dr.Close()
            LblMontoTotal.Text = FormatCurrency(Monto, 2)
        Else
            dr.Close()
            LblMontoTotal.Text = "$ 0,00"
        End If
        conn.Close()
    End Sub

    Sub LlenarGrilla()
        Dim Monto As Decimal
        Sql = "SELECT * FROM TABLAGASTOS WHERE FECHA BETWEEN @inicio AND @final"
        Dim GastosDA As New MySqlDataAdapter(Sql, conn)
        GastosDA.SelectCommand.Parameters.AddWithValue("@inicio", DTPInicio.Value)
        GastosDA.SelectCommand.Parameters.AddWithValue("@final", DTPFinal.Value)
        Dim GastosDS As New DataSet
        GastosDA.Fill(GastosDS)
        GrillaGastos.DataSource = GastosDS.Tables(0)

        Dim Filas As DataRow
        Monto = 0
        For Each Filas In GastosDS.Tables(0).Rows
            Monto += CDec(Filas("MONTO"))
        Next
        LblMontoTotal.Text = FormatCurrency(Monto, 2)

        GrillaGastos.Columns(0).Visible = False ' ID
        GrillaGastos.Columns(1).Visible = True ' MOTIVO
        GrillaGastos.Columns(2).Visible = True ' MONTO
        GrillaGastos.Columns(3).Visible = True ' OBSERVACIONES
        GrillaGastos.Columns(4).Visible = True ' FECHA

        GrillaGastos.Columns(1).Width = 120
        GrillaGastos.Columns(2).Width = 50
        GrillaGastos.Columns(3).Width = 190
        GrillaGastos.Columns(4).Width = 90

        GrillaGastos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrillaGastos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Sub Limpiar()
        CboMotivo.Text = "Otros"
        TxtMonto.Text = "$ 0,00"
        TxtDescripcion.Clear()
        CodigoABuscar = 0
        SumarTotal()
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        On Error GoTo Salir
        If TxtMonto.Text.Trim.Length = 0 Then MsgBox("Ingrese el Monto!", , "Aviso") : TxtMonto.Select() : Exit Sub
        If CboMotivo.Text = "Alquiler" Or CboMotivo.Text = "Impuestos" Or CboMotivo.Text = "Otros" Then
        Else
            MsgBox("Seleccione un Motivo Correcto!", vbInformation, "Aviso") : Exit Sub
        End If

        If CodigoABuscar <> 0 Then MsgBox("No puede ingresar estos registros porque ya existen en la base de datos quizas usted intento editarlo o eliminarlo", vbInformation, "SGB") : Exit Sub

        Sql = "INSERT INTO TABLAGASTOS (MOTIVO, MONTO, OBSERVACIONES, FECHA) VALUES (@MOTIVO, @MONTO, @OBSERVACIONES, @FECHA)"
        Dim comando As New MySqlCommand(Sql, conn)
        comando.CommandType = CommandType.Text
        With comando.Parameters
            .AddWithValue("@MOTIVO", Trim(CboMotivo.Text))
            .AddWithValue("@MONTO", CDec(TxtMonto.Text))
            .AddWithValue("@OBSERVACIONES", Trim(TxtDescripcion.Text))
            .AddWithValue("@FECHA", DtpFecha.Value)
        End With
        conn.Open()
        comando.ExecuteNonQuery()
        conn.Close()
        MsgBox("Se Ingreso correctamente!", vbInformation, "Aviso")
        LlenarGrilla()
        Limpiar()
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub GrillaGastos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaGastos.CellContentClick
        CodigoABuscar = GrillaGastos.Rows(GrillaGastos.CurrentRow.Index).Cells(0).Value
        CboMotivo.Text = GrillaGastos.Rows(GrillaGastos.CurrentRow.Index).Cells(1).Value
        TxtMonto.Text = GrillaGastos.Rows(GrillaGastos.CurrentRow.Index).Cells(2).Value
        TxtDescripcion.Text = GrillaGastos.Rows(GrillaGastos.CurrentRow.Index).Cells(3).Value
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        On Error GoTo Salir
        If CodigoABuscar = 0 Then MsgBox("Seleccione un gasto o dato del la grilla para poder editarlo.", vbInformation, "SGB") : Exit Sub
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        Sql = "UPDATE TABLAGASTOS SET MOTIVO = @MOTIVO, MONTO = @MONTO, OBSERVACIONES = @OBSERVACIONES, FECHA = @FECHA WHERE ID = @ID"
        cmd.CommandText = Sql
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@MOTIVO", Trim(CboMotivo.Text))
        cmd.Parameters.AddWithValue("@MONTO", CDec(TxtMonto.Text))
        cmd.Parameters.AddWithValue("@OBSERVACIONES", Trim(TxtDescripcion.Text))
        cmd.Parameters.AddWithValue("@FECHA", DtpFecha.Value)
        cmd.Parameters.AddWithValue("@ID", CodigoABuscar)
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
        MsgBox("Se edito correctamente", vbInformation, "SGB")
        Limpiar()
        LlenarGrilla()
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        On Error GoTo Salir
        If CodigoABuscar = 0 Then MsgBox("Seleccione un gasto o dato del la grilla para poder eliminarlo.", vbInformation, "SGB") : Exit Sub
        If MsgBox("Desea realmente eliminarlo ?", vbYesNo, "SGB") = vbYes Then
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            Sql = "DELETE FROM TABLAGASTOS WHERE ID = @ID"
            cmd.CommandText = Sql
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@ID", CodigoABuscar)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            MsgBox("Se elimino correctamente!", vbInformation, "SGB")
            Limpiar()
            LlenarGrilla()
        End If
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles BtnFiltrar.Click
        On Error GoTo Salir
        Dim Monto As Decimal

        Dim DAFiltro As New MySqlDataAdapter("SELECT * FROM TABLAGASTOS WHERE FECHA BETWEEN @inicio AND @final", conn)
        DAFiltro.SelectCommand.Parameters.AddWithValue("@inicio", DTPInicio.Value)
        DAFiltro.SelectCommand.Parameters.AddWithValue("@final", DTPFinal.Value)
        Dim DSFILTRO As New DataSet
        DAFiltro.Fill(DSFILTRO)
        GrillaGastos.DataSource = DSFILTRO.Tables(0)
        Dim Filas As DataRow
        Monto = 0
        For Each Filas In DSFILTRO.Tables(0).Rows
            Monto += CDec(Filas("MONTO"))
        Next
        LblMontoTotal.Text = FormatCurrency(Monto, 2)
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
    End Sub
End Class
