using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using VkNet.Enums.SafetyEnums;
using Expression = System.Linq.Expressions.Expression;

namespace VkNet.Utils;

/// <summary>
/// Converter for safety enum fields
/// </summary>
/// <typeparam name="TEnum"></typeparam>
[SuppressMessage("Minor Code Smell", "S3963:\"static\" fields should be initialized inline")]
public class DynamoSafetyEnumConverter<TEnum>: IPropertyConverter
	where TEnum : SafetyEnum<TEnum>, new()
{
	/// <summary>
	/// Convert DynamoDb field to enum
	/// </summary>
	/// <param name="entry"></param>
	/// <returns></returns>
	public DynamoDBEntry ToEntry(object value)
	{
		return new Primitive(value?.ToString());
	}

	/// <summary>
	/// Convert enum to DynamoDb field
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public object FromEntry(DynamoDBEntry entry)
	{
		var value = entry.AsString();
		return value != null ? SafetyEnum<TEnum>.FromJsonString(value) : null;
	}
}