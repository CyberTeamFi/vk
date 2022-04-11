#nullable enable
using System;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace VkNet.Utils;

/// <summary>
/// Converter for nullable enum fields in DynamoDb
/// </summary>
/// <typeparam name="TEnum"></typeparam>
public class DynamoNullableEnumConverter<TEnum> : IPropertyConverter
    where TEnum : Enum
{
    /// <summary>
    /// Convert DynamoDb field to enum
    /// </summary>
    /// <param name="entry"></param>
    /// <returns></returns>
    public object? FromEntry(DynamoDBEntry entry)
    {
        var p = entry.AsPrimitive();
        return p == null ? null : (TEnum)(object) p.AsInt();
    }

    /// <summary>
    /// Convert enum to DynamoDb field
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public DynamoDBEntry ToEntry(object? value)
    {
        int? num = value == null ? null : (int)value;
        return new Primitive(num?.ToString(), true);
    }
}