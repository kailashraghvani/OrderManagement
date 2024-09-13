namespace OrderManagement.Application.ResquestModel
{
    public class OrderRequestModel
    {
        public int Id { get; set; }
	    public int CustomerId { get; set; }
	    public decimal Amount {  get; set; }
	    public DateTime Date {  get; set; }
        internal bool IsDiscountApplicable => Amount >= 1000;
    }
}
