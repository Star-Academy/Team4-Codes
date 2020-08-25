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
        public void Evaluate()
        {
            if (Response.IsValid && Response.ApiCall.HttpStatusCode >= 200 && Response.ApiCall.HttpStatusCode < 300)
            {
                Console.WriteLine("slm bozqale hame chi okaye");
            }

            else
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
    }
}