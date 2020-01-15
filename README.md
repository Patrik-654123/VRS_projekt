# VRS_projekt

## Názov projektu: Rozpoznávanie gest snímačom VL53LX
### Využitý hardvér:
- DPS so štvoricou laserových diaľkových snámačov VL53LX 
- mikrokontrolér STM

<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/sensor.png" width="500" title="sensor scheme">
</p>

### Funkcia:
V snímanom poli štvorice laserových diaľkových snímačov VL53L1X, sú zaznamenávané rôzne pohyby ruky. Tieto zmeny sú spracované pomocou mikrokontroléra STM, a vyhodnotené do podoby rôznych gest. Informácia o detegovanom geste je poslaná do aplikácie v PC, ktorá beží na pozadí OS. Aplikacia je schopná ovládať užívateľské rozhranie OS, a funguje vo viacerých módoch.

### Prechod medzi jednotlivými módmi
- mód kurzoru
- uživateľský mód
<p align="center">
   <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/mode.png" width="300" title="Change mode">
</p>
Zmenu medzi jednotlivými módmi vykonáme podržnaním ruky v oblasti -change mode zone- (viď. obr.1) po dobu jednej sekundy.  

## Zväčenie zmenšenie
<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/up-down.png" width="200" title="scale-unscale">
</p>

### Zmena módu
<p align="center">
    <img src="https://github.com/Patrik-654123/VRS_projekt/blob/master/images/mode.png" width="300" title="Change mode">
</p>


