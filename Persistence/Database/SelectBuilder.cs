using Dapper;
using System.Text;

namespace Quotation.Persistence.Database
{
    public class SelectBuilder
    {
        private readonly StringBuilder _query = new StringBuilder();
        public readonly DynamicParameters Parameters = new DynamicParameters();

        public SelectBuilder Select()
        {
            _query.Append("SELECT ");
            return this;
        }

        public SelectBuilder AddField(string table, string field, string? tableAlias = null)
        {
            if (_query.Length > 0)
                _query.Append(", ");
            _query.Append(table + ".")
                .Append(field);
            if (tableAlias is not null)
                _query.Append(" AS " + tableAlias);
            return this;
        }

        public SelectBuilder AddFrom(string table, string? tableAlias = null)
        {
            CheckEmptyQuery();
            _query.Append(" FROM ").Append(table);
            if (tableAlias is not null)
                _query.Append(" AS " + tableAlias);
            return this;
        }

        public SelectBuilder AddJoin(string join, string tableLeft, string fieldLeft, string tableRight, string fieldRight)
        {
            CheckEmptyQuery();
            _query.AppendLine()
                .Append(join).Append(" " + tableRight + " ON ")
                .Append(tableLeft + "." + fieldLeft + " = " + tableRight + "." + fieldRight);
            return this;
        }

        public SelectBuilder AddAnd()
        {
            CheckEmptyQuery();
            _query.Append(" AND ");
            return this;
        }

        public SelectBuilder AddOr()
        {
            CheckEmptyQuery();
            _query.Append(" OR ");
            return this;
        }

        public SelectBuilder AddValue(string alias, object value)
        {
            CheckEmptyQuery();
            _query.AppendLine($" {alias} = @{alias}");
            Parameters.Add(alias, value);
            return this;
        }

        public SelectBuilder StartIsolation()
        {
            _query.Append(" ( ");
            return this;
        }

        public SelectBuilder EndIsolation()
        {
            CheckEmptyQuery();
            _query.Append(" ) ");
            return this;
        }

        public SelectBuilder Insert(string table)
        {
            _query.Append("INSERT INTO ").Append(table);
            return this;
        }

        public SelectBuilder AllFields()
        {
            CheckEmptyQuery();
            _query.Append(" * ");
            return this;
        }

        public SelectBuilder AddWhere()
        {
            CheckEmptyQuery();
            _query.Append(" WHERE ");
            return this;
        }

        public override string ToString() => _query.ToString();

        private void CheckEmptyQuery()
        {
            if (_query.Length == 0)
                throw new Exception("empty query");
        }
    }
}
