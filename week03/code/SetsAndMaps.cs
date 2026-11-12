
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Find all symmetric pairs of two-character words.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> wordSet = new HashSet<string>(words);
        List<string> pairs = new List<string>();

        foreach (string word in words)
        {
            // Skip words with identical characters, such as "aa".
            if (word[0] == word[1])
            {
                continue;
            }

            // Skip words that have already been processed.
            if (!wordSet.Remove(word))
            {
                continue;
            }

            string reversedWord = $"{word[1]}{word[0]}";

            // Remove the matching reversed word and record the pair.
            if (wordSet.Remove(reversedWord))
            {
                pairs.Add($"{word} & {reversedWord}");
            }
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Summarize the degrees earned by people in the census file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            string degree = fields[3];

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine whether two words are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
   {
    word1 = word1.Replace(" ", "").ToLowerInvariant();
    word2 = word2.Replace(" ", "").ToLowerInvariant();

    if (word1.Length != word2.Length)
    {
        return false;
    }

    Dictionary<char, int> letters = new Dictionary<char, int>();

    foreach (char letter in word1)
    {
        if (!letters.ContainsKey(letter))
        {
            letters[letter] = 0;
        }

        letters[letter]++;
    }

    foreach (char letter in word2)
    {
        if (!letters.ContainsKey(letter))
        {
            return false;
        }

        letters[letter]--;

        if (letters[letter] < 0)
        {
            return false;
        }
    }

    return true;
}


    /// <summary>
    /// Retrieve daily earthquake information from USGS.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.Send(getRequestMessage);

        response.EnsureSuccessStatusCode();

        using var jsonStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        List<string> summaries = new List<string>();

        if (featureCollection?.Features == null)
        {
            return summaries.ToArray();
        }

        foreach (var feature in featureCollection.Features)
        {
            if (feature.Properties == null)
            {
                continue;
            }

            string summary =
                $"{feature.Properties.Place} - Mag {feature.Properties.Mag}";

            summaries.Add(summary);
        }

        return summaries.ToArray();
    }
}
