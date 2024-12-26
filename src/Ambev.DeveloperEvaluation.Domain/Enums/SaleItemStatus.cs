using System.ComponentModel;

namespace Ambev.DeveloperEvaluation.Domain.Enums;

public enum SaleItemStatus
{
    [Description("Not Canceled")]
    NotCancelled,
    
    [Description("Canceled")]
    Cancelled
}