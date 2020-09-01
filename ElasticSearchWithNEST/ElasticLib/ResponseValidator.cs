using System;
using Nest;
using System.Collections.Generic;
using ElasticLib.Models;
using Elasticsearch.Net;

namespace ElasticLib
{
    public class ResponseValidator
    {
        private ISearchResponse<Person> Response;
        public ResponseValidator(ISearchResponse<Person> response){
            this.Response = response;
        }
        public void Evaluate(){
            if(Response.IsValid){
                Console.WriteLine("slm bozqale hame chi okaye");
            }
            else{
                Console.WriteLine(Response.DebugInformation);
            }
        }
    }
}