using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FlyWeight_Pattern_Homework;

abstract class Book {
    // I create this class because when game has 200 book this pattern saves (200 * (1 + 1 + 1 + 21) = (4.8)mb) from ram. 
    public string Name { get; set; } // 1kb
    public int Height { get; set; } // 1kb
    public int Width { get; set; } // 1kb
    public string appearence { get; set; } // 21kb
}

class Fahrenheit451 : Book {

    public Fahrenheit451() {

        // Initializing same variables for every books

        Name = "Fahrenheit451";
        Height = 100; 
        Width = 20;
        appearence = "Assets/Fahrenheit451BookDesign.png"; 
    }

    public void Display() {
        MessageBox.Show("Farenheit451 created");
    }
}

class AnimalFarm : Book {

    public AnimalFarm() {

        // Initializing same variables for every books

        Name = "AnimalFarm";
        Height = 100; 
        Width = 20;
        appearence = "Assets/AnimalFarmBookDesign.png"; 
    }

    public void Display() {
        MessageBox.Show("AnimalFarm created");
    }
}

class FlyWeightFactory {

    private Dictionary<string, Book?> _units = new();

    public Book? GetUnit(string key)  {
        Book? unit = null;


        if (_units.ContainsKey(key))
            unit = _units[key];
        else {
            
            if (key == "Fahrenheit451")
                unit = new Fahrenheit451();
            else if (key == "AnimalFarm"){
                unit = new AnimalFarm();
            }

            _units.Add(key, unit);
        }

        return unit;
    }
}


class Main {

    public Main() {
        FlyWeightFactory factory = new FlyWeightFactory();
        List<Book> units = new List<Book>();
        for(int i = 0; i < 200; i++) {
            units.Add(factory.GetUnit("Fahrenheit451")!);
            units.Add(factory.GetUnit("AnimalFarm")!);
        }

        // This Pattern totally saved 9.6 mb place from ram.
    }
}