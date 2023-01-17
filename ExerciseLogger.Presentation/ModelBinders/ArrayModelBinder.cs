using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLogger.Presentation.ModelBinders
{
    public class ArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // We are creating a model binder for the IEnumerable type.
            // We check if our parameter is the same type
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            //Value extraction (GUIDs (IDs) separated with commas)
            var providedValue = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName)
                .ToString();

            //If the value is empty or null return null
            if (string.IsNullOrEmpty(providedValue))
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            //Generic binder
            var genericType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0]; //Store the type IEnumerable consists of (GUID)
            var converter = TypeDescriptor.GetConverter(genericType); //Converter to GUID type

            //Object array consisting of all GUID values
            var objectArray = providedValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => converter.ConvertFromString(x.Trim()))
                .ToArray();

            //We create an array of GUID types and copy values from objectArray to guidArray
            var guidArray = Array.CreateInstance(genericType, objectArray.Length);
            objectArray.CopyTo(guidArray, 0);
            bindingContext.Model = guidArray;

            //Assigning guidArray to bindingContext and returning Success
            bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
            return Task.CompletedTask;
        }
    }
}
