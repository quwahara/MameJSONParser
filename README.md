# MameJSONParser

## Abstract

The MameJSONParser is a simple JSON parser. The feature is only parsing.
The result of parser is simple.
JSON Object turns to Dictionary<string, object>.
JSON Array does to List<object>.
The parser have no feature to map JSON Object to .NET Class.
The types of parser returns are: bool, int, double, string, 
List<object> and Dictonary<string, object>.

## Examples

```C#
var obj = MameJSONParser.Parse("{\"key\": \"val\"}");
// => (Dictionary<string, object>) obj["key"] = "val"

var ls = MameJSONParser.Parse("[9, \"s\", 0.1, true, null]");
// => (List<object>) ls[0] = 9; ls[1] = "s"; ls[2] = 0.1; ls[3] = true; ls[4] = null; 
```

## License

This software is released under the MIT License, see LICENSE.txt.


