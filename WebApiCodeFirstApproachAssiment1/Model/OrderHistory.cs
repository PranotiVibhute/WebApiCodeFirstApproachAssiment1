namespace WebApiCodeFirstApproachAssiment1.Model
{
    public class OrderHistory
    {//4. OrderHistory: OrderHistoryID, ProductID, Quantity, UnitPrice
        public int OrderHistoryID { get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
        public int? UnitPrice { get; set; }
    }
}
