using System;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace VkNet.Utils;

/// <summary>
/// Converter for uri
/// </summary>
public class DynamoUriConverter : IPropertyConverter
{
	/// <summary>
	/// Convert DynamoDb field to uri
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public DynamoDBEntry ToEntry(object value)
	{
		return new Primitive(((Uri) value).AbsoluteUri);
	}

	/// <summary>
	/// Convert uri to DynamoDb field
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public object FromEntry(DynamoDBEntry entry)
	{
		var str = entry.AsString();
		return new Uri(str, UriKind.Absolute);
	}
}