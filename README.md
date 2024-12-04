# Felsökningsuppgift
För denna uppgift så får du ett förskapat projekt med innehåll. I detta projekt så
finns där ett flertal problem. I denna beskrivning så radas det upp hur programmet
är tänkt att fungera, och då måste du undersöka för att se så att programmet
fungerar som tänkt. Där finns ett par olika nivåer på problem som du kan stöta på.
Programflöde
Så här förväntas programmet att köras:
1. Användare frågas efter användarnamn, användare skriver in namn och
trycker enter

2. En karta ska visas direkt efter att namnet skrivits in. Till höger ska man se
spelarens namn, hp och str.

3. På kartan så ska man se väggar, och spelaren ska visas som ett grönt “P”.

4. Med WASD så ska spelaren kunna förflytta sig. W = upp, A = vänster, S = ner
och D = höger.

5. Man ska inte kunna gå in i väggarna, eller genom dem. Spelaren ska inte
kunna lämna spelplanen.

## Del 2
Ifall du blir klar lite snabbare, eller vill testa på att felsöka lite till så kan du aktivera
så att fienden ska skapas och förfölja spelaren. Flödet där då med dessa stegen blir:
1. Ifall där inte finns en fiende så ska den spawna.

2. En fiende får endast spawna om den är mer än 3 (x + y-koordinater) steg ifrån
spelaren.

3. När det finns en fiende så ska den synas på kartan som ett rött E.

4. Efter spelaren har flyttat på sig så ska fienden flytta MOT spelaren.

5. Fienden får inte gå igenom väggar och inte lämna spelplanen.

# Om uppgiften
För att klara av denna uppgift så kommer du med största förmodan gå igenom koden
som du fått själv, och försöka reda ut vad den gör. På vissa delar finns det redan
kommentarer, och på andra saknas kommentarer. Fyll på med mer kommentarer för
dig själv för att förtydliga vad koden gör.
Där finns totalt 4 stycken filer i detta projekt. I mappen som heter “Math” finns där
en struktur för Vector2, denna har inte några problem, utan är endast där för att
hjälpa. Däremot så finns det problem i Program.cs, Player.cs och i Enemy.cs. Det är
då ditt uppdrag att reda ut vad det finns för problem i dem.

**För varje problem** du hittar så måste du på något vis dokumentera, det lättaste sättet
är när du arbetar med Git är att göra en commit för VARJE problem du löser. Då
skriver du vad du löser för problem i koden, exempel på detta kan vara: “Fixed player
jump force mode”.
Glöm inte bort att man kan fixa fram debuginformation på många olika vis, ifall vårt
program säger att det kraschar av någon anledning, då kan du se vad det är för
felmeddelande, och där kan du då börja hitta grunden till problemet..