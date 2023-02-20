using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace Scoreboard
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //Edwin Manuel Vazquez Vega
            //Febrero 12, 2023
            //Mi programa es de un Scoreboard
            //El README explica una parte del codigo que esta dificil
            int[] points = { 2000, 3000, 4000, 5500, 9000, 3500, 8000, 4600, 7000, 2345 };
            string[] username = { "Edwin", "Juan", "Pedro", "Maria", "Andre", "Brenda", "Carmen","Lopez", "Gustavo", "Emanuel", "Alturo" };
            int tempNum, tempNum2;
            int attempts = 0;
            string tempName, tempName2;
            string input = "na";

            //Buble Sorting
            //Ordenera los numeros a mayor a menor
            for (int i = 0; i < username.Length-1; i++)//Reste meno uno al primer loop y meno dos en el segundo loop porque sino se pasa
            {
                for (int e = 0; e < username.Length - 2; e++)
                {
                    if (points[e] < points[e + 1])
                    {
                        tempNum = points[e];
                        points[e] = points[e + 1];
                        points[e + 1] = tempNum;
                    }
                }
            }



            while (input != "E")//Menu
            {
                //Scoreboard
                Console.WriteLine("Welcome to my ScoreBoard");
                Console.WriteLine();
                Console.WriteLine("Usernames:".PadRight(12) + "Score:".PadLeft(4));

                for (int i = 0; i < username.Length-1; i++)//reste uno porque se pasa
                {
                    
                    Console.WriteLine(username[i].PadRight(12) + " " + points[i].ToString().PadLeft(1));
                }

                Console.WriteLine();
                Console.WriteLine("Instructions:");

                Console.WriteLine("The username needs to be less then 16 character. The score needs to be less then 9999 and larger then 0");
                Console.Write("Enter [N] New Score or [E] Exit:");
                input = Console.ReadLine().ToUpper();


                if (input == "N")
                {
                        
                        Console.Write("Username: ");
                        string usernameinput = Console.ReadLine();
                        int usernamelength = usernameinput.Length;

                        while(usernamelength < 0 || usernamelength > 16)
                        {
                            Console.WriteLine("Please enter a valid length of letters");

                            usernameinput = Console.ReadLine();
                            usernamelength = new int();
                            usernamelength = usernameinput.Length;
                        }

                        Console.Write("Score: ");
                        int scoreinput;

                        while(!int.TryParse(Console.ReadLine(), out scoreinput) || scoreinput<0 || scoreinput>9999)
                        {

                            Console.WriteLine("Please enter a valid length of number");

                        }


                        Console.Clear();
                        //Moviendo los numeros
                        //Arriba para bajo
                        for (int e = 0; e <= 8; e++)
                        {
                            if(attempts == 8)
                            {

                                e += 1;
                                if (scoreinput > points[e])
                                {
                                    points[e] = scoreinput;
                                    break;
                                }
                                
                            }
                            
                            if (scoreinput > points[e])//Va a comparar si el scoreinput es mayor que los Puntos
                            {
                                tempNum = points[e];//Gualdad la posicion que esta el array.
                                tempNum2 = points[e + 1];//Gualda la posciondel proximo array.

                                tempName = username[e];
                                tempName2 = username[e + 1];

                                points[e] = scoreinput;//La posicion de este array es igual a el input del usario
                                username[e] = usernameinput;

                                points[e + 1] = tempNum;//La posicion del proximo array ahora tiene el valor del tempNum(point[e])
                                username[e + 1] = tempName;

                                e += 1;

                                while (e <= 8)
                                {      
                                         tempName = username[e + 1];//Gualdamos la posicion del proximo array en tempName
                                         username[e + 1] = tempName2;//Ahora el proximo array va tener la posicion
                                         tempName2 = tempName;//El valor que tiene tempName ahora lo tiene tempName2
                                         //Se hace lo mismo con los puntos

                                         tempNum = points[e + 1];
                                         points[e+1] = tempNum2;
                                         tempNum2 = tempNum;

                                    e++;
                                    attempts += 1;  
                                    
                                }

                            }
                           
                          
                        }


                }

                      else if (input == "E")
                      {
                          Console.Write("Have a nice day");
                      }
                      else
                      {
                          Console.WriteLine("Invalid input, press any key");
                          Console.ReadKey();
                          Console.Clear();

                      }

            }



        }
    }
}