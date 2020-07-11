using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace WebApi2ToCore
{
    public class CustomControllerActivator : IControllerActivator
    {
        public object Create(ControllerContext context)
        {
            Debug.WriteLine("This is CustomControllerActivator Create.");

            var type = context.ActionDescriptor.ControllerTypeInfo.AsType();
            return Activator.CreateInstance(type);
        }

        public void Release(ControllerContext context, object controller)
        {
            Debug.WriteLine("This is CustomControllerActivator Release.");
        }
    }
}
