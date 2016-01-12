﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HttpLease.Formatters
{
    public class RequestParameters
    {
        internal Dictionary<string, string[]> _Store;
        public Encoding Encoding { get; set; }

        internal RequestParameters(Dictionary<string, string[]> dictionary, Encoding encoding)
        {
            _Store = new Dictionary<string, string[]>(dictionary);
            Encoding = encoding;
        }

        public override string ToString()
        {
            return ToString(true, true);
        }

        public string ToString(bool isEncodeKey, bool isEncodeValue)
        {
            var result = new List<string>();
            foreach (var pair in _Store)
            {
                foreach (var item in pair.Value)
                {
                    result.Add(String.Format("{0}={1}",
                        isEncodeKey ? System.Web.HttpUtility.UrlEncode(pair.Key, Encoding) : pair.Key,
                        isEncodeValue ? System.Web.HttpUtility.UrlEncode(item, Encoding) : item
                        ));
                }
            }
            result.Sort();
            return String.Join("&", result);
        }
    }
}
