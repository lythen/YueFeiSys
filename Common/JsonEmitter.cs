using System;
using System.Data;
using System.Web;
using System.Text;
using System.IO;
using System.Collections;
using System.Reflection;
using System.Globalization;
namespace Lythen.Common
{
    /// <summary>
    ///JsonEmitter 的摘要说明
    /// </summary>
    public static class JsonEmitter
    {
        public static void WriteResult(Stream stream, object val, string error)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                WriteValueAndError(sb, val, error);
            }
            catch (Exception ex)
            {
                // If an exception was thrown while formatting the
                // result value, we need to discard whatever was
                // written and start over with nothing but the error
                // message.
                sb.Length = 0;
                WriteValueAndError(sb, null, ex.Message);
            }
            byte[] buffer = Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteResult(HttpResponse resp, object val, string error)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                WriteValueAndError(sb, val, error);
            }
            catch (Exception ex)
            {
                // If an exception was thrown while formatting the
                // result value, we need to discard whatever was
                // written and start over with nothing but the error
                // message.
                sb.Length = 0;
                WriteValueAndError(sb, null, ex.Message);
            }
            resp.Write(sb.ToString());
        }

        public static string WriteResult(object val, string error)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                WriteValueAndError(sb, val, error);
            }
            catch (Exception ex)
            {
                // If an exception was thrown while formatting the
                // result value, we need to discard whatever was
                // written and start over with nothing but the error
                // message.
                sb.Length = 0;
                WriteValueAndError(sb, null, ex.Message);
            }
            return sb.ToString().Substring(1, sb.Length - 2);
        }

        static void WriteValueAndError(StringBuilder sb, object val, string error)
        {
            //sb.Append("{\"value\":");
            WriteValue(sb, val);
            //sb.Append(",\"error\":");
            //WriteValue(sb, error);
            //sb.Append("}");
        }

        static void WriteValue(StringBuilder sb, object val)
        {
            if (val == null || val == System.DBNull.Value)
            {
                sb.Append("null");
            }
            else if (val is string || val is Guid)
            {
                WriteString(sb, val.ToString());
            }
            else if (val is bool)
            {
                sb.Append(val.ToString().ToLower());
            }
            else if (val is double ||
              val is float ||
              val is long ||
              val is int ||
              val is short ||
              val is byte ||
              val is decimal)
            {
                sb.Append(val);
            }
            else if (val.GetType().IsEnum)
            {
                sb.Append((int)val);
            }
            else if (val is DateTime)
            {
                sb.Append("new Date(\"");
                sb.Append(((DateTime)val).ToString("MMMM, d yyyy HH:mm:ss", new CultureInfo("en-US", false).DateTimeFormat));
                sb.Append("\")");
            }
            else if (val is DataSet)
            {
                WriteDataSet(sb, val as DataSet);
            }
            else if (val is DataTable)
            {
                WriteDataTable(sb, val as DataTable);
            }
            else if (val is DataRow)
            {
                WriteDataRow(sb, val as DataRow);
            }
            else if (val is Hashtable)
            {
                WriteHashtable(sb, val as Hashtable);
            }
            else if (val is IEnumerable)
            {
                WriteEnumerable(sb, val as IEnumerable);
            }
            else
            {
                WriteObject(sb, val);
            }
        }

        static void WriteString(StringBuilder sb, string s)
        {
            sb.Append("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        int i = (int)c;
                        if (i < 32 || i > 127)
                        {
                            sb.AppendFormat("\\u{0:X04}", i);
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            sb.Append("\"");
        }

        static void WriteDataSet(StringBuilder sb, DataSet ds)
        {
            sb.Append("{\"Tables\":{");
            foreach (DataTable table in ds.Tables)
            {
                sb.AppendFormat("\"{0}\":", table.TableName);
                WriteDataTable(sb, table);
                sb.Append(",");
            }
            // Remove the trailing comma.
            if (ds.Tables.Count > 0)
            {
                --sb.Length;
            }
            sb.Append("}}");
        }

        static void WriteDataTable(StringBuilder sb, DataTable table)
        {
            //sb.Append("{\"rows\":[");
            sb.Append("[");
            foreach (DataRow row in table.Rows)
            {
                WriteDataRow(sb, row);
                sb.Append(",");
            }
            // Remove the trailing comma.
            if (table.Rows.Count > 0)
            {
                --sb.Length;
            }
            sb.Append("]");
        }

        static void WriteDataRow(StringBuilder sb, DataRow row)
        {
            sb.Append("{");
            foreach (DataColumn column in row.Table.Columns)
            {
                sb.AppendFormat("\"{0}\":", column.ColumnName);
                WriteValue(sb, row[column]);
                sb.Append(",");
            }
            // Remove the trailing comma.
            if (row.Table.Columns.Count > 0)
            {
                --sb.Length;
            }
            sb.Append("}");
        }

        static void WriteHashtable(StringBuilder sb, Hashtable e)
        {
            bool hasItems = false;
            sb.Append("{");
            foreach (string key in e.Keys)
            {
                sb.AppendFormat("\"{0}\":", key.ToLower());
                WriteValue(sb, e[key]);
                sb.Append(",");
                hasItems = true;
            }
            // Remove the trailing comma.
            if (hasItems)
            {
                --sb.Length;
            }
            sb.Append("}");
        }

        static void WriteEnumerable(StringBuilder sb, IEnumerable e)
        {
            bool hasItems = false;
            sb.Append("[");
            foreach (object val in e)
            {
                WriteValue(sb, val);
                sb.Append(",");
                hasItems = true;
            }
            // Remove the trailing comma.
            if (hasItems)
            {
                --sb.Length;
            }
            sb.Append("]");
        }

        static void WriteObject(StringBuilder sb, object o)
        {
            MemberInfo[] members = o.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public);
            sb.Append("{");
            bool hasMembers = false;
            foreach (MemberInfo member in members)
            {
                bool hasValue = false;
                object val = null;
                if ((member.MemberType & MemberTypes.Field) == MemberTypes.Field)
                {
                    FieldInfo field = (FieldInfo)member;
                    val = field.GetValue(o);
                    hasValue = true;
                }
                else if ((member.MemberType & MemberTypes.Property) == MemberTypes.Property)
                {
                    PropertyInfo property = (PropertyInfo)member;
                    if (property.CanRead && property.GetIndexParameters().Length == 0)
                    {
                        val = property.GetValue(o, null);
                        hasValue = true;
                    }
                }
                if (hasValue)
                {
                    sb.Append("\"");
                    sb.Append(member.Name);
                    sb.Append("\":");
                    WriteValue(sb, val);
                    sb.Append(",");
                    hasMembers = true;
                }
            }
            if (hasMembers)
            {
                --sb.Length;
            }
            sb.Append("}");
        }
    }
}