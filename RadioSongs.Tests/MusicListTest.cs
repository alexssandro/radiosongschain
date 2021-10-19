using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace RadioSongs.Tests
{
    public class MusicListTest
    {
        [Fact]
        public void GivenList_ShouldReturnTheLongest_List1()
        {
            List<string> songs = new List<string>
            {
                "Bye Bye Love",
                "Bye Bye Bye",
                "Nothing at All",
                "Money for Nothing",
                "Love Me Do",
                "Do You Feel Like We Do",
                "Do You Believe in Magic",
                "Bye Bye Baby",
                "Baby Ride Easy",
                "Easy Money",
                "All Right Now"
            };

            List<string> output = Program.songChain(songs);

            output.Count.Should().Be(4);
            output[0].Should().Be("Bye Bye Love");
            output[1].Should().Be("Love Me Do");
            output[2].Should().Be("Do You Feel Like We Do");
            output[3].Should().Be("Do You Believe in Magic");
        }

        [Fact]
        public void GivenList_ShouldReturnTheLongest_List2()
        {
            List<string> songs = new List<string>
            {
                "Bye Bye Bye",
                "Bye Bye Love",
                "Nothing at All",
                "Money for Nothing",
                "Love Me Do",
                "Do You Feel Like We Do",
                "Do You Believe in Magic",
                "Bye Bye Baby",
                "Baby Ride Easy",
                "Easy Money",
                "All Right Now"
            };

            List<string> output = Program.songChain(songs);

            output.Count.Should().Be(7);

            output[0].Should().Be("Bye Bye Bye");
            output[1].Should().Be("Bye Bye Baby");
            output[2].Should().Be("Baby Ride Easy");
            output[3].Should().Be("Easy Money");
            output[4].Should().Be("Money for Nothing");
            output[5].Should().Be("Nothing at All");
            output[6].Should().Be("All Right Now");
        }

        [Fact]
        public void GivenList_ShouldReturnTheLongest_List3()
        {
            List<string> songs = new List<string>
            {
               "Bye Bye Bye",
               "Bye Bye Love",
               "Bye Bye Baby"
            };

            List<string> output = Program.songChain(songs);

            output.Count.Should().Be(2);

            output[0].Should().Be("Bye Bye Bye");
            output[1].Should().Be("Bye Bye Baby");
        }
    }
}
