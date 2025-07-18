using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
/// <summary>
/// The words parameter contains a list of two-character 
/// words (lowercase, no duplicates). Using sets, this function finds
/// all symmetric pairs. For example, "am" and "ma" form a pair.
/// Returns an array of strings like "am & ma".
/// 
/// Constraints:
/// - O(n) time using a HashSet
/// - Ignore words like "aa" (letters are the same)
/// - Order of output and pair words doesn't matter
/// </summary>
public static string[] FindPairs(string[] words)
{
    var result = new List<string>();              // List to store the final output
    var wordSet = new HashSet<string>(words);     // Use a HashSet for O(1) lookups
    var usedPairs = new HashSet<string>();        // To avoid duplicate entries like "ab & ba" and "ba & ab"

    foreach (string word in words)
    {
        // Skip words where both characters are the same (e.g., "aa")
        if (word[0] == word[1])
            continue;

        // Reverse the word, e.g., "am" => "ma"
        string reversed = new string(new[] { word[1], word[0] });

        // Create a canonical form of the pair by sorting alphabetically.
        // This prevents adding both "ab & ba" and "ba & ab" separately.
        string canonical = word.CompareTo(reversed) < 0
            ? $"{word} & {reversed}"
            : $"{reversed} & {word}";

        // If the reversed word exists and we haven't used this pair yet
        if (wordSet.Contains(reversed) && !usedPairs.Contains(canonical))
        {
            result.Add(canonical);        // Add to result
            usedPairs.Add(canonical);     // Mark this pair as used
        }
    }

    // Return the list of symmetric pairs as an array
    return result.ToArray();
}


  /// <summary>
/// Read a census file and summarize the degrees (education)
/// earned by those contained in the file. The summary
/// is stored in a dictionary where the key is the degree
/// and the value is the number of people with that degree.
/// Degree is in the 4th column (index 3). No header row.
/// </summary>
public static Dictionary<string, int> SummarizeDegrees(string filename)
{
    var degrees = new Dictionary<string, int>();

    // Read each line from the file
    foreach (var line in File.ReadLines(filename))
    {
        var fields = line.Split(","); // Split the line by commas

        if (fields.Length >= 4) // Make sure there are at least 4 fields
        {
            string degree = fields[3].Trim(); // Get the 4th column (index 3)

            // If degree already exists in dictionary, increment the count
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                // Otherwise, add it with a count of 1
                degrees[degree] = 1;
            }
        }
    }

    return degrees;
}


 /// <summary>
/// Determine if 'word1' and 'word2' are anagrams.
/// An anagram has the exact same letters with the same frequency.
/// Spaces and letter casing should be ignored.
/// </summary>
public static bool IsAnagram(string word1, string word2)
{
    // Remove spaces and convert to lowercase to normalize input
    word1 = word1.Replace(" ", "").ToLower();
    word2 = word2.Replace(" ", "").ToLower();

    // If lengths don’t match, they can't be anagrams
    if (word1.Length != word2.Length)
        return false;

    // Dictionary to count letter frequencies in word1
    var letterCounts = new Dictionary<char, int>();

    // Count each letter in word1
    foreach (char c in word1)
    {
        if (letterCounts.ContainsKey(c))
        {
            letterCounts[c]++;
        }
        else
        {
            letterCounts[c] = 1;
        }
    }

    // Subtract letter counts based on word2
    foreach (char c in word2)
    {
        if (!letterCounts.ContainsKey(c))
        {
            return false; // Letter in word2 not found in word1
        }

        letterCounts[c]--;

        if (letterCounts[c] < 0)
        {
            return false; // More of this letter in word2 than in word1
        }
    }

    // If all values in the dictionary are zero, it's an anagram
    return true;
}

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}