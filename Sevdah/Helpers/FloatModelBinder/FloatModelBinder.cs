using System;
using System.Globalization;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Sevdah.Helpers.FloatModelBinder
{
    public class FloatModelBinder : IModelBinder
    {
        private readonly SimpleTypeModelBinder _baseBinder;

        public FloatModelBinder(Type modelType) => _baseBinder = new SimpleTypeModelBinder(modelType);

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

                var valueAsString = valueProviderResult.FirstValue;

                if (float.TryParse(valueAsString, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out float result))
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                    return Task.CompletedTask;
                }
            }

            return _baseBinder.BindModelAsync(bindingContext);
        }
    }
}
