using Dapper;
using System.Text;

namespace Quotation.Persistence.Database
{
    internal class UpsertBuilder(string tableName, string[] primaryKeys)
    {
        private readonly StringBuilder _insertHeader = new StringBuilder();
        private readonly StringBuilder _insertBody = new StringBuilder();
        private readonly StringBuilder _updateBody = new StringBuilder();
        public readonly DynamicParameters Parameters = new();

        public UpsertBuilder InsertField(string fieldName, object fieldValue)
        {
            if (_insertHeader.Length > 0 && _insertBody.Length > 0 && _updateBody.Length > 0)
            {
                _insertHeader.Append(',');
                _insertBody.Append(',');
                _updateBody.Append(',');
            }
            _insertHeader.Append(fieldName);
            _insertBody.Append($"@{fieldName}");
            _updateBody.Append(fieldName).Append(" = ").Append($"@{fieldName}");
            Parameters.Add(fieldName, fieldValue);
            return this;
        }

        public override string ToString() =>
            $"INSERT INTO {tableName} ({_insertHeader.ToString()}) VALUES ({_insertBody.ToString()}) ON CONFLICT ({string.Join(',', primaryKeys)}) DO UPDATE SET {_updateBody.ToString()}";
    }
}
