using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Helpers;

/// <summary>
///     Represent set of constant.
/// </summary>
internal static class CommonConstant
{
    internal static class SqlDatabase
    {
        internal static class DataType
        {
            internal const string DATETIME = "DATETIME2";

            internal const string NVARCHAR_MAX = "NVARCHAR(MAX)";

            /// <summary>
            ///     Nvarchar datatype resolver.
            /// </summary>
            internal static class NvarcharGenerator
            {
                private static readonly Dictionary<int, string> _storage = [];
                private const string NvarcharDataTypeName = "NVARCHAR";

                /// <summary>
                ///     Generate Varchar datatype with given length.
                /// </summary>
                /// <param name="length">
                ///     Length of Varchar.
                /// </param>
                /// <returns>
                ///     The old instance if it is already existed
                ///     or the new one.
                /// </returns>
                /// <remarks>
                ///     The extension cannot generate max length.
                /// </remarks>
                internal static string Get(int length)
                {
                    if (_storage.TryGetValue(key: length, value: out var value))
                    {
                        return value;
                    }

                    var newValue = $"{NvarcharDataTypeName}({length})";

                    _storage.Add(key: length, value: newValue);

                    return newValue;
                }
            }
        }

        public static class Collation
        {
        }
    }
}
