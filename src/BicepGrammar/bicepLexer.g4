lexer grammar bicepLexer;

/** Lexer rules **/
//Tokens

TARGETSCOPE: 'targetscope';
PARAM: 'param';
RESOURCE: 'resource';
MODULE: 'module';
OUTPUT: 'output';

EXISTING: 'existing';



STRING: 'string';
BOOL: 'bool';
INT: 'int';
ARRAY: 'array';
OBJECT: 'object';

COLON: ':';

ET: '@';
OPENSQUARE: '[';
CLOSESQUARE: ']';
OPENGRAPH: '{' -> pushMode(DEFAULT_MODE);
CLOSEGRAPH: '}' -> popMode;
SLASH: '/';

COMMA: ',';
OPENPARENTHESIS: '(';
CLOSEPARENTHESIS: ')' ;

POINT: '.';

EQUAL: '=';

DOLLAR: '$';

fragment DIGIT: [0-9];

BOOLEAN: 'true' | 'false';
NUMBER: DIGIT+;

IDENTIFIER: [A-Za-z_][A-Za-z0-9_]*;

WS : [ \r\t\n]+ -> skip ; 

OPEN_STRING: '\'' -> pushMode(STRINGMODE); 

mode STRINGMODE;

ESCAPED_APEX : '\\\'';
ESCAPED_DOLLAR: '\\$';
TEXT: (~['$]|ESCAPED_APEX|ESCAPED_DOLLAR)+; 

CLOSE_STRING: '\'' -> popMode; 

ENTER_INTERPOLATION: '${' -> pushMode(DEFAULT_MODE); // When we see this, start parsing program tokens.

