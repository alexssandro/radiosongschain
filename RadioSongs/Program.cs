using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioSongs
{
    public class Program
    {
        public static string GetFistWord(string sentence)
        {
            return sentence.Split(' ')[0];
        }

        public static string GetLastWord(string sentence)
        {
            string[] words = sentence.Split(' ');

            return words.LastOrDefault();
        }

        public static string[] FindNext(ref List<string> songs, string baseSong, string lastWord, List<string> removedSongs, List<string> ramificationExcluded)
        {
            return songs.Where(s => s.StartsWith(lastWord))
                        .Where(s => !removedSongs.Any(r => r == s))
                        .Where(s => !ramificationExcluded.Any(r => r == s))
                        .ToArray();
        }

        public static List<string> songChain(List<string> songs)
        {
            //string firstword;
            string lastword;

            var result = new List<List<string>>();
            string firstSong = songs.First();

            bool hasRamification = false;
            List<string> ramificationExcluded = new List<string>();

            do
            {
                hasRamification = false;
                lastword = GetLastWord(firstSong);
                bool hasNextSong = true;
                string matchedSong = firstSong;
                List<string> sequence = new List<string> { firstSong };
                List<string> removedNames = new List<string>() { firstSong };

                do
                {
                    hasNextSong = false;
                    string[] foundedSongs = FindNext(ref songs, matchedSong, lastword, removedNames, ramificationExcluded);

                    if (foundedSongs.Length > 1)
                    {
                        ramificationExcluded.Add(foundedSongs[0]);
                        hasRamification = true;
                    }

                    if (foundedSongs.Count() > 0 && !string.IsNullOrEmpty(foundedSongs[0]))
                    {
                        sequence.Add(foundedSongs[0]);
                        removedNames.Add(foundedSongs[0]);
                        hasNextSong = true;
                        matchedSong = foundedSongs[0];
                        lastword = GetLastWord(foundedSongs[0]);
                    }
                } while (hasNextSong);

                result.Add(sequence);

            } while (hasRamification);

            List<string> longest = result.OrderByDescending(r => r.Count)
                                         .ThenBy(r => r.Min(i => i))
                                         .FirstOrDefault();

            // Your code goes here.
            // NOTE: You may use print statements for debugging purposes, but you may
            //       need to remove them for the tests to pass.
            return longest;
        }

        static int Main(string[] args)
        {
            string line;
            List<string> songs = new List<string>();

            while ((line = Console.ReadLine()) != null)
            {
                if (line.Equals("")) continue;

                songs.Add(line);
            }

            List<string> result = songChain(songs);
            foreach (string song in result)
            {
                Console.WriteLine(song);
            }
            return 0;
        }
    }
}
