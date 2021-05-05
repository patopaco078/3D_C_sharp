using System;

namespace _3D_only_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool juego_activo = true;

            //posición de camara
            double position_x = 5;
            double position_y = 5;
            double position_z = 5; //profundidad

            //resolución pantalla
            float x = 110; //cantidad de pixeles en x
            float y = 60; //cantidad de pixeles en y
            bool[,] pantalla = new bool[Convert.ToInt32(x), Convert.ToInt32(y)];
            float roolY = y - 1;
            float roolX = 0;

            //mundo
            double M_x = 30;
            double M_y = 30;
            double M_z = 300;//profundidad
            bool[,,] mundo = new bool[Convert.ToInt32(M_x), Convert.ToInt32(M_y), Convert.ToInt32(M_z)];

            for (int dibujo = 0; dibujo < 290; dibujo++)
            {
                mundo[0, 10, dibujo] = true;
                mundo[10, 10, dibujo] = true;
                mundo[10, 0, dibujo] = true;
                mundo[0, 0, dibujo] = true;
            }

            mundo[5, 5, 20] = true;

            while (juego_activo)
            {
                //pantalla
                for (roolX = 0; roolX <= x && roolY >= 0; roolX++)
                {

                    if (roolX > (x - 1))
                    {
                        roolX = 0;
                        roolY--;
                        Console.Write("\n");
                    }
                    //Console.Write(roolX);
                    if (!(roolY < 0))
                    {
                        Console.Write(pixel(pixelB(pantalla[Convert.ToInt32(roolX), Convert.ToInt32(roolY)], roolX, roolY, x, y, y, position_x, position_y, position_z, mundo, M_x, M_y, M_z)));
                    }

                }
                Console.WriteLine("hacia donde ira?");

                string direction = Console.ReadLine();

                if (direction == "a")
                {
                    position_x--;
                }
                if (direction == "d")
                {
                    position_x++;
                }
                if (direction == "w")
                {
                    position_z++;
                }
                if (direction == "s")
                {
                    position_z--;
                }

                roolY = y - 1;
                roolX = 0;
                Console.Clear();

            }

        }
        static string pixel(bool p)
        {
            string y = "  "; //pixel desactivo
            if (p)
            {
                y = "██"; //pixel activo
            }
            return y;
        }
        static bool pixelB(bool p, float x, float y, float totalX, float totalY, float totalZ, double position_x, double position_y, double position_z, bool[,,] mundo, double M_x, double M_y, double M_z)
        {
            //Console.WriteLine("comienzo");
            p = false;
            bool a = true;

            //angulo del rayo
            double anguloX = (x * (1 / totalX)) - 0.5;
            double anguloY = (y * (1 / totalY)) - 0.5;
            double anguloZ = 1;

            while (a)
            {
                if (!(position_x > (M_x - 1) || position_y > (M_y - 1) || position_z > (M_z - 1) || position_x < 0 || position_y < 0 || position_z < 0))
                {
                    if (mundo[Convert.ToInt32(position_x), Convert.ToInt32(position_y), Convert.ToInt32(position_z)])
                    {
                        a = false;
                        p = true;

                    }
                }

                position_x += anguloX;
                position_y += anguloY;
                position_z += anguloZ;

                //Console.Write("X = " + position_x + " | ");
                //Console.Write("Y = " + position_y + " | ");
                //Console.Write("Z = " + position_z + " | ");

                if (position_x > (M_x - 1) || position_y > (M_y - 1) || position_z > (M_z - 1) || position_x < 0 || position_y < 0 || position_z < 0)
                {
                    a = false;
                }
            }
            //Console.WriteLine(" \ntermino");
            return p;
        }
    }
}
