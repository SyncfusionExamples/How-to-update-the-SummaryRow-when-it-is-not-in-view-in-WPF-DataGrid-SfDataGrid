using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SfDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.sfDataGrid.CellRenderers.Remove("Numeric");
            this.sfDataGrid.CellRenderers.Add("Numeric", new CustomizedGridCellNumericRenderer(sfDataGrid));
            sfDataGrid.Loaded += SfDataGrid_Loaded;
        }

        private void SfDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (sfDataGrid.View != null) 
                sfDataGrid.View.RecordPropertyChanged += View_RecordPropertyChanged;
        }

        private void View_RecordPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sfDataGrid.View != null && sfDataGrid.View.SummaryRows.Count > 0)
            {
                var groupSummaryRows = this.sfDataGrid.RowGenerator.Items.Where(item => (item.RowType == RowType.SummaryCoveredRow || item.RowType == RowType.SummaryRow));
                foreach (SpannedDataRow row in groupSummaryRows)
                    sfDataGrid.UpdateDataRow(row.RowIndex);
            }
        }
    }
}
