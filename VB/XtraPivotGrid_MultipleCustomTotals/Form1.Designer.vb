' Developer Express Code Central Example:
' How to calculate multiple Custom Totals with SummaryType set to Custom
' 
' The following example demonstrates how to calculate and display multiple Custom
' Totals for a field.
' 
' In this example, two Custom Totals are implemented for
' the Category Name field. The first one displays a median calculated against
' summary values, while the second one displays the first and third
' quartiles.
' 
' To accomplish this task, we create two PivotGridCustomTotal
' objects and set their summary type to PivotSummaryType.Custom. We also assign
' the Custom Totals' names to PivotGridCustomTotalBase.Tag properties to be able
' to distinguish between the Custom Totals when we calculate their values.
' Finally, we add the created objects to the Category Name field's
' PivotGridField.CustomTotals collection and enable the Custom Totals to be
' displayed for this field by setting the PivotGridFieldBase.TotalsVisibility
' property to PivotTotalsVisibility.CustomTotals.
' 
' Custom Total values are
' actually calculated in the PivotGridControl.CustomCellValue event. First, the
' event handler prepares a list of summary values against which a Custom Total
' will be calculated. For this purpose, it creates a summary datasource and copies
' the summary values to an array. After that, the array is sorted and passed to an
' appropriate method that calculates a median or quartile value against the
' provided array. Finally, the resulting value is assigned to the event
' parameter's PivotCellValueEventArgs.Value property.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3815


Imports Microsoft.VisualBasic
Imports System
Namespace XtraPivotGrid_MultipleCustomTotals
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim pivotGridGroup1 As New DevExpress.XtraPivotGrid.PivotGridGroup()
			Dim pivotGridGroup2 As New DevExpress.XtraPivotGrid.PivotGridGroup()
			Me.fieldYear = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldQuarter = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldMonth = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.pivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
			Me.fieldProductName = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldProductSales = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldCategoryName = New DevExpress.XtraPivotGrid.PivotGridField()
			CType(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' fieldYear
			' 
			Me.fieldYear.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
			Me.fieldYear.AreaIndex = 0
			Me.fieldYear.Caption = "Year"
			Me.fieldYear.FieldName = "ShippedDate"
			Me.fieldYear.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear
			Me.fieldYear.Name = "fieldYear"
			Me.fieldYear.UnboundFieldName = "fieldYear"
			' 
			' fieldQuarter
			' 
			Me.fieldQuarter.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
			Me.fieldQuarter.AreaIndex = 1
			Me.fieldQuarter.Caption = "Quarter"
			Me.fieldQuarter.FieldName = "ShippedDate"
			Me.fieldQuarter.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateQuarter
			Me.fieldQuarter.Name = "fieldQuarter"
			Me.fieldQuarter.UnboundFieldName = "fieldQuarter"
			' 
			' fieldMonth
			' 
			Me.fieldMonth.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
			Me.fieldMonth.AreaIndex = 2
			Me.fieldMonth.Caption = "Month"
			Me.fieldMonth.FieldName = "ShippedDate"
			Me.fieldMonth.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth
			Me.fieldMonth.Name = "fieldMonth"
			Me.fieldMonth.UnboundFieldName = "fieldMonth"
			' 
			' pivotGridControl1
			' 
			Me.pivotGridControl1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.pivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() { Me.fieldYear, Me.fieldProductName, Me.fieldProductSales, Me.fieldCategoryName, Me.fieldQuarter, Me.fieldMonth})
			pivotGridGroup1.Fields.Add(Me.fieldYear)
			pivotGridGroup1.Fields.Add(Me.fieldQuarter)
			pivotGridGroup1.Fields.Add(Me.fieldMonth)
			pivotGridGroup1.Hierarchy = Nothing
			pivotGridGroup1.ShowNewValues = True
			pivotGridGroup2.Caption = "Category - Product"
			pivotGridGroup2.Fields.Add(Me.fieldCategoryName)
			pivotGridGroup2.Fields.Add(Me.fieldProductName)
			pivotGridGroup2.Hierarchy = Nothing
			pivotGridGroup2.ShowNewValues = True
			Me.pivotGridControl1.Groups.AddRange(New DevExpress.XtraPivotGrid.PivotGridGroup() { pivotGridGroup1, pivotGridGroup2})
			Me.pivotGridControl1.Location = New System.Drawing.Point(12, 12)
			Me.pivotGridControl1.Name = "pivotGridControl1"
			Me.pivotGridControl1.Size = New System.Drawing.Size(726, 452)
			Me.pivotGridControl1.TabIndex = 0
'			Me.pivotGridControl1.CustomCellValue += New System.EventHandler(Of DevExpress.XtraPivotGrid.PivotCellValueEventArgs)(Me.pivotGridControl1_CustomCellValue);
			' 
			' fieldProductName
			' 
			Me.fieldProductName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			Me.fieldProductName.AreaIndex = 1
			Me.fieldProductName.Caption = "Product Name"
			Me.fieldProductName.FieldName = "ProductName"
			Me.fieldProductName.Name = "fieldProductName"
			' 
			' fieldProductSales
			' 
			Me.fieldProductSales.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
			Me.fieldProductSales.AreaIndex = 0
			Me.fieldProductSales.Caption = "Sales"
			Me.fieldProductSales.FieldName = "ProductSales"
			Me.fieldProductSales.Name = "fieldProductSales"
			' 
			' fieldCategoryName
			' 
			Me.fieldCategoryName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			Me.fieldCategoryName.AreaIndex = 0
			Me.fieldCategoryName.Caption = "Category Name"
			Me.fieldCategoryName.FieldName = "CategoryName"
			Me.fieldCategoryName.Name = "fieldCategoryName"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(750, 476)
			Me.Controls.Add(Me.pivotGridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents pivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl
		Private fieldYear As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldProductName As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldProductSales As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldCategoryName As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldQuarter As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldMonth As DevExpress.XtraPivotGrid.PivotGridField
	End Class
End Namespace

