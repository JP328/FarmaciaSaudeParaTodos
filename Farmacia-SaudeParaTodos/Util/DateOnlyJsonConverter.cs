﻿using Newtonsoft.Json;
using System.Globalization;

namespace Farmacia_SaudeParaTodos.Util
{
    public class DateOnlyJsonConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public DateOnlyJsonConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
