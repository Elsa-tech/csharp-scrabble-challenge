﻿using csharp_scrabble_challenge.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Test
{
    [TestFixture]
    public class ExtensionTests
    {

        [TestCase("{street}", 12)] //extension double word
        [TestCase("[street]", 18)] //extension triple word
        [TestCase("{quirky}", 44)] //extension double word
        [TestCase("[quirky]", 66)] //extension triple word
        [TestCase("{OXyPHEnBUTaZoNE}", 82)]
        [TestCase("[OXyPHEnBUTaZoNE]", 123)]
        public void ExtendedCriteriaTests(string word, int targetScore)
        {
            Assert.AreEqual(this.GetWordScore(word), targetScore);
        }

        private int GetWordScore(string word) => new Scrabble(word).score();

        [TestCase("{a}s", 3)]
        [TestCase("{z}alo", 23)]
        [TestCase("Els[a]", 6)]
        public void shouldGiveDoublePointForLetter(string word, int actual)
        {
            int score = this.GetWordScore(word);
            Assert.AreEqual(score, actual);
        }
    }
}
