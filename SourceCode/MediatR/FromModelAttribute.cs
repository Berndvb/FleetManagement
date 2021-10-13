using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace MediatR.Cqrs
{
    public sealed class FromModelAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource { get; } = BindingSource.ModelBinding;
    }
}
