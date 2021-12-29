�
yC:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.API\Configurations\ConfigureConnections.cs
	namespace 	
	Peliculas
 
. 
API 
. 
Configurations &
{ 
public		 

static		 
class		  
ConfigureConnections		 ,
{

 
public 
static 
IServiceCollection (!
AddConnectionProvider) >
(> ?
this? C
IServiceCollectionD V
servicesW _
,_ `
IConfigurationa o

)} ~
{ 	
string 
conexionString !
=" #

.1 2
GetConnectionString2 E
(E F
$strF Y
)Y Z
;Z [
services 
. 
AddDbContextPool %
<% &
PeliculasContext& 6
>6 7
(7 8
options8 ?
=>@ B
optionsC J
.J K
UseSqlServerK W
(W X
conexionStringX f
,f g"
sqlServerOptionsAction &
:& '

sqlOptions( 2
=>3 5
{ 

sqlOptions 
.  
EnableRetryOnFailure 3
(3 4

:! "
$num# $
,$ %

:! "
TimeSpan# +
.+ ,
FromSeconds, 7
(7 8
$num8 :
): ;
,; <
errorNumbersToAdd %
:% &
null' +
)+ ,
;, -
} 
) 
) 
; 
return 
services 
; 
} 	
} 
}   �!
zC:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.API\Configurations\ServicesConfiguration.cs
	namespace		 	
	Peliculas		
 
.		 
API		 
.		 
Configurations		 &
{

 
public 

static 
class !
ServicesConfiguration -
{ 
public
static
IServiceCollection
AddCorsConfiguration
(
this
IServiceCollection
services
)
=>
services	 
. 
AddCors 
( 
options !
=>" $
{	 

options
. 
	AddPolicy 
( 
$str 
, 
builder 
=> 
builder 
. 
AllowAnyOrigin $
($ %
)% &
.& '
AllowAnyHeader' 5
(5 6
)6 7
.7 8
AllowAnyMethod8 F
(F G
)G H
)H I
;I J
}	 

)
 
; 
public 
static 
IServiceCollection (
AddConfigureService) <
(< =
this= A
IServiceCollectionB T
servicesU ]
)] ^
{ 	
var 
entities 
= 
typeof !
(! "
Entity" (
<( )
>) *
)* +
.+ ,
Assembly, 4
.4 5
GetTypes5 =
(= >
)> ?
.? @
Where@ E
(E F
itF H
=>I K
itL N
.N O
IsClassO V
&&W Y
!Z [
it[ ]
.] ^

IsAbstract^ h
&&i k
itl n
.n o
GetCustomAttribute	o �
<
� �
EntityAttribute
� �
>
� �
(
� �
)
� �
!=
� �
null
� �
)
� �
;
� �
foreach 
( 
var 
clase 
in !
entities" *
)* +
{ 
var 

typeBaseId 
=  
clase! &
.& '
GetProperty' 2
(2 3
$str3 7
)7 8
.8 9
PropertyType9 E
;E F
services   
.   
AddTransient   %
(  % &
typeof  & ,
(  , -
ICrudService  - 9
<  9 :
,  : ;
>  ; <
)  < =
.  = >
MakeGenericType  > M
(  M N
clase  N S
,  S T

typeBaseId  U _
)  _ `
,  ` a
typeof!! 
(!! 
CrudService!! *
<!!* +
,!!+ ,
>!!, -
)!!- .
.!!. /
MakeGenericType!!/ >
(!!> ?
clase!!? D
,!!D E

typeBaseId!!F P
)!!P Q
)!!Q R
;!!R S
services"" 
."" 
AddTransient"" %
(""% &
typeof""& ,
("", -
IRepository""- 8
<""8 9
,""9 :
>"": ;
)""; <
.""< =
MakeGenericType""= L
(""L M
clase""M R
,""R S

typeBaseId""T ^
)""^ _
,""_ `
typeof## 
(## 
EFCoreRepository## +
<##+ ,
,##, -
>##- .
)##. /
.##/ 0
MakeGenericType##0 ?
(##? @
clase##@ E
,##E F

typeBaseId##G Q
)##Q R
)##R S
;##S T
}$$ 
services&& 
.&& 
AddTransient&& !
<&&! ""
IImagenPeliculaService&&" 8
,&&8 9!
ImagenPeliculaService&&: O
>&&O P
(&&P Q
)&&Q R
;&&R S
services(( 
.(( 
AddTransient(( !
<((! "
IAlmacenarArchivos((" 4
,((4 5$
AlmacenadorArchivosLocal((6 N
>((N O
(((O P
)((P Q
;((Q R
return** 
services** 
;** 
}++ 	
},, 
}-- � 
pC:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.API\Controllers\BaseController.cs
	namespace 	
	Peliculas
 
. 
API 
. 
Controllers #
{ 
[ 
Route 

(
 
$str 
) 
] 
[		 

]		 
public

 

class

 
BaseController

 
<

  
TEntity

  '
,

' (
TId

( +
>

+ ,
:

- .
ControllerBase

/ =
where 
TEntity 
: 
Entity 
< 
TId "
>" #
,# $
new% (
(( )
)) *
where 
TId 
: 
IComparable 
,  
IComparable! ,
<, -
TId- 0
>0 1
{ 
	protected 
readonly 
ICrudService '
<' (
TEntity( /
,/ 0
TId0 3
>3 4
_crudService5 A
;A B
public 
BaseController 
( 
ICrudService *
<* +
TEntity+ 2
,2 3
TId3 6
>6 7
crudService8 C
)C D
=>E G
_crudServiceH T
=U V
crudServiceW b
;b c
[ 	
HttpGet	 
] 
public 

Get  
(  !
)! "
{ 	
return 
Ok 
( 
_crudService "
." #
GetAll# )
() *
)* +
)+ ,
;, -
} 	
[ 	
HttpGet	 
] 
public 

	GetFilter &
<& '
TFilter' .
>. /
(/ 0
TFilter0 7
filter8 >
)> ?
where@ E
TFilterF M
:N O
classP U
{ 	
return 
Ok 
( 
_crudService "
." #
GetByFilter# .
(. /
x0 1
=>1 3
{4 5
return 
true 
; 
} 
)
) 
; 
} 	
["" 	
HttpGet""	 
]"" 
[## 	
Route##	 
(## 
$str## 
)## 
]## 
public$$ 

Get$$  
($$  !
TId$$! $
id$$% '
)$$' (
{%% 	
return&& 
Ok&& 
(&& 
_crudService&& "
.&&" #
GetById&&# *
(&&* +
id&&+ -
)&&- .
)&&. /
;&&/ 0
}'' 	
[** 	
HttpPost**	 
]** 
public++ 

Post++ !
(++! "
TEntity++" )
entity++* 0
)++0 1
{,, 	
return-- 
Ok-- 
(-- 
_crudService-- "
.--" #
Add--# &
(--& '
entity--' -
)--- .
)--. /
;--/ 0
}.. 	
[00 	

HttpDelete00	 
]00 
public11 
virtual11 

Delete11% +
(11+ ,
TId11, /
id110 2
)112 3
{22 	
return33 
Ok33 
(33 
_crudService33 "
.33" #
Delete33# )
(33) *
id33* ,
)33, -
)33- .
;33. /
}44 	
[66 	
HttpPut66	 
]66 
public77 

Update77 #
(77# $
TEntity77$ +
entity77, 2
)772 3
{88 	
return99 
Ok99 
(99 
_crudService99 "
.99" #
Update99# )
(99) *
entity99* 0
)990 1
)991 2
;992 3
}:: 	
};; 
}<< �
zC:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.API\Controllers\ImagenPeliculaController.cs
	namespace		 	
	Peliculas		
 
.		 
API		 
.		 
Controllers		 #
{

 
[ 
Route 

(
 
$str 
) 
] 
[ 

] 
public

class
ImagenPeliculaController
:
ControllerBase
{ 
private 
readonly "
IImagenPeliculaService /"
_imagenPeliculaService0 F
;F G
public $
ImagenPeliculaController '
(' ("
IImagenPeliculaService( >!
imagenPeliculaService? T
,T U 
IHttpContextAccessor  
host! %
,% &
IWebHostEnvironment 
env  #
)# $
{ 	"
_imagenPeliculaService "
=# $!
imagenPeliculaService% :
;: ;
if 
( 
string 
. 

(# $
AppVariables$ 0
.0 1
RootPath1 9
)9 :
): ;
AppVariables 
. 
RootPath %
=& '
$"( *
{* +
host+ /
./ 0
HttpContext0 ;
.; <
Request< C
.C D
SchemeD J
}J K
$strK N
{N O
hostO S
.S T
HttpContextT _
._ `
Request` g
.g h
Hosth l
}l m
"m n
;n o
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 

>' (
Post) -
(- .
ImagenPeliculaDTO. ?
request@ G
)G H
{ 	
return 
Ok 
( 
await "
_imagenPeliculaService 2
.2 3
Add3 6
(6 7
request7 >
)> ?
)? @
;@ A
} 	
[   	
HttpGet  	 
]   
[!! 	
Route!!	 
(!! 
$str!! 
)!! 
]!! 
public"" 

GetByPeliculaId"" ,
("", -
Guid""- 1
id""2 4
)""4 5
{## 	
return$$ 
Ok$$ 
($$ "
_imagenPeliculaService$$ ,
.$$, -
GetByPeliculaId$$- <
($$< =
id$$= ?
)$$? @
)$$@ A
;$$A B
}%% 	
['' 	

HttpDelete''	 
]'' 
[(( 	
Route((	 
((( 
$str(( 
)(( 
](( 
public)) 
async)) 
Task)) 
<)) 

>))' (
Delete))) /
())/ 0
[))0 1
Required))1 9
]))9 :
Guid)): >
id))? A
)))A B
{** 	
await++ "
_imagenPeliculaService++ (
.++( )
Delete++) /
(++/ 0
id++0 2
)++2 3
;++3 4
return,, 
Ok,, 
(,, 
),, 
;,, 
}-- 	
}.. 
}// �
tC:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.API\Controllers\PeliculaController.cs
	namespace 	
	Peliculas
 
. 
API 
. 
Controllers #
{ 
[ 
Route 

(
 
$str 
) 
] 
[		 

]		 
public

 

class

 
PeliculaController

 #
:

$ %
BaseController

& 4
<

4 5
Pelicula

5 =
,

= >
Guid

? C
>

C D
{ 
private 
readonly "
IImagenPeliculaService /"
_imagenPeliculaService0 F
;F G
public
PeliculaController
(
ICrudService
<
Pelicula
,
Guid
>
crudService
,
IImagenPeliculaService
imagenPeliculaService
)
:
base	
(

crudService

)

{ 	"
_imagenPeliculaService "
=# $!
imagenPeliculaService% :
;: ;
} 	
[ 	

HttpDelete	 
] 
[ 	
Route	 
( 
$str 
) 
] 
public 
override 

Delete& ,
(, -
Guid- 1
id2 4
)4 5
{ 	
_crudService 
. 
Delete 
(  
id  "
)" #
;# $"
_imagenPeliculaService "
." #
GetByPeliculaId# 2
(2 3
id3 5
)5 6
.6 7
ForEach7 >
(> ?
x? @
=>A C
{ 
_imagenPeliculaService &
.& '
Delete' -
(- .
x. /
./ 0
Id0 2
)2 3
;3 4
} 
)
; 
return 
Ok 
( 
) 
; 
} 	
} 
} �
]C:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.API\Program.cs
string 
_Cors 
=
$str 
; 
var 
builder 
= 
WebApplication 
. 

(* +
args+ /
)/ 0
;0 1
ConfigurationManager 

=# $
builder% ,
., -

;: ;
IWebHostEnvironment 
environment 
=  !
builder" )
.) *
Environment* 5
;5 6
AppVariables 
. 
WebRootPath
= 
environment &
.& '
WebRootPath' 2
;2 3
builder
.
Services
.
AddCors
(
options
=>
{
options 
. 
	AddPolicy 
( 
name 
: 
_Cors !
,! "
builder 
=>  
{ 
builder !
.! "
AllowAnyHeader" 0
(0 1
)1 2
;2 3
builder !
.! "
AllowAnyMethod" 0
(0 1
)1 2
;2 3
builder !
.! "
SetIsOriginAllowed" 4
(4 5
(5 6
Host6 :
): ;
=>< >
true? C
)C D
;D E
builder !
.! "
AllowCredentials" 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
) 
; 
builder 
. 
Services 
. 
AddConfigureService 
( 
) 
.  
AddCorsConfiguration 
( 
) 
. !
AddConnectionProvider 
( 

)( )
;) *
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder   
.   
Services   
.   #
AddEndpointsApiExplorer   (
(  ( )
)  ) *
;  * +
builder!! 
.!! 
Services!! 
.!! 

(!! 
)!!  
;!!  !
builder"" 
."" 
Services"" 
."" "
AddHttpContextAccessor"" '
(""' (
)""( )
;"") *
var$$ 
app$$ 
=$$ 	
builder$$
 
.$$ 
Build$$ 
($$ 
)$$ 
;$$ 
if'' 
('' 
app'' 
.'' 
Environment'' 
.'' 

(''! "
)''" #
)''# $
{(( 
app)) 
.)) 

UseSwagger)) 
()) 
))) 
;)) 
app** 
.** 
UseSwaggerUI** 
(** 
)** 
;** 
}++ 
app-- 
.-- 
UseStaticFiles-- 
(-- 
)-- 
;-- 
app.. 
... 
UseHttpsRedirection.. 
(.. 
).. 
;.. 
app00 
.00 
UseAuthorization00 
(00 
)00 
;00 
app33 
.33 
UseCors33 
(33 
_Cors33 
)33 
;33 
app55 
.55 
MapControllers55 
(55 
)55 
;55 
app77 
.77 
Run77 
(77 
)77 	
;77	 