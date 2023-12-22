using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ValueGuardian
{
	/// <summary>
	/// Utility class for checking conditions related to null or empty values.
	/// </summary>
	public class Checks
	{
		/// <summary>
		/// Checks if any of the provided values is null or empty.
		/// </summary>
		/// <param name="values">The values to check.</param>
		/// <returns>True if any value is null or empty, otherwise false.</returns>
		public static bool IsEmptyOrNullUseOr(params object[] values)
		{
			return values.Any(IsNullOrEmpty);
		}

		/// <summary>
		/// Checks if all of the provided values are null or empty.
		/// </summary>
		/// <param name="values">The values to check.</param>
		/// <returns>True if all values are null or empty, otherwise false.</returns>
		public static bool IsEmptyOrNullUseAnd(params object[] values)
		{
			return values.All(IsNullOrEmpty);
		}

		/// <summary>
		/// Checks properties of a model object and returns a message if any property is null or empty.
		/// </summary>
		/// <param name="model">The model object to check.</param>
		/// <returns>A message indicating properties with null or empty values, or a message indicating all properties have values.</returns>
		public static string CheckModelProperties(object model)
		{
			if (model == null)
			{
				return null;
			}

			var emptyProperties = GetEmptyProperties(model);

			if (emptyProperties.Any())
			{
				return $"Empty or null properties: {string.Join(", ", emptyProperties)}";
			}

			return "All properties have values.";
		}

		/// <summary>
		/// Checks if a value is null or empty, considering different data types.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <returns>True if the value is null or empty, otherwise false.</returns>
		private static bool IsNullOrEmpty(object value)
		{
			if (value == null) return true;

			return value switch
			{
				string str => string.IsNullOrEmpty(str),
				System.Collections.ICollection collection => collection.Count == 0,
				_ => IsModelObjectWithEmptyProperties(value)
			};
		}

		/// <summary>
		/// Checks if a model object has all properties with null or empty values.
		/// </summary>
		/// <param name="value">The model object to check.</param>
		/// <returns>True if all properties are null or empty, otherwise false.</returns>
		private static bool IsModelObjectWithEmptyProperties(object value)
		{
			if (value.GetType().IsClass && !value.GetType().IsArray)
			{
				return value.GetType().GetProperties().All(property =>
				{
					var propertyValue = property.GetValue(value);
					return propertyValue == null || (propertyValue is string str && string.IsNullOrEmpty(str));
				});
			}

			return false;
		}

		/// <summary>
		/// Gets the names of properties with null or empty values in a model object.
		/// </summary>
		/// <param name="model">The model object to check.</param>
		/// <returns>A list of property names with null or empty values.</returns>
		private static IEnumerable<string> GetEmptyProperties(object model)
		{
			var emptyProperties = new List<string>();

			if (model.GetType().IsClass && !model.GetType().IsArray)
			{
				foreach (var property in model.GetType().GetProperties())
				{
					var propertyValue = property.GetValue(model);
					if (propertyValue == null || (propertyValue is string str && string.IsNullOrEmpty(str)))
					{
						emptyProperties.Add(property.Name);
					}
				}
			}

			return emptyProperties;
		}
	}
}
