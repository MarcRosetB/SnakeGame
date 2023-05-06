using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSerpiente
{
    internal class Serpiente
    {
        List<Posicion> Cola { get; set; }
        public Direccion Direccion { get; set; }
        public int Puntos { get; set; }

        public bool EstaViva { get; set; }

        public Serpiente(int x, int y)
        {
            
            Posicion posicionInicial = new Posicion(x, y);
            Cola = new List<Posicion>() { posicionInicial };
            Direccion = Direccion.Abajo;
            EstaViva = true;
        }

        public void DibujarSerpiente()
        {
            foreach(Posicion posicion in Cola)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Utilidades.DibujarPosicion(posicion.x, posicion.y, "S");
                Console.ResetColor();
            }
        }

        public void Morir(Tablero tablero)
        {
            Posicion primeraPosicion = Cola.First();
            PosicionEnCola(primeraPosicion.x, primeraPosicion.y);
            EstaViva = ! ((Cola.Count(a => a.x == primeraPosicion.x && a.y == primeraPosicion.y) > 1) || CabezaEnPared(tablero, Cola.First()));
        }

        private bool CabezaEnPared(Tablero tablero, Posicion primeraPosicion)
        {
            return primeraPosicion.y == 0 || primeraPosicion.y == tablero.Altura || primeraPosicion.x == 0 || primeraPosicion.x == tablero.Anchura;

        }

        public void Moverse(bool haComido)
        {
            List<Posicion> nuevaCola = new List<Posicion>();
            nuevaCola.Add(ObtenerNuevaPrimeraPosicion());
            nuevaCola.AddRange(Cola);

            if (!haComido)
                nuevaCola.Remove(nuevaCola.Last());

            Cola = nuevaCola;
        }

        private Posicion ObtenerNuevaPrimeraPosicion()
        {
            int x = Cola.First().x;
            int y = Cola.First().y;

            switch (Direccion)
            {
                case Direccion.Abajo:
                    y += 1;
                    break;
                case Direccion.Arriba:
                    y -= 1;
                    break;
                case Direccion.Derecha:
                    x += 1;
                    break;
                case Direccion.Izquierda:
                    x -= 1;
                    break;
            }
            return new Posicion(x, y);
        }

        public bool PosicionEnCola(int x, int y)
        {
            return Cola.Any(a=>a.x== x && a.y == y);
        }

        public bool ComerCaramelo(Caramelo caramelo, Tablero tablero)
        {
            if (PosicionEnCola(caramelo.Posicion.x, caramelo.Posicion.y))
            {
                Puntos += 10;
                tablero.ContieneCaramelo = false;
                return true;
            }
            return false;
        }
    }
}
