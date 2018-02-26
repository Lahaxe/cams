using cams.model.QueryParameters.Filters;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace cams.MongoDBConnector.Sessions
{
    internal static class FilterExtensions
    {
        public static FilterDefinition<BsonDocument> ToFilterDefinition(this Filter filter)
        {
            if (filter == null)
            {
                return null;
            }

            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> result = null;

            switch (filter.Operator)
            {
                case FilterOperator.And:
                    {
                        result = builder.And(filter.Filters.ToFilterDefinitionList());
                        break;
                    }
                case FilterOperator.Or:
                    {
                        result = builder.Or(filter.Filters.ToFilterDefinitionList());
                        break;
                    }
                case FilterOperator.Equal:
                    {
                        result = builder.Eq(filter.Attribute, filter.Value);
                        break;
                    }
                case FilterOperator.NotEqual:
                    {
                        result = builder.Not(builder.Eq(filter.Attribute, filter.Value));
                        break;
                    }
                case FilterOperator.GreaterOrEqual:
                    {
                        result = builder.Gte(filter.Attribute, filter.Value);
                        break;
                    }
                case FilterOperator.GreaterThan:
                    {
                        result = builder.Gt(filter.Attribute, filter.Value);
                        break;
                    }
                case FilterOperator.LessOrEqual:
                    {
                        result = builder.Lte(filter.Attribute, filter.Value);
                        break;
                    }
                case FilterOperator.LessThan:
                    {
                        result = builder.Lt(filter.Attribute, filter.Value);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return result;
        }

        public static IEnumerable<FilterDefinition<BsonDocument>> ToFilterDefinitionList(this ICollection<Filter> filters)
        {
            if (filters == null)
            {
                return null;
            }

            var result = new List<FilterDefinition<BsonDocument>>();

            foreach (var filter in filters)
            {
                result.Add(filter.ToFilterDefinition());
            }

            return result;
        }
    }
}