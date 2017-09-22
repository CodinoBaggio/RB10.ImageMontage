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
            If ImageMasterTextBox.Text = "" Then
                MessageBox.Show("画像マスタを選択してください。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If ConfigurationMasterTextBox.Text = "" Then
                MessageBox.Show("構成マスタを選択してください。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim dlg As New FolderBrowserDialog
            dlg.Description = "出力フォルダーを選択してください。"
            If dlg.ShowDialog() = DialogResult.Cancel Then Return
            Dim saveFolder = dlg.SelectedPath

            Dim imageMaster = New ImageMaster(ImageMasterTextBox.Text)
            Dim configMaster = New ConfigurationMaster(ConfigurationMasterTextBox.Text)

            For Each parts In configMaster.PartsList
                Dim imageCreater = New ImageCreator()
                imageCreater.FaceLine = imageMaster.GetFaceLineImage(parts)
                imageCreater.Eye = imageMaster.GetEyeImage(parts)
                imageCreater.Nose = imageMaster.GetNoseImage(parts)
                imageCreater.Mouth = imageMaster.GetMouthImage(parts)
                imageCreater.Cheek = imageMaster.GetCheekImage(parts)
                imageCreater.Moles = imageMaster.GetMolesImage(parts)
                imageCreater.Create(saveFolder)
            Next

            MessageBox.Show("処理が完了しました。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
