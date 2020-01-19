# VRS_projekt

## Rozpoznávanie gest snímačom VL53LX
### Využitý hardvér:
- DPS so štvoricou laserových diaľkových snímačov VL53LX 
- mikrokontrolér STM

<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/sensor.png" width="500" title="sensor scheme">
</p>

### Popis:
V snímanom poli štvorice laserových diaľkových snímačov VL53L1X, sú zaznamenávané rôzne pohyby ruky. Tieto pohyby sú zosnímané a pomocou mikrokontroléra STM spracované. Mikrokontrolér zmeny vyhodnotí do podoby rôznych gest. Informácia o detegovanom geste je poslaná do aplikácie v PC, ktorá beží na pozadí OS. Aplikácia je schopná ovládať užívateľské rozhranie OS, a funguje vo viacerých módoch.

### Módy a prechod medzi nimi
- mód kurzor
- uživateľský mód
- mód rýchleho prepnutia
<p align="center">
   <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/mode.png" width="300" title="Change mode">
</p>
Zmenu medzi jednotlivými módmi vykonáme podržnaním ruky vo vzdialenosti -change mode zone- (viď. obr.1), po dobu jednej sekundy.  

### Funkcie módu kurzor a práca s nimi
Tento mód obsahuje funkcie na prácu s kurzorom. 
K pohybu kurzora pristúpime: 
- podržaním ruky v oblasti -gestesture detection zone- (viď. obr.1) po dobu jednej sekundy
- táto vzdialanosť sa následne nastavý ako východzia poloha 
- kurzor potom ovládame pohybom ruky v horizontálnom smere (reprezentuje pohyb kurzora vpravo/vľavo), a vo vertikálnom smere (reprezentuje pohyb ruky hore/dolu). Jednotlivé pohyby sa nedajú kombinovať a kurzor sa pohybuje buď vertikálne alebo horizontálne
- mód obládania kurzora sa preruší akonáhle ruka opustí detegovaný priestor. Pre navrátenie do ovládania kurzora je potrebné postupovať od prvého kroku
<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/hold.png" width="800" title="scale-unscale">
</p>
Okrem pohybu kurzora sa tomto móde vykonáva aj stlačenie tlačidla v zmysle ľavý/pravý klik myši.
Ľavý klik vykonýme pohybom ruky z ľavej strany snímača smerom vpravo, následne vľavo, mimo dosah snímača. Pri pohybe do prava však ruka nesmie vyjsť von z dosahu snímača.
Pravý klik vykonáme rovnako ako pravý, len postupujeme z pravej strany snímača.
<p align="center">
   <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/click.png" width="500" title="Change mode">
</p>


### Funkcie uživateľského módu a práca s nimi
Užívateľký mód obsahuje funkciu pre rolovanie a približovanie aktívneho okna OS. 
K funkcií pristúpime: 
- podržaním ruky v oblasti -gestesture detection zone- (viď. obr.1) po dobu jednej sekundy
- táto vzdialanosť sa následne nastavý ako východza poloha 
- rolovanie dokumentu vykonáme pohybom ruky vo vertikálnom smere. Pre približovanie dokumetu pohybujeme rukou v horizontálnom smere
- funkcia sa preruší pokiaľ počas horizontálneho pohybu ruka opustí detegovaný priestor. Pre návrat opäť pristupujeme od prvého kroku.
<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/hold.png" width="800" title="scale-unscale">
</p>
Okrem možnosti rolovať a približovať obsahuje užívateľský mód aj fukciu pre listovanie. Pre prepnutie listu dokumentu vpravo, vykonáme horizontálny pohyb z ľavej strany snímača smerom vpravo, pričom ruka musí vyjsť z dosahu snímaného priestoru. Pre prepnutie listu vľavo postupujeme rovnako, len pohyb začína na pravej strane a končí na ľavej strane snímača.
<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/left-right.png" width="300" title="scale-unscale">
</p>

### Funkcia rýchleho prepnutia
Posledným módom aplikácie je mód rýchleho prepnutia obrazovky. Ak snímač deteguje pohyb v oblasti -gestesture detection zone- (viď. obr.1), aplikácia zavrie aktuálne otvorené okno. 





