Class top16

    Private Declare Function ListTop16Boards Lib "top16.dll" (ByRef byteArray As Byte) As Long
    Private Declare Function SetOut Lib "top16.dll" Alias "SetOutputs" (ByVal handle As Int32, ByVal mask As Byte, ByVal SetUnSet As Byte) As Long
    Private Declare Function OpenBoard Lib "top16.dll" (ByVal boardName As String) As Int32
    Private Declare Function CloseBoard Lib "top16.dll" (ByVal handle As Int32) As Long
    Private Declare Function readAnalogInput Lib "top16.dll" (ByVal handle As Int32, ByVal input As Int16, ByVal gain As Byte) As Int32
    Private Declare Function GetInputs Lib "top16.dll" (ByVal handle As Int32) As Int32



    REM 'bits' must be an array of 8 values

    Shared Function GetDigitalInputs(ByVal boardName As String, ByRef bits() As Boolean) As Int32
        Dim lHandle As Int32
        Dim lRtn As Int32

        If (boardName.Length > 0) Then
            lHandle = OpenBoard(boardName)

            If (lHandle > 0) Then
                lRtn = GetInputs(lHandle)
                CloseBoard(lHandle)

                Dim x As Integer
                Dim mask As Integer
                mask = 1

                For x = 0 To 7

                    REM test the bits if they equal 1 then the digital input is High
                    bits(x) = (lRtn And mask)

                    mask = mask * 2  REM shift left
                Next x


            Else
                GetDigitalInputs = -1

            End If
        End If

    End Function

    Shared Function readAnalog(ByVal boardName As String, ByVal input As Int16, ByVal gain As Byte) As Int32

        Dim lHandle As Int32
        Dim lRtn As Long

        If (boardName.Length > 0) Then
            lHandle = OpenBoard(boardName)

            If (lHandle > 0) Then
                readAnalog = readAnalogInput(lHandle, input, gain)
                lRtn = CloseBoard(lHandle)
            Else
                readAnalog = -1

            End If

        End If



    End Function

    Shared Function setOutputs(ByRef handle As Int32, ByVal boardName As String, ByVal mask As Byte, ByVal SetUnSet As Byte) As Long

        Dim lHandle As Int32
        Dim lRtn As Long

        If handle > 0 Then
            lHandle = handle
        Else
            lHandle = OpenBoard(boardName)
            handle = lHandle
        End If


        If (lHandle > 0) Then
            lRtn = SetOut(lHandle, mask, SetUnSet)
            lRtn = CloseBoard(lHandle)
        End If

        setOutputs = 0

    End Function





    ' name Strings must be an Arry of 20 strings or more

    Shared Function getTop16BoardNames(ByVal nameStrings As String()) As Long

        getTop16BoardNames = 0

        ' Create a 20 by 20 byte array to pass in:
        Dim byteArray(20, 20) As Byte

        Dim returnValue As Long

        ' pass pointer to first location of 20 X 20 byte array

        returnValue = ListTop16Boards(byteArray(0, 0))

        ' Extract arrays of bytes from array of arrays

        Dim i As Integer
        For i = 0 To 19

            ' Extract one byte array (string) from 2 dimensional array

            Dim subArray(20) As Byte
            subArray(0) = byteArray(i, 0)
            subArray(1) = byteArray(i, 1)
            subArray(2) = byteArray(i, 2)
            subArray(3) = byteArray(i, 3)
            subArray(4) = byteArray(i, 4)
            subArray(5) = byteArray(i, 5)
            subArray(6) = byteArray(i, 6)
            subArray(7) = byteArray(i, 7)
            subArray(8) = byteArray(i, 8)
            subArray(9) = byteArray(i, 9)
            subArray(10) = byteArray(i, 10)
            subArray(11) = byteArray(i, 11)
            subArray(12) = byteArray(i, 12)
            subArray(13) = byteArray(i, 13)
            subArray(14) = byteArray(i, 14)
            subArray(15) = byteArray(i, 15)
            subArray(16) = byteArray(i, 16)
            subArray(17) = byteArray(i, 17)
            subArray(18) = byteArray(i, 18)
            subArray(19) = byteArray(i, 19)

            ' Convert the sub-array of bytes into a string

            If (i < (nameStrings.Length - 1)) Then
                nameStrings(i) = System.Text.ASCIIEncoding.ASCII.GetString(subArray)
                ' was a board found ?
                If (Char.IsLetterOrDigit(nameStrings(i)(0))) Then
                    getTop16BoardNames += 1

                End If
            End If


        Next i

    End Function
End Class
