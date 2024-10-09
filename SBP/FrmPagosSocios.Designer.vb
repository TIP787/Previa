<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPagosSocios
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagosSocios))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GrillaSocios = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.RdoDireccion = New System.Windows.Forms.RadioButton()
        Me.RdoTelefono = New System.Windows.Forms.RadioButton()
        Me.RdoDNI = New System.Windows.Forms.RadioButton()
        Me.RdoNombre = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GrillaSocios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GrillaSocios)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(674, 294)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'GrillaSocios
        '
        Me.GrillaSocios.AllowUserToAddRows = False
        Me.GrillaSocios.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        Me.GrillaSocios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaSocios.Location = New System.Drawing.Point(6, 22)
        Me.GrillaSocios.Name = "GrillaSocios"
        Me.GrillaSocios.ReadOnly = True
        Me.GrillaSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaSocios.Size = New System.Drawing.Size(662, 266)
        Me.GrillaSocios.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBuscar)
        Me.GroupBox1.Controls.Add(Me.RdoDireccion)
        Me.GroupBox1.Controls.Add(Me.RdoTelefono)
        Me.GroupBox1.Controls.Add(Me.RdoDNI)
        Me.GroupBox1.Controls.Add(Me.RdoNombre)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(674, 54)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtrar"
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(301, 21)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(367, 23)
        Me.txtBuscar.TabIndex = 4
        '
        'RdoDireccion
        '
        Me.RdoDireccion.AutoSize = True
        Me.RdoDireccion.Location = New System.Drawing.Point(217, 22)
        Me.RdoDireccion.Name = "RdoDireccion"
        Me.RdoDireccion.Size = New System.Drawing.Size(78, 20)
        Me.RdoDireccion.TabIndex = 3
        Me.RdoDireccion.Text = "Direccion"
        Me.RdoDireccion.UseVisualStyleBackColor = True
        '
        'RdoTelefono
        '
        Me.RdoTelefono.AutoSize = True
        Me.RdoTelefono.Location = New System.Drawing.Point(135, 22)
        Me.RdoTelefono.Name = "RdoTelefono"
        Me.RdoTelefono.Size = New System.Drawing.Size(76, 20)
        Me.RdoTelefono.TabIndex = 2
        Me.RdoTelefono.Text = "Telefono"
        Me.RdoTelefono.UseVisualStyleBackColor = True
        '
        'RdoDNI
        '
        Me.RdoDNI.AutoSize = True
        Me.RdoDNI.Location = New System.Drawing.Point(83, 22)
        Me.RdoDNI.Name = "RdoDNI"
        Me.RdoDNI.Size = New System.Drawing.Size(46, 20)
        Me.RdoDNI.TabIndex = 1
        Me.RdoDNI.Text = "DNI"
        Me.RdoDNI.UseVisualStyleBackColor = True
        '
        'RdoNombre
        '
        Me.RdoNombre.AutoSize = True
        Me.RdoNombre.Checked = True
        Me.RdoNombre.Location = New System.Drawing.Point(6, 22)
        Me.RdoNombre.Name = "RdoNombre"
        Me.RdoNombre.Size = New System.Drawing.Size(71, 20)
        Me.RdoNombre.TabIndex = 0
        Me.RdoNombre.TabStop = True
        Me.RdoNombre.Text = "Nombre"
        Me.RdoNombre.UseVisualStyleBackColor = True
        '
        'FrmPagosSocios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 377)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPagosSocios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Socios"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GrillaSocios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GrillaSocios As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents RdoDireccion As System.Windows.Forms.RadioButton
    Friend WithEvents RdoTelefono As System.Windows.Forms.RadioButton
    Friend WithEvents RdoDNI As System.Windows.Forms.RadioButton
    Friend WithEvents RdoNombre As System.Windows.Forms.RadioButton
End Class
