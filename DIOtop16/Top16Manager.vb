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

        Return True
    End Function

    ''' <summary>
    ''' DigitalInputを取得する
    ''' </summary>
    ''' <returns>True:取得成功, False:取得失敗</returns>
    ''' <remarks></remarks>
    Public Function GetDigitalInput(ByRef id As Integer) As Boolean
        If Not IsGettedBoardname() Then Return False

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


    ' ''' <summary>
    ' ''' 出力のオンオフ切り替え
    ' ''' </summary>
    ' ''' <returns>True:切り替え成功, False:切り替え失敗</returns>
    ' ''' <remarks>動かないためコメントアウト 190614</remarks>
    'Public Function ResetOutput() As Boolean
    '    If Not IsGettedBoardname() Then Return False

    '    Dim h As Int32 = 0
    '    For i As Integer = 1 To 8
    '        top16.setOutputs(h, boardName, i, 0)
    '        If h < 0 Then
    '            Return False
    '        End If
    '    Next i

    '    Return True
    'End Function


End Class
