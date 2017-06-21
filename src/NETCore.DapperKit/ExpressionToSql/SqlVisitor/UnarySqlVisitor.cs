using NETCore.DapperKit.ExpressionToSql.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NETCore.DapperKit.ExpressionToSql.SqlVisitor
{
    public class UnarySqlVisitor : BaseSqlVisitor<UnaryExpression>
    {
        protected override ISqlBuilder Select(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }

        protected override ISqlBuilder Delete(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            //m=>!m.IsAmdin
            if (expression.NodeType == ExpressionType.Not && expression.Operand is MemberExpression && expression.Type == typeof(bool))
            {
                var memberExp = expression.Operand as MemberExpression;

                var columnName = memberExp.Member.Name;
                var sqlParamName = sqlBuilder.SetSqlParameter(0);

                sqlBuilder.AppendWhereSql($"{sqlBuilder._SqlFormater.Left}{columnName}{sqlBuilder._SqlFormater.Right} ");
                sqlBuilder.AppendWhereSql("= ");
                sqlBuilder.AppendWhereSql($"{sqlParamName} ");
            }
            //DateTime.Now
            else if (expression.NodeType == ExpressionType.Convert)
            {
                var value = GetExpreesionValue(expression);
                var sqlParamName = sqlBuilder.SetSqlParameter(value);
                sqlBuilder.AppendWhereSql($"{sqlParamName} ");
            }
            else
            {
                SqlVistorProvider.Delete(expression.Operand, sqlBuilder);
            }
            return sqlBuilder;
        }

        protected override ISqlBuilder Join(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }

        protected override ISqlBuilder Where(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }

        protected override ISqlBuilder GroupBy(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }

        protected override ISqlBuilder OrderBy(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }

        protected override ISqlBuilder ThenBy(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }
        protected override ISqlBuilder OrderByDescending(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }

        protected override ISqlBuilder ThenByDescending(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }

        protected override ISqlBuilder Max(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }

        protected override ISqlBuilder Min(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }

        protected override ISqlBuilder Avg(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }

        protected override ISqlBuilder Count(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }

        protected override ISqlBuilder Sum(UnaryExpression expression, ISqlBuilder sqlBuilder)
        {
            return sqlBuilder;
        }
    }
}
