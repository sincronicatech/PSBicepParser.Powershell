parser grammar bicepParser;

options {   tokenVocab = bicepLexer; }

/** Parser rules **/

bicep
  : targetScope? ( resource | param | module | output)+;

module: Module identifier modulePath Equal objectValue;

output: Output identifier type Equal value;

//TargetScope
targetScope: TargetScope Equal scope;

scope : stringValue;

//Param
param: decorator* Param identifier type ( Equal value )? ;

decorator: Et valueExpression;

identifier: Identifier;

type
  : Object
  | String
  | Bool
  | Array
  | Int
;

//Resource
resource: Resource identifier resourceType Existing? Equal objectValue;
resourceType: stringValue;

//Module
modulePath: stringValue;

//value
value
  : valueExpression
  | stringValue
  | numberValue
  | boolValue
  | arrayValue
  | objectValue
;

valueExpression
  : function Point memberExpression
  | reference Point memberExpression
  | function
  | reference
;

memberExpression   
  : function Point memberExpression
  | member Point memberExpression
  | function
  | member
;

member: identifier;

reference: identifier (LeftSquareBracket value RightSquareBracket)?;

function: identifier LeftRoundBracket (functionParameter ( Comma functionParameter)*)* RightRoundBracket;

functionParameter: value;

stringValue: StringStart ( InterpolationStart value RightCurlyBracket | Text )* StringEnd;
boolValue: BooleanValue;
numberValue: Number;

arrayValue: LeftSquareBracket value* RightSquareBracket ;
objectValue: LeftCurlyBracket property* RightCurlyBracket ;

property: propertyName Colon value ;
propertyName: identifier|stringValue;
