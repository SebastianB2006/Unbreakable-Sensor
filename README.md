# Unbreakable-Sensor
O implementare robustă și tolerantă la erori a unui senzor de temperatură în C#, dezvoltată pe principii de încapsulare si validare a datelor de intrare.
## Funcționalități principale

-**Identificator obligatoriu:** Respinge instanțierea dacă Id este gol, null sau conține doar spații albe (string.IsNullOrWhiteSpace).
-**Praguri de alarmă**: Validează intervalul de funcționare direct în constructor; dacă pragul minim este mai mare decât cel maxim (Min > Max), aruncă excepție.
-**Proprietățile de configurare** (Id, Min, Max) sunt read-only după creare.
-**Constanta Unit = "C"** definește unitatea standard a valorilor interne.
-**Dacă o citire este null** depășește pragurile configurate sau coboară sub limita fizică de $-273.15^\circ\text{C}$, execuția nu se blochează; senzorul incrementează contorul ErrorCount.
-**Înregistrează valorile valide într-o listă internă privată, expusă către exterior doar prin IReadOnlyList<double> pentru a împiedica modificarea externă.**
-**Întoarce temperatura curentă în Celsius ("C") sau o convertește în Fahrenheit ("F"), aruncând excepție pentru orice altă unitate nesuportată**.

## Exemplu de utilizare

using Provocarea02A_start;

// Inițializare senzor cu ID și limite operaționale (°C)
var sensor = new TemperatureSensor("SENZOR_01", -20.0, 80.0);

// Înregistrare citiri (acceptă valori de tip double?)
sensor.AddReading(22.5);
sensor.AddReading(25.0);
sensor.AddReading(null);   // Valoare invalidă -> Crește ErrorCount
sensor.AddReading(120.0);  // Depășește Max -> Crește ErrorCount

// Citire temperatură curentă
Console.WriteLine($"Temperatură (°C): {sensor.ReturnTemperature("C")} °C");
Console.WriteLine($"Temperatură (°F): {sensor.ReturnTemperature("F")} °F");

// Verificare erori și istoric
Console.WriteLine($"Număr erori: {sensor.ErrorCount}");
Console.WriteLine("Istoric citiri: " + string.Join(", ", sensor.History));
