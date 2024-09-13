namespace OrderManagement.Application
{
    public static class OrderManagementConstant
    {
        public static class commonMessage
        {
            public const string BedRequest = "Bed Request";
            public const string Failed = "Failed";
            public const string Success = "Success";
        }

        public static class EmailValidationMessage
        {
            public const string EmailCanNotBeBlank = "Email can not be blank or empty.";
            public const string InvalidEmail = "Invalid Email.";
            public const string EmailExists = "Email Address Exists.";
        }

        public static class CustomerValidationMesage
        {
            public const string CustomerNameIsMust = "Customer name name is must.";
            public const string CustomerNotExists = "Customer not exists.";
            public const string CustomerDeleteSuccess = "Customer deleted success.";
        }

        public static class orderValidationMesage
        {
            public const string OrderNotExists = "Order Not exists.";
            public const string InvalidOrderAmount = "Invalid Order Amount.";
            public const string OrderCreated = "Order created successfully.";
            public const string OrderDeleted = "Order deleted successfully.";
            public const string OrderUpdated = "Order updated successfully.";
            public const string OrdernotExists = "Order Not Exists.";
        }
    }
}
