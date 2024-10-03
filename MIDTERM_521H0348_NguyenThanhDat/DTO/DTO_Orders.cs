public class DTO_Order
{
    public string ID { get; set; }
    public string ClientID { get; set; }
    public string EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
}