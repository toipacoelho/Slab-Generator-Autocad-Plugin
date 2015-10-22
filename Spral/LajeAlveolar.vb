' (C) Copyright 2015 by Pedro Toipa Coelho (toipacoelho@ua.pt)

Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Geometry
Imports FileHelpers
Imports System.IO

Namespace Spral

    Public Class LajeAlveolar

        ''Get the current document
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        ''Get the current database
        Dim acCurDb As Database = acDoc.Database

        Private buff As Double = 0.005
        Private prflwidth As Double = 1.25
        Private prflleft As Double = 0.1
        Private NPERFIS As Integer = 0
        Private type As String
        Private mirror As Matrix3d
        Private mflag As Boolean
        Private lastcota = 0
        Private lista As List(Of Export)

        ''Construtor
        Public Sub LajeAlveolar(pvtype As String, dir As Boolean, mir As Boolean)
            acDoc.LockDocument()

            Dim hs As HostApplicationServices = HostApplicationServices.Current
            Dim fp As String = hs.FindFile(acDoc.Name, acDoc.Database, FindFileHint.Default)
            Dim fn As String = Path.GetFileNameWithoutExtension(fp)
            Dim fd As String = Path.GetDirectoryName(fp)

            lista = New List(Of Export)()
            Dim engine = New FileHelperAsyncEngine(Of Export)()

            If My.Computer.FileSystem.FileExists(fd + "\" + fn + ".csv") Then
                Using engine.BeginReadFile(fd + "\" + fn + ".csv")
                    ' The engine is IEnumerable
                    For Each cust As Export In engine
                        ' your code here
                        For flag = cust.count To 0 Step -1
                            add(cust.reference)
                        Next
                    Next
                End Using
            End If

            Dim acPoly As Polyline = getPolyline()

            ''referente ao vao
            Dim aPt As Point3d = promptForPoint("de ínico do segmento.")
            Dim bPt As Point3d = promptForPoint("de fim do segmento.")
            Dim rotation As Matrix3d = New Matrix3d()

            If dir = True Then
                rotation = getRotationY(aPt, bPt)
            Else
                rotation = getRotationX(aPt, bPt)
            End If

            If mir = True Then
                mirror = Matrix3d.Mirroring(New Line3d(aPt, bPt))
                acPoly = acPoly.GetTransformedCopy(mirror)
                mflag = True
            End If

            Dim poly As Polyline = acPoly.GetTransformedCopy(rotation)
            Dim startpoint As Point3d = getStartPoint(poly, aPt)
            Dim length As Double = startpoint.DistanceTo(getLastPoint(poly, aPt))

            type = pvtype

            drawAlveolares(poly, length, startpoint, rotation)

            Dim msg As MsgBoxResult = MsgBox("A desenhar")
            Dim err As MsgBoxResult
            Dim Box As MsgBoxResult = MsgBox("Confimar laje?", MsgBoxStyle.YesNo)
            If Box = MsgBoxResult.Yes Then
                'escrever
                acDoc.Editor.WriteMessage(vbLf + "Exported to: " + fd + "\" + fn + ".csv")
                Using engine.BeginWriteFile(fd + "\" + fn + ".csv")
                    For Each cust As Export In lista
                        engine.WriteNext(cust)
                    Next
                End Using
            Else
                '' nao
                err = MsgBox("Exportação de referências cancelada, por favor execute Ctrl+Z")
            End If

        End Sub

        ''prompts user for point 3D
        Private Function promptForPoint(msg As String) As Point3d

            Dim pPtRes As PromptPointResult
            Dim pPtOpts As PromptPointOptions = New PromptPointOptions("")

            '' Prompt for the start point
            pPtOpts.Message = vbLf & "Marcar ponto " & msg
            pPtRes = acDoc.Editor.GetPoint(pPtOpts)
            Dim ptPoint As Point3d = pPtRes.Value

            Dim point As Point2d = New Point2d(ptPoint.X, ptPoint.Y)

            '' Exit if the user presses ESC or cancels the command
            If pPtRes.Status = PromptStatus.Cancel Then
                Return Nothing
                Exit Function
            End If

            Return ptPoint
        End Function

        ''gets polyline
        Private Function getPolyline() As Polyline

            Dim acPoly As Polyline = New Polyline()
            Dim peo As New PromptEntityOptions(vbLf & "Select a polyline")
            peo.SetRejectMessage("Please select a polyline")
            peo.AddAllowedClass(GetType(Polyline), True)
            Dim per As PromptEntityResult = acDoc.Editor.GetEntity(peo)
            Dim tr As Transaction = acCurDb.TransactionManager.StartTransaction()
            Using tr
                acPoly = TryCast(tr.GetObject(per.ObjectId, OpenMode.ForRead), Polyline)
                tr.Commit()
            End Using

            Return acPoly
        End Function

        ''gets rotation with the X axys
        Private Function getRotationX(basePoint As Point3d, cursorPoint As Point3d) As Matrix3d
            ' get the vector from basepoint to cursorPoint
            Dim direction As Vector3d = basePoint.GetVectorTo(cursorPoint)

            ' compute the angle between this vector and X axis
            Dim angle As Double = direction.GetAngleTo(Vector3d.XAxis, Vector3d.ZAxis)

            ' build a transformation matrix to rotate points
            Dim rotation As Matrix3d = Matrix3d.Rotation(angle, Vector3d.ZAxis, basePoint)

            Return rotation
        End Function

        ''gets rotation with the Y axys
        Private Function getRotationY(basePoint As Point3d, cursorPoint As Point3d) As Matrix3d
            ' get the vector from basepoint to cursorPoint
            Dim direction As Vector3d = basePoint.GetVectorTo(cursorPoint)

            ' compute the angle between this vector and X axis
            Dim angle As Double = direction.GetAngleTo(Vector3d.YAxis, Vector3d.ZAxis)

            ' build a transformation matrix to rotate points
            Dim rotation As Matrix3d = Matrix3d.Rotation(angle, Vector3d.ZAxis, basePoint)

            Return rotation
        End Function

        ''gets "first" point of polyline
        Private Function getStartPoint(pline As Polyline, aPt As Point3d) As Point3d
            Dim result As Point3d = aPt
            ' iterate the vertices
            For i As Integer = 0 To pline.NumberOfVertices - 1
                Dim pt As Point3d = pline.GetPoint3dAt(i)
                ' compare the rotated point X coordinate to the result point one
                If pt.X < result.X Then
                    result = pt
                End If
            Next

            Return New Point3d(result.X, aPt.Y, 0)
        End Function

        ''gets "last" point of polyline
        Private Function getLastPoint(pline As Polyline, aPt As Point3d) As Point3d
            Dim result As Point3d = aPt
            ' iterate the vertices
            For i As Integer = 0 To pline.NumberOfVertices - 1
                Dim pt As Point3d = pline.GetPoint3dAt(i)
                ' compare the rotated point X coordinate to the result point one
                If pt.X > result.X Then
                    result = pt
                End If
            Next

            Return New Point3d(result.X, aPt.Y, 0)
        End Function

        Private Function getic(pline As Polyline, a As Point2d, b As Point2d, v As Double) As Point2d()
            Dim result(pline.NumberOfVertices) As Point2d
            Dim j = 0

            ' iterate the vertices
            For i As Integer = 0 To pline.NumberOfVertices - 1
                Dim pt As Point3d = pline.GetPoint3dAt(i)
                ' compare the rotated point X coordinate to the result point one
                If (pt.X < b.X And pt.X > a.X) And ((pt.Y > a.Y And pt.Y < b.Y) Or (pt.Y < a.Y And pt.Y > b.Y)) Then
                    result(0) = New Point2d(pt.X, pt.Y)
                    j += 1
                End If
            Next
            ReDim Preserve result(j + 1)
            Return result
        End Function

        ''auxiliar function to draw rectangular shapes
        Private Sub drawRectangle(a As Point2d, b As Point2d, c As Point2d, d As Point2d, rotation As Matrix3d)
            '' Start a transaction
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                '' Open the Block table for read
                Dim acBlkTbl As BlockTable
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)
                '' Open the Block table record Model space for write
                Dim acBlkTblRec As BlockTableRecord
                acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

                '' Create a polyline with four segments (4 points)
                Using acPoly As Polyline = New Polyline()

                    acPoly.SetDatabaseDefaults()
                    acPoly.AddVertexAt(0, a, 0, 0, 0)
                    acPoly.AddVertexAt(1, b, 0, 0, 0)
                    acPoly.AddVertexAt(2, c, 0, 0, 0)
                    acPoly.AddVertexAt(3, d, 0, 0, 0)
                    acPoly.Closed = True

                    ''rotates polyline
                    acPoly.TransformBy(rotation.Inverse())

                    If (mflag = True) Then
                        acPoly.TransformBy(mirror)
                    End If

                    '' Add the new object to the block table record and the transaction
                    acBlkTblRec.AppendEntity(acPoly)
                    acTrans.AddNewlyCreatedDBObject(acPoly, True)
                End Using

                '' Save the new object to the database
                acTrans.Commit()
            End Using
        End Sub

        ''draw laje alveolares
        Private Sub drawAlveolares(poly As Polyline, length As Double, pt As Point3d, rotation As Matrix3d)
            Dim a As Point2d = New Point2d()
            Dim b As Point2d = New Point2d()
            Dim c As Point2d = New Point2d()
            Dim d As Point2d = New Point2d()

            ''incremento = largura 125 do perfil mais espaçamento 0.005 m
            For i As Double = pt.X To pt.X + length Step 1.255

                ''garante que não ultrapassa o tamanho da base
                If i + 1.25 > pt.X + length Then
                    endlaje(poly, New Point2d(i, pt.Y), (pt.X + length) - i, rotation)
                    NPERFIS += 1
                    Exit For
                End If

                a = New Point2d(i, getlowerpoint(poly, i).Y - prflleft)
                b = New Point2d(i + prflwidth, getlowerpoint(poly, i + prflwidth).Y - prflleft)
                c = New Point2d(b.X, b.Y + 0.2 + getWidth(poly, New Point3d(b.X, b.Y, 0)))
                d = New Point2d(a.X, a.Y + 0.2 + getWidth(poly, New Point3d(a.X, a.Y, 0)))
                printDimension(b, c, rotation)
                'If cib(poly, a, b) Or cib(poly, d, c) Then
                '    DrawSpecial(poly, a, b, c, d, rotation)
                'Else
                drawRectangle(a, b, c, d, rotation)
                'End If


                outConfig(a, b, c, d)
                
            Next

        End Sub


        Private Sub add(v As String)
            Dim count As Integer = 1
            Dim i As Integer
            If (lista.Exists(Function(x) x.reference = v)) Then
                i = lista.FindIndex(Function(x) x.reference = v)
                count = lista(i).count + 1
                lista.RemoveAt(i)
            End If
            lista.Add(New Export With {.reference = v, .count = count})
        End Sub

        Private Function cib(pline As Polyline, a As Point2d, b As Point2d)
            Dim result As Boolean = False
            ' iterate the vertices
            For i As Integer = 0 To pline.NumberOfVertices - 1
                Dim pt As Point3d = pline.GetPoint3dAt(i)
                ' compare the rotated point X coordinate to the result point one
                If pt.X < b.X And pt.X > a.X Then
                    result = True
                End If
            Next
            Return result
        End Function

        ''função awesome que nos da a largura da laje!
        Private Function getWidth(pline As Polyline, apt As Point3d) As Double
            Dim result As Double = 0
            Dim aux As Point3d = apt
            Dim l As Line = New Line(New Point3d(apt.X, -pline.Length, 0), New Point3d(apt.X, apt.Y + pline.Length, 0))
            Dim pts As Point3dCollection = New Point3dCollection()
            Dim lista As List(Of Point3d) = New List(Of Point3d)

            pline.IntersectWith(l, Intersect.OnBothOperands, pts, IntPtr.Zero, IntPtr.Zero)

            For Each pt In pts
                lista.Add(pt)
            Next
            For i = 1 To lista.Count - 1
                If lista.Item(i).DistanceTo(lista.Item(i - 1)) > result Then result = lista.Item(i).DistanceTo(lista.Item(i - 1))
            Next

            Return result
        End Function

        Private Function getlowerpoint(pline As Polyline, x As Double) As Point3d

            Dim result As Double = 0
            Dim l As Line = New Line(New Point3d(x, -10 * pline.Length, 0), New Point3d(x, 10 * pline.Length, 0))
            Dim pts As Point3dCollection = New Point3dCollection()
            Dim listas As List(Of Point3d) = New List(Of Point3d)

            pline.IntersectWith(l, Intersect.OnBothOperands, pts, IntPtr.Zero, IntPtr.Zero)

            For Each pt In pts
                listas.Add(pt)
            Next

            Dim a As Point3d

            Try
                a = listas.Item(0)
                acDoc.Editor.WriteMessage("Passou" & vbLf)
            Catch ex As Exception
                a = getlowerpoint(pline, x - 0.25)
                acDoc.Editor.WriteMessage("NAO" & vbLf)
            End Try
            Return a

        End Function

        ''auxiliar function to draw last laje
        Private Sub endlaje(pline As Polyline, pt As Point2d, left As Double, rotation As Matrix3d)
            Dim width As Double = 0

            Select Case type
                Case "400"
                    If (left >= 0.3745 And left <= 0.5923) Or (left >= 0.6575 And left <= 0.8755) Or (left >= 0.9405 And left <= 1.1585) Then
                        width = left
                    ElseIf left < 0.3745 Then
                        width = 0.3745
                    ElseIf left < 0.6575 Then
                        width = 0.6575
                    ElseIf left < 0.9405 Then
                        width = 0.9405
                    ElseIf left < 1.25 Then
                        width = 1.25
                    End If

                Case "265"
                    If (left >= 0.309 And left <= 0.493) Or (left >= 0.533 And left <= 0.717) Or (left >= 0.757 And left <= 0.939) Or (left >= 0.981 And left <= 1.165) Then
                        width = left
                    ElseIf left < 0.309 Then
                        width = 0.309
                    ElseIf left < 0.533 Then
                        width = 0.533
                    ElseIf left < 0.757 Then
                        width = 0.757
                    ElseIf left < 0.981 Then
                        width = 0.981
                    ElseIf left < 1.25 Then
                        width = 1.25
                    End If
                Case "180"
                    If (left >= 0.19 And left <= 0.31) Or (left >= 0.34 And left <= 0.46) Or (left >= 0.49 And left <= 0.61) Or (left >= 0.64 And left <= 0.76) Or (left >= 0.79 And left <= 0.91) Or (left >= 0.94 And left <= 1.06) Or (left >= 1.09 And left <= 1.21) Then
                        width = left
                    ElseIf left < 0.19 Then
                        width = 0.19
                    ElseIf left < 0.34 Then
                        width = 0.34
                    ElseIf left < 0.49 Then
                        width = 0.49
                    ElseIf left < 0.64 Then
                        width = 0.64
                    ElseIf left < 0.79 Then
                        width = 0.79
                    ElseIf left < 0.94 Then
                        width = 0.94
                    ElseIf left < 1.09 Then
                        width = 1.09
                    ElseIf left < 1.25 Then
                        width = 1.25
                    End If
            End Select

            If width = 0 Then Return
            Dim endWith As Double = getEndWith(pline, New Point3d(pt.X, pt.Y, 0), left)

            Dim a As Point2d = New Point2d(pt.X, getlowerpoint(pline, pt.X).Y - prflleft)
            Dim b As Point2d = New Point2d(a.X + width, getlowerpoint(pline, a.X + width).Y - prflleft)
            Dim c As Point2d = New Point2d(b.X, b.Y + 0.2 + endWith)
            Dim d As Point2d = New Point2d(a.X, a.Y + 0.2 + getWidth(pline, New Point3d(a.X, b.Y, 0)))
            drawRectangle(a, b, c, d, rotation)

            outConfig(a, b, c, d)
        End Sub

        Private Function getEndWith(pline As Polyline, pt As Point3d, left As Double) As Double
            Dim aux As Point3d = getLastPoint(pline, pt)

            Dim d1 As Double = getWidth(pline, pt)
            Dim p1 As Point2d = New Point2d(pt.X, pt.Y + d1)

            Dim d2 As Double = getWidth(pline, aux)
            Dim p2 As Point2d = New Point2d(aux.X, aux.Y + d1)

            Dim m As Double = (p2.Y - p1.Y) / (p2.X - p1.X)
            Dim b As Double = p1.Y - m * p1.X

            ''y = mx+b
            Dim y As Double = m * (pt.X + left) + b

            Return getWidth(pline, New Point3d(pt.X + left, y, 0))

        End Function

        ''função muito gira que poe as cotas com o estilo defindo pelo utilizador no autocad
        Private Sub printDimension(a As Point2d, b As Point2d, rotation As Matrix3d)
            Dim value As Double = Math.Round(a.GetDistanceTo(b), 1)

            If value <> lastcota Then
                lastcota = value

                '' Start a transaction
                Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                    '' Open the Block table for read
                    Dim acBlkTbl As BlockTable
                    acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)
                    '' Open the Block table record Model space for write
                    Dim acBlkTblRec As BlockTableRecord
                    acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

                    Dim d As AlignedDimension = New AlignedDimension(New Point3d(a.X, a.Y, 0), New Point3d(b.X, b.Y, 0), New Point3d(a.X, a.Y, 0), value.ToString, acCurDb.DimStyleTableId)

                    ''rotates polyline
                    d.TransformBy(rotation.Inverse())

                    If (mflag = True) Then
                        d.TransformBy(mirror)
                    End If

                    '' Add the new object to the block table record and the transaction
                    acBlkTblRec.AppendEntity(d)
                    acTrans.AddNewlyCreatedDBObject(d, True)

                    '' Save the new object to the database
                    acTrans.Commit()
                End Using
            End If

        End Sub

        Private Sub outConfig(a As Point2d, b As Point2d, c As Point2d, d As Point2d)
            Dim temp As Double
            If (a.GetDistanceTo(b) < d.GetDistanceTo(c)) Then
                temp = a.GetDistanceTo(b)
            Else
                temp = d.GetDistanceTo(c)
            End If

            If (b.GetDistanceTo(c) > a.GetDistanceTo(d)) Then
                add(type & Math.Round(temp * 1000, 1).ToString("0000") & Math.Round(b.GetDistanceTo(c) * 1000).ToString("0000"))
            Else
                add(type & Math.Round(temp * 1000, 1).ToString("0000") & Math.Round(a.GetDistanceTo(d) * 1000).ToString("0000"))
            End If

        End Sub

    End Class

End Namespace

