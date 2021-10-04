using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Cqs
{
    public sealed class FromModelAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource { get; } = BindingSource.ModelBinding;
    }
}
