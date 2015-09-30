' (C) Copyright 2015 by Pedro Toipa Coelho (toipacoelho@ua.pt)
'
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry

<Assembly: CommandClass(GetType(Spral.MyCommands))>
Namespace Spral

    Public Class MyCommands

        <CommandMethod("LajeAligeirada")>
        Public Sub LajeAligeirada()
            Dim form As FormAli = New FormAli
            form.Show()
        End Sub

        <CommandMethod("LajeAlveolar")> _
        Public Sub LajeAlveolar()
            Dim form As FormAlv = New FormAlv
            form.Show()
        End Sub

        <CommandMethod("Coberturas")> _
        Public Sub Coberturas()
            Dim form As FormCob = New FormCob
            form.Show()
        End Sub


        ''get prependicular of a vector to a point
        Private Function getPrependicular(aV As Point2d, bV As Point2d, iP As Point2d) As Vector2d

            'Dim l1 As Line2d = New Line2d(aV, bV)
            'Dim l2 As Line2d = l1.GetPerpendicularLine(iP)

            'Dim aux As Point2d = l1.IntersectWith(l2)(0)
            'Return aux.GetVectorTo(iP)

            Return getPrependicularLine(aV, bV, iP).GetVectorTo(iP)
        End Function

        Private Function getPrependicularLine(aV As Point2d, bv As Point2d, iP As Point2d) As Point2d
            Dim l1 As Line2d = New Line2d(aV, bv)
            Dim l2 As Line2d = l1.GetPerpendicularLine(iP)

            Dim aux As Point2d = l1.IntersectWith(l2)(0)

            Return aux
        End Function

        Private Sub showpoint(result As Point3d)
            '' Get the current document and database
            Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
            Dim acCurDb As Database = acDoc.Database

            '' Start a transaction
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

                '' Open the Block table for read
                Dim acBlkTbl As BlockTable
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)

                '' Open the Block table record Model space for write
                Dim acBlkTblRec As BlockTableRecord
                acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                                OpenMode.ForWrite)

                '' Create a point at (4, 3, 0) in Model space
                Using acPoint As DBPoint = New DBPoint(New Point3d(result.X, result.Y, 0))

                    '' Add the new object to the block table record and the transaction
                    acBlkTblRec.AppendEntity(acPoint)
                    acTrans.AddNewlyCreatedDBObject(acPoint, True)
                End Using

                '' Set the style for all point objects in the drawing
                acCurDb.Pdmode = 34
                acCurDb.Pdsize = 1

                '' Save the new object to the database
                acTrans.Commit()
            End Using
        End Sub

        Private Function GetMostLeftVertex(pline As Polyline, basePoint As Point3d, cursorPoint As Point3d) As Point3d
            ' get the vector from basepoint to cursorPoint
            Dim direction As Vector3d = basePoint.GetVectorTo(cursorPoint)

            ' compute the angle between this vector and X axis
            Dim angle As Double = direction.GetAngleTo(Vector3d.XAxis, Vector3d.ZAxis)

            ' build a transformation matrix to rotate points
            Dim rotation As Matrix3d = Matrix3d.Rotation(angle, Vector3d.ZAxis, basePoint)

            ' initialize the result point
            Dim result As Point3d = basePoint

            ' iterate the vertices
            For i As Integer = 0 To pline.NumberOfVertices - 1
                Dim pt As Point3d = pline.GetPoint3dAt(i).TransformBy(rotation)
                ' compare the rotated point X coordinate to the result point one
                If pt.X < result.X Then
                    result = pt
                End If
            Next
            showpoint(result.TransformBy(rotation.Inverse()))
            Return result.TransformBy(rotation.Inverse())
        End Function

    End Class

End Namespace