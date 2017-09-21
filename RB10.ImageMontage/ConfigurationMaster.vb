Imports System.IO
Imports RB10.Library.Extensions
Imports NPOI.SS.UserModel

Public Class ConfigurationMaster

    Private Const SHEET_NAME As String = "analysis"
    Private Const KEYWORD_ROW_INDEX As Integer = 0
    Private Const DATA_START_ROW_INDEX As Integer = 4

    Public Class FaceParts
        Public Property FaceLineA As Integer
        Public Property FaceLineB As Integer
        Public Property FaceLineC As Integer
        Public Property FaceLineD As Integer
        Public Property Eye As Integer
        Public Property Nose As Integer
        Public Property Mouth As Integer
        Public Property Cheek As Integer
        Public Property Moles As Integer
    End Class

    Public Property FacePartsList As List(Of FaceParts)

    Public Sub New(fileName As String)
        Initialize(fileName)
    End Sub

    Private Sub Initialize(fileName As String)

        Dim book As IWorkbook
        Using stream = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            book = NPOI.SS.UserModel.WorkbookFactory.Create(stream)
        End Using
        Dim sheet = book.GetSheet(SHEET_NAME)

        Dim faceLineAColumnIndex As Integer
        Dim faceLineBColumnIndex As Integer
        Dim faceLineCColumnIndex As Integer
        Dim faceLineDColumnIndex As Integer
        Dim eyeColumnIndex As Integer
        Dim noseColumnIndex As Integer
        Dim mouthColumnIndex As Integer
        Dim cheekColumnIndex As Integer
        Dim molesColumnIndex As Integer
        Dim keywordRow = sheet.GetRow(KEYWORD_ROW_INDEX)

        For i = 0 To keywordRow.LastCellNum - 1
            Dim cell = keywordRow.GetCell(i)
            If cell Is Nothing Then Continue For

            Dim cellValue = cell.GetStringCellValue()
            Select Case cellValue
                Case "9_1"
                    faceLineAColumnIndex = i
                Case "9_2"
                    faceLineBColumnIndex = i
                Case "9_3"
                    faceLineCColumnIndex = i
                Case "9_4"
                    faceLineDColumnIndex = i
                Case "10_1"
                    eyeColumnIndex = i
                Case "11_1"
                    noseColumnIndex = i
                Case "12_1"
                    mouthColumnIndex = i
                Case "13_1"
                    cheekColumnIndex = i
                Case "14_1"
                    molesColumnIndex = i
            End Select
        Next

        FacePartsList = New List(Of FaceParts)
        For i = DATA_START_ROW_INDEX To sheet.LastRowNum
            Dim row = sheet.GetRow(i)
            If row Is Nothing Then Continue For
            If row.GetCell(faceLineAColumnIndex).GetStringCellValue() = "" Then Continue For

            Dim faceParts = New FaceParts()
            faceParts.FaceLineA = If(row.GetCell(faceLineAColumnIndex) Is Nothing, 0, Convert.ToInt32(row.GetCell(faceLineAColumnIndex).GetStringCellValue()))
            faceParts.FaceLineB = If(row.GetCell(faceLineBColumnIndex) Is Nothing, 0, Convert.ToInt32(row.GetCell(faceLineBColumnIndex).GetStringCellValue()))
            faceParts.FaceLineC = If(row.GetCell(faceLineCColumnIndex) Is Nothing, 0, Convert.ToInt32(row.GetCell(faceLineCColumnIndex).GetStringCellValue()))
            faceParts.FaceLineD = If(row.GetCell(faceLineDColumnIndex) Is Nothing, 0, Convert.ToInt32(row.GetCell(faceLineDColumnIndex).GetStringCellValue()))
            faceParts.Eye = If(row.GetCell(eyeColumnIndex) Is Nothing, 0, Convert.ToInt32(row.GetCell(eyeColumnIndex).GetStringCellValue()))
            faceParts.Nose = If(row.GetCell(noseColumnIndex) Is Nothing, 0, Convert.ToInt32(row.GetCell(noseColumnIndex).GetStringCellValue()))
            faceParts.Mouth = If(row.GetCell(mouthColumnIndex) Is Nothing, 0, Convert.ToInt32(row.GetCell(mouthColumnIndex).GetStringCellValue()))
            faceParts.Cheek = If(row.GetCell(cheekColumnIndex) Is Nothing, 0, Convert.ToInt32(row.GetCell(cheekColumnIndex).GetStringCellValue()))
            faceParts.Moles = If(row.GetCell(molesColumnIndex) Is Nothing, 0, Convert.ToInt32(row.GetCell(molesColumnIndex).GetStringCellValue()))

            FacePartsList.Add(faceParts)
        Next
    End Sub
End Class
