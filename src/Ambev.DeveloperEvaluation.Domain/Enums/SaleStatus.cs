using System.ComponentModel;

namespace Ambev.DeveloperEvaluation.Domain.Enums;

public enum SaleStatus
{
    [Description("Not Canceled")]
    NotCancelled,
    
    [Description("Canceled")]
    Cancelled
}