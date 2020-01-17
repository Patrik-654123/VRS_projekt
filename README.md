# VRS_projekt

## Názov projektu: Rozpoznávanie gest snímačom VL53LX
### Využitý hardvér:
- DPS so štvoricou laserových diaľkových snámačov VL53LX 
- mikrokontrolér STM

<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/sensor.png" width="500" title="sensor scheme">
</p>

### Funkcia:
V snímanom poli štvorice laserových diaľkových snímačov VL53L1X, sú zaznamenávané rôzne pohyby ruky. Tieto zmeny sú spracované pomocou mikrokontroléra STM, a vyhodnotené do podoby rôznych gest. Informácia o detegovanom geste je poslaná do aplikácie v PC, ktorá beží na pozadí OS. Aplikacia je schopná ovládať užívateľské rozhranie OS a funguje vo viacerých módoch.

### Prechod medzi jednotlivými módmi
- mód kurzor
- uživateľský mód
<p align="center">
   <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/mode.png" width="300" title="Change mode">
</p>
Zmenu medzi jednotlivými módmi vykonáme podržnaním ruky vo vzdialenosti -change mode zone- (viď. obr.1), po dobu jednej sekundy.  

### Funkcie módu kurzor a práca s nimi
Mód kurzoru obsahuje funkcie na pracu s kurzorm v OS. 
K pohybu kurzora pristúpime: 
- podržaním ruky v oblasti -gestesture detection zone- (viď. obr.1) po dobu jednej sekundy.
- táto vzdialanosť sa následne nastavý ako východza poloha 
- kurzor potom ovládame pohybom ruky v horizontálnom smere (reprezentuje pohyb kurzora vpravo/vľavo) a vo vertikálnom smere (reprezentuje pohyb ruky hore/dolu). Jednotlivé pohyby sa nedajú kombinovať a kurzor sa pohybuje buď vertikálne alebo horizontálne
- mód obládania kurzora sa preruší akonáhle ruka opustí detegovaný priestor. Pre navrátenie do obládania je potrebné postupovať od prvého kroku
<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/hold.png" width="800" title="scale-unscale">
</p>
Okrem pohybu kurzorom sa tomto móde vykonáva aj stlačenie tlačidla v zmysle ľavý/pravý klik myši.
<p align="center">
   <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/click.png" width="500" title="Change mode">
</p>


### Funkcie uživateľského módu a práca s nimi



