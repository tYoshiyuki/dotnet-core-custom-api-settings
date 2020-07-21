using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebApi2ToCore
{
    public class NamespaceRoutingConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var hasAttributeRouteModels = controller.Selectors.Any(selector => selector.AttributeRouteModel != null);

                if (!hasAttributeRouteModels)
                {
                    if (controller.ControllerType.Namespace == null)
                    {
                        continue;
                    }

                    var template = controller.ControllerType.Namespace
                                       .Replace("WebApi2ToCore.Controllers", "")
                                       .Replace('.', '/') + "/[controller]/[action]";
                    Debug.WriteLine($"Template is {template}.");

                    controller.Selectors[0].AttributeRouteModel = new AttributeRouteModel
                    {
                        Template = template
                    };
                }
            }
        }
    }
}
