public class DTO_Bill
{
    public string ID { get; set; }
    public string OrderID { get; set; }
    public string ClientID { get; set; }
    public string EmployeeID { get; set; }
    public DateTime BillDate { get; set; }
    public decimal TotalPrice { get; set; }
}
