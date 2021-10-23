using DvlDevTools.Http.Attributes;
using DvlDevTools.Http.Enumeration;
using System;

namespace DvlDevTools.Http.Helper
{
	internal static class GetAttributeValue
	{
		internal static string GetDisplayName<TSource>(this TSource source)
		{
			var type = source.GetType();

			var name = type == typeof(AcceptType) || type == typeof(ContentType) ? Enum.GetName(type, source) : string.Empty;

			if (string.IsNullOrEmpty(name))
				throw new Exception($"Cannot convert {nameof(source)}.");

			var fieldInfo = type.GetField(name ?? "");

			if (fieldInfo == null)
				throw new Exception($"Field: {nameof(name)} maybe does not exist in {type.Name}.");

			if (Attribute.GetCustomAttribute(fieldInfo
				, typeof(HeaderDisplayName)) is not HeaderDisplayName attribute)
				throw new Exception($"The attribute is null.");

			return attribute.DisplayName;
		}
	}
}
