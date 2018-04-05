namespace PsiCorps.BlackOmega.Storage.Abstractions.GetById
{
    using System;


    public interface IGetByIdStatusProvider
    {
        Status NotFound();

        Status Ok();

        Status Error(Exception x);
    }
}