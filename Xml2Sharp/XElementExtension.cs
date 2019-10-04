using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Xml2Sharp
{
    public static class XElementExtension
    {
        public static IEnumerable<Class> ExtractClassInfo(this XElement element)
        {
            var @classes = new HashSet<Class>();
            ElementToClass(element, classes);
            foreach(var cl in @classes)
            {
                cl.Fields = ReplaceDuplicatesWithLists(cl.Fields);
            }
            return @classes;
        }

        public static bool IsEmpty(this XElement element)
        {
            return !element.HasAttributes && !element.HasElements;
        }

        private static Class ElementToClass(XElement xElement, ICollection<Class> classes)
        {
            var @class = new Class
            {
                Name = xElement.Name.LocalName,
                XmlName = xElement.Name.LocalName,
                Fields = ExtractFields(xElement, classes, xElement.Name.LocalName).ToList(),
                Namespace = xElement.Name.NamespaceName
            };

            StripBadCharacters(@class);

            if (xElement.Parent == null || (@classes.FirstOrDefault(c => c.Name == @class.Name) == null && @class.Fields.Any()))
                @classes.Add(@class);
            else
            {
                var cl = @classes.FirstOrDefault(c => c.Name == @class.Name);
                if (cl != null)
                    cl.Fields = cl.Fields.Union(@class.Fields).ToList();
            }

            return @class;

        }

        private static IEnumerable<Field> ExtractFields(XElement xElement, ICollection<Class> classes, string className)
        {
            foreach (var element in xElement.Elements().ToList())
            {
                var tempClass = ElementToClass(element, classes);
                var type = element.IsEmpty() ? "string" : tempClass.Name;

                yield return new Field
                {
                    Name = tempClass.Name,
                    Type = type,
                    XmlName = tempClass.XmlName,
                    XmlType = XmlType.Element,
                    Namespace = tempClass.Namespace
                };
            }

            foreach (var attribute in xElement.Attributes().ToList())
            {
                var type = attribute.Value.GetType().Name == "String" ? "string" : attribute.Value.GetType().Name;

                yield return new Field
                {
                    Name = attribute.Name.LocalName != className ? attribute.Name.LocalName : "_" + attribute.Name.LocalName,
                    XmlName = attribute.Name.LocalName,
                    Type = type,
                    XmlType = XmlType.Attribute,
                    Namespace = attribute.Name.NamespaceName
                };
            }
        }

        private static IEnumerable<Field> ReplaceDuplicatesWithLists(IEnumerable<Field> fields)
        {
            return fields.GroupBy(field => field.XmlName, field => field,
                (key, g) =>
                    g.Count() > 1
                        ? new Field()
                        {
                            Name = g.First().Name + "List",
                            Namespace = g.First().Namespace,
                            Type = g.Select(s => s.Type != "string") != null ? string.Format("List<{0}>", g.FirstOrDefault(f => f.Type != "string").Type) : string.Format("List<{0}>", g.First().Type),
                            XmlName = key,
                            XmlType = XmlType.Element
                        } :
                        g.First()).ToList();
        }
        private static void StripBadCharacters(Class @class)
        {
            @class.Name = @class.Name != "string" ? FirstCharToUpper(@class.Name.Replace("-", "").Replace(".", "_")) : @class.Name;
            foreach (var f in @class.Fields)
            {
                f.Name = f.Name != @class.Name ? FirstCharToUpper(f.Name.Replace("-", "").Replace(".", "_")) : FirstCharToUpper(("_" + f.Name).Replace("-", "").Replace(".", "_"));
                f.Type = f.Type != "string" ? FirstCharToUpper(f.Type.Replace("-", "").Replace(".", "_")) : f.Type;
            }
        }

        private static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
