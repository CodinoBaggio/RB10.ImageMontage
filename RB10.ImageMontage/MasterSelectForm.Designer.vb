<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterSelectForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageMasterTextBox = New System.Windows.Forms.TextBox()
        Me.ImageMasterSelectButton = New System.Windows.Forms.Button()
        Me.ConfigurationMasterSelectButton = New System.Windows.Forms.Button()
        Me.ConfigurationMasterTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExecuteButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "画像マスタ選択"
        '
        'ImageMasterTextBox
        '
        Me.ImageMasterTextBox.Location = New System.Drawing.Point(136, 28)
        Me.ImageMasterTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ImageMasterTextBox.Name = "ImageMasterTextBox"
        Me.ImageMasterTextBox.Size = New System.Drawing.Size(558, 25)
        Me.ImageMasterTextBox.TabIndex = 1
        '
        'ImageMasterSelectButton
        '
        Me.ImageMasterSelectButton.Location = New System.Drawing.Point(700, 28)
        Me.ImageMasterSelectButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ImageMasterSelectButton.Name = "ImageMasterSelectButton"
        Me.ImageMasterSelectButton.Size = New System.Drawing.Size(64, 25)
        Me.ImageMasterSelectButton.TabIndex = 2
        Me.ImageMasterSelectButton.Text = "参照"
        Me.ImageMasterSelectButton.UseVisualStyleBackColor = True
        '
        'ConfigurationMasterSelectButton
        '
        Me.ConfigurationMasterSelectButton.Location = New System.Drawing.Point(700, 61)
        Me.ConfigurationMasterSelectButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ConfigurationMasterSelectButton.Name = "ConfigurationMasterSelectButton"
        Me.ConfigurationMasterSelectButton.Size = New System.Drawing.Size(64, 25)
        Me.ConfigurationMasterSelectButton.TabIndex = 5
        Me.ConfigurationMasterSelectButton.Text = "参照"
        Me.ConfigurationMasterSelectButton.UseVisualStyleBackColor = True
        '
        'ConfigurationMasterTextBox
        '
        Me.ConfigurationMasterTextBox.Location = New System.Drawing.Point(136, 61)
        Me.ConfigurationMasterTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ConfigurationMasterTextBox.Name = "ConfigurationMasterTextBox"
        Me.ConfigurationMasterTextBox.Size = New System.Drawing.Size(558, 25)
        Me.ConfigurationMasterTextBox.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "構成マスタ選択"
        '
        'ExecuteButton
        '
        Me.ExecuteButton.Location = New System.Drawing.Point(349, 98)
        Me.ExecuteButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ExecuteButton.Name = "ExecuteButton"
        Me.ExecuteButton.Size = New System.Drawing.Size(130, 34)
        Me.ExecuteButton.TabIndex = 6
        Me.ExecuteButton.Text = "実行"
        Me.ExecuteButton.UseVisualStyleBackColor = True
        '
        'MasterSelectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 141)
        Me.Controls.Add(Me.ExecuteButton)
        Me.Controls.Add(Me.ConfigurationMasterSelectButton)
        Me.Controls.Add(Me.ConfigurationMasterTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ImageMasterSelectButton)
        Me.Controls.Add(Me.ImageMasterTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "MasterSelectForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FaceCreator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ImageMasterTextBox As TextBox
    Friend WithEvents ImageMasterSelectButton As Button
    Friend WithEvents ConfigurationMasterSelectButton As Button
    Friend WithEvents ConfigurationMasterTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ExecuteButton As Button
End Class
