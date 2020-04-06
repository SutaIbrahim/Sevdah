using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Sevdah.Helpers.DoubleModelBinder
{
    public class DoubleModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (!context.Metadata.IsComplexType && (context.Metadata.ModelType == typeof(double) || context.Metadata.ModelType == typeof(double?)))
                return new DoubleModelBinder(context.Metadata.ModelType);

            return null;
        }
    }
}
