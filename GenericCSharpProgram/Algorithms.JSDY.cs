﻿using System.Text;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;

namespace GenericCSharpProgram;

public partial class Algorithms
{
    [Benchmark] public void SimpleType_JSDY() => SimpleType(ConstructTypeName_JSDY);
    [Benchmark] public void ModerateType_JSDY() => ModerateType(ConstructTypeName_JSDY);
    [Benchmark] public void CrazyType_JSDY() => CrazyType(ConstructTypeName_JSDY);

    [Benchmark] public void SimpleType_JSDY_OPT() => SimpleType(ConstructTypeName_JSDY_OPT);
    [Benchmark] public void ModerateType_JSDY_OPT() => ModerateType(ConstructTypeName_JSDY_OPT);
    [Benchmark] public void CrazyType_JSDY_OPT() => CrazyType(ConstructTypeName_JSDY_OPT);

    [Benchmark] public void SimpleType_JSDY_OPT2() => SimpleType(ConstructTypeName_JSDY_OPT2);
    [Benchmark] public void ModerateType_JSDY_OPT2() => ModerateType(ConstructTypeName_JSDY_OPT2);
    [Benchmark] public void CrazyType_JSDY_OPT2() => CrazyType(ConstructTypeName_JSDY_OPT2);

    [Benchmark] public void SimpleType_JSDY_OPT3() => SimpleType(ConstructTypeName_JSDY_OPT3);
    [Benchmark] public void ModerateType_JSDY_OPT3() => ModerateType(ConstructTypeName_JSDY_OPT3);
    [Benchmark] public void CrazyType_JSDY_OPT3() => CrazyType(ConstructTypeName_JSDY_OPT3);

    [Benchmark] public void SimpleType_JSDY_OPT5()   => SimpleType(ConstructTypeName_JSDY_OPT5);
    [Benchmark] public void ModerateType_JSDY_OPT5() => ModerateType(ConstructTypeName_JSDY_OPT5);
    [Benchmark] public void CrazyType_JSDY_OPT5()    => CrazyType(ConstructTypeName_JSDY_OPT5);


    [Benchmark] public void SimpleType_JSDY_OPT4() => SimpleType(ConstructTypeName_JSDY_OPT4);
    [Benchmark] public void ModerateType_JSDY_OPT4() => ModerateType(ConstructTypeName_JSDY_OPT4);
    [Benchmark] public void CrazyType_JSDY_OPT4() => CrazyType(ConstructTypeName_JSDY_OPT4);

    [Benchmark] public void SimpleType_JSDY_OPT6() => SimpleType(ConstructTypeName_JSDY_OPT6);
    [Benchmark] public void ModerateType_JSDY_OPT6() => ModerateType(ConstructTypeName_JSDY_OPT6);
    [Benchmark] public void CrazyType_JSDY_OPT6() => CrazyType(ConstructTypeName_JSDY_OPT6);

    [Benchmark] public void SimpleType_JSDY_OPT7() => SimpleType(ConstructTypeName_JSDY_OPT7);
    [Benchmark] public void ModerateType_JSDY_OPT7() => ModerateType(ConstructTypeName_JSDY_OPT7);
    [Benchmark] public void CrazyType_JSDY_OPT7() => CrazyType(ConstructTypeName_JSDY_OPT7);

    [Benchmark] public void SimpleType_JSDY_OPT8() => SimpleType(ConstructTypeName_JSDY_OPT8);
    [Benchmark] public void ModerateType_JSDY_OPT8() => ModerateType(ConstructTypeName_JSDY_OPT8);
    [Benchmark] public void CrazyType_JSDY_OPT8() => CrazyType(ConstructTypeName_JSDY_OPT8);

    [Benchmark] public void SimpleType_JSDY_OPT9() => SimpleType(ConstructTypeName_JSDY_OPT9);
    [Benchmark] public void ModerateType_JSDY_OPT9() => ModerateType(ConstructTypeName_JSDY_OPT9);
    [Benchmark] public void CrazyType_JSDY_OPT9() => CrazyType(ConstructTypeName_JSDY_OPT9);
    [Benchmark] public void SimpleType_JSDY_OPT5_2() => SimpleType(ConstructTypeName_JSDY_OPT5_2);
    [Benchmark] public void ModerateType_JSDY_OPT5_2() => ModerateType(ConstructTypeName_JSDY_OPT5_2);
    [Benchmark] public void CrazyType_JSDY_OPT5_2() => CrazyType(ConstructTypeName_JSDY_OPT5_2);

    [Benchmark] public void SimpleType_JSDY_OPT7_2() => SimpleType(ConstructTypeName_JSDY_OPT7_2);
    [Benchmark] public void ModerateType_JSDY_OPT7_2() => ModerateType(ConstructTypeName_JSDY_OPT7);
    [Benchmark] public void CrazyType_JSDY_OPT7_2() => CrazyType(ConstructTypeName_JSDY_OPT7_2);

    [Benchmark] public void SimpleType_JSDY_OPT8_2() => SimpleType(ConstructTypeName_JSDY_OPT8_2);
    [Benchmark] public void ModerateType_JSDY_OPT8_2() => ModerateType(ConstructTypeName_JSDY_OPT8_2);
    [Benchmark] public void CrazyType_JSDY_OPT8_2() => CrazyType(ConstructTypeName_JSDY_OPT8_2);

    [Benchmark] public void SimpleType_JSDY_OPT9_2() => SimpleType(ConstructTypeName_JSDY_OPT9_2);
    [Benchmark] public void ModerateType_JSDY_OPT9_2() => ModerateType(ConstructTypeName_JSDY_OPT9_2);
    [Benchmark] public void CrazyType_JSDY_OPT9_2() => CrazyType(ConstructTypeName_JSDY_OPT9_2);

    public static string ConstructTypeName_JSDY(Type type)
    {
        if (type.IsArray || type.IsGenericType)
        {
            var sb = new StringBuilder();
            BuildType(sb, type);
            return sb.ToString();
        }

        return GetSimpleTypeName(type);

        static void BuildType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                BuildArray(sb, type);
            }
            else if (type.IsGenericType)
            {
                BuildGeneric(sb, type);
            }
            else
            {
                sb.Append(GetSimpleTypeName(type));
            }
        }

        static void BuildArray(StringBuilder sb, Type type)
        {
            var elementType = type;
            while (elementType.IsArray)
            {
                elementType = elementType.GetElementType()!;
            }

            BuildType(sb, elementType);
            BuildArrayRecursive(sb, type);

            static void BuildArrayRecursive(StringBuilder sb, Type type)
            {
                BuildArrayBrackets(sb, type.GetArrayRank());
                var elementType = type.GetElementType()!;
                if (elementType.IsArray)
                {
                    BuildArrayRecursive(sb, elementType);
                }
            }

            static void BuildArrayBrackets(StringBuilder sb, int rank)
            {
                sb.Append('[');
                for (int i = 0; i < rank - 1; i++)
                {
                    sb.Append(',');
                }

                sb.Append(']');
            }
        }

        static void BuildGeneric(StringBuilder sb, Type type)
        {
            var genericDefinitionFullName = type.GetGenericTypeDefinition().FullName ?? string.Empty;
            var genericArgs = type.GenericTypeArguments;

            //Nullable
            if (genericDefinitionFullName == "System.Nullable`1")
            {
                BuildType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (genericDefinitionFullName.StartsWith("System.ValueTuple`"))
            {
                sb.Append('(');
                BuildParamTypes(sb, genericArgs);
                sb.Append(')');
                return;
            }

            //normal generic
            sb.Append(type.Name[..type.Name.LastIndexOf('`')]);
            sb.Append('<');
            BuildParamTypes(sb, genericArgs);
            sb.Append('>');

            static void BuildParamTypes(StringBuilder sb, Type[] genericArgs)
            {
                for (int i = 0; i < genericArgs.Length; i += 1)
                {
                    BuildType(sb, genericArgs[i]);
                    if (i < genericArgs.Length - 1)
                    {
                        sb.Append(',').Append(' ');
                    }
                }
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return type.FullName switch
            {
                "System.SByte" => "sbyte",
                "System.Byte" => "byte",
                "System.Int16" => "short",
                "System.UInt16" => "ushort",
                "System.Int32" => "int",
                "System.UInt32" => "uint",
                "System.Int64" => "long",
                "System.UInt64" => "ulong",
                "System.IntPtr" => "nint",
                "System.UIntPtr" => "nuint",
                "System.Single" => "float",
                "System.Double" => "double",
                "System.Decimal" => "decimal",
                "System.Boolean" => "bool",
                "System.Char" => "char",
                "System.String" => "string",
                "System.Object" => "object",
                _ => type.Name
            };
        }
    }

    [ThreadStatic] private static StringBuilder _stringBuilder;

    public static string ConstructTypeName_JSDY_OPT(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder ??= new StringBuilder();
        var sb = _stringBuilder;
        AppendType(sb, type);
        var result = sb.ToString();
        _stringBuilder.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
            }
            else if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
            }
            else
            {
                sb.Append(GetSimpleTypeName(type));
            }
        }

        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element
            var elementType = type.GetElementType()!;
            while (elementType.IsArray)
            {
                elementType = elementType.GetElementType()!;
            }

            AppendType(sb, elementType);
            //append brackets
            AppendArrayRecursive(sb, type);

            static void AppendArrayRecursive(StringBuilder sb, Type type)
            {
                //append bracket with rank
                var rank = type.GetArrayRank();
                sb.Append('[');
                for (int i = 0; i < rank - 1; i++)
                {
                    sb.Append(',');
                }

                sb.Append(']');
                //recursive call
                var elementType = type.GetElementType()!;
                if (elementType.IsArray)
                {
                    AppendArrayRecursive(sb, elementType);
                }
            }
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {
            var genericDefinitionFullName = type.GetGenericTypeDefinition().FullName ?? string.Empty;
            var genericArgs = type.GenericTypeArguments;

            //Nullable
            if (genericDefinitionFullName == "System.Nullable`1")
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (genericDefinitionFullName.StartsWith("System.ValueTuple`"))
            {
                sb.Append('(');
                AppendParamTypes(sb, genericArgs);
                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');

            static void AppendParamTypes(StringBuilder sb, Type[] genericArgs)
            {
                for (int i = 0; i < genericArgs.Length; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    if (i < genericArgs.Length - 1)
                    {
                        sb.Append(',').Append(' ');
                    }
                }
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return type.FullName switch
            {
                "System.SByte" => "sbyte",
                "System.Byte" => "byte",
                "System.Int16" => "short",
                "System.UInt16" => "ushort",
                "System.Int32" => "int",
                "System.UInt32" => "uint",
                "System.Int64" => "long",
                "System.UInt64" => "ulong",
                "System.IntPtr" => "nint",
                "System.UIntPtr" => "nuint",
                "System.Single" => "float",
                "System.Double" => "double",
                "System.Decimal" => "decimal",
                "System.Boolean" => "bool",
                "System.Char" => "char",
                "System.String" => "string",
                "System.Object" => "object",
                _ => type.Name
            };
        }
    }


    [ThreadStatic] private static StringBuilder _stringBuilder2;

    public static string ConstructTypeName_JSDY_OPT2(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder2 ??= new StringBuilder(256);
        var sb = _stringBuilder2;
        AppendType(sb, type);
        var result = sb.ToString();
        _stringBuilder2.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
            }
            else if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
            }
            else
            {
                sb.Append(GetSimpleTypeName(type));
            }
        }

        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element
            var elementType = type.GetElementType()!;
            while (elementType.IsArray)
            {
                elementType = elementType.GetElementType()!;
            }

            AppendType(sb, elementType);
            //append brackets
            AppendArrayRecursive(sb, type);

            static void AppendArrayRecursive(StringBuilder sb, Type type)
            {
                while (true)
                {
                    //append bracket with rank
                    var rank = type.GetArrayRank();
                    sb.Append('[');
                    for (int i = 0; i < rank - 1; i++)
                    {
                        sb.Append(',');
                    }

                    sb.Append(']');
                    //recursive call
                    var elementType = type.GetElementType()!;
                    if (elementType.IsArray)
                    {
                        type = elementType;
                        continue;
                    }

                    break;
                }
            }
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {
            var fullName = type.GetGenericTypeDefinition().FullName;
            ReadOnlySpan<char> genericDefinitionFullName = fullName != null ? fullName.AsSpan() : ReadOnlySpan<char>.Empty;
            var genericArgs = type.GenericTypeArguments;

            //Nullable
            if (genericDefinitionFullName == "System.Nullable`1")
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (genericDefinitionFullName.StartsWith("System.ValueTuple`"))
            {
                sb.Append('(');
                AppendParamTypes(sb, genericArgs);
                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');

            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(',').Append(' ');
                }

                AppendType(sb, genericArgs[^1]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return type.FullName switch
            {
                "System.SByte" => "sbyte",
                "System.Byte" => "byte",
                "System.Int16" => "short",
                "System.UInt16" => "ushort",
                "System.Int32" => "int",
                "System.UInt32" => "uint",
                "System.Int64" => "long",
                "System.UInt64" => "ulong",
                "System.IntPtr" => "nint",
                "System.UIntPtr" => "nuint",
                "System.Single" => "float",
                "System.Double" => "double",
                "System.Decimal" => "decimal",
                "System.Boolean" => "bool",
                "System.Char" => "char",
                "System.String" => "string",
                "System.Object" => "object",
                _ => type.Name
            };
        }
    }


    [ThreadStatic] private static StringBuilder _stringBuilder3;

    public static string ConstructTypeName_JSDY_OPT3(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder3 ??= new StringBuilder(256);
        var sb = _stringBuilder3;
        AppendType(sb, type);
        var result = sb.ToString();
        _stringBuilder3.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
            }
            else if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
            }
            else
            {
                sb.Append(GetSimpleTypeName(type));
            }
        }

        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element
            var elementType = type.GetElementType()!;
            while (elementType.IsArray)
            {
                elementType = elementType.GetElementType()!;
            }

            AppendType(sb, elementType);
            //append brackets
            AppendArrayRecursive(sb, type);

            static void AppendArrayRecursive(StringBuilder sb, Type type)
            {
                while (true)
                {
                    //append bracket with rank
                    var rank = type.GetArrayRank();
                    sb.Append('[');
                    sb.Append(',', rank - 1);
                    sb.Append(']');
                    //recursive call
                    var elementType = type.GetElementType()!;
                    if (elementType.IsArray)
                    {
                        type = elementType;
                        continue;
                    }

                    break;
                }
            }
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {
            var fullName = type.GetGenericTypeDefinition().FullName;
            ReadOnlySpan<char> genericDefinitionFullName = fullName != null ? fullName.AsSpan() : ReadOnlySpan<char>.Empty;
            var genericArgs = type.GenericTypeArguments;

            //Nullable
            if (genericDefinitionFullName == "System.Nullable`1")
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (genericDefinitionFullName.StartsWith("System.ValueTuple`"))
            {
                sb.Append('(');
                AppendParamTypes(sb, genericArgs);
                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');

            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(',').Append(' ');
                }

                AppendType(sb, genericArgs[^1]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return type.FullName switch
            {
                "System.SByte" => "sbyte",
                "System.Byte" => "byte",
                "System.Int16" => "short",
                "System.UInt16" => "ushort",
                "System.Int32" => "int",
                "System.UInt32" => "uint",
                "System.Int64" => "long",
                "System.UInt64" => "ulong",
                "System.IntPtr" => "nint",
                "System.UIntPtr" => "nuint",
                "System.Single" => "float",
                "System.Double" => "double",
                "System.Decimal" => "decimal",
                "System.Boolean" => "bool",
                "System.Char" => "char",
                "System.String" => "string",
                "System.Object" => "object",
                _ => type.Name
            };
        }
    }

    [ThreadStatic] private static StringBuilder _stringBuilder4;

    private static readonly HashSet<Type> _tupleTypes = new HashSet<Type>()
    {
        // ValueTuple with only one element should be treated as normal generic type.
        //typeof(ValueTuple<>),
        typeof(ValueTuple<,>),
        typeof(ValueTuple<,,>),
        typeof(ValueTuple<,,,>),
        typeof(ValueTuple<,,,,>),
        typeof(ValueTuple<,,,,,>),
        typeof(ValueTuple<,,,,,,>),
        typeof(ValueTuple<,,,,,,,>),
    };

    private static readonly Dictionary<Type, string> _builtinTypeNameDict = new()
    {
        { typeof(sbyte), "sbyte" },
        { typeof(byte), "byte" },
        { typeof(short), "short" },
        { typeof(ushort), "ushort" },
        { typeof(int), "int" },
        { typeof(uint), "uint" },
        { typeof(long), "long" },
        { typeof(ulong), "ulong" },
        { typeof(nint), "nint" },
        { typeof(nuint), "nuint" },
        { typeof(float), "float" },
        { typeof(double), "double" },
        { typeof(decimal), "decimal" },
        { typeof(bool), "bool" },
        { typeof(char), "char" },
        { typeof(string), "string" },
        { typeof(object), "object" },
    };


    public static string ConstructTypeName_JSDY_OPT4(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder4 ??= new StringBuilder(256);
        var sb = _stringBuilder4;
        AppendType(sb, type);
        var result = sb.ToString();
        _stringBuilder4.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
            }
            else if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
            }
            else
            {
                sb.Append(GetSimpleTypeName(type));
            }
        }

        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element
            var elementType = type.GetElementType()!;
            while (elementType.IsArray)
            {
                elementType = elementType.GetElementType()!;
            }

            AppendType(sb, elementType);
            //append brackets
            AppendArrayRecursive(sb, type);

            static void AppendArrayRecursive(StringBuilder sb, Type type)
            {
                while (true)
                {
                    //append bracket with rank
                    var rank = type.GetArrayRank();
                    sb.Append('[');
                    sb.Append(',', rank - 1);
                    sb.Append(']');
                    //recursive call
                    var elementType = type.GetElementType()!;
                    if (elementType.IsArray)
                    {
                        type = elementType;
                        continue;
                    }

                    break;
                }
            }
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {

            var genericArgs = type.GenericTypeArguments;
            var genericDefinition = type.GetGenericTypeDefinition();
            //Nullable
            if (genericDefinition == typeof(Nullable<>))
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (_tupleTypes.Contains(genericDefinition))
            {
                sb.Append('(');
                while (true)
                {
                    // We assume that ValueTuple has 1~8 elements.
                    // And the 8th element (TRest) is always another ValueTuple.

                    // This is a hard coded tuple element length check.
                    if (genericArgs.Length != 8)
                    {
                        AppendParamTypes(sb, genericArgs);
                        break;
                    }
                    else
                    {
                        AppendParamTypes(sb, genericArgs.AsSpan(0, 7));
                        sb.Append(", ");

                        // TRest should be a ValueTuple!
                        var nextTuple = genericArgs[7];

                        genericArgs = nextTuple.GenericTypeArguments;
                    }
                }

                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');

            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(", ");
                }

                AppendType(sb, genericArgs[n]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return _builtinTypeNameDict.TryGetValue(type, out var name) ? name : type.Name;
        }
    }
    [ThreadStatic] private static StringBuilder _stringBuilder5;
    public static string ConstructTypeName_JSDY_OPT5(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder5 ??= new StringBuilder(256);
        var sb = _stringBuilder5;
        AppendType(sb, type);
        var result = sb.ToString();
        sb.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
            }else
            if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
            }
            else
            {
                sb.Append(GetSimpleTypeName(type));
            }
         
        }

        static Type GetRootElementType(Type type)
        {

            var elementType = type;
            while (true)
            {
                if (!elementType!.IsArray)
                {
                    break;
                }
                elementType = elementType.GetElementType()!;
            }

            return elementType;
        }

        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element

            var elementType = GetRootElementType(type);


            AppendType(sb, elementType);

            //append brackets
            AppendArrayRecursive(sb, type);

            static void AppendArrayRecursive(StringBuilder sb, Type type)
            {
                while (true)
                {
                    if (!type!.IsArray)
                    {
                        return;
                    }
                    //append bracket with rank
                    var rank = type.GetArrayRank();
                    sb.Append('[');
                    sb.Append(',', rank- 1);
                    sb.Append(']');
                    //recursive call
                    type = type.GetElementType();
                }
            }
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {
            var genericArgs = type.GenericTypeArguments;
      
            var genericDefinition = type.GetGenericTypeDefinition();
            //Nullable
            if (genericDefinition == typeof(Nullable<>))
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (_tupleTypes.Contains(genericDefinition))
            {
                sb.Append('(');
                while (true)
                {
                    if (genericArgs.Length != 8)
                    {
                        AppendParamTypes(sb, genericArgs);
                        break;
                    }
                    // We assume that ValueTuple has 1~8 elements.
                    AppendParamTypes(sb, genericArgs.AsSpan(0, 7));
                    sb.Append(", ");

                    // TRest should be a ValueTuple!
                    genericArgs = genericArgs[7].GenericTypeArguments;
                }


                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');
            return;


            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(", ");
                }

                AppendType(sb, genericArgs[n]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return _builtinTypeNameDict.TryGetValue(type, out var name) ? name : type.Name;
        }
    }
    [ThreadStatic] private static StringBuilder _stringBuilder6;
    public static string ConstructTypeName_JSDY_OPT6(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder6 ??= new StringBuilder(256);
        var sb = _stringBuilder6;
        AppendType(sb, type);
        var result = sb.ToString();
        sb.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
                return;
            }
            if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
                return;
            }
            sb.Append(GetSimpleTypeName(type));
        }

        static Type GetRootElementType(Type type)
        {
            return type!.IsArray ? GetRootElementType(type.GetElementType()) : type;
        }


        static void AppendArray(StringBuilder sb, Type type)
        {
            var elementType = GetRootElementType(type);


            AppendType(sb, elementType);

            //append brackets
            AppendArrayRecursive(sb, type);

            static void AppendArrayRecursive(StringBuilder sb, Type type)
            {
                if (!type.IsArray)
                {
                    return;
                }
                sb.Append('[');
                sb.Append(',', type.GetArrayRank() - 1);
                sb.Append(']');
                //recursive call
                AppendArrayRecursive(sb, type.GetElementType());
            }

        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {

            var genericArgs = type.GenericTypeArguments;
            var genericDefinition = type.GetGenericTypeDefinition();
            //Nullable
            if (genericDefinition == typeof(Nullable<>))
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (_tupleTypes.Contains(genericDefinition))
            {
                sb.Append('(');
                AppendTuple(sb, ref genericArgs);

                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');
            return;

            static void AppendTuple(StringBuilder sb, ref Type[] genericArgs)
            {
                if (genericArgs.Length != 8)
                {
                    AppendParamTypes(sb, genericArgs);
                    return;
                }
                AppendParamTypes(sb, genericArgs.AsSpan(0, 7));
                sb.Append(", ");
                genericArgs = genericArgs[7].GenericTypeArguments;
                AppendTuple(sb, ref genericArgs);
            }

            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(", ");
                }

                AppendType(sb, genericArgs[n]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return _builtinTypeNameDict.TryGetValue(type, out var name) ? name : type.Name;
        }
    }

    [ThreadStatic] private static StringBuilder _stringBuilder7;
    [ThreadStatic] private static StringBuilder _stringBuilderBrackets7;
    public static string ConstructTypeName_JSDY_OPT7(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder7 ??= new StringBuilder(256);
        _stringBuilderBrackets7 ??= new StringBuilder(64);
        var sb = _stringBuilder7;
        AppendType(sb, type);
        var result = sb.ToString();
        sb.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
                return;
            }
            if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
                return;
            }
            sb.Append(GetSimpleTypeName(type));
        }


        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element
            var elementType = type;
            var sbBrackets = _stringBuilderBrackets7;
            while (true)
            {
                if (!elementType!.IsArray)
                {
                    AppendType(sb, elementType);
                    break;
                }
                sbBrackets.Append('[');
                sbBrackets.Append(',', elementType.GetArrayRank() - 1);
                sbBrackets.Append(']');
                elementType = elementType.GetElementType();
            }

            //append brackets
            sb.Append(sbBrackets);
            sbBrackets.Clear();
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {

            var genericArgs = type.GenericTypeArguments;
            var genericDefinition = type.GetGenericTypeDefinition();
            //Nullable
            if (genericDefinition == typeof(Nullable<>))
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (_tupleTypes.Contains(genericDefinition))
            {
                sb.Append('(');
                while (true)
                {
                    if (genericArgs.Length != 8)
                    {
                        AppendParamTypes(sb, genericArgs);
                        break;
                    }
                    AppendParamTypes(sb, genericArgs.AsSpan(0, 7));
                    sb.Append(", ");

                    // TRest should be a ValueTuple!
                    genericArgs = genericArgs[7].GenericTypeArguments;
                }

                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');
            return;


            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(", ");
                }

                AppendType(sb, genericArgs[n]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return _builtinTypeNameDict.TryGetValue(type, out var name) ? name : type.Name;
        }
    }

    [ThreadStatic] private static StringBuilder _stringBuilder8;
    [ThreadStatic] private static List<int> _listRanks8;
    public static string ConstructTypeName_JSDY_OPT8(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder8 ??= new StringBuilder(256);
        _listRanks8 ??= new List<int>(64);
        var sb = _stringBuilder8;
        AppendType(sb, type);
        var result = sb.ToString();
        sb.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
                return;
            }
            if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
                return;
            }
            sb.Append(GetSimpleTypeName(type));
        }



        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element
            var elementType = type;
            var listRanks = _listRanks8;
            while (true)
            {
                if (!elementType!.IsArray)
                {
                    AppendType(sb, elementType);
                    break;
                }
                listRanks.Add(elementType.GetArrayRank() - 1);
                elementType = elementType.GetElementType();
            }



            //append brackets
            foreach (var rank in listRanks)
            {
                sb.Append('[');
                sb.Append(',', rank);
                sb.Append(']');
            }
            listRanks.Clear();
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {

            var genericArgs = type.GenericTypeArguments;
            var genericDefinition = type.GetGenericTypeDefinition();
            //Nullable
            if (genericDefinition == typeof(Nullable<>))
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (_tupleTypes.Contains(genericDefinition))
            {
                sb.Append('(');
                while (true)
                {
                    if (genericArgs.Length != 8)
                    {
                        AppendParamTypes(sb, genericArgs);
                        break;
                    }
                    AppendParamTypes(sb, genericArgs.AsSpan(0, 7));
                    sb.Append(", ");

                    // TRest should be a ValueTuple!
                    genericArgs = genericArgs[7].GenericTypeArguments;
                }


                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');
            return;


            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(", ");
                }

                AppendType(sb, genericArgs[n]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return _builtinTypeNameDict.TryGetValue(type, out var name) ? name : type.Name;
        }
    }

    [ThreadStatic] private static StringBuilder _stringBuilder9;
    [ThreadStatic] private static List<int> _listRanks9;
    public static string ConstructTypeName_JSDY_OPT9(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder9 ??= new StringBuilder(256);
        _listRanks9 ??= new List<int>(64);
        var sb = _stringBuilder9;
        AppendType(sb, type);
        var result = sb.ToString();
        sb.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
                return;
            }
            if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
                return;
            }
            sb.Append(GetSimpleTypeName(type));
        }



        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element
            var elementType = type;
            var listRanks = _listRanks9;
            while (true)
            {
                if (!elementType!.IsArray)
                {
                    AppendType(sb, elementType);
                    break;
                }
                listRanks.Add(elementType.GetArrayRank() - 1);

                elementType = elementType.GetElementType();
            }


            //append brackets
            var count = listRanks.Count;
            for (var i = 0; i < count; i++)
            {
                sb.Append('[');
                sb.Append(',', listRanks[i]);
                sb.Append(']');
            }
            listRanks.Clear();
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {

            var genericArgs = type.GenericTypeArguments;
            var genericDefinition = type.GetGenericTypeDefinition();
            //Nullable
            if (genericDefinition == typeof(Nullable<>))
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (_tupleTypes.Contains(genericDefinition))
            {
                sb.Append('(');
                while (true)
                {
                    if (genericArgs.Length != 8)
                    {
                        AppendParamTypes(sb, genericArgs);
                        break;
                    }
                    AppendParamTypes(sb, genericArgs.AsSpan(0, 7));
                    sb.Append(", ");

                    // TRest should be a ValueTuple!
                    genericArgs = genericArgs[7].GenericTypeArguments;
                }

                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');
            return;


            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(", ");
                }

                AppendType(sb, genericArgs[n]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return _builtinTypeNameDict.TryGetValue(type, out var name) ? name : type.Name;
        }
    }

    [ThreadStatic] private static StringBuilder _stringBuilder5_2;
    public static string ConstructTypeName_JSDY_OPT5_2(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder5_2 ??= new StringBuilder(256);
        var sb = _stringBuilder5_2;
        AppendType(sb, type);
        var result = sb.ToString();
        sb.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
                return;
            }
            if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
                return;
            }
            sb.Append(GetSimpleTypeName(type));
        }

        static Type GetRootElementType(Type type)
        {

            var elementType = type;
            while (elementType!.IsArray)
            {
                elementType = elementType.GetElementType();
            }

            return elementType;
        }

        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element

            var elementType = GetRootElementType(type);


            AppendType(sb, elementType);

            //append brackets
            AppendArrayRecursive(sb, type);

            static void AppendArrayRecursive(StringBuilder sb, Type type)
            {
                while (type!.IsArray)
                {

                    //append bracket with rank
                    sb.Append('[');
                    sb.Append(',', type.GetArrayRank() - 1);
                    sb.Append(']');
                    //recursive call
                    type = type.GetElementType();
                }
            }
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {

            var genericArgs = type.GenericTypeArguments;
            var genericDefinition = type.GetGenericTypeDefinition();
            //Nullable
            if (genericDefinition == typeof(Nullable<>))
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (_tupleTypes.Contains(genericDefinition))
            {
                sb.Append('(');
                while (genericArgs.Length == 8)
                {
                    // We assume that ValueTuple has 1~8 elements.
                    AppendParamTypes(sb, genericArgs.AsSpan(0, 7));
                    sb.Append(", ");

                    // TRest should be a ValueTuple!
                    genericArgs = genericArgs[7].GenericTypeArguments;
                }

                AppendParamTypes(sb, genericArgs);
                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');
            return;


            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(", ");
                }

                AppendType(sb, genericArgs[n]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return _builtinTypeNameDict.TryGetValue(type, out var name) ? name : type.Name;
        }
    }


    [ThreadStatic] private static StringBuilder _stringBuilder7_2;
    [ThreadStatic] private static StringBuilder _stringBuilderBrackets7_2;
    public static string ConstructTypeName_JSDY_OPT7_2(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder7_2 ??= new StringBuilder(256);
        _stringBuilderBrackets7_2 ??= new StringBuilder(64);
        var sb = _stringBuilder7_2;
        AppendType(sb, type);
        var result = sb.ToString();
        sb.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
                return;
            }
            if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
                return;
            }
            sb.Append(GetSimpleTypeName(type));
        }


        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element
            var sbBrackets = _stringBuilderBrackets7_2;
            var elementType = type;
            while (elementType!.IsArray)
            {
                sbBrackets.Append('[');
                sbBrackets.Append(',', elementType.GetArrayRank() - 1);
                sbBrackets.Append(']');
                elementType = elementType.GetElementType();
            }
            AppendType(sb, elementType);
            //append brackets
            sb.Append(sbBrackets);
            sbBrackets.Clear();
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {

            var genericArgs = type.GenericTypeArguments;
            var genericDefinition = type.GetGenericTypeDefinition();
            //Nullable
            if (genericDefinition == typeof(Nullable<>))
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (_tupleTypes.Contains(genericDefinition))
            {
                sb.Append('(');
                while (genericArgs.Length == 8)
                {
                    AppendParamTypes(sb, genericArgs.AsSpan(0, 7));
                    sb.Append(", ");

                    // TRest should be a ValueTuple!
                    genericArgs = genericArgs[7].GenericTypeArguments;
                }
                AppendParamTypes(sb, genericArgs);
                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');
            return;


            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(", ");
                }

                AppendType(sb, genericArgs[n]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return _builtinTypeNameDict.TryGetValue(type, out var name) ? name : type.Name;
        }
    }

    [ThreadStatic] private static StringBuilder _stringBuilder8_2;
    [ThreadStatic] private static List<int> _listRanks8_2;
    public static string ConstructTypeName_JSDY_OPT8_2(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder8_2 ??= new StringBuilder(256);
        _listRanks8_2 ??= new List<int>(64);
        var sb = _stringBuilder8_2;
        AppendType(sb, type);
        var result = sb.ToString();
        sb.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
                return;
            }
            if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
                return;
            }
            sb.Append(GetSimpleTypeName(type));
        }



        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element
            var listRanks = _listRanks8_2;
            var elementType = type;
            while (elementType!.IsArray)
            {
                listRanks.Add(elementType.GetArrayRank() - 1);
                elementType = elementType.GetElementType();
            }
            AppendType(sb, elementType);


            //append brackets
            foreach (var rank in listRanks)
            {
                sb.Append('[');
                sb.Append(',', rank);
                sb.Append(']');
            }
            listRanks.Clear();
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {

            var genericArgs = type.GenericTypeArguments;
            var genericDefinition = type.GetGenericTypeDefinition();
            //Nullable
            if (genericDefinition == typeof(Nullable<>))
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (_tupleTypes.Contains(genericDefinition))
            {
                sb.Append('(');
                while (genericArgs.Length == 8)
                {

                    AppendParamTypes(sb, genericArgs.AsSpan(0, 7));
                    sb.Append(", ");

                    // TRest should be a ValueTuple!
                    genericArgs = genericArgs[7].GenericTypeArguments;
                }

                AppendParamTypes(sb, genericArgs);
                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');
            return;


            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(", ");
                }

                AppendType(sb, genericArgs[n]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return _builtinTypeNameDict.TryGetValue(type, out var name) ? name : type.Name;
        }
    }

    [ThreadStatic] private static StringBuilder _stringBuilder9_2;
    [ThreadStatic] private static List<int> _listRanks9_2;
    public static string ConstructTypeName_JSDY_OPT9_2(Type type)
    {
        if (!type.IsArray && !type.IsGenericType)
        {
            return GetSimpleTypeName(type);
        }

        _stringBuilder9_2 ??= new StringBuilder(256);
        _listRanks9_2 ??= new List<int>(64);
        var sb = _stringBuilder9_2;
        AppendType(sb, type);
        var result = sb.ToString();
        sb.Clear();
        return result;

        static void AppendType(StringBuilder sb, Type type)
        {
            if (type.IsArray)
            {
                AppendArray(sb, type);
                return;
            }
            if (type.IsGenericType)
            {
                AppendGeneric(sb, type);
                return;
            }
            sb.Append(GetSimpleTypeName(type));
        }



        static void AppendArray(StringBuilder sb, Type type)
        {
            //append inner most non-array element
            var listRanks = _listRanks9_2;
            var elementType = type;
            while (true)
            {
                if (!elementType!.IsArray)
                {
                    AppendType(sb, elementType);
                    break;
                }
                listRanks.Add(elementType.GetArrayRank() - 1);

                elementType = elementType.GetElementType();
            }


            //append brackets
            var count = listRanks.Count;
            for (var i = 0; i < count; i++)
            {
                sb.Append('[');
                sb.Append(',', listRanks[i]);
                sb.Append(']');
            }
            listRanks.Clear();
        }

        static void AppendGeneric(StringBuilder sb, Type type)
        {

            var genericArgs = type.GenericTypeArguments;
            var genericDefinition = type.GetGenericTypeDefinition();
            //Nullable
            if (genericDefinition == typeof(Nullable<>))
            {
                AppendType(sb, genericArgs[0]);
                sb.Append('?');
                return;
            }

            //ValueTuple
            if (_tupleTypes.Contains(genericDefinition))
            {
                sb.Append('(');
                while (genericArgs.Length == 8)
                {
                    AppendParamTypes(sb, genericArgs.AsSpan(0, 7));
                    sb.Append(", ");

                    // TRest should be a ValueTuple!
                    genericArgs = genericArgs[7].GenericTypeArguments;
                }
                AppendParamTypes(sb, genericArgs);
                sb.Append(')');
                return;
            }

            //normal generic
            var typeName = type.Name.AsSpan();
            sb.Append(typeName[..typeName.LastIndexOf('`')]);
            sb.Append('<');
            AppendParamTypes(sb, genericArgs);
            sb.Append('>');
            return;


            static void AppendParamTypes(StringBuilder sb, ReadOnlySpan<Type> genericArgs)
            {
                var n = genericArgs.Length - 1;
                for (int i = 0; i < n; i += 1)
                {
                    AppendType(sb, genericArgs[i]);
                    sb.Append(", ");
                }

                AppendType(sb, genericArgs[n]);
            }
        }

        static string GetSimpleTypeName(Type type)
        {
            return _builtinTypeNameDict.TryGetValue(type, out var name) ? name : type.Name;
        }
    }
}