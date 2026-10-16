using System; 

namespace Ritprogrammet
{
    class Program
    {
        static void Main(string[] args)
        {
            //DEL 1: Skapa rutnätet =====
            int storlek = 10;                    // Rutnätet ska vara 10x10 rutor
            char[,] rutnät = new char[storlek, storlek];  // Tvådimensionell matris = rutnät

            // Fyll alla rutor med punkten "." så vi ser att de är tomma
            for (int y = 0; y < storlek; y++)        // den här går igenom varje rad (lodrätt)
            {
                for (int x = 0; x < storlek; x++)    // den här går igenom varje kolumn (vågrätt)
                {
                    rutnät[y, x] = '.';              // Sätt varje ruta till en punkt
                }
            }

            // ===== DEL 2: Markörens startposition =====
            int posX = 0;           // Markören börjar längst till vänster
            int posY = 0;           // Markören börjar längst upp
            char valtTecken = 'X';  // Standard-tecknet vi ritar med är ett X

            // ===== DEL 3: Huvudloop – programmet körs tills vi trycker Q =====
            while (true)  // "För alltid" – tills vi bryter loopen
            {
                Console.Clear();  // Rensa skärmen så vi får en ren vy varje gång
                SkrivUtRutnät(rutnät, posX, posY);  // Visa rutnätet på skärmen

                // Skriv ut menyn så användaren vet vad man kan göra
                Console.WriteLine("\n=== MENY ===");
                Console.WriteLine($"Valt tecken: {valtTecken}");
                Console.WriteLine("Piltangenter = Flytta");
                Console.WriteLine("Mellanslag  = Rita");
                Console.WriteLine("E           = Välj nytt tecken");
                Console.WriteLine("Q           = Avsluta");

                ConsoleKeyInfo tangent = Console.ReadKey(true);  // Läs in tangenttryckning

                // ===== Avsluta programmet =====
                if (tangent.Key == ConsoleKey.Q)
                    break;  // Hoppar ut ur loopen → programmet slutar

                // ===== Flytta markören =====
                // Höger: bara om vi INTE är längst till höger
                if (tangent.Key == ConsoleKey.RightArrow && posX < storlek - 1) posX++;
                // Vänster: bara om vi INTE är längst till vänster
                if (tangent.Key == ConsoleKey.LeftArrow && posX > 0) posX--;
                // Ner: bara om vi INTE är längst ner
                if (tangent.Key == ConsoleKey.DownArrow && posY < storlek - 1) posY++;
                // Upp: bara om vi INTE är längst upp
                if (tangent.Key == ConsoleKey.UpArrow && posY > 0) posY--;

                // ===== Välj nytt tecken =====
                if (tangent.Key == ConsoleKey.E)
                {
                    Console.Write("\nSkriv in ett tecken: ");
                    valtTecken = Console.ReadKey(true).KeyChar;  // Spara det nya tecknet
                }

                // ===== Rita på den valda rutan =====
                if (tangent.Key == ConsoleKey.Spacebar)
                {
                    rutnät[posY, posX] = valtTecken;  // Sätt tecknet på rätt position
                }
            }
        }

        // ===== DEL 4: Metod som ritar upp rutnätet på skärmen =====
        static void SkrivUtRutnät(char[,] rutnät, int markörX, int markörY)
        {
            // Gå igenom varje rad i matrisen
            for (int y = 0; y < rutnät.GetLength(0); y++)
            {
                // Gå igenom varje kolumn i raden
                for (int x = 0; x < rutnät.GetLength(1); x++)
                {
                    // Är vi på markörens position? Visa då en tom ruta istället för tecknet
                    if (x == markörX && y == markörY)
                    {
                        Console.Write("[ ]");  // Visar var markören är just nu
                    }
                    else
                    {
                        Console.Write($" {rutnät[y, x]} ");  // Skriv ut tecknet från matrisen
                    }
                }
                Console.WriteLine();  // Hoppa till nästa rad när vi är klara med en rad
            }
        }
    }
}