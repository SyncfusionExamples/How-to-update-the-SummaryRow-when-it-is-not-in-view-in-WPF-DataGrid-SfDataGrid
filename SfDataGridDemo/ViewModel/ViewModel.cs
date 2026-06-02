using System.Collections.ObjectModel;

namespace SfDataGridDemo
{
    public class ViewModel
    {
        private ObservableCollection<OrderInfo> _orders;
        public ObservableCollection<OrderInfo> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public ViewModel()
        {
            _orders = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            _orders.Add(new OrderInfo(0, "Maria Anders", "Germany", "ALFKI", "Berlin"));
            _orders.Add(new OrderInfo(0, "Ana Trujilo", "Mexico", "ANATR", "Mexico D.F."));
            _orders.Add(new OrderInfo(0, "Antonio Moreno", "Mexico", "ANTON", "Mexico D.F."));
            _orders.Add(new OrderInfo(0, "Thomas Hardy", "Germany", "AROUT", "London"));
            _orders.Add(new OrderInfo(0, "Christina Berglund", "Sweden", "BERGS", "Lula"));
            _orders.Add(new OrderInfo(0, "Hanna Moos", "Germany", "BLAUS", "Mannheim"));
            _orders.Add(new OrderInfo(0, "Frederique Citeaux", "Germany", "BLONP", "Strasbourg"));
            _orders.Add(new OrderInfo(0, "Martin Sommer", "Germany", "BOLID", "Madrid"));
            _orders.Add(new OrderInfo(0, "Laurence Lebihan", "Germany", "BONAP", "Marseille"));
            _orders.Add(new OrderInfo(0, "Elizabeth Lincoln", "Germany", "BOTTM", "Tsawassen"));
        }
    }
}
