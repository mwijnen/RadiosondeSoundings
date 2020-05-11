using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RadiosondeDataCollector.Collectors.Parsers
{
    public class BaseParser
    {
        public static bool PrintToConsole = true;

        protected IList<T> Parse<T>(IEnumerable<string> lines)
        {
            var result = new List<object>();

            foreach (var line in lines)
            {
                var lineElements = SplitLine(line);

                Validate(lineElements);

                var lineEntity = ParseObjectFromLineElements<T>(lineElements);

                result.Add(lineEntity);
            }

            return ConvertObjectsToEntities<T>(result);
        }

        protected virtual Dictionary<object, string> SplitLine(string line)
        {
            throw new NotFiniteNumberException();
        }

        protected virtual void Validate(Dictionary<object, string> lineElements)
        {
            throw new NotFiniteNumberException();
        }

        protected virtual object ParseObjectFromLineElements<T>(Dictionary<object, string> lineElements)
        {
            throw new NotFiniteNumberException();
        }

        protected IList<T> ConvertObjectsToEntities<T>(IEnumerable<object> objects)
        {
            var result = new List<T>();

            foreach (var _object in objects)
            {
                if (_object is T)
                {
                    result.Add((T)_object);
                }
            }

            return result;
        }

        protected string FindFirstMatchWithRegexAndRemoveMatchFromLine(string pattern, ref string line)
        {
            var match = Regex.Match(line, pattern, RegexOptions.None);
            var parameter = match.ToString();
            var startIndexOfRemainingLine = match.Index + parameter.Length;
            line = line.Substring(startIndexOfRemainingLine);
            return parameter;
        }

        protected string FindLastMatchWithRegexAndRemoveMatchFromLine(string pattern, ref string line)
        {
            var match = Regex.Match(line, pattern, RegexOptions.RightToLeft);
            var parameter = match.ToString();
            var lengthOfRemainingLine = match.Index;
            line = line.Substring(0, lengthOfRemainingLine);
            return parameter;
        }

        protected string FindSubstringAndRemoveSubstringFromLine(int substringLength, ref string line)
        {
            var parameter = line.Substring(0, substringLength);
            line = line.Substring(substringLength);
            return parameter;
        }

        protected void RemoveTrailingWhiteSpaces(ref string line)
        {
            while (line[0] == ' ')
            {
                line = line.Substring(1);
            }
        }
    }
}
