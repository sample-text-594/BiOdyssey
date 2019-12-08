![Portada](/Imágenes/portada_gdd.png)


# Índice
1. [Introducción](#1-introducción)
2. [Diseño y mecánicas](#2-diseño-y-mecánicas)
3. [Estética y arte](#3-estética-y-arte)
4. [Trasfondo e historia](#4-trasfondo-e-historia)
5. [Sonido y música](#5-sonido-y-música)
6. [Comercialización](#6-comercialización)
7. [Bibliografía](#7-bibliografía)


## 1. Introducción 
### Sobre BiOdyssey
BiOdyssey es un videojuego de exploración en el que el jugador debe recorrer el espacio para descubrir sistemas planetarios, planetas y las especies de fauna alienígena que los habitan, y adquirir conocimiento sobre los distintos biomas en los que se engloban estos mundos.
### Plataformas
BiOdyssey está pensado para jugarse en Google Chrome y Mozilla Firefox, tanto desde un ordenador como desde un smartphone, sin embargo, dado el espíritu y las características del videojuego, el móvil es la plataforma que consideramos ideal para disfrutar de BiOdyssey.
### Decisiones de diseño
Al comienzo del diseño de BiOdyssey nos encontramos con una serie de decisiones que han marcado el posterior desarrollo del título:
* En el juego, al estar pensado para jugarse en navegador y en móvil, las sesiones de juego deben de ser cortas y rápidas.
* No debe haber ninguna mecánica de combate, el protagonista es un investigador, no un conquistador.
*	Al ser un juego de exploración espacial, y siguiendo los pasos de otros títulos como No Man’s Sky, consideramos que implementar cierto componente multijugador es algo importante.
* El juego debe de ser tranquilo. El número de peligros es mínimo, lo más importante es explorar el espacio y disfrutar con el viaje.


## 2. Diseño y mecánicas
### Sistemas
*	Número de planetas por sistema: entre 3 y 5
*	Organización del sistema: los planetas del sistema orbitan entorno a una estrella, cada planeta en una órbita diferente.
*	Estrella: la estrella se sitúa en el medio del sistema, los planetas orbitan entorno a ella, y puede ser de tres tamaños: pequeña (0.5x), mediana (1.0x) o grande (1.5x).
*	Nombre: el nombre del sistema consiste en 1 o 2 palabras aleatorias. Como máximo pueden tener 9 letras cada palabra. También, como máximo pueden ir 2 vocales o 2 consonantes seguidas, para evitar así que surjan palabras de difícil pronunciación. El jugador que descubra por vez primera el sistema tendrá la posibilidad de darle un nombre a su elección o dejar el nombre por defecto.
*	Si el sistema tiene sólo 3 planetas, no habrá un planeta combustible.
*	Viajar entre sistemas consume combustible, el cual sólo se puede recuperar en los mundos combustible.


### Planetas
*	Hay dos tipos de planeta: los normales y los planetas combustible.
*	Estos, a su vez, se dividen en subtipos:
   * Normal:
     * Océano: planetas formados por islas, con la mayoría de su superficie siendo grandes mares.
     * Desierto: planetas con cantidades mínimas de agua, siendo en su mayoría llanos con leves elevaciones (dunas).
     * Selva: planetas con grandes cantidades de vegetación y agua.
     * Helado: planetas fríos, con pequeñas cantidades de agua, montañas y mucho hielo. Hay llanuras y zonas escarpadas por igual.
     * Sintético: planetas creados artificialmente, son metálicos, con formas angulosas y rectas. Sin agua.
   * Combustible:
     * Venenoso: planetas contaminados, con mares envenenados. Si el jugador se queda sin combustible en este planeta pierde permanentemente una carga de combustible de la nave de exploración.
     * Muerto: planeta seco, sin agua y sin restos de vida. Como la Luna. Hogar del monstruo.
     * Fuego: planetas sin mares, con volcanes, magma y fuego por todas partes. Cuando el jugador visite este tipo de planeta la nave de exploración perderá combustible a mayor velocidad.
   * Tamaño: hay tres tamaños: pequeño (0.5x), mediano (1.0x) o grande (1.5x).
   * Nombre: el nombre de los planetas será el nombre del sistema + - + una letra dependiendo del lugar que ocupe en órbita. Por ejemplo: Arzamás-b (los planetas comienzan a nombrarse a partir de la letra b, estando la a reservada a la estrella). El primer jugador que lo explore podrá darle un nombre.
   * El mundo combustible es un planeta que habrá en los sistemas de 4 o 5 planetas (UN planeta), dónde no habrá criaturas que escanear. También, es el único lugar donde puedes recuperar combustible encontrando una cápsula. Además, cada tipo de planeta combustible te dañará de maneras diferentes.
   * Aparte de los planetas que el jugador vaya descubriendo a lo largo de sus aventuras, está el planeta base, desde el cual el jugador comienza la exploración del espacio cada vez que entra al juego. Este planeta no será procedimental, y al principio tendrá la apariencia de un planeta muerto. Según el jugador vaya consiguiendo conocimiento de bioma, este comenzará a tener vida y naturaleza.
   * El jugador puede volver a la nave nodriza en cualquier momento, para ello deberá pulsar la tecla correspondiente y esperar 3 segundos.


### Planeta base
* Después del menú principal, una vez comenzado el juego, el jugador aparece en el planeta base.
* Este planeta es, al principio, un mundo muerto. A medida que el jugador vaya recolectando conocimiento de bioma, este mundo irá “iluminándose” e irán apareciendo zonas de los biomas en cuestión.
* Este planeta no es procedimental, como los otros, sino que está definido (y modelado) desde el principio.
* En el planeta habrá, además, una zona de despegue para viajar a otros sistemas planetarios, y una plataforma de repostaje, en la que se puede recuperar (y comprar) combustible.


### Criaturas
* En cada planeta hay entre 2 y 4 especies distintas, dependiendo del tamaño del planeta. Habrá en total 15 criaturas de cada especie (si se puede, se agruparán en 3 manadas de 5 individuos cada una). Siempre que se pueda, cada especie será de un tipo de criaturas diferentes.
* Para escanear a una criatura, habrá que acercarse a la misma y pulsar el botón que aparezca por pantalla.
* El objetivo en cada mundo es escanear a todas las especies que lo habitan, de esa manera conseguiremos un objeto llamado “conocimiento de bioma”, el cual nos es necesario para completar el juego.
* Dependiendo del bioma conseguiremos conocimiento de ese bioma en concreto.
* El conocimiento se consigue sólo en los planetas normales.
* Hay tres tipos de criaturas.
* Las criaturas de tipo 1 y 2 andarán por tierra, mientras que las del tipo 3 andarán tanto por tierra como por agua.
* Las criaturas solo se moverán de un lado a otro por la superficie, no volarán ni bucearán.
* Se agruparán en manadas de hasta 5 individuos.
* Las criaturas avanzarán a 0.5 la velocidad de la nave.
* Las criaturas NO atacarán al jugador.
* Las criaturas no huirán del jugador.


### Monstruo
* El monstruo aparecerá en los planetas combustible cuyo bioma sea planeta muerto.
* El monstruo perseguirá al jugador volando y le atacará dándole un zarpazo.
* Si el monstruo consigue atacar 3 veces al jugador, el jugador se verá obligado a volver al planeta base.
* El monstruo aparecerá en las cercanías de las reservas de combustible.
* El monstruo se desplazará a 1.2 la velocidad de la nave.
* El jugador no podrá hacer daño al monstruo.


### Mecánicas
#### Escaneado
*	La nave de exploración tiene la capacidad de escanear las criaturas del planeta que se está visitando. 
*	El escáner no estará siempre activado, se activará mediante un botón en pantalla. 
*	Para escanear una criatura la nave deberá colocarse encima de dicha criatura. 
*	Cuando se pulse el botón de escanear surgirá de la nave un haz de luz proyectado perpendicularmente a la superficie del planeta, el cual tendrá un área con un tamaño parecido al de la nave. 
*	Si la nave está situada encima de una criatura y se mantiene pulsado el botón de escanear, empezará el período de escaneo, el cual tendrá una duración de 3 segundos. 
*	Si se escanean dos o más criaturas de la misma especie a la vez solo se escaneará una. 
*	Si se escanean dos o más criaturas de especies distintas se escaneará solo una por escaneo. Se dará prioridad a la criatura que esté más cerca del centro del área de escaneo. 
*	Cuando se escanea una criatura la energía de la nave de exploración se recupera al máximo. 


### Gestión de recursos
#### Conocimiento de bioma
*	Una vez se escaneen todas las criaturas de un planeta, el jugador obtendrá una unidad de “conocimiento de bioma”.
*	Este conocimiento de bioma varía dependiendo del planeta en cuestión, si el jugador está en un planeta selvático, será “conocimiento de selva”, si es un planeta oceánico será “conocimiento de océano”, etc.
*	El objetivo final del jugador es conseguir la mayor cantidad de conocimiento de cada bioma de planeta (los planetas combustible quedan excluidos).
*	Una vez el jugador tenga 10 unidades de conocimiento de un bioma en el planeta base se desbloqueará el terreno de ese bioma; cuando tenga 15, se desbloqueará la paleta de color; a los 20, la flora.
*	Una vez haya conseguido todo esto, el jugador puede seguir recolectando conocimiento de bioma para recibir recompensas adicionales.

#### Combustible
*	El combustible es el recurso que permite al jugador moverse con la nave entre los diferentes sistemas planetarios y por los propios planetas.
*	El desplazamiento entre planetas del mismo sistema no supondrá gasto de combustible. Esto se debe a que la nave nodriza lanzará la nave de exploración a cada uno de los planetas y la abducirá cuando se termine la exploración.
*	El desplazamiento entre sistemas sí supondrá gasto de combustible.
*	Hay dos naves en el juego: la nave nodriza y la nave de exploración, y cada una tiene un combustible o fuente de energía diferente.
*	Hay dos tipos de combustible: el combustible para la nave nodriza y el combustible para la nave de exploración.
*	El combustible de la nave nodriza consistirá en una sofisticada mezcla creada a partir de los elementos químicos Moscovio y Oganesón, el nombre de dicha mezcla es “MO-233”.
  *	La cantidad de combustible empleado para saltar de un sistema a otro será siempre una unidad fija, el 25% del combustible total o 1000 celemines.
  * El combustible “MO-233” solo se podrá recuperar en los planetas combustible y en el planeta base, en la estación de repostaje.
  * Si el jugador se queda sin combustible “MO-233” volverá al planeta base.
  * La medida de capacidad usada para medir el combustible “MO-233” será el celemín, el cual equivale a 4,625 litros.
  * En la estación de repostaje del planeta base se recarga el combustible a una velocidad de 1000 celemines/15 minutos.
  * Salir del planeta base gasta un 25% del combustible.
  * Volver al planeta base no gasta combustible.
  * Si el monstruo te elimina, el tiempo de espera para recargar combustible se verá multiplicado por 1.5.
*	El combustible, o mejor dicho fuente de energía, de la nave de exploración será la energía eléctrica. 
  *	Esta energía se repartirá en 5 cargas.
  * Conforme la nave avanza por el planeta la energía irá disminuyendo. La energía que se gastará en función a la distancia se estimará con el testeo del juego.
  * El jugador puede gastar una carga entera para conseguir un potenciador de velocidad para escapar del monstruo o simplemente ir más rápido.
  * Si el jugador se queda sin energía volverá automáticamente a la nave. No se podrá volver a visitar el planeta, así que será conveniente no tomar muchos riesgos e ir siempre con reservas de energía.
  * Cuando la nave de exploración vuelve a la nave nodriza se recupera la energía al máximo.
  * Escanear una criatura recupera la energía al máximo.
  * Si en el planeta veneno el jugador se queda sin combustible en la nave de exploración, pierde permanentemente una carga de combustible.
*	Los planetas combustible solo se encontraran en los sistemas de 4 y 5 planetas.


## 3. Estética y arte
#### Criaturas
*	Tanto la flora como la fauna han sido creadas con Blender.
*	Hay varios tipos de criaturas:
  *	Las de tipo 1 están inspiradas en los seres de la serie Digimon en su etapa como bebés. Son redondos y botan para desplazarse.
  *	Las criaturas de tipo 2 están inspiradas en los experimentos de la serie Lilo & Stich y basadas en la anatomía de un felino. Están modeladas, animadas y texturizadas con Blender 2.8 y ayuda de Photoshop.
  *	Las de tipo 3 (no implementadas) son criaturas bípedas, con características más extrañas y alienígenas que las anteriores.
  *	A parte de estos, se planean introducir otros tipos de criaturas con características que las distinguiesen del resto.
*	Las criaturas se generan de manera procedimental, es decir, están divididas en cinco partes, de las cuáles hay cinco modelos. Estas se pueden combinar entre sí, dando un total de: (5 partes) ^ 5 modelos de cada una = 3125 combinaciones disponibles por cada tipo.
*	Las criaturas son modelos de baja poligonización para que no evitar problemas de carga en el navegador. También, al verse desde una perspectiva aérea, darles demasiado detalle a las criaturas resultaría en una pérdida de tiempo, ya que no se aprecian muchos de los detalles. A parte de esto, la baja poligonización aporta un estilo distintivo y diferenciador a la estética del videojuego.
*	Están diseñadas buscando que sean simples, fáciles de distinguir y agradables a la vista (que no transmitan agresividad). No son enemigos, así que no deben de verse como tal.

#### Planetas
*	Dependiendo del subtipo del planeta, cada uno tendrá unas características visuales distintas:
  *	Un tipo de flora característica.
  *	Uno o dos assets únicos.
  *	Una paleta de color propia.
  *	Unas texturas propias.
  *	Unas características topográficas diferentes.
* Cada uno tiene una órbita y una velocidad de rotación diferente, haciéndolos así únicos.

#### Monstruo
*	El monstruo tiene un aspecto más agresivo, ya que es la única criatura en todo el juego que ataca al jugador y de esta manera se logra una diferenciación clara respecto al resto de criaturas. 
*	Dado que aparece en el planeta muerto, se le ha dado una apariencia esquelética, su aspecto recuerda a un dragón.
+	Tiene un toque cartoon para mantener la estética del videojuego. Por ello la cabeza y la mitad superior del cuerpo son más grandes, más exageradas, y la mitad inferior más pequeña.

#### Interfaz
*	Todos los botones implementados dentro del videojuego mantienen una estética futurista acorde con la temática espacial del juego, para lograr este efecto, se ha simulado una luz de neón alrededor de los mismos. 
*	Los botones del menú principal, en cambio, se han diseñado como si fueran planetas en los que la orografía de los mismos forma los símbolos de lo que representan. Por ejemplo, el botón de jugar aparece con el símbolo de play, o el de ajustes con un engranaje
*	Para las pantallas de carga se ha optado por unos dibujos sencillos, minimalistas, que informen de manera clara al jugador de lo que está haciendo.


## 4. Trasfondo e historia
BiOdyssey es la historia de un explorador espacial que, tras ver la situación en la que se encuentra su planeta, decide viajar por el espacio para encontrar nuevos planetas y criaturas, aprender de ellos y ganar el conocimiento suficiente para recuperar la habitabilidad de su mundo.

El planeta del protagonista ha sido víctima de una horrible crisis medioambiental que lo ha dejado muerto, sin ningún tipo de señal de vida. Viendo esta situación, la única opción que ve el protagonista es tratar de revivir su hogar, para lo cual viaja por multitud de sistemas aprendiendo de la biodiversidad alienígena. Así, pretende aplicar este conocimiento para tratar de recuperar la habitabilidad de su mundo de origen.

Su nave principal está propulsada por un vanguardista combustible: el MO-233, una mezcla de moscovio y oganesón. Este combustible es completamente limpio y era generado, y desechado, como residuo al usar combustibles anteriores más contaminantes. Ahora, el protagonista ha aprendido a aprovecharlo y así, puede recorrer el espacio de manera no contaminante.

Para aprender sobre estos ecosistemas, el protagonista debe escanear a las criaturas que lo habitan. Cuando encuentra y escanea a todas las criaturas de un planeta, adquiere lo que llama “conocimiento de bioma”, este conocimiento es una representación del progreso que hace en su búsqueda por revitalizar su planeta. Llegado el momento en que consigue el suficiente, comprende el funcionamiento del bioma en cuestión y adquiere la habilidad de replicarlo en su planeta origen.


## 5. Sonido y música
La banda sonora y los efectos de sonido del videojuego han sido creados en ABLETON LIVE 10, un software multiplataforma que está estructurado en escenas y tracks.

Cada tema ha sido compuesto a partir de unos acordes base que hacen recordar a armonías típicas de videojuegos.

Con los archivos .midi de las armonías y melodías iniciales se han ido aunando y modificando los patrones para complementar temas orquestrales con simuladores VST (Philarmonik) de instrumentos reales que usan samples y FXs para darle mayor realismo. El resultado, como hemos dicho, es orquestral, pero mezclamos también plugins análogos (Sylenth) para darle un toque retro de videojuego. Todo ha sido mezclado y masterizado usando iZotope Ozone 7 para darle calidad profesional al conjunto.

Algunas de las referencias que hemos usado provienen de consolas retro como la SNES y GameCube, recordando a temas de videojuegos clásicos como The Legend of Zelda.

Todo este proceso da como resultado final varios temas que se reproducen mientras se juega dependiendo del bioma en que se encuentre el jugador, a parte de otros temas extra (para el planeta base o el menú); y efectos de sonido para las criaturas y para las acciones que realiza el jugador durante su aventura.


## 6. Comercialización
#### Audiencia objetivo
Con este título queremos llegar, en especial, a la audiencia casual de gente entre 10 y 40 años. En SampleText594 consideramos que, dado que BiOdyssey es un juego enfocado a partidas cortas y rápidas, además, la sencillez del gameplay hace que la audiencia que mejor casa con las características del juego sea la casual.

#### Diferenciación con la competencia
A pesar de que BiOdyssey bebe de otros juegos, como No Man’s Sky o Seaway, desde SampleText594 buscamos diferenciarnos de ellos aportando ideas únicas, como un gameplay más pausado, la posibilidad de terraformar tus propios planetas y la personalización que se permite.

Una de las mayores fortalezas de BiOdyssey es su editor de mapas, el cual da la posibilidad de crear planetas completamente personalizados a gusto del jugador, de esta manera, el planeta base de cada jugador es único para él, hecho a su gusto.

También, siendo como es, un juego más enfocado a móvil que a ordenador, el hecho de que el gameplay sea más pausado, sin exigir demasiada habilidad o esfuerzo, hace que sea un videojuego perfecto para jugar en ratos “muertos”, ofreciendo así, una experiencia diferente y distintiva. 

#### Modelo de negocio
BiOdyssey disfrutará de tres tipos diferentes de fuentes de ingreso: los BiOdyssey Points, las expansiones y los productos derivados.

##### BiOdyssey Points
Los BiOdyssey Points estarán disponibles para adquirir desde el lanzamiento inicial del juego. Alrededor del planeta base habrá dos instalaciones orbitando a su alrededor: el taller y la gasolinera. Su función es simple, la de adquirir mejoras y la de repostar el tanque de combustible. Si queremos hacer uso de estas instalaciones, deberemos esperar un tiempo determinado que a cada uso irá aumentando hasta un máximo de una hora y media. Los BiOdyssey Points son una moneda comprable dentro del juego que elimina estos tiempos de espera.
*	100 BiOdyssey Points recargan el 25% del combustible de la nave nodriza.
*	Es posible recargar 100 BiOdyssey Points viendo un anuncio.
*	También se puede recuperar una carga de combustible de la nave de exploración o adquirir una carga adicional gastando 100 BiOdyssey Points.
*	Los BiOdyssey Points también se podrán gastar en adquirir mejoras, tales como:
  *	El potenciador de velocidad de la nave de exploración solo consumirá media carga. Coste: 1500 BiOdyssey Points .
  *	La nave de exploración consume un 25% menos de combustible que antes. Coste 1500 BiOdyssey Points.
  
Precios:
*	100 BiOdyssey Points - 1.49 €
*	500 BiOdyssey Points - 4.99 €

##### Expansiones
Las expansiones serán contenido descargable que añadirán mejoras estéticas. Desde nuevos terrenos, paletas de colores o flora para los planetas base del jugador, como nuevas skins para las naves a nuevos tipos de criaturas. Con estas expansiones se pretende dar más opciones de personalización a los jugadores sin alterar la experiencia base del videojuego. En SampleText594 no creemos en el contenido descargable que dé ventajas a unos jugadores respecto a otros (el llamado pay to win), por eso todo el contenido descargable de BiOdyssey se limitará al apartado estético y a expansiones de carácter más banal.

Estas expansiones están programadas para lanzarse cada 3 meses a partir de la salida de BiOdyssey, y con una duración de 2 años, haciendo un total de 8 expansiones. La planificación sería la siguiente:

*	Marzo 2020 – 1 nueva skin para la nave de exploración, 1 nuevo tipo de flora, 1 nueva paleta de color y 1 nuevo bioma. Precio: 5€.
*	Junio 2020 – 1 tipo nuevo de criaturas. Precio: Gratis.
*	Septiembre 2020 – 1 nueva skin para la nave de exploración, 1 nuevo tipo de flora, 1 nueva paleta de color y 1 nuevo bioma. Precio: 5€.
*	Diciembre 2020 – más planetas bases, serán ilimitados, cuando el jugador llene un sistema entero (4 planetas) se le creará otro. Precio: 5€/planeta o 15€/sistema (4 planetas).
*	Marzo 2021 – 1 nueva skin para la nave de exploración, 1 nuevo tipo de flora, 1 nueva paleta de color y 1 nuevo bioma. Precio: 5€.
*	Junio 2021 – 1 tipo nuevo de criaturas. Precio: Gratis.
*	Septiembre 2021 – 1 nueva skin para la nave de exploración, 1 nuevo tipo de flora, 1 nueva paleta de color y 1 nuevo bioma. Precio: 5€.
*	Diciembre 2021 – posibilidad de regalar planetas entre jugadores. Precio: 5€.

##### Productos derivados
En SampleText594 consideramos que uno de los puntos fuertes de BiOdyssey es la posibilidad de diseñar mundos propios, por eso, en un futuro próximo se lanzará, partiendo del editor de planetas que tiene el juego base, una herramienta de creación de planetas. De esta manera, los desarrolladores y aficionados de BiOdyssey podrán crear fácilmente planetas únicos y personales que luego podrán utilizar como assets en sus propios proyectos. Esta herramienta saldrá al mercado a un precio de 20 €.

#### Cálculo de pérdidas y beneficios
*	Sueldos para 7 personas durante los dos años siguientes a la salida de BiOdyssey: 158.450€.
*	Precio servidor para alojar el juego durante dos años: 1.200€.

##### Caso pesimista
*	500 jugadores
*	Dichos jugadores no pagan por contenido extra
*	Ganancias: 0€
*	Pérdidas: -159.050€

Total: 0€

##### Caso probable
*	3000 jugadores
*	De esos 3000, 1000 se gastan 135€ en contenido extra = +135.000€
*	2500 compras de la herramienta de creación de planetas, a 20€ = +50.000€
*	Ganancias por los anuncios en forma de vídeo: +6.570€
*	Ganancias: +191.570€
*	Pérdidas: -159.050€

	Total: +31.320€

##### Caso optimista
*	5000 jugadores
*	Todos los jugadores se gastan 135€ en contenido extra = + 675.000€
*	5000 compras de la herramienta de creación de planetas, a 20€ = +100.000€
*	Ganancias por los anuncios en forma de vídeo: +10.950€
*	Ganancias: +785.950€
*	Pérdidas: -159.050€

	Total: +626.900€


## 7. Bibliografía
* RestClient - *AssetStore*
* OSK (teclado) - *AssetStore*
* TextMeshPro - Paquete oficial de *Unity*
* Implementación del ruido de Perlin - [*Stefan Gustavson, Karsten Schmidt, Sebastian Lague*](https://github.com/SebLague/Procedural-Planets/blob/master/Procedural%20Planet%20Noise/Noise.cs)
* ConditionalHideAttribute - *Brecht Lecluyse, Sebastian Lague*
