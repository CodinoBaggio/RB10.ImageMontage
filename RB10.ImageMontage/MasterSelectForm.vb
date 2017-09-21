Public Class MasterSelectForm
    Private Sub MasterSelectButton_Click(sender As Object, e As EventArgs) Handles ImageMasterSelectButton.Click, ConfigurationMasterSelectButton.Click
        Dim dlg As New OpenFileDialog With {
            .Filter = "Excel ブック (*.xlsx)|*.xlsx|Excel マクロ有効ブック (*.xlsm)|*.xlsm|Excel 97-2003 ブック (*.xls)|*.xls"
        }
        If dlg.ShowDialog() = DialogResult.Cancel Then Return

        Dim btn As Button = CType(sender, Button)
        If btn.Name = ImageMasterSelectButton.Name Then
            ImageMasterTextBox.Text = dlg.FileName
        Else
            ConfigurationMasterTextBox.Text = dlg.FileName
        End If
    End Sub

    Private Sub ExecuteButton_Click(sender As Object, e As EventArgs) Handles ExecuteButton.Click
        Try

            Dim configMaster = New ConfigurationMaster(ConfigurationMasterTextBox.Text)







        Catch ex As Exception
            MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
