using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DominoExercise;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Dominoes dominoes;

        [TestInitialize]
        public void TestInitialize()
        {
            dominoes = new Dominoes();
        }

        [TestMethod]
        public void NoDominoes()
        {
            var tiles = Array.Empty<(int,int)>();
            Assert.IsTrue(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void OneDominoChain()
        {
            var tiles = new[] { (1, 1) };
            Assert.IsTrue(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void OneDominoNoChain()
        {
            var tiles = new[] { (1, 2) };
            Assert.IsFalse(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void ThreeDominoeChain1()
        {
            var tiles = new[] { (1, 2), (2, 3), (3, 1) };
            Assert.IsTrue(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void ReverseDominoeChain1()
        {
            var tiles = new[] { (2, 1), (3, 2), (1, 3) };
            Assert.IsTrue(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void ThreeDominoeChain2()
        {
            var tiles = new[] { (3, 2), (2, 1), (1, 3) };
            Assert.IsTrue(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void ThreeDominoeChain3()
        {
            var tiles = new[] { (1, 3), (3, 2), (2, 1) };
            Assert.IsTrue(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void ThreeDominoeNoChain()
        {
            var tiles = new[] { (1, 2), (4, 1), (2, 3) };
            Assert.IsFalse(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void DisconnectedSimple()
        {
            var tiles = new[] { (1, 1), (2, 2) };
            Assert.IsFalse(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void DisconnectedDoubleLoop()
        {
            var tiles = new[] { (1, 2), (2, 1), (3, 4), (4, 3) };
            Assert.IsFalse(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void DisconnectedSingleIsolated()
        {
            var tiles = new[] { (1, 2), (2, 3), (3, 1), (4, 4) };
            Assert.IsFalse(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void NeedBacktrack()
        {
            var tiles = new[] { (1, 2), (2, 3), (3, 1), (2, 4), (2, 4) };
            // works - var tiles = new[] { (1, 2), (2, 4), (4, 2), (2, 3), (3, 1)};
            Assert.IsTrue(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void SeparateLoops()
        {
            var tiles = new[] { (1, 2), (2, 3), (3, 1), (1, 1), (2, 2), (3, 3) };
            Assert.IsTrue(dominoes.CanChain(tiles));
        }

        [TestMethod]
        public void NineElements()
        {
            var tiles = new[] { (1, 2), (5, 3), (3, 1), (1, 2), (2, 4), (1, 6), (2, 3), (3, 4), (5, 6) };
            Assert.IsTrue(dominoes.CanChain(tiles));
        }

    }
}
