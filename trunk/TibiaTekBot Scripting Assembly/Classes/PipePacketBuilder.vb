﻿'    Copyright (C) 2007 TibiaTek Development Team
'
'    This file is part of TibiaTek Bot.
'
'    TibiaTek Bot is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    TibiaTek Bot is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with TibiaTek Bot. If not, see http://www.gnu.org/licenses/gpl.txt
'    or write to the Free Software Foundation, 59 Temple Place - Suite 330,
'    Boston, MA 02111-1307, USA.

Imports System.Windows.Forms

Public Class PipePacketBuilder
    Implements IPipePacketBuilder

    Private Packets As New Queue(Of Packet)
    Private _Pipe As IPipe
    Private _AutoSend As Boolean = True

    Public Sub New(ByVal Pipe As IPipe, Optional ByVal AutoSend As Boolean = True)
        _Pipe = Pipe
        _AutoSend = AutoSend
    End Sub

    Public Sub SetConstant(ByVal ConstantName As String, ByVal Value As UInteger) Implements IPipePacketBuilder.SetConstant
        Try
            Dim _Packet As New Packet
            _Packet.AddByte(1)
            _Packet.AddString(ConstantName)
            _Packet.AddDWord(Value)
            Packets.Enqueue(_Packet)
            If _AutoSend Then Send()
        Catch Ex As Exception
            MessageBox.Show("TargetSite: " & Ex.TargetSite.Name & vbCrLf & "Message: " & Ex.Message & vbCrLf & "Source: " & Ex.Source & vbCrLf & "Stack Trace: " & Ex.StackTrace & vbCrLf & vbCrLf & "Please report this error to the developers, be sure to take a screenshot of this message box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SetConstant(ByVal ConstantName As String, ByVal Value As UShort) Implements IPipePacketBuilder.SetConstant
        Try
            Dim _Packet As New Packet
            _Packet.AddByte(1)
            _Packet.AddString(ConstantName)
            _Packet.AddWord(Value)
            Packets.Enqueue(_Packet)
            If _AutoSend Then Send()
        Catch Ex As Exception
            MessageBox.Show("TargetSite: " & Ex.TargetSite.Name & vbCrLf & "Message: " & Ex.Message & vbCrLf & "Source: " & Ex.Source & vbCrLf & "Stack Trace: " & Ex.StackTrace & vbCrLf & vbCrLf & "Please report this error to the developers, be sure to take a screenshot of this message box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SetConstant(ByVal ConstantName As String, ByVal Value As Byte) Implements IPipePacketBuilder.SetConstant
        Try
            Dim _Packet As New Packet
            _Packet.AddByte(1)
            _Packet.AddString(ConstantName)
            _Packet.AddByte(Value)
            Packets.Enqueue(_Packet)
            If _AutoSend Then Send()
        Catch Ex As Exception
            MessageBox.Show("TargetSite: " & Ex.TargetSite.Name & vbCrLf & "Message: " & Ex.Message & vbCrLf & "Source: " & Ex.Source & vbCrLf & "Stack Trace: " & Ex.StackTrace & vbCrLf & vbCrLf & "Please report this error to the developers, be sure to take a screenshot of this message box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SetConstant(ByVal ConstantName As String, ByVal Value As String) Implements IPipePacketBuilder.SetConstant
        Try
            Dim _Packet As New Packet
            _Packet.AddByte(1)
            _Packet.AddString(ConstantName)
            _Packet.AddString(Value)
            Packets.Enqueue(_Packet)
            If _AutoSend Then Send()
        Catch Ex As Exception
            MessageBox.Show("TargetSite: " & Ex.TargetSite.Name & vbCrLf & "Message: " & Ex.Message & vbCrLf & "Source: " & Ex.Source & vbCrLf & "Stack Trace: " & Ex.StackTrace & vbCrLf & vbCrLf & "Please report this error to the developers, be sure to take a screenshot of this message box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SetConstant(ByVal ConstantName As String, ByVal Value As Integer) Implements IPipePacketBuilder.SetConstant
        Try
            Dim _Packet As New Packet
            _Packet.AddByte(1)
            _Packet.AddString(ConstantName)
            _Packet.AddDWord(Value)
            Packets.Enqueue(_Packet)
            If _AutoSend Then Send()
        Catch Ex As Exception
            MessageBox.Show("TargetSite: " & Ex.TargetSite.Name & vbCrLf & "Message: " & Ex.Message & vbCrLf & "Source: " & Ex.Source & vbCrLf & "Stack Trace: " & Ex.StackTrace & vbCrLf & vbCrLf & "Please report this error to the developers, be sure to take a screenshot of this message box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SetConstant(ByVal ConstantName As String, ByVal Value As Double) Implements IPipePacketBuilder.SetConstant
        Try
            Dim _Packet As New Packet
            _Packet.AddByte(1)
            _Packet.AddString(ConstantName)
            _Packet.AddDouble(Value)
            Packets.Enqueue(_Packet)
            If _AutoSend Then Send()
        Catch Ex As Exception
            MessageBox.Show("TargetSite: " & Ex.TargetSite.Name & vbCrLf & "Message: " & Ex.Message & vbCrLf & "Source: " & Ex.Source & vbCrLf & "Stack Trace: " & Ex.StackTrace & vbCrLf & vbCrLf & "Please report this error to the developers, be sure to take a screenshot of this message box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub HookWndProc(ByVal Hook As Boolean) Implements IPipePacketBuilder.HookWndProc
        Try
            Dim _Packet As New Packet
            _Packet.AddByte(2)
            _Packet.AddByte(CByte(Hook))
            Packets.Enqueue(_Packet)
            If _AutoSend Then Send()
        Catch Ex As Exception
            MessageBox.Show("TargetSite: " & Ex.TargetSite.Name & vbCrLf & "Message: " & Ex.Message & vbCrLf & "Source: " & Ex.Source & vbCrLf & "Stack Trace: " & Ex.StackTrace & vbCrLf & vbCrLf & "Please report this error to the developers, be sure to take a screenshot of this message box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Test() Implements IPipePacketBuilder.Test
        Try
            Dim _Packet As New Packet
            _Packet.AddByte(3)
            Packets.Enqueue(_Packet)
            If _AutoSend Then Send()
        Catch Ex As Exception
            MessageBox.Show("TargetSite: " & Ex.TargetSite.Name & vbCrLf & "Message: " & Ex.Message & vbCrLf & "Source: " & Ex.Source & vbCrLf & "Stack Trace: " & Ex.StackTrace & vbCrLf & vbCrLf & "Please report this error to the developers, be sure to take a screenshot of this message box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub DisplayText(ByVal TextNum As Byte, ByVal Position As ITibia.LocationDefinition, ByVal ColorRed As Integer, ByVal ColorGreen As Integer, ByVal ColorBlue As Integer, ByVal FontNumber As Integer, ByVal Text As String)
        Try
            Dim _Packet As New Packet
            _Packet.AddByte(4)
            _Packet.AddByte(TextNum)
            _Packet.AddWord(Position.X)
            _Packet.AddWord(Position.Y)
            _Packet.AddWord(ColorRed)
            _Packet.AddWord(ColorGreen)
            _Packet.AddWord(ColorBlue)
            _Packet.AddWord(FontNumber)
            _Packet.AddString(Text)
            Packets.Enqueue(_Packet)
            If _AutoSend Then Send()
        Catch ex As Exception
            MessageBox.Show("TargetSite: " & ex.TargetSite.Name & vbCrLf & "Message: " & ex.Message & vbCrLf & "Source: " & ex.Source & vbCrLf & "Stack Trace: " & ex.StackTrace & vbCrLf & vbCrLf & "Please report this error to the developers, be sure to take a screenshot of this message box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Send() Implements IPacketBuilder.Send
        Try
            While Packets.Count > 0
                Dim P As Packet = Packets.Dequeue()
                _Pipe.Send(P)
            End While
        Catch Ex As System.InvalidOperationException
        Catch Ex As Exception
            MessageBox.Show("TargetSite: " & Ex.TargetSite.Name & vbCrLf & "Message: " & Ex.Message & vbCrLf & "Source: " & Ex.Source & vbCrLf & "Stack Trace: " & Ex.StackTrace & vbCrLf & vbCrLf & "Please report this error to the developers, be sure to take a screenshot of this message box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
