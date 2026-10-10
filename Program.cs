using System.ComponentModel;
using Provocarea02A_start;
TemperatureSensor s1 = new TemperatureSensor("senzor1", -20, 100);
TemperatureSensor s2 = new TemperatureSensor("senzor2", 0, 200);
//adauga prima valoare
s1.AddReading(15);
s2.AddReading(10);
//adauga a doua valoare
s1.AddReading(20);
s2.AddReading(15);

//adauga valoare eronata
s1.AddReading(200);
s2.AddReading(300);
s1.AddReading(-300);
//afiseaza valoare curenta in C
Console.WriteLine(s1.ReturnTemperature());
//afiseaza valoarea curenta in F
Console.WriteLine(s2.ReturnTemperature("F"));
//afiseaza istoricul temperaturilor
Console.WriteLine($"Istoricul senzorului:{s1.Id}");
foreach(double temp in s1.History)
{
    Console.WriteLine($"{temp} C");
}
Console.WriteLine($"Istoricul senzorului:{s2.Id}");
foreach(double temp in s2.History)
{
    Console.WriteLine($"{temp} C");
}
//Erori
Console.WriteLine($"Erori gasite in senzorul {s1.Id}:{s1.ErrorCount}");
Console.WriteLine($"Erori gasite in senzorul {s2.Id}:{s2.ErrorCount}");

//Praguri inversate
TemperatureSensor s3 = new TemperatureSensor("senzor3", 200, -20);
//sub zero absolut
s1.AddReading(-500);
//fara identitate
TemperatureSensor s4 = new TemperatureSensor("", -20, 100);
