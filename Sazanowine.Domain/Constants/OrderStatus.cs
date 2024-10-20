namespace Sazanowine.Domain.Constants;

public static class OrderStatus
{
    public const string Pending = "Pending";
    public const string Sent = "Sent";
    public const string Canceled = "Canceled";

    public static string[] Statuses =  {Pending, Sent, Canceled};
}