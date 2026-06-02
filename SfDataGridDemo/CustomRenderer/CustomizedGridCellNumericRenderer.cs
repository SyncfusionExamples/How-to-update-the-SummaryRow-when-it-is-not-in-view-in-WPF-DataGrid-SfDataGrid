using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Cells;
using Syncfusion.UI.Xaml.ScrollAxis;
using Syncfusion.Windows.Shared;

namespace SfDataGridDemo
{
    internal class CustomizedGridCellNumericRenderer : GridCellNumericRenderer
    {
        RowColumnIndex RowColumnIndex;

        SfDataGrid DataGrid { get; set; }

        string newvalue = null;

        public CustomizedGridCellNumericRenderer(SfDataGrid dataGrid)
        {
            DataGrid = dataGrid;
        }

        public override void OnInitializeEditElement(DataColumnBase dataColumn, DoubleTextBox uiElement, object dataContext)
        {
            base.OnInitializeEditElement(dataColumn, uiElement, dataContext);
            uiElement.ValueChanging += UiElement_ValueChanging;
            this.RowColumnIndex.ColumnIndex = dataColumn.ColumnIndex;
            this.RowColumnIndex.RowIndex = dataColumn.RowIndex;
        }

        private void UiElement_ValueChanging(object sender, Syncfusion.Windows.Shared.ValueChangingEventArgs e)
        {
            newvalue = e.NewValue.ToString();
            UpdateSummaryValues(this.RowColumnIndex.RowIndex, this.RowColumnIndex.ColumnIndex);
        }

        private void UpdateSummaryValues(int rowIndex, int columnIndex)
        {
            string editEelementText = newvalue == "0" ? "0" : newvalue;
            columnIndex = this.DataGrid.ResolveToGridVisibleColumnIndex(columnIndex);
            if (columnIndex < 0)
                return;

            var mappingName = DataGrid.Columns[columnIndex].MappingName;
            var recordIndex = this.DataGrid.ResolveToRecordIndex(rowIndex);

            if (recordIndex < 0)
                return;

            if (DataGrid.View.TopLevelGroup != null)
            {
                var record = DataGrid.View.TopLevelGroup.DisplayElements[recordIndex];
                if (!record.IsRecords)
                    return;

                var data = (record as RecordEntry).Data;
                data.GetType().GetProperty(mappingName).SetValue(data, (int.Parse(editEelementText)));
            }
            else
            {
                var record1 = DataGrid.View.Records.GetItemAt(recordIndex);
                record1.GetType().GetProperty(mappingName).SetValue(record1, (int.Parse(editEelementText)));
            }
        }
    }
}
