Public Class Top16Manager
    Private boardName As String = "" ' ボード名を保持する

    ''' <summary>
    ''' ボード名が既に取得されているかどうか判定
    ''' </summary>
    ''' <returns>True:既に取得済み, False:取得していない</returns>
    ''' <remarks></remarks>
    Private Function IsGettedBoardname() As Boolean
        Return boardName <> ""
    End Function

    ''' <summary>
    ''' ボード名取得
    ''' </summary>
    ''' <returns>ボード名を返す</returns>
    ''' <remarks>一度取得したらそのまま値を保持する</remarks>
    Public Function GetBoardName() As String
        If IsGettedBoardname() Then Return boardName

        Dim stat As Int32 = 0
        Dim deviceList(20) As String
        stat = top16.getTop16BoardNames(deviceList)
        If stat = 1 Then
            boardName = deviceList(0)
            Return deviceList(0)
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' DigitalInputを取得する
    ''' </summary>
    ''' <param name="bits">Boolean配列 8個分 Trueのとき1, Falseのとき0</param>
    ''' <returns>True:取得成功, False:取得失敗</returns>
    ''' <remarks></remarks>
    Public Function GetDigitalInputs(ByRef bits() As Boolean) As Boolean
        If Not IsGettedBoardname() Then Return False

        Dim stat As Int32 = 0
        stat = top16.GetDigitalInputs(boardName, bits)
        If stat = -1 Then Return False

        Return True
    End Function

    ''' <summary>
    ''' DigitalInputをidバイト列で取得する
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDigitalInput(ByRef id As Integer) As Boolean
        If Not IsGettedBoardname() Then Return False

        Dim bits(7) As Boolean
        If Not GetDigitalInputs(bits) Then Return False

        For i = 0 To UBound(bits)
            id = id Or IIf(bits(i), 1, 0) << i
        Next

        Return True
    End Function
    ''' <summary>
    ''' 出力のオンオフ切り替え
    ''' </summary>
    ''' <param name="in_input">出力ID 1～8</param>
    ''' <param name="in_SetUnSet">オン:1, オフ:0</param>
    ''' <returns>True:切り替え成功, False:切り替え失敗</returns>
    ''' <remarks></remarks>
    Public Function SetOutput(in_input As Byte, in_SetUnSet As Byte) As Boolean
        If Not IsGettedBoardname() Then Return False

        Dim h As Int32 = 0
        top16.setOutputs(h, boardName, in_input, in_SetUnSet)
        If h <> 0 Then
            Return False
        Else
            Return True
        End If
    End Function



End Class
