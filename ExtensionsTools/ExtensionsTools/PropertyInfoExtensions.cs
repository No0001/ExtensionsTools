using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class PropertyInfoExtensions
{
    /// <summary>
    /// 取得ClassAttributValue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TAttribute"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="prop"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TValue GetClassAttributValue<T, TAttribute, TValue>(this T prop, Func<TAttribute, TValue> value) where TAttribute : Attribute where T : class
    {
        if (prop.GetType().GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute att)
        {
            return value(att);
        }
        return default(TValue);
    }

    /// <summary>
    /// 取得欄位AttributValue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TAttribute"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="propertyName"></param>
    /// <param name="className"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TValue GetPropertyAttributValue<T, TAttribute, TValue>(this string propertyName, T className, Func<TAttribute, TValue> value) where TAttribute : Attribute where T : class
    {
        var prop = className.GetType().GetProperty(propertyName);

        if (prop.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute att)
        {
            return value(att);
        }
        return default(TValue);
    }
}