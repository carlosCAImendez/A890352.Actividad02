using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
   
    class Program
    {
        static void Main(string[] args)
        {
           
            // Inicio punto A
            int repeticion;
            int[,] catalogo;
            bool menoracero0;
            bool menoracero1;
            bool menoracero2;
            bool menoracero3;
            bool menoracero4; 
            int id, stockk; 
            Console.WriteLine("Usted va a ingresar un catalogo de productos");
           
            do
            {
                Console.WriteLine("Ingrese el numero de productos a ingresar:");
                repeticion = Convert.ToInt32(Console.ReadLine());
                if (repeticion <= 0)
                {
                Console.WriteLine("No se puede ingresar un valor igual o menor a 0");
                    menoracero0 = false;
                }
                else menoracero0 = true;
            } while (menoracero0 == false);

            catalogo = new int[repeticion, 2];
          
                for (int i = 0; i < repeticion; i++)
            {
                do
                {
                    // También se podria controlar que el id no sea repetido.
                    Console.WriteLine("Ingrese el id del producto");
                    id = Convert.ToInt32(Console.ReadLine());
                    if (id <= 0)
                    {
                        Console.WriteLine("No se puede ingresar un valor igual o menor a 0");
                        menoracero1 = false;
                    }
                    else menoracero1 = true;
                    
                } while (menoracero1 == false);

                do
                {
                    Console.WriteLine("Ingrese el stock");
                stockk = Convert.ToInt32(Console.ReadLine());
                if (stockk <= 0) 
                    { 
                        Console.WriteLine("No se puede ingresar un valor igual o menor a 0");
                        menoracero2 = false;
                    }
                    else menoracero2 = true;
                } while (menoracero2 == false);
                catalogo[i, 0] = id;
                catalogo[i, 1] = stockk;
            }
         
            // Fin punto A

            // inicio punto B
            bool salir = false;
           
            Console.WriteLine("Usted va a ingresar una cantidad de pedidos y entregas de producto");
            Console.WriteLine("Para terminar de ingresar los datos, escriba:´salir`");
            do
            {
                int cantPedido, cantEntrega;
                Console.WriteLine("Para terminar escriba:´salir`");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Ingrese el id del producto:");
                var idProducto = Console.ReadLine();
              
                if (idProducto == "salir") { salir = true; break; }
               
                do
                {
                    Console.WriteLine("Ingrese la cantidad de pedidos:");
                     cantPedido = Convert.ToInt32(Console.ReadLine());
                    if (cantPedido < 0)
                    {
                        Console.WriteLine("No se puede ingresar un valor menor a 0");
                        menoracero3 = false;
                    }
                    else menoracero3 = true;
                } while (menoracero3 == false);

                do
                {
                    Console.WriteLine("Ingrese la cantidad de entregas:");
                     cantEntrega = Convert.ToInt32(Console.ReadLine());
                    if (cantEntrega < 0)
                    {
                        Console.WriteLine("No se puede ingresar un valor menor a 0");
                        menoracero4 = false;
                    }
                    else menoracero4 = true;
                } while (menoracero4 == false);




                // Iniciamos la busqueda del producto y procedemos a sumar y restar

                for (int i = 0; i < catalogo.GetLength(0); i++)
                {

                    if (catalogo[i,0] == Convert.ToInt32(idProducto))
                    {
                        /*
                        catalogo[i, 1] = catalogo[i, 1] - cantPedido;
                        catalogo[i, 1] = catalogo[i, 1] + cantEntrega;
                        */
                        // Lo hago en una variable temporal para no afectar el stock sin antes comprobar
                        // si es menor a 0.
                        int operatoria = ( catalogo[i, 1] - cantPedido) + cantEntrega;

                        if (operatoria < 0)
                        {
                            Console.WriteLine("El stock del producto no puede ser menor a 0.");
                            break;
                        }
                        else
                        {
                            catalogo[i, 1] = operatoria;
                        }

                        
                    }
                    
                }

            } while (salir == false);

            // Fin Punto B

            //Inicio Punto C
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Stock de todos los productos:");
            for (int i = 0; i < repeticion; i++)
            {
                Console.WriteLine("El producto {0} tiene {1} unidades", catalogo[i, 0], catalogo[i, 1]);
            }

            // Fin punto C
                Console.Read();
        }
    }
}
