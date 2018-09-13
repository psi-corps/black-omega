using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlackOmega.Contracts.Ordering.Storage
{
    public class UpdateOrder<TEntity>
    {
        
    }



    public interface IPersistanceStateProvider<in TEntity>
    {
        bool GetPersistanceState(TEntity entity);
    }

    public interface ICreateAuthorizer<in TUser>
    {
        Task<bool> Authorize<TEntity>(TUser user, CancellationToken ct = default);
    }

    public interface IValidator<in TTarget>
    {
        Task<ValidationResult> Validate(TTarget target, CancellationToken ct = default);
    }

    public readonly struct ValidationResult
    {
        private IReadOnlyDictionary<string, IReadOnlyList<string>> Errors { get; }

        public ValidationResult(IReadOnlyDictionary<string, IReadOnlyList<string>> errors) => Errors = errors;

        public bool IsSuccess => Errors == null;
    }


    /*
     *
     *    Facilities:
     *      - Routing;
     *      - Filtering;
     *      - Request Binding;
     *      - 
     *
     *
     *
     *    Create:
     *      - Authorize the access                --> 401;
     *      - Validate the request                --> 400;
     *      - Authorize the action                --> 403;
     *      - Validate the entity                 --> 400 (?);
     *      - Persist the entity and retrieve id;
     *      - Publish the event;
     *      - Log the context;
     *      --> 201/500;
     *    
     *
     *    Save:
     *      - Authorize the access                --> 401;
     *      - Validate the request                --> 400;
     *      - Try to retrieve an entity           --> 404;
     *      - Authorize the action                --> 403;
     *      - Validate the entity                 --> 400 (?);
     *      - Persist the entity;
     *      - Publish the event;
     *      - Log the context;
     *      --> 202/500;
     *
     *
     *    Update:
     *      - Authorize the access                --> 401;
     *      - Validate the request                --> 400;
     *      - Try to retrieve an entity           --> 404;
     *      - Authorize the action                --> 403;
     *      - Validate the entity                 --> 400 (?);
     *      - Persist the entity;
     *      - Publish the event;
     *      - Log the context;
     *      --> 202/500;
     *
     *
     *    Remove:
     *
     *
     *
     *
     *
     * 
     */
}