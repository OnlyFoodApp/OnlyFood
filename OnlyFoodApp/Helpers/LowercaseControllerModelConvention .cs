using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace OnlyFoodApp.Helpers
{
    public class LowercaseControllerModelConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.ControllerName = controller.ControllerName.ToLowerInvariant();
        }
    }

}
