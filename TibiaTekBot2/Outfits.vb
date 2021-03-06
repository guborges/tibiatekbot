'    Copyright (C) 2007 TibiaTek Development Team
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

Imports System.Xml, Scripting

Public Class Outfits
    Implements IOutfits

    Private OutfitsList As New List(Of IOutfits.OutfitDefinition)

    Public ReadOnly Property GetOutfits() As IOutfits.OutfitDefinition() Implements IOutfits.GetOutfits
        Get
            Try
                Dim OutfitsArray(OutfitsList.Count - 1) As IOutfits.OutfitDefinition
                OutfitsList.CopyTo(OutfitsArray)
                Return OutfitsArray
            Catch Ex As Exception
                ShowError(Ex)
                End
            End Try
        End Get
    End Property

    Public Function GetOutfitByName(ByVal Name As String, ByRef Outfit As IOutfits.OutfitDefinition) As Boolean Implements IOutfits.GetOutfitByName
        Try
            For Each TempOutfit As IOutfits.OutfitDefinition In OutfitsList
                If String.Compare(TempOutfit.Name, Name, True) = 0 Then
                    Outfit = TempOutfit
                    Return True
                End If
            Next
            Return False
        Catch Ex As Exception
            ShowError(Ex)
            End
        End Try
    End Function

    Public Function GetOutfitByID(ByVal ID As UShort, ByRef Outfit As IOutfits.OutfitDefinition) As Boolean Implements IOutfits.GetOutfitByID
        Try
            For Each TempOutfit As IOutfits.OutfitDefinition In OutfitsList
                If TempOutfit.ID = ID Then
                    Outfit = TempOutfit
                    Return True
                End If
            Next
            Return False
        Catch Ex As Exception
            ShowError(Ex)
            End
        End Try
    End Function

    Public Sub New()
        LoadOutfits()
    End Sub

    Public Sub LoadOutfits()
        Dim Reader As New System.Xml.XmlTextReader(GetConfigurationDirectory() & "\Outfits.xml")
        Dim Outfit As IOutfits.OutfitDefinition
        Dim Value As String
        OutfitsList.Clear()
        Reader.WhitespaceHandling = WhitespaceHandling.None
        While Reader.Read()
            If Reader.NodeType = XmlNodeType.Element Then
                Select Case Reader.Name
                    Case "Outfits"
                        While Reader.Read()
                            If Reader.NodeType = XmlNodeType.Element AndAlso Reader.Name = "Outfit" Then
                                If Reader.HasAttributes Then
                                    Value = Reader.GetAttribute("ID")
                                    If Value.Length > 0 AndAlso Value.Chars(0) = "H" Then Value = "&" + Value
                                    Outfit.ID = CUShort(Value)
                                    Outfit.Name = Reader.GetAttribute("Name")
                                    OutfitsList.Add(Outfit)
                                End If
                            ElseIf Reader.NodeType = XmlNodeType.EndElement AndAlso Reader.Name = "Outfits" Then
                                Exit While
                            End If
                        End While
                End Select
            End If
        End While
    End Sub

End Class
