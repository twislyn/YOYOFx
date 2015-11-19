﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinHost
{

    using System.IO;
    using YOYO.Owin;

    public class MyMiddleWareComponent : PipelineComponent
    {

        public override async Task Invoke(IDictionary<string, object> requestEnvironment, Func<IDictionary<string, object>, Task> next)
        {
            if (requestEnvironment[OwinConstants.Request.Path].ToString() == "/")
            {
                

                var response = requestEnvironment["owin.ResponseBody"] as Stream;
                var writer = new StreamWriter(response);
                
                    await writer.WriteAsync("<h1>Hello from My First Middleware</h1>");

                    await writer.WriteAsync("<h1>log before</h1>");



                    await next(requestEnvironment);



                    await writer.WriteAsync("<h1>log after</h1>");

                writer.Dispose();
            }
        }



    }
}