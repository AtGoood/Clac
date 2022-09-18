using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalcProject.App
{
    public class Resources
    {
        public String Culture { get; set; } = "uk-UA";

        public String GetEmptyStringMessage(String? culture = null)
        {
            if (culture == null) culture = Culture;
            switch (culture)
            {
                case "uk-rus": return "рядок не совпадает";
                case "en-US": return "Empty string not allowed";
            }
            throw new Exception("Unupported culture");
        }

        public String GetInvalidCharMessage(char c, String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-rus" => $"неразрешенный символ '{c}'",
                "en-US" => $"Invalid char '{c}'",
                _ => throw new Exception("Unupported culture")
            };
        }
        public String GetInvalidTypeMessage(String type, String? culture = null)
        {
            culture = culture ?? Culture;
            return culture switch
            {
                "uk-rus" => $"Тип аругмента '{type}' не поддерживается",
                "en-US" => $"Argument type '{type}' unsupported",
                _ => throw new Exception("Unupported culture")
            };
        }
        public String GetMispalcedNMessage(String? culture = null)
        {
            if (culture == null) culture = Culture;
            return culture switch
            {
                "uk-rus" => "'N' не разрешается в данном контексте ",
                "en-rus" => "'N' is not allowed in this context",
                _ => throw new Exception("Unupported culture")
            };
        }
        public String GetEnterNumberMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-rus" => "введит число ",
                "en-US" => "Enter number: ",
                _ => throw new Exception("Unsupported culture"),
            };
        }
        // Enter operation
        public String GetEnterOperationMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-rus" => "ведите операцию: ",
                "en-US" => "Enter operation: ",
                _ => throw new Exception("Unsupported culture"),
            };
        }
        // Result
        public String GetResultMessage(int res, String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-rus" => $"Результат: {res}",
                "en-US" => $"Result: {res}",
                _ => throw new Exception("Unsupported culture"),
            };
        }

    }
}