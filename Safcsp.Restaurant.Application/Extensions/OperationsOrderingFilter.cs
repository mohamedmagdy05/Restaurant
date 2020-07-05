using Microsoft.OpenApi.Models;
using Safcsp.Restaurant.Application.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Safcsp.Restaurant.Application.Extensions
{
    public class OperationsOrderingFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument openApiDoc, DocumentFilterContext context)
        {
            Dictionary<KeyValuePair<string, OpenApiPathItem>, int> paths = new Dictionary<KeyValuePair<string, OpenApiPathItem>, int>();
            foreach (var path in openApiDoc.Paths)
            {
                OperationOrderAttribute orderAttribute = context.ApiDescriptions.FirstOrDefault(x => x.RelativePath.Replace("/", string.Empty)
                    .Equals(path.Key.Replace("/", string.Empty), StringComparison.InvariantCultureIgnoreCase))?
                    .ActionDescriptor?.EndpointMetadata?.FirstOrDefault(x => x is OperationOrderAttribute) as OperationOrderAttribute;

                if (orderAttribute == null)
                    throw new ArgumentNullException("there is no order for operation " + path.Key);

                int order = orderAttribute.Order;
                paths.Add(path, order);
            }

            var orderedPaths = paths.OrderBy(x => x.Value).ToList();
            openApiDoc.Paths.Clear();
            orderedPaths.ForEach(x => openApiDoc.Paths.Add(x.Key.Key, x.Key.Value));
        }

    }
}
