using System;
using System.Linq;
using System.Collections.Generic;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> bombEffect = new Queue<int>(firstInput);
            Stack<int> bombCasing = new Stack<int>(secondInput);
            Dictionary<string, int> craftedBombsList = new Dictionary<string, int>();

            int daturaBomb = 40;
            int cherryBomb = 60;
            int smokeBomb = 120;

            int daturaCounter = 0;
            int cherryCounter = 0;
            int smokeCounter = 0;

            bool isDone = false;

            while (bombEffect.Count > 0
                && bombCasing.Count > 0
                && isDone == false)
            {
                int currentEffect = bombEffect.Peek();
                int currentCasing = bombCasing.Peek();
                int currentSum = currentEffect + currentCasing;

                if(daturaCounter >= 3
                    && cherryCounter >= 3
                    && smokeCounter >= 3)
                {
                    isDone = true;
                    break;
                }

                if (currentSum == daturaBomb)
                {
                    daturaCounter++;
                    if (craftedBombsList.ContainsKey("Datura Bombs"))
                    {
                        craftedBombsList["Datura Bombs"] += 1;
                        bombEffect.Dequeue();
                        bombCasing.Pop();
                        continue;
                    }
                    craftedBombsList.Add("Datura Bombs", 1);
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else if (currentSum == cherryBomb)
                {
                    cherryCounter++;
                    if (craftedBombsList.ContainsKey("Cherry Bombs"))
                    {
                        craftedBombsList["Cherry Bombs"] += 1;
                        bombEffect.Dequeue();
                        bombCasing.Pop();
                        continue;
                    }
                    craftedBombsList.Add("Cherry Bombs", 1);
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else if (currentSum == smokeBomb)
                {
                    smokeCounter++;
                    if (craftedBombsList.ContainsKey("Smoke Decoy Bombs"))
                    {
                        craftedBombsList["Smoke Decoy Bombs"] += 1;
                        bombEffect.Dequeue();
                        bombCasing.Pop();
                        continue;
                    }
                    craftedBombsList.Add("Smoke Decoy Bombs", 1);
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else
                {
                    bombCasing.Pop();
                    bombCasing.Push(currentCasing - 5);
                }
            }
            if (isDone)
            {
                Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine($"You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",bombEffect)}");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: empty");
            }

            if (bombCasing.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}"); 
            }
            else
            {
                Console.WriteLine($"Bomb Casings: empty");
            }

            foreach (var item in craftedBombsList.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            //All the instructions were followed correctly
            //Judge score and expected outcome is different then the task instructions
        }
    }
}
