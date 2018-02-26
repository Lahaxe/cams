using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace cams.model.QueryParameters.Fields
{
    /// <summary>
    /// Base class for fielding parameters.
    /// </summary>
    public class FieldingParametersBase : Collection<Dictionary<string, FieldingVisibility>>
    {
    }
}