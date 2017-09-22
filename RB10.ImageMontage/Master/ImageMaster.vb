Imports System.IO
Imports NPOI.SS.UserModel
Imports RB10.Library.Extensions

Public Class ImageMaster
    Public Class ImageConfiguration
        Public Property ImagePath As String
        Public Property ImageHeight As Integer
        Public Property ImageWidth As Integer
        Public Property NextImageHeight As Integer
        Public Property NextImageWidth As Integer
        Public Property PasteOrder As Integer
    End Class

    Public Class FaceLine : Inherits ImageConfiguration
        Public Property No1 As Integer
        Public Property No2 As Integer
        Public Property No3 As Integer
        Public Property No4 As Integer
    End Class

    Public Class Eye : Inherits ImageConfiguration
        Public Property No As Integer
    End Class

    Public Class Nose : Inherits ImageConfiguration
        Public Property No As Integer
    End Class

    Public Class Mouth : Inherits ImageConfiguration
        Public Property No As Integer
    End Class

    Public Class Cheek : Inherits ImageConfiguration
        Public Property No As Integer
    End Class

    Public Class Moles : Inherits ImageConfiguration
        Public Property No As Integer
    End Class

    Private Const SHEET_NAME_FACE As String = "イラスト_9"
    Private Const KEYWORD_ROW_INDEX_FACE As Integer = 1
    Private Const DATA_START_ROW_INDEX_FACE As Integer = 2

    Private Const SHEET_NAME_EYE As String = "イラスト_10"
    Private Const KEYWORD_ROW_INDEX_EYE As Integer = 1
    Private Const DATA_START_ROW_INDEX_EYE As Integer = 2

    Private Const SHEET_NAME_NOSE As String = "イラスト_11"
    Private Const KEYWORD_ROW_INDEX_NOSE As Integer = 1
    Private Const DATA_START_ROW_INDEX_NOSE As Integer = 2

    Private Const SHEET_NAME_MOUTH As String = "イラスト_12"
    Private Const KEYWORD_ROW_INDEX_MOUTH As Integer = 1
    Private Const DATA_START_ROW_INDEX_MOUTH As Integer = 2

    Private Const SHEET_NAME_CHEEK As String = "イラスト_13"
    Private Const KEYWORD_ROW_INDEX_CHEEK As Integer = 1
    Private Const DATA_START_ROW_INDEX_CHEEK As Integer = 2

    Private Const SHEET_NAME_MOLES As String = "イラスト_14"
    Private Const KEYWORD_ROW_INDEX_MOLES As Integer = 1
    Private Const DATA_START_ROW_INDEX_MOLES As Integer = 2

    Private _faceLineList As List(Of FaceLine)
    Private _eyeList As List(Of Eye)
    Private _noseList As List(Of Nose)
    Private _mouthList As List(Of Mouth)
    Private _cheekList As List(Of Cheek)
    Private _molesList As List(Of Moles)

    Public Sub New(fileName As String)
        Initialize(fileName)
    End Sub

    Public Sub Initialize(fileName As String)
        Dim book As IWorkbook
        Using stream = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            book = NPOI.SS.UserModel.WorkbookFactory.Create(stream)
        End Using

        ' フェースライン取り込み
        Dim values = book.GetSheet(SHEET_NAME_FACE).UsedRange()
        Dim faceLine1ColumnIndex As Integer
        Dim faceLine2ColumnIndex As Integer
        Dim faceLine3ColumnIndex As Integer
        Dim faceLine4ColumnIndex As Integer

        For i = 0 To values.GetUpperBound(1)
            Dim a = values(KEYWORD_ROW_INDEX_FACE, i)
            Select Case a
                Case "9_1"
                    faceLine1ColumnIndex = i
                Case "9_2"
                    faceLine2ColumnIndex = i
                Case "9_3"
                    faceLine3ColumnIndex = i
                Case "9_4"
                    faceLine4ColumnIndex = i
            End Select
        Next

        _faceLineList = New List(Of FaceLine)
        For i = DATA_START_ROW_INDEX_FACE To values.GetUpperBound(0)
            If values(i, faceLine1ColumnIndex) = "" Then Continue For

            Dim faceLine = New FaceLine()
            faceLine.No1 = If(values(i, faceLine1ColumnIndex) = "", 0, ToInt32(values(i, faceLine1ColumnIndex)))
            faceLine.No2 = If(values(i, faceLine2ColumnIndex) = "", 0, ToInt32(values(i, faceLine2ColumnIndex)))
            faceLine.No3 = If(values(i, faceLine3ColumnIndex) = "", 0, ToInt32(values(i, faceLine3ColumnIndex)))
            faceLine.No4 = If(values(i, faceLine4ColumnIndex) = "", 0, ToInt32(values(i, faceLine4ColumnIndex)))
            faceLine.ImagePath = If(values(i, faceLine4ColumnIndex + 1) = "", "", values(i, faceLine4ColumnIndex + 1))
            faceLine.ImageHeight = If(values(i, faceLine4ColumnIndex + 2) = "", 0, ToInt32(values(i, faceLine4ColumnIndex + 2)))
            faceLine.ImageWidth = If(values(i, faceLine4ColumnIndex + 3) = "", 0, ToInt32(values(i, faceLine4ColumnIndex + 3)))
            faceLine.NextImageHeight = If(values(i, faceLine4ColumnIndex + 4) = "", 0, ToInt32(values(i, faceLine4ColumnIndex + 4)))
            faceLine.NextImageWidth = If(values(i, faceLine4ColumnIndex + 5) = "", 0, ToInt32(values(i, faceLine4ColumnIndex + 5)))
            faceLine.PasteOrder = If(values(i, faceLine4ColumnIndex + 6) = "", 0, ToInt32(values(i, faceLine4ColumnIndex + 6)))

            _faceLineList.Add(faceLine)
        Next

        ' 目取り込み
        values = book.GetSheet(SHEET_NAME_EYE).UsedRange()
        Dim eyeColumnIndex As Integer

        For i = 0 To values.GetUpperBound(1)
            Dim a = values(KEYWORD_ROW_INDEX_EYE, i)
            Select Case a
                Case "10_1"
                    eyeColumnIndex = i
            End Select
        Next

        _eyeList = New List(Of Eye)
        For i = DATA_START_ROW_INDEX_EYE To values.GetUpperBound(0)
            If values(i, eyeColumnIndex) = "" Then Continue For

            Dim eye = New Eye()
            eye.No = If(values(i, eyeColumnIndex) = "", 0, ToInt32(values(i, eyeColumnIndex)))
            eye.ImagePath = If(values(i, eyeColumnIndex + 1) = "", "", values(i, eyeColumnIndex + 1))
            eye.ImageHeight = If(values(i, eyeColumnIndex + 2) = "", 0, ToInt32(values(i, eyeColumnIndex + 2)))
            eye.ImageWidth = If(values(i, eyeColumnIndex + 3) = "", 0, ToInt32(values(i, eyeColumnIndex + 3)))
            eye.NextImageHeight = If(values(i, eyeColumnIndex + 4) = "", 0, ToInt32(values(i, eyeColumnIndex + 4)))
            eye.NextImageWidth = If(values(i, eyeColumnIndex + 5) = "", 0, ToInt32(values(i, eyeColumnIndex + 5)))
            eye.PasteOrder = If(values(i, eyeColumnIndex + 6) = "", 0, ToInt32(values(i, eyeColumnIndex + 6)))

            _eyeList.Add(eye)
        Next

        ' 鼻取り込み
        values = book.GetSheet(SHEET_NAME_NOSE).UsedRange()
        Dim noseColumnIndex As Integer

        For i = 0 To values.GetUpperBound(1)
            Dim a = values(KEYWORD_ROW_INDEX_NOSE, i)
            Select Case a
                Case "10_1"
                    noseColumnIndex = i
            End Select
        Next

        _noseList = New List(Of Nose)
        For i = DATA_START_ROW_INDEX_NOSE To values.GetUpperBound(0)
            If values(i, noseColumnIndex) = "" Then Continue For

            Dim nose = New Nose()
            nose.No = If(values(i, noseColumnIndex) = "", 0, ToInt32(values(i, noseColumnIndex)))
            nose.ImagePath = If(values(i, noseColumnIndex + 1) = "", "", values(i, noseColumnIndex + 1))
            nose.ImageHeight = If(values(i, noseColumnIndex + 2) = "", 0, ToInt32(values(i, noseColumnIndex + 2)))
            nose.ImageWidth = If(values(i, noseColumnIndex + 3) = "", 0, ToInt32(values(i, noseColumnIndex + 3)))
            nose.NextImageHeight = If(values(i, noseColumnIndex + 4) = "", 0, ToInt32(values(i, noseColumnIndex + 4)))
            nose.NextImageWidth = If(values(i, noseColumnIndex + 5) = "", 0, ToInt32(values(i, noseColumnIndex + 5)))
            nose.PasteOrder = If(values(i, noseColumnIndex + 6) = "", 0, ToInt32(values(i, noseColumnIndex + 6)))

            _noseList.Add(nose)
        Next

        ' 口取り込み
        values = book.GetSheet(SHEET_NAME_MOUTH).UsedRange()
        Dim mouthColumnIndex As Integer

        For i = 0 To values.GetUpperBound(1)
            Dim a = values(KEYWORD_ROW_INDEX_MOUTH, i)
            Select Case a
                Case "10_1"
                    mouthColumnIndex = i
            End Select
        Next

        _mouthList = New List(Of Mouth)
        For i = DATA_START_ROW_INDEX_MOUTH To values.GetUpperBound(0)
            If values(i, mouthColumnIndex) = "" Then Continue For

            Dim mouth = New Mouth()
            mouth.No = If(values(i, mouthColumnIndex) = "", 0, ToInt32(values(i, mouthColumnIndex)))
            mouth.ImagePath = If(values(i, mouthColumnIndex + 1) = "", "", values(i, mouthColumnIndex + 1))
            mouth.ImageHeight = If(values(i, mouthColumnIndex + 2) = "", 0, ToInt32(values(i, mouthColumnIndex + 2)))
            mouth.ImageWidth = If(values(i, mouthColumnIndex + 3) = "", 0, ToInt32(values(i, mouthColumnIndex + 3)))
            mouth.NextImageHeight = If(values(i, mouthColumnIndex + 4) = "", 0, ToInt32(values(i, mouthColumnIndex + 4)))
            mouth.NextImageWidth = If(values(i, mouthColumnIndex + 5) = "", 0, ToInt32(values(i, mouthColumnIndex + 5)))
            mouth.PasteOrder = If(values(i, mouthColumnIndex + 6) = "", 0, ToInt32(values(i, mouthColumnIndex + 6)))

            _mouthList.Add(mouth)
        Next

        ' 頬取り込み
        values = book.GetSheet(SHEET_NAME_CHEEK).UsedRange()
        Dim cheekColumnIndex As Integer

        For i = 0 To values.GetUpperBound(1)
            Dim a = values(KEYWORD_ROW_INDEX_CHEEK, i)
            Select Case a
                Case "10_1"
                    cheekColumnIndex = i
            End Select
        Next

        _cheekList = New List(Of Cheek)
        For i = DATA_START_ROW_INDEX_CHEEK To values.GetUpperBound(0)
            If values(i, cheekColumnIndex) = "" Then Continue For

            Dim cheek = New Cheek()
            cheek.No = If(values(i, cheekColumnIndex) = "", 0, ToInt32(values(i, cheekColumnIndex)))
            cheek.ImagePath = If(values(i, cheekColumnIndex + 1) = "", "", values(i, cheekColumnIndex + 1))
            cheek.ImageHeight = If(values(i, cheekColumnIndex + 2) = "", 0, ToInt32(values(i, cheekColumnIndex + 2)))
            cheek.ImageWidth = If(values(i, cheekColumnIndex + 3) = "", 0, ToInt32(values(i, cheekColumnIndex + 3)))
            cheek.NextImageHeight = If(values(i, cheekColumnIndex + 4) = "", 0, ToInt32(values(i, cheekColumnIndex + 4)))
            cheek.NextImageWidth = If(values(i, cheekColumnIndex + 5) = "", 0, ToInt32(values(i, cheekColumnIndex + 5)))
            cheek.PasteOrder = If(values(i, cheekColumnIndex + 6) = "", 0, ToInt32(values(i, cheekColumnIndex + 6)))

            _cheekList.Add(cheek)
        Next

        ' ほくろ取り込み
        values = book.GetSheet(SHEET_NAME_MOLES).UsedRange()
        Dim molesColumnIndex As Integer

        For i = 0 To values.GetUpperBound(1)
            Dim a = values(KEYWORD_ROW_INDEX_MOLES, i)
            Select Case a
                Case "10_1"
                    molesColumnIndex = i
            End Select
        Next

        _molesList = New List(Of Moles)
        For i = DATA_START_ROW_INDEX_MOLES To values.GetUpperBound(0)
            If values(i, molesColumnIndex) = "" Then Continue For

            Dim moles = New Moles()
            moles.No = If(values(i, molesColumnIndex) = "", 0, ToInt32(values(i, molesColumnIndex)))
            moles.ImagePath = If(values(i, molesColumnIndex + 1) = "", "", values(i, molesColumnIndex + 1))
            moles.ImageHeight = If(values(i, molesColumnIndex + 2) = "", 0, ToInt32(values(i, molesColumnIndex + 2)))
            moles.ImageWidth = If(values(i, molesColumnIndex + 3) = "", 0, ToInt32(values(i, molesColumnIndex + 3)))
            moles.NextImageHeight = If(values(i, molesColumnIndex + 4) = "", 0, ToInt32(values(i, molesColumnIndex + 4)))
            moles.NextImageWidth = If(values(i, molesColumnIndex + 5) = "", 0, ToInt32(values(i, molesColumnIndex + 5)))
            moles.PasteOrder = If(values(i, molesColumnIndex + 6) = "", 0, ToInt32(values(i, molesColumnIndex + 6)))

            _molesList.Add(moles)
        Next
    End Sub

    Public Function GetFaceLineImage(config As ConfigurationMaster.Parts) As ImageConfiguration
        Return _faceLineList.Where(
            Function(x) x.No1 = config.FaceLine1 And x.No2 = config.FaceLine2 And x.No3 = config.FaceLine3 And x.No4 = config.FaceLine4).FirstOrDefault()
    End Function

    Public Function GetEyeImage(config As ConfigurationMaster.Parts) As ImageConfiguration
        Return _eyeList.Where(Function(x) x.No = config.Eye).FirstOrDefault()
    End Function

    Public Function GetNoseImage(config As ConfigurationMaster.Parts) As ImageConfiguration
        Return _noseList.Where(Function(x) x.No = config.Nose).FirstOrDefault()
    End Function

    Public Function GetMouthImage(config As ConfigurationMaster.Parts) As ImageConfiguration
        Return _mouthList.Where(Function(x) x.No = config.Mouth).FirstOrDefault()
    End Function

    Public Function GetCheekImage(config As ConfigurationMaster.Parts) As ImageConfiguration
        Return _cheekList.Where(Function(x) x.No = config.Cheek).FirstOrDefault()
    End Function

    Public Function GetMolesImage(config As ConfigurationMaster.Parts) As ImageConfiguration
        Return _molesList.Where(Function(x) x.No = config.Moles).FirstOrDefault()
    End Function

    Private Function ToInt32(value As String) As Integer
        Dim ret As Integer
        Return If(Integer.TryParse(value, ret), ret, -1)
    End Function
End Class
