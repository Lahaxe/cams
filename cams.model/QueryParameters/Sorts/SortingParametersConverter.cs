﻿using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Globalization;

namespace cams.model.QueryParameters.Sorts
{
    /// <summary>
    /// Defines the converter for sorting parameters.
    /// </summary>
    public class SortingParametersConverter : TypeConverter
    {
        /// <summary>
        /// Indicates if a json string can be convert to an object.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// Converts a json string to object.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                try
                {
                    return new SortingParameters(JsonConvert.DeserializeObject<SortingParametersBase>(Uri.UnescapeDataString((string)value)));
                }
                catch
                {
                    return new SortingParameters(false);
                }
            }
            else
            {
                throw new ArgumentException("Sorting parameter should be a string value", nameof(value));
            }
        }
    }
}