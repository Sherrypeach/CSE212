using System;
using System.Collections.Generic;

public class Translator
{
    public static void Run()
    {
        // Create a new Translator (English to German)
        var englishToGerman = new Translator();

        // Add translations
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        // Try translating some words
        Console.WriteLine($"Car -> {englishToGerman.Translate("Car")}");
        Console.WriteLine($"Plane -> {englishToGerman.Translate("Plane")}");
        Console.WriteLine($"Train -> {englishToGerman.Translate("Train")}"); // not found
    }

    // Dictionary to store word translations
    private Dictionary<string, string> _words = new();

    // Add a word and its translation
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord;
    }

    // Translate a word or return "???" if not found
    public string Translate(string fromWord)
    {
        if (_words.ContainsKey(fromWord))
        {
            return _words[fromWord];
        }
        return "???";
    }
}
