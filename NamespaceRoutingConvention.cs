using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebApi2ToCore
{
    /// <summary>
    /// 名前空間を用いてコントローラのアクションを設定するためのクラスです。
    /// </summary>
    public class NamespaceRoutingConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                // NOTE ルート属性が存在している場合は、そちらを優先します。
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
