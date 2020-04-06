using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Sevdah.Helpers.FloatModelBinder
{
    public class FloatModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (!context.Metadata.IsComplexType && (context.Metadata.ModelType == typeof(float) || context.Metadata.ModelType == typeof(float?)))
                return new FloatModelBinder(context.Metadata.ModelType);

            return null;
        }
    }
}
