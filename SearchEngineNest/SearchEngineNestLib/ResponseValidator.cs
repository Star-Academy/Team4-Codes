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

        public void CheckApiCall()
        {
            if(Response.ApiCall.OriginalException != null)
            {
                if(Response.ApiCall.HttpStatusCode == 404){
                    Console.WriteLine("Index not found");
                }
                else if (Response.ApiCall.HttpStatusCode == 403)
                {
                    Console.WriteLine("Index is read only");
                }
                else if (Response.ApiCall.HttpStatusCode == 409)
                {
                    Console.WriteLine("Conflict in indices");
                }
                else if (Response.ApiCall.HttpStatusCode == 400)
                {
                    Console.WriteLine("Bad Request");
                }
                throw  Response.ApiCall.OriginalException;
            }
        }

        public void CheckClientExceptions()
        {
            if(Response.OriginalException != null)
            {
                throw Response.OriginalException;
            }
        }

        public void Evaluate()
        {
            if (!(Response.IsValid && Response.ApiCall.HttpStatusCode >= 200 && Response.ApiCall.HttpStatusCode < 300))
            {
                CheckApiCall();
                CheckClientExceptions();
            }
        }
    }
}