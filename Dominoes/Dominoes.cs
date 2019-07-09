using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoExercise
{
    public class Dominoes
    {
        bool chained = false;
        bool[] dominoInPlay;

        List<(int, int)> dominoesChain = new List<(int, int)>();
        List<(int, int)> dominoesContainer = new List<(int, int)>();

        public bool CanChain(IEnumerable<(int, int)> dominoes)
        {
            if (dominoes.Count() == 0)
                return true;

            dominoInPlay = new bool[dominoes.Count()];
            dominoesContainer = dominoes.ToList();

            AddDominoToChain(0);

            return chained;
        }

        void AddDominoToChain(int index)
        {
            dominoesChain.Add(dominoesContainer[index]);

            if (dominoesChain.Count == dominoesContainer.Count)         
            {
                if (dominoesChain.First().Item1.Equals(dominoesChain.Last().Item2))
                {
                    chained = true;
                    return;
                }                    
            }

            dominoInPlay[index] = true;
            int i = 0;
            foreach (var domino in dominoesContainer)
            {
                if (!dominoInPlay[i])
                {
                    if (domino.Item1.Equals(dominoesContainer[index].Item1) || 
                        domino.Item1.Equals(dominoesContainer[index].Item2) ||
                        domino.Item2.Equals(dominoesContainer[index].Item1) || 
                        domino.Item2.Equals(dominoesContainer[index].Item2))
                        AddDominoToChain(i);
                }
                i++;
            }
            dominoesChain.Remove(dominoesContainer[index]);
            dominoInPlay[index] = false;
        }
    }
}
