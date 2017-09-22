Imports System.IO
Imports RB10.Library.Extensions
Imports NPOI.SS.UserModel

Public Class ConfigurationMaster
    Public Class Parts
        Public Property Seq As String
        Public Property FaceLine1 As Integer
        Public Property FaceLine2 As Integer
        Public Property FaceLine3 As Integer
        Public Property FaceLine4 As Integer
        Public Property Eye As Integer
        Public Property Nose As Integer
        Public Property Mouth As Integer
        Public Property Cheek As Integer
        Public Property Moles As Integer
    End Class

    Public Property PartsList As List(Of Parts)

    Private Const SHEET_NAME As String = "analysis"
    Private Const KEYWORD_ROW_INDEX As Integer = 0
    Private Const DATA_START_ROW_INDEX As Integer = 4

    Public Sub New(fileName As String)
        Initialize(fileName)
    End Sub

    Private Sub Initialize(fileName As String)
        Dim book As IWorkbook
        Using stream = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            book = NPOI.SS.UserModel.WorkbookFactory.Create(stream)
        End Using
        Dim values = book.GetSheet(SHEET_NAME).UsedRange()

        Dim SeqColumnIndex As Integer
        Dim faceLine1ColumnIndex As Integer
        Dim faceLine2ColumnIndex As Integer
        Dim faceLine3ColumnIndex As Integer
        Dim faceLine4ColumnIndex As Integer
        Dim eyeColumnIndex As Integer
        Dim noseColumnIndex As Integer
        Dim mouthColumnIndex As Integer
        Dim cheekColumnIndex As Integer
        Dim molesColumnIndex As Integer

        For i = 0 To values.GetUpperBound(1)
            Dim a = values(KEYWORD_ROW_INDEX, i)
            Select Case a
                Case "No."
                    SeqColumnIndex = i
                Case "9_1"
                    faceLine1ColumnIndex = i
                Case "9_2"
                    faceLine2ColumnIndex = i
                Case "9_3"
                    faceLine3ColumnIndex = i
                Case "9_4"
                    faceLine4ColumnIndex = i
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

        PartsList = New List(Of Parts)
        For i = DATA_START_ROW_INDEX To values.GetUpperBound(0)
            Dim isEmpty = False
            For j = 0 To values.GetUpperBound(1)
                If (values(i, j) = "") Then
                    isEmpty = True
                    Exit For
                End If
            Next

            If isEmpty Then Continue For

            Dim faceParts = New Parts()
            faceParts.Seq = values(i, SeqColumnIndex)
            faceParts.FaceLine1 = ToInt32(values(i, faceLine1ColumnIndex))
            faceParts.FaceLine2 = ToInt32(values(i, faceLine2ColumnIndex))
            faceParts.FaceLine3 = ToInt32(values(i, faceLine3ColumnIndex))
            faceParts.FaceLine4 = ToInt32(values(i, faceLine4ColumnIndex))
            faceParts.Eye = ToInt32(values(i, eyeColumnIndex))
            faceParts.Nose = ToInt32(values(i, noseColumnIndex))
            faceParts.Mouth = ToInt32(values(i, mouthColumnIndex))
            faceParts.Cheek = ToInt32(values(i, cheekColumnIndex))
            faceParts.Moles = ToInt32(values(i, molesColumnIndex))

            PartsList.Add(faceParts)
        Next
    End Sub

    Private Function ToInt32(value As String) As Integer
        Dim ret As Integer
        Return If(Integer.TryParse(value, ret), ret, -1)
    End Function
End Class
