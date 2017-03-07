﻿using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.MvcCore.Mvc.Formatters
{
    public class CsvInputFormatter : InputFormatter
    {
        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var type = context.ModelType;
            var request = context.HttpContext.Request;
            MediaTypeHeaderValue requestContentType = null;
            MediaTypeHeaderValue.TryParse(request.ContentType, out requestContentType);


            var result = readStream(type, request.Body);
            return InputFormatterResult.SuccessAsync(result);
        }

        public override bool CanRead(InputFormatterContext context)
        {
            var type = context.ModelType;
            if (type == null)
                throw new ArgumentNullException("type");

            return isTypeOfIEnumerable(type);
        }

        private bool isTypeOfIEnumerable(Type type)
        {

            foreach (Type interfaceType in type.GetInterfaces())
            {

                if (interfaceType == typeof(IList))
                    return true;
            }

            return false;
        }

        private object readStream(Type type, Stream stream)
        {
            // We only proocess an IList item at present and simple model type with properties
            IList list = (IList)Activator.CreateInstance(type);

            var reader = new StreamReader(stream);

            bool skipFirstLine = true;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                if (skipFirstLine)
                {
                    skipFirstLine = false;
                }
                else
                {
                    var itemTypeInGeneric = list.GetType().GetType().GenericTypeArguments[0];
                    var item = Activator.CreateInstance(itemTypeInGeneric);
                    var properties = item.GetType().GetProperties();
                    for (int i = 0; i < values.Length; i++)
                    {
                        properties[i].SetValue(item, Convert.ChangeType(values[i], properties[i].PropertyType), null);
                    }

                    list.Add(item);
                }

            }

            return list;
        }
    }
}
