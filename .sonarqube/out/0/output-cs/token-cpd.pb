ˆ	
sC:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.Domain\Attributes\EntityAttribute.cs
	namespace 	
	Peliculas
 
. 
Domain 
. 

Attributes %
{ 
[ 
AttributeUsage 
( 
AttributeTargets $
.$ %
Class% *
)* +
]+ ,
public 

class 
EntityAttribute  
:! "
	Attribute# ,
{ 
public 
string 
CollectionName $
{% &
get' *
;* +
private, 3
set4 7
;7 8
}9 :
public

 
EntityAttribute

 
(

 
)

  
{ 	
CollectionName 
= 
null !
;! "
} 	
public 
EntityAttribute 
( 
string %
collectionName& 4
)4 5
{ 	
CollectionName 
= 
collectionName +
;+ ,
} 	
} 
} Ì
hC:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.Domain\Entities\Entity.cs
	namespace 	
	Peliculas
 
. 
Domain 
. 
Entities #
{ 
public 

abstract 
class 
Entity  
<  !
TId! $
>$ %
where& +
TId, /
:0 1
IComparable2 =
,= >
IComparable? J
<J K
TIdK N
>N O
{ 
public		 
TId		 
Id		 
{		 
get		 
;		 
set		 
;		  
}		! "
}

 
} ¶
rC:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.Domain\Entities\ImagenesPelicula.cs
	namespace 	
	Peliculas
 
. 
Domain 
. 
Entities #
{ 
[ 
Entity 
] 
public		 

class		 
ImagenPelicula		  
:		! "
Entity		# )
<		) *
Guid		* .
>		. /
{

 
public 
string 
Nombre 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Path 
{ 
get  
;  !
set" %
;% &
}' (
public 
Guid 

PeliculaId 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} Æ
jC:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.Domain\Entities\Pelicula.cs
	namespace 	
	Peliculas
 
. 
Domain 
. 
Entities #
{ 
[ 
Entity 
] 
public 

class 
Pelicula 
: 
Entity #
<# $
Guid$ (
>( )
{ 
public		 
string		 
Codigo		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public

 
string

 
Nombre

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
string 
Descripcion !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
int 
GeneroId 
{ 
get !
;! "
set# &
;& '
}( )
} 
} Ã

vC:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.Domain\Repository\IAlmacenarArchivos.cs
	namespace 	
	Peliculas
 
. 
Domain 
. 

Repository %
{ 
public		 

	interface		 
IAlmacenarArchivos		 '
{

 
public 
Task 
< 
string 
> 
EditarArchivo )
() *
byte* .
[. /
]/ 0
	contenido1 :
,: ;
string< B
	extensionC L
,L M
stringM S
nombreContenedorT d
,d e
stringe k
rutaArchivol w
)w x
;x y
public 
Task 
EliminarArchivo #
(# $
string$ *
ruta+ /
,/ 0
string1 7
nombreContenedor8 H
)H I
;I J
public 
Task 
< 
string 
> 
GuardarArchivo *
(* +
byte+ /
[/ 0
]0 1
	contenido2 ;
,; <
string< B
	extensionC L
,L M
stringN T

contenedorU _
)_ `
;` a
} 
} 
oC:\Users\rafap\source\repos\ClasesDavid\ActividadFinal\Peliculas.API\Peliculas.Domain\Repository\IRepository.cs
	namespace 	
	Peliculas
 
. 
Domain 
. 

Repository %
{ 
public 

	interface 
IRepository  
<  !
TEntity! (
,( )
TId) ,
>, -
where		 
TEntity		 
:		 
Entity		 
<		 
TId		 !
>		! "
,		" #
new		$ '
(		' (
)		( )
where

 
TId

 
:

 
IComparable

 
,

  
IComparable

! ,
<

, -
TId

- 0
>

0 1
{ 
public 
TEntity 
GetById 
( 
TId "
id# %
)% &
;& '
public 
List 
< 
TEntity 
> 
GetAll #
(# $
)$ %
;% &
public 
List 
< 
TEntity 
> 
GetByFilter (
(( )
Func) -
<- .
TEntity. 5
,5 6
bool7 ;
>; <
	predicate= F
)F G
;G H
public 
TEntity 
Add 
( 
TEntity "
entity# )
)) *
;* +
public 
TEntity 
Update 
( 
TEntity %
entity& ,
), -
;- .
public 
TEntity 
Delete 
( 
TId !
id" $
)$ %
;% &
} 
} 