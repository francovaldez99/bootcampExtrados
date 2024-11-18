int[,] Tablero = new int[8, 8];

void generarTablero()
{

for (int i = 0; i < 8; i++)
{
  

    for (int j = 0;    j < 8; j++)
    {
        Tablero[i, j] = 0;
      
       
    }

    
}
}

generarTablero();
void ImprimirTablero()
{
    for (int i = 0; i < 8; i++)
    {
        Console.WriteLine("\n _ _ _ _ _ _ _ _ _ _ _ _");

        for (int j = 0; j < 8; j++)
        { 
            Console.Write("|");

            if (Tablero[i, j] == 1) Console.Write("Q");
            else Console.Write(Tablero[i, j]);
           
            Console.Write("|");
        }
        Console.Write("");
        if (i == 7)
        {
            Console.WriteLine();

            Console.Write("_ _ _ _ _ _ _ _ _ _ _ _");

        }
    }
}

bool esSeguro(int[,] tablero,int fila , int columna)
{
    //verificar fila
    for (int i = 0; i < 8; i++)
    {
        if (tablero[fila, i] == 1) return false;
    }
    for(int j = 0; j < 8; j++)
    {
        if (tablero[j, columna] == 1) return false;
    }
  
    for (int i = fila, j = columna; i >= 0 && j >= 0; i--, j--)
    {
        if (tablero[i, j] == 1) return false;
    }
    //diagonal superior derecha
    for (int i = fila, j = columna; i >= 0 && j < 8; i--, j++)
    {
        if (tablero[i, j] == 1) return false;
    }

    return true;
}

//funcion que colocara reinas y probara la condicion 
bool probarReinas(int fila)
{   //colocacion de reinas en el tablero
   
    if (fila >= 8)
    {
    Console.WriteLine("\n se imprime el tablero con las reinas");
    ImprimirTablero();
        return true;
    }
    else
    {

    for (int col = 0; col < 8; col++) {
        if (esSeguro(Tablero, fila, col))
        {
            Tablero[fila, col] = 1;

                if (probarReinas(fila + 1))
                {
                    return true;
                }

                Tablero[fila,col]=0;
          }


    }

    }
    return false;
}

probarReinas(0);