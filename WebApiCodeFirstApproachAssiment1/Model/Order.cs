namespace WebApiCodeFirstApproachAssiment1.Model
{
    public class Order
    {
        //3. Order: OrderID, CustomerID, OrderDate, TotalAmount

        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public string? OrderDate { get; set; }
        public string? TotalAmount { get; set; }
    }

}
