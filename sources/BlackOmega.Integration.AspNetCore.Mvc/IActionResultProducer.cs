using BlackOmega.Ordering;
using Microsoft.AspNetCore.Mvc;

namespace BlackOmega.Integration.AspNetCore.Mvc
{
    public interface IActionResultProducer
    {
        IActionResult CreateResult(IOrderStatus status);
    }
}