using System.Data.Common;
using System.Dynamic;

namespace Provocarea02A_start;
public class TemperatureSensor
{
    public double Min{get;}
    public double Max{get;}
    private double Value;
    public const string Unit = "C";
    private readonly List<double> _history = new List<double>();
    public IReadOnlyList<double> History
    {
        get
        {
            return _history.AsReadOnly();
        }
    }
    public int ErrorCount {get; private set;}
    public string Id{get;}
    public TemperatureSensor(string Id, double Min, double Max)
    {
        if(!string.IsNullOrWhiteSpace(Id))
            this.Id=Id;
        else
        {
            throw new ArgumentException("Id gol");
        }
        if((Min > Max) || Min<=-273.15)
        {
            throw new ArgumentException("Praguri inversate");            
            //double temp;
            //temp=Min;
            //Min=Max;
            //Max=temp;
        }
        //else if ( Min == Max)
        //{
            //Max = Max + 1.0;
        //}
        //if (Min<=-273.15)
        //{
            //throw new ArgumentException("Valoare Imposibila");
        //}
        this.Min = Min;
        this.Max=Max;
    }
    public void AddReading(double? Valoare)
    {
        if(Valoare == null)
        {
            ErrorCount+=1;
            return;
        }
        double val = (double)Valoare;
        
        if(val < Min || val>=Max || val <=-273.15)
        {
            ErrorCount+=1;
            return;
        }
        this.Value = val;
        _history.Add(val);
    }
    public double ReturnTemperature(string unit = "C")
    {
        if(unit=="F")
        {
            return Value * 1.8 + 32.0;
        }
        if(unit=="C")
        {
            return Value;
        }
        throw new ArgumentException("unitate invalida");

    }

}
