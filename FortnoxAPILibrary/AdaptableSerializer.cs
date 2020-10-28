﻿using System;
using System.Runtime.Serialization;
using FortnoxAPILibrary.Serialization;

namespace FortnoxAPILibrary
{
    public class AdaptableSerializer
    {
        private readonly JsonEntitySerializer serializer;

        public Func<string, string> FixRequestContent; //Needed for fixing irregular json requests //TODO: rename to "adapt serialization" //post-serialization
        public Func<string, string> FixResponseContent; //Needed for fixing irregular json responses //TODO: rename to adapt deserialization //pre-deserialization

        public AdaptableSerializer()
        {
            serializer = new JsonEntitySerializer();
        }

        public string Serialize<T>(T entity)
        {
            var json = serializer.Serialize(entity);

            if (FixRequestContent != null)
                json = FixRequestContent(json);

            FixRequestContent = null;
            return json;
        }

        public T Deserialize<T>(string content)
        {
            try
            {
                if (FixResponseContent != null)
                    content = FixResponseContent(content);
                FixResponseContent = null;
                return serializer.Deserialize<T>(content);
            }
            catch (Exception e)
            {
                throw new SerializationException("An error occured while deserializing the response. Check ResponseContent.", e.InnerException);
            }
        }
    }
}
