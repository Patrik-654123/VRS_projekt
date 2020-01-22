# VRS_projekt

## Rozpoznávanie gest snímačom VL53L1X
### Využitý hardvér:
- DPS so štvoricou laserových diaľkových snímačov VL53L1X
- mikrokontrolér STM

<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/sensor.png" width="500" title="sensor scheme">
</p>

### Popis projektu
V snímanom poli, štvorice laserových diaľkových snímačov VL53L1X, sú zaznamenávané rôzne pohyby ruky. Tieto pohyby sú zosnímané a pomocou mikrokontroléra STM spracované. Mikrokontrolér zmeny vyhodnotí do podoby rôznych gest. Informácia o detegovanom geste je poslaná do aplikácie v PC, ktorá beží na pozadí OS. Aplikácia je schopná ovládať užívateľské rozhranie OS, a funguje vo viacerých módoch.

### Módy a prechod medzi nimi
- mód kurzor
- uživateľský mód
- mód rýchleho prepnutia
<p align="center">
   [obr1.]<img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/mode.png" width="300" title="Change mode">
</p>
Zmenu medzi jednotlivými módmi vykonáme podržnaním ruky vo vzdialenosti -change mode zone- (viď. obr.1), po dobu jednej sekundy.  

### Funkcie módu kurzor a práca s nimi
Tento mód obsahuje funkcie na prácu s kurzorom. 
K pohybu kurzora pristúpime: 
- podržaním ruky v oblasti -gestesture detection zone- (viď. obr.1) po dobu jednej sekundy
- táto vzdialanosť sa následne nastaví ako východisková poloha - v tejto polohe sa kurzor nepohybuje  
- kurzor potom ovládame pohybom ruky v horizontálnom smere (reprezentuje pohyb kurzora vpravo/vľavo), a vo vertikálnom smere (reprezentuje pohyb ruky hore/dolu), rýchlosť pohybu kurzora je úmerná vzdialanosti od východiskovej polohy. Jednotlivé pohyby sa nedajú kombinovať a kurzor sa pohybuje buď vertikálne alebo horizontálne
- mód ovládania kurzora sa preruší akonáhle ruka opustí detegovaný priestor. Pre navrátenie do ovládania kurzora, je potrebné postupovať od prvého kroku
<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/hold.png" width="850" title="scale-unscale">
</p>
Okrem pohybu kurzora sa v tomto móde vykonáva aj stlačenie tlačidla v zmysle ľavý/pravý klik myši.
Ľavý klik vykonáme pohybom ruky z ľavej strany snímača smerom vpravo, následne vľavo, mimo dosah snímača. Pri pohybe doprava však ruka nesmie vyjsť von z dosahu snímača.
Pravý klik vykonáme rovnako ako ľavý, len postupujeme z pravej strany snímača.
<p align="center">
   <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/click1.png" width="500" title="Change mode">
</p>


### Funkcie uživateľského módu a práca s nimi
Užívateľký mód obsahuje funkciu pre rolovanie a približovanie aktívneho okna OS. 
K funkcií pristúpime: 
- podržaním ruky v oblasti -gestesture detection zone- (viď. obr.1) po dobu jednej sekundy
- táto vzdialanosť sa následne nastaví ako východisková poloha - v tejto polohe sa rolovanie nevykonáva
- rolovanie dokumentu vykonáme pohybom ruky vo vertikálnom smere, pričom rýchlosť rolovania sa zvyšuje s rastúcou vzdialenosťou od východiskovej polohy. Pre približovanie dokumetu pohybujeme rukou v horizontálnom smere
- funkcia sa preruší pokiaľ počas horizontálneho pohybu ruka opustí detegovaný priestor. Pre návrat funkcionality pristupujeme od prvého kroku.
<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/hold.png" width="850" title="scale-unscale">
</p>
Okrem možnosti rolovať a približovať obsahuje užívateľský mód aj fukciu pre listovanie (prepínanie strán). Pre prepnutie listu dokumentu vpravo, vykonáme horizontálny pohyb z ľavej strany snímača smerom vpravo, pričom ruka musí vyjsť z dosahu snímaného priestoru. Pre prepnutie listu vľavo postupujeme rovnako, len pohyb začína na pravej strane a končí naľavo od snímača.
<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/left-right.png" width="300" title="scale-unscale">
</p>

### Funkcia rýchleho prepnutia
Posledným módom je mód rýchleho prepnutia obrazovky. Nastavená funkcia prepnutia však funguje aj pri uživateľskom móde a móde kurzora, kedy sa deteguje gesto v zmysle rýchleho pohybu v snímanom poli -gestesture detection zone- (viď. obr.1). Ak sa užívateľ nachádza práve v tomto móde, funguje len detegovanie spomínaného rýchleho pohybu a ostatné gestá sa nevyhodnocujú. Akcia na toto gesto sa dá zmeniť v obslužnej aplikácií, kde má užívateľ na výber z troch režimov. 


# Návod na obsluhu aplikácie
Obslužná aplikácia napísaná v jazyku C# zabezpečuje komunikáciu po sériovej linke so zariadením STM a vykonávanie príkazov na základe prijatých správ podľa typu detegovaného gesta.

### Prostredie
Po spustení aplikácia beží na pozadí, pričom je možné zo stavovej lišty vyvolať rýchle menu. Menu zobrazuje aktuálne zvolený mód a umožňuje jeho zmenu.

<p align="center">
    <img src="https://github.com/Sendrik-C/VRS_projekt/blob/master/images/bar_menu.png" width="300" title="menu">
</p>

Hlavné okno aplikácie obsahuje niekoľko prvkov vďaka ktorým máme podrobný prehľad o stave aplikácie a prijímaných dátach. V ľavej časti sa nachádza Live byte pre signalizáciu aktívneho spojenia so zariadením.
V sekcii Mode selection sa nachádzajú na výber 3 módy

<p align="center">
    <img src="https://github.com/Sendrik-C/VRS_projekt/blob/master/images/nahlad.png" width="400" title="nahlad">
</p>

- Cursor mode
- User mode
- Fast action

Posledný mód má užívateľom voliteľné 3 režimy v ktorých môže vykonávať príkazy:
- Close application: po prijatí príkazu sa zatvorí aktuálna aplikácia, ktorá beží na popredí v prostredí Windows
- Switch application: vykonaním rýchleho gesta je možné sa prepínať medzi aktuálne bežiacimi aplikáciami
- Open application: užívateľ si vyberie jednu zo štyroch preddefinovaných aplikácií, ktorá sa otvorí po prijatí príkazu

V pravom hornom rohu sa nachádza okno, ktoré obsahuje históriu prijatých príkazov a ich časovú značku. Hneď pod ním sú k dispozícii opcie pre mód kurzoru vďaka ktorým je možné nastaviť rýchlosť akou sa kurzor v danom smere bude hýbať.
Po kliknutí na tlačidlo Show data vyvoláme okno s grafom. V tomto grafe sú vykresľované vzdialenosti z každého snímača so vzorkovacou periódou 100 ms.

<p align="center">
    <img src="https://github.com/Sendrik-C/VRS_projekt/blob/master/images/nahlad_data.png" width="400" title="data">
</p>

Pri každej zmene módu je užívateľ informovaný prostredníctvom notifikácie.

<p align="center">
    <img src="https://github.com/Sendrik-C/VRS_projekt/blob/master/images/mod.png" width="300" title="mod">
</p>

## Spustenie obslužnej aplikácie a pripojenie zariadenia

- stiahnite [aplikáciu](https://github.com/Patrik-654123/VRS_projekt/blob/master/App.zip)
- po stiahnutí spustite VRS_Projekt.exe
- pripojte snímač do USB portu
- aplikácia nadviaže komunikáciu so snímačom
- všetko je pripravené
