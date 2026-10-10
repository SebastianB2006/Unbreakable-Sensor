# Unbreakable-Sensor
O implementare robustă și tolerantă la erori a unui senzor de temperatură în C#, dezvoltată pe principii de încapsulare si validare a datelor de intrare.
## Funcționalități principale

- Încapsulare: Starea internă a senzorului este protejată împotriva modificărilor externe neautorizate; limitele de operare (`Min`, `Max`) și identificatorul (`Id`) sunt de tipul read-only după instanțiere.
- Validare fizică și de interval: Respectă zero absolut (limita inferioară de -273.15, inversează automat intervalele dacă `Min > Max` și validează fiecare citire nouă.
- Monitorizare erori: Citirile invalide (`null` sau în afara limitelor admise) cresc contorul `ErrorCount` fără a întrerupe execuția programului sau a corupe starea internă.
- Istoric securizat: Înregistrează istoricul valorilor valide, expus la exterior printr-o colecție securizată de tip `IReadOnlyList<double>`.
- Conversie la cerere: Stochează datele intern exclusiv în Celsius, oferind conversie instantanee în Fahrenheit la apelare, fără a altera starea senzorului.

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
