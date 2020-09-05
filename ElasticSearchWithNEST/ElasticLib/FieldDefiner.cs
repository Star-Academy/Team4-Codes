using System;
using Nest;
using ElasticLib.Models;

namespace ElasticLib
{
    public static class FieldDefiner
    {

        private const string TextFieldName = "ngram";
        private const string KeywordFieldName = "raw";
        private const string MyAnalyzer = "myNgramAnalyzer";
        
        public static PropertiesDescriptor<Person> AddAboutFieldMapping(this PropertiesDescriptor<Person> propertiesDescriptor)
        {
            return propertiesDescriptor
                .Text(t => t
                    .Name(n => n.About)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name(TextFieldName)
                            .Analyzer(MyAnalyzer)
                        )
                    )
                );
        }

        public static PropertiesDescriptor<Person> AddAgeFieldMapping(this PropertiesDescriptor<Person> propertiesDescriptor)
        {
            return propertiesDescriptor
                .Number(t => t
                    .Name(n => n.Age)
                );
        }

        public static PropertiesDescriptor<Person> AddEyeColorFieldMapping(this PropertiesDescriptor<Person> propertiesDescriptor)
        {
            return propertiesDescriptor
                .Keyword(d => d
                    .Name(p => p.EyeColor)
                );
        }

        public static PropertiesDescriptor<Person> AddNameFieldMapping(this PropertiesDescriptor<Person> propertiesDescriptor)
        {
            return propertiesDescriptor
                .Text(t => t
                    .Name(n => n.Name)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name(TextFieldName)
                            .Analyzer(MyAnalyzer)
                        )
                        .Keyword(ky => ky
                            .Name(KeywordFieldName)
                        )
                    )
                );
        }

        public static PropertiesDescriptor<Person> AddGenderFieldMapping(this PropertiesDescriptor<Person> propertiesDescriptor)
        {
            return propertiesDescriptor
                .Keyword(d => d
                    .Name(p => p.Gender)
                );
        }

        public static PropertiesDescriptor<Person> AddCompanyFieldMapping(this PropertiesDescriptor<Person> propertiesDescriptor)
        {
            return propertiesDescriptor
                .Text(t => t
                    .Name(n => n.Company)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name(TextFieldName)
                            .Analyzer(MyAnalyzer)
                        )
                        .Keyword(ky => ky
                            .Name(KeywordFieldName)
                        )
                    )
                );
        }

        public static PropertiesDescriptor<Person> AddEmailFieldMapping(this PropertiesDescriptor<Person> propertiesDescriptor)
        {
            return propertiesDescriptor
                .Text(d => d
                    .Name(p => p.Email)
                );
        }

        public static PropertiesDescriptor<Person> AddPhoneFieldMapping(this PropertiesDescriptor<Person> propertiesDescriptor)
        {
            return propertiesDescriptor
                .Keyword(d => d
                    .Name(p => p.Phone)
                );
        }

        public static PropertiesDescriptor<Person> AddAddressFieldMapping(this PropertiesDescriptor<Person> propertiesDescriptor)
        {
            return propertiesDescriptor
                .Text(t => t
                    .Name(n => n.Address)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name(TextFieldName)
                            .Analyzer(MyAnalyzer)
                        )
                    )
                );
        }

        public static PropertiesDescriptor<Person> AddRegistrationDateFieldMapping(this PropertiesDescriptor<Person> propertiesDescriptor)
        {
            return propertiesDescriptor
                .Text(d => d
                    .Name(p => p.RegisterationDate)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name(TextFieldName)
                            .Analyzer(MyAnalyzer)
                        )
                    )
                );
        }

        public static PropertiesDescriptor<Person> AddLocationFieldMapping(this PropertiesDescriptor<Person> propertiesDescriptor)
        {
            return propertiesDescriptor
                .GeoPoint(t => t
                    .Name(n => n.Location));
        }
    }
}