- ## CO APLIKACE/HRA/BOT DĚLÁ
- ### hra se snaží zaplnit díru na trhu tower defense her a nabídnout hráčovi dobrý herní zážitek i z pohledu první osoby jenž je pro tower defense hry neobvyklý -
- ### hráč má možnost si vybrat ze škály dvou/tří (změň to vole) map, která každá nabízí jiné nepřátele a jiné taktiky 
- ### zároveň systém vln v této hře byl navržen tak aby pokaždé generoval jiné nepřátele - to znamená že kdykoliv se hráč vrátí hra mu nabídne něco nového co ještě nezažil 
- ### hra taktéž nabízí dva herní módy : Kampaň, Nekonečný
- ### Kampaň - nabízí hráčovi si zahrát herní mód s levely které mají danou délku a mají k sobě daný příběh (backstory, lore)
- ### Nekonečný - nabízí hráčovi si zahrát na mapách z kampaňového módu nekonečně dlouho - hra nemá žádnou konečnou vlnu 

- ## POPIS POUŽITÝCH TECHNOLOGIÍ
- ### použity byly : 
- ### herní engine Unity a jeho verze 2021.3 a 2022.2 
- ### program pro 3D modelování Blender 
- ### programy pro úpravu rastrové grafiky GNU Image Manipulation Program a pro tvorbu loga "Frist Studios" program Microsoft Paint
- ### Zároveň pro získání hudby byla použita stránka pixabay.com a jiné zdroje royalty free hudby 
- ### Soundtrack v hlavním menu vytvořil Thomas Mutiu a byl nalezen taktéž na platformě pixabay.com (má fakt good hudbu do her ngl)
- ### Pro některé animace jsem vytvořil stránku Mixamo a zároveň jejich mixamo auto-rig funkci
- ### Větší část assetů byla stažena z Unity Asset Store a později upravena pro potřeby hry 

- ## STRUČNÝ POPIS JAK TO FUNGUJE UVNITŘ 
- ### TL:DR - je to celkem složité a docela messy
- ### jelikož se jedná o poměrně hodně rozsáhlou videohru (na rozměry projektu a to že jsme na projektu měli strávit okolo 15 hodin) je velmi těžké popsat jak celá videohra funguje uvnitř, ale pokusím se alespoň základně
- ### Celá videohra samozřejmě běží na herním enginu Unity což velmi zjednodušuje a zrychluje práci na celé videohře - Unity kód není veřejně dostupný pouze se dá najít referenční kód pro skriptovací API Unity ve kterém jsem celý tento projekt napsal 
- ### Pro příklad : asi nejdůležitejší část hry - procedurálně generovaný systém vln nepřátel funguje následovně : 
- ### skript si převezme nepřátele a všem nepřátelům je přirazena nějaká hodnota (například medvěd má hodnotu 2 a goblin hodnotu 1 )
- ### skriptu nastavím jakou maximální hodnotu nepřátel má jedna vlna (například vlna 1 - 5, vlna 2 - 10 )
- ### skript poté pomocí funkce vytváří nepřátele v nastavené časové odchylce dokud nedosáhne hodnoty dané pro tuto vlnu - nepřátelé jsou vytvářeni náhodně a hráč ani vývojář nemá žádnou moc ovlivnit jací nepřátelé se objeví 


- ## NÁVOD NA POUŽITÍ PROJEKTU 
- ### Hra vás hned po startu načte do hlavního menu zde najdete tlačítka pro  : 
 ### Spuštění nové hry 
 ### Pokračování v naposledy vypnuté hře
 ### načtení některé z uložených pozic
 ### nastavení hry
 ### vypnutí hry 


 - ### Spuštění nové hry : 
   #### po kliknutí na tlačítko "New Game" se vás hra zeptá jak se chcete jmenovat a jakou si chcete zvolit obtížnost - Novice, Journeyman nebo Master
   #### po zvolení obtížnosti kliknete na tlačítko "Start Game" a hra vás načte přímo do mapy 
- ### Pokračovaní v naposledy vypnuté hře:
  #### po kliknutí na toto tlačítko "Continue" vám hra načte naposledy uloženou pozici
- ### Načtení uložených pozic:
  #### po kliknutí na tlačítko "Load Game" vám hra dá na výběr z vašich uložených pozic - klikněte na jednu z nich pro načtení 
- ### Nastavení hry:
  #### zde najdete různé nastavení pro hlasitost hry, grafiku, ovládání a podobně dostanete se pomocí "Settings"
- ### Vypnutí hry: 
  #### po kliknutí na tlačítko "Quit Game" se vás hra zeptá jestli to opravdu chcete udělat - po kliknutí na "Yes" se hra vypne 

- ### Samotná hra má v sobě zabudovaný tutoriál, který se přehraje každému novému hráči hned po spuštění, popřípadě se dá resetovat v nastavení hry 


- ## MOŽNÝ ROZVOJ/POPIS VYUŽITÍ 
- ### možnosti rozvoje v budoucnu jsou velmi rozsáhlé a mnoho z nich je plánováno, například může být do hry přidáno více nepřátel a nebo více budov a více map
- ### využití projektu je čistě pro pobavení lidí - hra je zábavná nikoli naučná
- ### Po dokončení projektu je plánováno hru vydat na platformu itch.io, volně dostupnou ke stažení a pro generování potencionálního finačního zisku 
