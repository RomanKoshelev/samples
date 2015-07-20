# Aspose.Html

### Subject
- We create Tools for building the Hierarchical Model which represents the given html-file.
- We have to provide easy way for modification of any aspects of the solution.
- Our code should be clear.

### Selected Approach
1. Use the [`Html Agility Pack`](https://htmlagilitypack.codeplex.com/) to rapidly realize the [`HapParser:IParser`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Tools/Parsers/Concrete/HtmlAgilityPack/HapParser.cs).
2. Invent the proper Architecture and declare all main Classes which are needed for us.
3. Write [`Tests`](https://github.com/RomanKoshelev/Aspose/tree/master/src/Aspose.Tests.Nunit.Html/Tests) to implement classes (using TDD) and to keep the functinality in the correct state.
4. Refactore to make the Code Clear.
5. Improve the solution (say, add new tag support or implement [`LexicalAnalyserParser`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Tools/Parsers/Concrete/LexicalAnalyzer/LexParser.cs)).
<img src="http://content.screencast.com/users/Romakosh/folders/Jing/media/22ad87ed-814a-49cf-b888-1345134552e7/2015-07-20_0532.png">

### How to Use
- To build the [`Model`](https://github.com/RomanKoshelev/Aspose/tree/master/src/Aspose.Html/Elements) we have to obtain some [`Tools`](https://github.com/RomanKoshelev/Aspose/tree/master/src/Aspose.Html/Tools) using the [`Factory`](https://github.com/RomanKoshelev/Aspose/tree/master/src/Aspose.Html/Factoriers):
```c#
	var factory = new HapFactory();
	var parser  = factory.MakeHtmlParser();
	var builder = factory.MakeModelBuilder();
	var model   = builder.BuildModel( parser, File.ReadAllText( "input.html" ) );
```
- Now we can access the [`Elements and their Properties`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Types/IModelElement.cs):
```c#
	var tabCellspacing = model[ "table" ][ 0 ].Attributes[ "cellspacing" ];
	var tdBorderStyle  = model[ "table" ][ 0 ][ "tr" ][ 1 ][ "td" ][ 2 ].Styles[ "border" ];
	var tdText         = model[ "table" ][ 0 ][ "tr" ][ 0 ][ "td" ][ 1 ].TextElement.Text;
```
- Following tools can be used for serializing (see [`output.html`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Tests.Nunit.Html/bin/Debug/App_Data/output.html)) and verification of the Model:
```c#
	// To serialize
	var htmlWriter = factory.MakeHtmlWriter()      
	File.WriteAllText( "output.html", htmlWriter.Write( model ) );
	
	// To verify the model structure
	var structWriter = factory.MakeStructWriter();
    Assert.AreEqual(
		"Page:(0)[]{Table:(0)[border,cellspacing,style]{Tr:(0)[]{Td:(0)[]{Text:(57)[]{}}Td:(0)[style]{Text:(57)[]{}}Td:(0)[style]{Text:(57)[]{}}}Tr:(0)[]{Td:(0)[width]{Text:(57)[]{}}Td:(0)[]{Text:(57)[]{}}Td:(0)[]{Text:(57)[]{}}}}}",
        structWriter.Write( model ) );

	// To view the model outline
	var outlineWriter = factory.MakeOutlineWriter();
	Console.WriteLine( outlineWriter.Write( model ) );
```

### How to Explore
- We can browse the Documented Tests [`\Tests\Main_Tests.cs`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Tests.Nunit.Html/Tests/Main_Tests.cs) (and some other tests) for the exploitation details.
- Note that the [`Core Code`](https://github.com/RomanKoshelev/Aspose/tree/master/src/Aspose.Html) has no any comments because, as we hope, this code is plain and clear.
- Each test writes to Console, so we can view its outputs: <img width=700 src="http://content.screencast.com/users/Romakosh/folders/Jing/media/942269e2-cb95-4c1f-be6c-6e35aec4c020/2015-07-20_0155.png"/>

### How to Develop
- To implement another html Parser:
  - add new parser-class in: [`\Tools\Parsers\Concrete\`](https://github.com/RomanKoshelev/Aspose/tree/master/src/Aspose.Html/Tools/Parsers/Concrete);
  - implement the [`IParser`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Types/IParser.cs) and [`IParserNode`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Interfaces/IParserNode.cs) interfaces for the `MyParser` class (and write at least [`all code`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Tools/Parsers/Concrete/HtmlAgilityPack/HapParserNode.cs) we need to it can work properly :)
  - add new factory to encapsulate the parser creation: `\Factories\MyFactory.cs` (we have to override one method);
- To support new Tag: 
  - add new element-class in [`\Elements\`](https://github.com/RomanKoshelev/Aspose/tree/master/src/Aspose.Html/Elements)
  - let it inherit [`AbstractElement`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Elements/AbstractlElement.cs) and override at least the `doGetTag()` method;
  - register tag as constant-string: [`Common.Constants.Tags`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Common/Constants.cs);
  - add new case in the method [`ModelBuilder.CreateTaggedElement()`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Tools/Builders/ModelBuilder.pvt.Elements.cs):
```c#
		case Constants.Tags.Mytag :
			return new Mytag();
```
- To support new element Type (e.g. Comment or Script): 
  - add new value to the enum [`ParserNodeType`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Types/ParserNodeType.cs);
  - add new case in the method [`ModelBuilder.CreateElement()`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Tools/Builders/ModelBuilder.pvt.Elements.cs);
  - inherit [`AbstractElement`](https://github.com/RomanKoshelev/Aspose/blob/master/src/Aspose.Html/Elements/AbstractlElement.cs)

### Sources
- Here they are: [Github.com/RomanKoshelev/Aspose](https://github.com/RomanKoshelev/Aspose).


*Thank you. Roman Koshelev.*