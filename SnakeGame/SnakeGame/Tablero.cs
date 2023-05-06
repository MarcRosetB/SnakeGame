using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSerpiente
{
    internal class Tablero
    {
        public readonly int Altura;
        public readonly int Anchura;
        public bool ContieneCaramelo;

        public Tablero(int altura, int anchura)
        {
            Altura = altura;
            Anchura = anchura;
            ContieneCaramelo = false;
        }
        public void DibujarTablero()
        {
            for (int i = 0; i <= Altura; i++)
            {
                Utilidades.DibujarPosicion(Anchura, i, "#");
                Utilidades.DibujarPosicion(0, i, "#");
            }
            for (int i = 0; i <= Anchura; i++)
            {
                Utilidades.DibujarPosicion(i, 0, "#");
                Utilidades.DibujarPosicion(i, Altura, "#");
            }
        }
    }
}
