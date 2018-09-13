using BlackOmega.Ordering;
using Microsoft.AspNetCore.Mvc;

namespace BlackOmega.Integration.AspNetCore.Mvc
{
    public class ActionResultProducer : IActionResultProducer
    {
        public IActionResult CreateResult(IOrderStatus status)
        {
            throw new System.NotImplementedException();
        }
    }
}