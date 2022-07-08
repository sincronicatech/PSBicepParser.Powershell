lexer grammar bicepLexer;

/** Lexer rules **/
//Tokens

TargetScope: 'targetscope';
Param: 'param';
Resource: 'resource';
Module: 'module';
Output: 'output';

Existing: 'existing';



String: 'string';
Bool: 'bool';
Int: 'int';
Array: 'array';
Object: 'object';

Colon: ':';

Et: '@';
LeftSquareBracket: '[';
RightSquareBracket: ']';
LeftCurlyBracket: '{' -> pushMode(DEFAULT_MODE);
RightCurlyBracket: '}' -> popMode;

Comma: ',';
LeftRoundBracket: '(';
RightRoundBracket: ')' ;

Point: '.';

Equal: '=';

Dollar: '$';

fragment Digit: [0-9];

BooleanValue: 'true' | 'false';
Number: Digit+;

Identifier: [A-Za-z_][A-Za-z0-9_]*;

WhiteSpace : [ \r\t\n]+ -> skip ; 

StringStart: '\'' -> pushMode(STRINGMODE); 

mode STRINGMODE;

EscapedApex : '\\\'';
EscapedDollar: '\\$';
Text: (~['$]|[$]~['{]|EscapedApex|EscapedDollar)+; 

StringEnd: '\'' -> popMode; 

InterpolationStart: '${' -> pushMode(DEFAULT_MODE); // When we see this, start parsing program tokens.

