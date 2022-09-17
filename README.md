# OOSE StringCalculator: Unit testen

# Inleiding
Deze code is gebaseerd op de String Calculator op de [OOSE](https://bitbucket.aimsites.nl/projects/OOSEDT/repos/string-calculator-kata-ut/browse) Java versie en de 
kata van Roy Osherove, de oorspronkelijke oefening vind je op [String Calculator](https://osherove.com/tdd-kata-1/).

De stappen zoals beschreven voor de Java variant kunnen hier ook gebruikt worden, alleen zijn deze gebaseerd op .Net en Visual Studio

## Inrichting

### Framework en tools
- Git
- .Net 6.0
- C#
- Visual Studio 2022 (elke versie) of Jetbrains Rider
- Nuget

### Project

- StringCalculator
- StringCalculatorTest

Alle benodigde packages worden via Nuget geinstalleerd. De inhoud van de branches komen overeen met de hierboven genoemde Java variant.

# TDD
In test-driven development (TDD) worden testen gebruikt als uitvoerbare specificaties voordat de daadwerkelijke code wordt geschreven.
Red-Green-Refactor.


## Stappen 

### Stap_1a
- Maak het project aan voor het te bouwen product: StringCalculator
- Voeg de Calculator class toe. Hier komt de daadwerkelijke functionaliteit (business logica).
- Maak een Test project aan
- Voeg de eerste Add methode toe aan de Calculator class. Maar nog implementatie van de methode!
- Voeg een eerste unittest toe aan de Test class. EmptyStringReturnsZero().
- Voer de test uit. Deze zal falen! 
- In de volgende stap gaan we business logica toevoegen.

### Stap_1b
- Schrijf de logica zodat de test EmptyStringReturnsZero() slaagt.
- Voer de test opnieuw uit. Green!

### Stap_1c
- Schrijf de overige unittesten zodat alle condities worden getest.
- De logica kan ook een Error opgooien. Schrijf een test die ook deze error controleert!

### Stap_2a
- Breidt de test uit met een unittest die de som berekent van 3 getallen.
- Voer de test uit. Waarom faalt deze?

### Stap_2b
- Groen: Refactored, StringCaulator had teveel verantwoordelijkheden. Het parsen van de string naar een lijst van integer is een aparte class (had ook functie kunnen zijn) geworden, 
de calculator doet alleen nog het rekenwerk.

### Stap_3
- Schrijf een test die test of de Add method een lege regel tussen de nummers kan verwerken. ok: “1\n2,3” (som = 6).
- Schrijf nu de code zodat de test groen wordt.