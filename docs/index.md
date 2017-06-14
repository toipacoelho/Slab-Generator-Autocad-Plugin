# autoCAD plugin: auto-generate slab schematics #

## Brief ##

This plugin provides a tool capable of drawing schematics and export related info to a .csv file.

The plugin born out of the need to facilitate the work of one team member, with this in mind it has designed to handle the following types of slab:

*  hollow-core slab
*  block slab
*  roof support system (it's not a slab but... civil engineers right?!)

This was the requirements that we started with, of course it can be expanded to support other types.

## Development ##

The plugin was written in VB to be consistent with a deprecated tool with a similar purpose, future versions will be adapted to C# since there is nothing to learn from the tool above mentioned and C# it's more close to the team background.

To develop the project the following tools were necessary:

* Microsoft® Visual Studio
* AutoCAD
* [The ObjectARX SDK](http://usa.autodesk.com/adsk/servlet/index?siteID=123112&id=773204)
* [The AutoCAD .NET Wizards](http://usa.autodesk.com/adsk/servlet/index?siteID=123112&id=1911627)

The end result are a set of three forms that allow the user to enter the details for each slab, i.e. type/size of the elements.

Running the plugin it's as easy as is to import the the .bundle to the plugin folder and you are good to go, a manual is included so the user knows what he can do and how to troubleshoot when necessary.
 
Soon a change log will be available.

## External Libraries ##

To deal with some features we used open source libraries, we chose this approach because it is not worth reinventing the wheel when it's already done.

#### FileHelpers ####
[FileHelpers](http://www.filehelpers.net/) it's used in all operations involving reading or writing a file.
Currently we only support csv files but we expect the implementation of other formats, such as excel, all based in this library. Kudos guys!

## Setbacks ##

The ObjectARX SDK it's a very powerful and big SDK, there are a few examples but not every one are clear, some are deprecated and other not relevant.

The development process was slow paced and suported on extensive research to find articles and other materials to suport the needs of the team. There are a few blogs and an awsome comunity of developers on autodesk foruns. Kudos to them and to [Kean Walmsley's Blog](http://through-the-interface.typepad.com)

