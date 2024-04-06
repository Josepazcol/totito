using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

public class totito
{
    private const int DIMENSION = 3;
    private char[,] tablero = new char[DIMENSION, DIMENSION];
    private bool turnoJugador1 = true;

    public void IniciarJuego()
    {
        for (int i = 0; i < DIMENSION; i++)
        {
            for (int j = 0; j < DIMENSION; j++)
            {
                tablero[i, j] = ' ';
            }
        }

        while (!HayGanador() && !EstaLleno())
        {
            MostrarTablero();
            RealizarJugada();
            CambiarTurno();
        }

        MostrarTablero();
        if (HayGanador())
        {
            Console.WriteLine("¡{0} ha ganado!", turnoJugador1 ? "Jugador 1" : "Jugador 2");
        }
        else
        {
            Console.WriteLine("Empate!");
        }
    }

    private void MostrarTablero()
    {
        for (int i = 0; i < DIMENSION; i++)
        {
            for (int j = 0; j < DIMENSION; j++)
            {
                Console.Write(" {0} ", tablero[i, j]);
            }
            Console.WriteLine();
        }
    }

    private void RealizarJugada()
    {
        int fila, columna;

        do
        {
            Console.WriteLine("Ingrese la fila (1-{0}): ", DIMENSION);
            fila = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Ingrese la columna (1-{0}): ", DIMENSION);
            columna = int.Parse(Console.ReadLine()) - 1;
        }
        while (!PosicionValida(fila, columna));

        tablero[fila, columna] = turnoJugador1 ? 'X' : 'O';
    }

    private void CambiarTurno()
    {
        turnoJugador1 = !turnoJugador1;
    }

    private bool HayGanador()
    {
        // Filas
        for (int i = 0; i < DIMENSION; i++)
        {
            if (tablero[i, 0] == tablero[i, 1] && tablero[i, 1] == tablero[i, 2] && tablero[i, 0] != ' ')
            {
                return true;
            }
        }

        // Columnas
        for (int i = 0; i < DIMENSION; i++)
        {
            if (tablero[0, i] == tablero[1, i] && tablero[1, i] == tablero[2, i] && tablero[0, i] != ' ')
            {
                return true;
            }
        }

        
        if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2] && tablero[0, 0] != ' ')
        {
            return true;
        }

        if (tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0] && tablero[0, 2] != ' ')
        {
            return true;
        }

        return false;
    }

    private bool EstaLleno()
    {
        for (int i = 0; i < DIMENSION; i++)
        {
            for (int j = 0; j < DIMENSION; j++)
            {
                if (tablero[i, j] == ' ')
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool PosicionValida(int fila, int columna)
    {
        return fila >= 0 && fila < DIMENSION && columna >= 0 && columna < DIMENSION && tablero[fila, columna] == ' ';
    }

    public static void Main(string[] args)
    {
        totito juego = new totito();
        juego.IniciarJuego();
    }
}
