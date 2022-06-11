parser grammar bicepParser;

options {   tokenVocab = bicepLexer; }

/** Parser rules **/

bicep
  : targetScope? ( resource | param | module | output)+;

module: MODULE identifier modulePath EQUAL objectValue;

output: OUTPUT identifier type EQUAL value;

//TargetScope
targetScope: TARGETSCOPE EQUAL scope;

scope : stringValue;

//Param
param: decorator* PARAM identifier type ( EQUAL value )? ;

decorator: ET valueExpression;

identifier: IDENTIFIER;

type
  : OBJECT
  | STRING
  | BOOL
  | ARRAY
  | INT
;

//Resource
resource: RESOURCE identifier resourceType EXISTING? EQUAL objectValue;
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
  : function POINT valueExpression
  | variable POINT valueExpression
  | function
  | variable
;

variable: IDENTIFIER (OPENSQUARE value CLOSESQUARE)?;

function: IDENTIFIER OPENPARENTHESIS (functionParameter ( COMMA functionParameter)*)* CLOSEPARENTHESIS;

functionParameter: value;

stringValue: OPEN_STRING ( ENTER_INTERPOLATION value CLOSEGRAPH | TEXT )* CLOSE_STRING;
boolValue: BOOLEAN;
numberValue: NUMBER;

arrayValue: OPENSQUARE value+ CLOSESQUARE ;
objectValue: OPENGRAPH property+ CLOSEGRAPH ;

property: propertyName COLON value ;
propertyName: IDENTIFIER|stringValue;
