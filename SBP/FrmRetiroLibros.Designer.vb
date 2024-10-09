<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRetiroLibros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRetiroLibros))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GrillaInventario = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.RdoCategoria = New System.Windows.Forms.RadioButton()
        Me.RdoCodigo = New System.Windows.Forms.RadioButton()
        Me.RdoNombre = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GrillaInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GrillaInventario)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(674, 294)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'GrillaInventario
        '
        Me.GrillaInventario.AllowUserToAddRows = False
        Me.GrillaInventario.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        Me.GrillaInventario.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaInventario.Location = New System.Drawing.Point(6, 22)
        Me.GrillaInventario.Name = "GrillaInventario"
        Me.GrillaInventario.ReadOnly = True
        Me.GrillaInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaInventario.Size = New System.Drawing.Size(662, 266)
        Me.GrillaInventario.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBuscar)
        Me.GroupBox1.Controls.Add(Me.RdoCategoria)
        Me.GroupBox1.Controls.Add(Me.RdoCodigo)
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
        Me.txtBuscar.Location = New System.Drawing.Point(241, 21)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(427, 23)
        Me.txtBuscar.TabIndex = 4
        '
        'RdoCategoria
        '
        Me.RdoCategoria.AutoSize = True
        Me.RdoCategoria.Location = New System.Drawing.Point(154, 22)
        Me.RdoCategoria.Name = "RdoCategoria"
        Me.RdoCategoria.Size = New System.Drawing.Size(81, 20)
        Me.RdoCategoria.TabIndex = 2
        Me.RdoCategoria.Text = "Categoria"
        Me.RdoCategoria.UseVisualStyleBackColor = True
        '
        'RdoCodigo
        '
        Me.RdoCodigo.AutoSize = True
        Me.RdoCodigo.Location = New System.Drawing.Point(83, 22)
        Me.RdoCodigo.Name = "RdoCodigo"
        Me.RdoCodigo.Size = New System.Drawing.Size(65, 20)
        Me.RdoCodigo.TabIndex = 1
        Me.RdoCodigo.Text = "Codigo"
        Me.RdoCodigo.UseVisualStyleBackColor = True
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
        'FrmRetiroLibros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 379)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRetiroLibros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Libros"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GrillaInventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GrillaInventario As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents RdoCategoria As System.Windows.Forms.RadioButton
    Friend WithEvents RdoCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents RdoNombre As System.Windows.Forms.RadioButton
End Class
