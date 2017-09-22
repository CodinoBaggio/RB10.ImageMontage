Public Class ImageCreator
    Public Property Seq As String
    Public Property FaceLine As ImageMaster.ImageConfiguration
    Public Property Eye As ImageMaster.ImageConfiguration
    Public Property Nose As ImageMaster.ImageConfiguration
    Public Property Mouth As ImageMaster.ImageConfiguration
    Public Property Cheek As ImageMaster.ImageConfiguration
    Public Property Moles As ImageMaster.ImageConfiguration

    Public Sub Create(saveFolder As String)

        Dim bmp As New Bitmap("")

        Dim resizeWidth As Integer = 100
        Dim resizeHeight As Integer = 300
        'int resizeWidth = 160;
        'int resizeHeight = (int)(bmp.Height * ((double)resizeWidth / (double)bmp.Width));

        Dim resizeBmp As New Bitmap(resizeWidth, resizeHeight)
        Dim g As Graphics = Graphics.FromImage(resizeBmp)
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        'g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        g.DrawImage(bmp, 0, 0, resizeWidth, resizeHeight)
        g.Dispose()

    End Sub
End Class
