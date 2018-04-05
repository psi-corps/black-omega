using System;
using System.Collections.Generic;

namespace PsiCorps.BlackOmega.Storage.DependencyInjection.Builders
{
    public class GetByIdCommandBuilder<TGetByIdQuery>
    {
        public GetByIdCommandBuilder() => CommandType = typeof(TGetByIdQuery);


        public Type CommandType { get; }

        public UseConventionalDecorators();

        public GetByIdCommandBuilder<TGetByIdQuery> DecorateWith<TDecorator>();
    }


    public class StorageBuilder<TEntity, TId, TUserIdentity>
    {
        private readonly IList<Type> _dependencies = new List<Type>();


        public void ImplementWith<TStorage>() => _dependencies.Add(typeof(TStorage));
 

        public GetByIdCommandBuilder<TGetByIdQuery> GetByIdWith<TGetByIdQuery>()
            where TGetByIdQuery : IGetByIdQuery<TEntity, TId, TUserIdentity> =>
            new GetByIdCommandBuilder<TGetByIdQuery>();


        public StorageBuilder<TEntity, TId, TUserIdentity> UseSaveCommand<TSaveCommand>()
            where TSaveCommand : ISaveCommand<TEntity, TUserIdentity>
        {
            _types.Add(typeof(TSaveCommand));
            return this;
        }

        public StorageBuilder<TEntity, TId, TUserIdentity> UseUpdateCommand<TUpdateCommand>()
            where TUpdateCommand : ISaveCommand<TEntity, TUserIdentity>
        {
            _types.Add(typeof(TUpdateCommand));
            return this;
        }

        public StorageBuilder<TEntity, TId, TUserIdentity> UseRemoveCommand<TRemoveCommand>()
            where TRemoveCommand : ISaveCommand<TEntity, TUserIdentity>
        {
            _types.Add(typeof(TRemoveCommand));
            return this;
        }



    }
}