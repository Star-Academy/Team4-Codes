using System;
using Nest;

namespace SearchEngineNestLib
{
    public class ResponseValidator
    {
        private IResponse Response;
        public ResponseValidator(IResponse response)
        {
            this.Response = response;
        }
        public string Evaluate()
        {
            if (Response.IsValid)
            {
                return "slm bozqale hame chi okaye";
            }
            else
            {
                return Response.DebugInformation;
            }
        }
    }
}