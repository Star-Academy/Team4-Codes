using System;
using Nest;
using System.Collections.Generic;
using SearchEngineNestLib.Models;

namespace SearchEngineNestLib
{
    public class ResponseValidator
    {
        private IResponse Response;
        public ResponseValidator(IResponse response)
        {
            this.Response = response;
        }
        public void Evaluate()
        {
            if (Response.IsValid)
            {
                Console.WriteLine("slm bozqale hame chi okaye");
            }
            else
            {
                Console.WriteLine(Response.DebugInformation);
            }
        }
    }
}