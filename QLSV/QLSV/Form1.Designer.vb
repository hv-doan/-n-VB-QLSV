<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dtgrv_sinhvien = New DataGridView()
        Bt_add = New Button()
        Bt_edit = New Button()
        Bt_delete = New Button()
        Bt_search = New Button()
        Lb_search = New Label()
        Txt_search = New TextBox()
        Grb_sinhvien = New GroupBox()
        Cb_sinhvien = New ComboBox()
        Lb_gt = New Label()
        CType(Dtgrv_sinhvien, ComponentModel.ISupportInitialize).BeginInit()
        Grb_sinhvien.SuspendLayout()
        SuspendLayout()
        ' 
        ' Dtgrv_sinhvien
        ' 
        Dtgrv_sinhvien.BackgroundColor = Color.White
        Dtgrv_sinhvien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Dtgrv_sinhvien.Location = New Point(12, 77)
        Dtgrv_sinhvien.Name = "Dtgrv_sinhvien"
        Dtgrv_sinhvien.RowHeadersWidth = 51
        Dtgrv_sinhvien.Size = New Size(867, 471)
        Dtgrv_sinhvien.TabIndex = 0
        ' 
        ' Bt_add
        ' 
        Bt_add.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Bt_add.ForeColor = Color.HotPink
        Bt_add.Location = New Point(901, 77)
        Bt_add.Name = "Bt_add"
        Bt_add.Size = New Size(214, 29)
        Bt_add.TabIndex = 1
        Bt_add.Text = "Add"
        Bt_add.UseVisualStyleBackColor = True
        ' 
        ' Bt_edit
        ' 
        Bt_edit.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Bt_edit.ForeColor = Color.Red
        Bt_edit.Location = New Point(901, 176)
        Bt_edit.Name = "Bt_edit"
        Bt_edit.Size = New Size(214, 29)
        Bt_edit.TabIndex = 1
        Bt_edit.Text = "Edit"
        Bt_edit.UseVisualStyleBackColor = True
        ' 
        ' Bt_delete
        ' 
        Bt_delete.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Bt_delete.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Bt_delete.Location = New Point(901, 276)
        Bt_delete.Name = "Bt_delete"
        Bt_delete.Size = New Size(214, 29)
        Bt_delete.TabIndex = 1
        Bt_delete.Text = "Delete"
        Bt_delete.UseVisualStyleBackColor = True
        ' 
        ' Bt_search
        ' 
        Bt_search.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Bt_search.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(192))
        Bt_search.Location = New Point(721, 31)
        Bt_search.Name = "Bt_search"
        Bt_search.Size = New Size(158, 29)
        Bt_search.TabIndex = 1
        Bt_search.Text = "Search"
        Bt_search.UseVisualStyleBackColor = True
        ' 
        ' Lb_search
        ' 
        Lb_search.AutoSize = True
        Lb_search.BackColor = Color.White
        Lb_search.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lb_search.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(192))
        Lb_search.Location = New Point(12, 35)
        Lb_search.Name = "Lb_search"
        Lb_search.Size = New Size(59, 20)
        Lb_search.TabIndex = 2
        Lb_search.Text = "Search:"
        ' 
        ' Txt_search
        ' 
        Txt_search.Location = New Point(86, 32)
        Txt_search.Name = "Txt_search"
        Txt_search.Size = New Size(629, 27)
        Txt_search.TabIndex = 3
        ' 
        ' Grb_sinhvien
        ' 
        Grb_sinhvien.Controls.Add(Cb_sinhvien)
        Grb_sinhvien.Controls.Add(Lb_gt)
        Grb_sinhvien.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Grb_sinhvien.ForeColor = Color.Teal
        Grb_sinhvien.Location = New Point(901, 364)
        Grb_sinhvien.Name = "Grb_sinhvien"
        Grb_sinhvien.Size = New Size(226, 184)
        Grb_sinhvien.TabIndex = 4
        Grb_sinhvien.TabStop = False
        Grb_sinhvien.Text = "Filter"
        ' 
        ' Cb_sinhvien
        ' 
        Cb_sinhvien.FormattingEnabled = True
        Cb_sinhvien.Location = New Point(6, 105)
        Cb_sinhvien.Name = "Cb_sinhvien"
        Cb_sinhvien.Size = New Size(214, 28)
        Cb_sinhvien.TabIndex = 6
        ' 
        ' Lb_gt
        ' 
        Lb_gt.AutoSize = True
        Lb_gt.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lb_gt.Location = New Point(6, 50)
        Lb_gt.Name = "Lb_gt"
        Lb_gt.Size = New Size(60, 20)
        Lb_gt.TabIndex = 5
        Lb_gt.Text = "Gender"
        Lb_gt.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.top_phan_mem_quan_ly_hoc_sinh
        ClientSize = New Size(1139, 588)
        Controls.Add(Grb_sinhvien)
        Controls.Add(Txt_search)
        Controls.Add(Lb_search)
        Controls.Add(Bt_delete)
        Controls.Add(Bt_edit)
        Controls.Add(Bt_search)
        Controls.Add(Bt_add)
        Controls.Add(Dtgrv_sinhvien)
        Name = "Form1"
        Text = "Quản Lý Sinh Viên"
        CType(Dtgrv_sinhvien, ComponentModel.ISupportInitialize).EndInit()
        Grb_sinhvien.ResumeLayout(False)
        Grb_sinhvien.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Dtgrv_sinhvien As DataGridView
    Friend WithEvents Bt_add As Button
    Friend WithEvents Bt_edit As Button
    Friend WithEvents Bt_delete As Button
    Friend WithEvents Bt_search As Button
    Friend WithEvents Lb_search As Label
    Friend WithEvents Txt_search As TextBox
    Friend WithEvents Grb_sinhvien As GroupBox
    Friend WithEvents Cb_sinhvien As ComboBox
    Friend WithEvents Lb_gt As Label

End Class
