
using System.Threading;
using System.Threading.Tasks;
using BlackOmega.Integration.AspNetCore.Authorization;
using BlackOmega.Integration.AspNetCore.Mvc.ModelBinding;
using BlackOmega.Ordering;
using BlackOmega.Ordering.Storage;
using Microsoft.AspNetCore.Mvc;


namespace BlackOmega.Integration.AspNetCore.Mvc
{
    public abstract class BlackOmegaStorageControllerBase<TId, TEntity> : ControllerBase where TEntity : Entity<TId>
    {
        protected readonly int UnmplementedStatusCode;
        protected readonly IActionResultProducer ResultProducer;
        protected readonly IAspNetCoreContextUserProvider UserProvider;
        protected readonly IOrderIdProducer OrderIdProducer;
        protected readonly ISeviceIdProvider ServiceIdProvider;

        
        protected BlackOmegaStorageControllerBase(int unmplementedStatusCode, IActionResultProducer resultProducer,
            IAspNetCoreContextUserProvider userProvider)
        {
            UnmplementedStatusCode = unmplementedStatusCode;
            ResultProducer = resultProducer;
            UserProvider = userProvider;
        }

        
        public async Task<IActionResult> Post([FromServices] IOrderExecutor<SaveOrder<TId, TEntity>> executor,
            SaveOrder<TId, TEntity> order, CancellationToken ct)
        {
            var user = await UserProvider.GetContextUser(HttpContext, ct);
            var result = await executor.ExecuteOrder(order, user, ct);

            return ResultProducer.CreateResult(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromServices] IOrderExecutor<SaveAsOrder<TId, TEntity>> executor,
            [OrderModelBinder] SaveAsOrder<TId, TEntity> order, CancellationToken ct)
        {
            
        }
    }

    public interface ISeviceIdProvider
    {
        object GetServiceId();
    }

    public interface IOrderIdProducer
    {
        object CreateOrderId();
    }
}