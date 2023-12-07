using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    public class Hand
    {
        public List<Card> Cards = new List<Card>();
        public int Bid { get; set; }
        public int HandStrength { get; set; }
        public int Rank { get; set; }
    }
    public class Card
    {
        public int Strength { get; set; }
        public string Name { get; set; }
    }


    public class Day7
    {
        public List<Card> AvailableCards = new List<Card>()
        {
            new Card { Name = "2", Strength = 1 },
            new Card { Name = "3", Strength = 2 },
            new Card { Name = "4", Strength = 3 },
            new Card { Name = "5", Strength = 4 },
            new Card { Name = "6", Strength = 5 },
            new Card { Name = "7", Strength = 6 },
            new Card { Name = "8", Strength = 7 },
            new Card { Name = "9", Strength = 8 },
            new Card { Name = "T", Strength = 9 },
            new Card { Name = "J", Strength = 0 },
            new Card { Name = "Q", Strength = 11 },
            new Card { Name = "K", Strength = 12 },
            new Card { Name = "A", Strength = 13 },
        };

        public int Part1(string[] input)
        {
            var answer = 0;
            var allHands = new List<Hand>();


            foreach (var line in input)
            {
                var hand = new Hand();
                var split = line.Split(' ');
                var cardinput = split[0].ToCharArray();
                foreach (var c in cardinput)
                {
                    var cardd = AvailableCards.Where(x => x.Name == c.ToString()).First();
                    hand.Cards.Add(cardd);
                }
                hand.Bid = Int32.Parse(split[1]);
                allHands.Add(hand);
            }

            foreach (var hand in allHands)
            {
                hand.HandStrength = checkHandStrength(hand);
            }

            allHands = allHands.OrderByDescending(x => x.HandStrength).ToList();

            var s = allHands.GroupBy(x => x.HandStrength).ToList();
            foreach(var sameHand in s.Where(x => x.Count() > 1))
            {
                var a = sameHand.ToList();
                var hstrength = a.Select(x => x.HandStrength).FirstOrDefault();
                a.Sort((x, y) =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (x.Cards[i].Strength == y.Cards[i].Strength)
                        {
                            continue;
                        }
                        else
                        {
                            return  y.Cards[i].Strength - x.Cards[i].Strength;
                        }
                    }
                    return 0;
                });

                var indexesToReplace = new List<int>();
                foreach(var original in allHands.Where(x => x.HandStrength == hstrength))
                {
                    var idx = allHands.IndexOf(original);
                    indexesToReplace.Add(idx);
                   
                }
                for(int i = 0; i < indexesToReplace.Count; i++)
                {
                    allHands[indexesToReplace[i]] = a[i];
                }
            }
            
            for(int i = 0; i < allHands.Count; i++)
            {
                allHands[i].Rank = allHands.Count - i;
            }

            for(int i = 1; i <= allHands.Count; i++)
            {
                var bid = allHands[i-1].Bid;
                var ran = allHands[i - 1].Rank;
                answer += (allHands[i - 1].Bid * allHands[i - 1].Rank);
            }

            return answer;
        }

        public int checkHandStrength(Hand hand)
        {
            var cardCount =(
                from card in hand.Cards
                group card by card.Name into g
                select new { g.Key, Count = g.Count() }).ToList();

       
            //  Five of a kind
            if (hand.Cards.Select(x => x.Name).Distinct().Count() == 1)
            {
                return 10;
            }
            //  four of a kind
            else if (cardCount.Any(x => x.Count == 4))
            {
                return 9;
            }
            //Fullhouse
            else if (cardCount.Any(x => x.Count == 3) && cardCount.Any(x => x.Count == 2))
            {
                return 8;
            }
            // three of a kind
            else if(cardCount.Any(x => x.Count == 3))
            {
                return 7;
            }
            // two pair
            else if (cardCount.Where(x => x.Count == 2).Count() == 2)
            {
                return 6;
            }
            //one pair
            else if (cardCount.Any(x => x.Count == 2))
            {
                return 5;
            }
            return 1;
        }





        public int checkHandStrengthWithJ(Hand hand)
        {
            var cardCount = (
                from card in hand.Cards
                group card by card.Name into g
                select new { g.Key, Count = g.Count() }).ToList();

            var jCardsCount = cardCount.Where(x => x.Key == "J").Select(x => x.Count).FirstOrDefault();

            //  Five of a kind
            if (hand.Cards.Select(x => x.Name).Distinct().Count() == 1 ||
                cardCount.Any(x => x.Key != "J" && x.Count + jCardsCount >= 5)
                )
            {
                return 10;
            }
            //  four of a kind
            else if (cardCount.Any(x => x.Count == 4)
                || cardCount.Any(x => x.Key != "J" && x.Count + jCardsCount >= 4)
                )
            {
                return 9;
            }
            //Fullhouse
            var f = cardCount.Where(x => x.Key != "J" && x.Count >= 2).FirstOrDefault();
            if (cardCount.Any(x =>
                 (f != null && f.Count > 2 && f.Key != x.Key && x.Count + jCardsCount >= 2) ||
                 (f != null && f.Count == 2 && f.Key != x.Key && x.Count + jCardsCount >= 3)
                 )
                )
            {
                return 8;
            }
            // three of a kind
            else if (cardCount.Any(x => x.Count == 3 ||
            (x.Key != "J" && x.Count + jCardsCount >= 3)
            ))
            {
                return 7;
            }
            // two pair
            var p = cardCount.Where(x => x.Key != "J" && x.Count == 2).FirstOrDefault();
            if (cardCount.Where(x => x.Count == 2).Count() == 2 
                || 
                (cardCount.Any(x => p != null && p.Key != x.Key && x.Count + jCardsCount >= 2))
                )
            {
                return 6;
            }
            //one pair
            else if (cardCount.Any(x => x.Count == 2 || (x.Key != "J" && x.Count + jCardsCount >= 2)))
            {
                return 5;
            }
            return 1;
        }



        public int Part2(string[] input)
        {
            var answer = 0;
            var allHands = new List<Hand>();


            foreach (var line in input)
            {
                var hand = new Hand();
                var split = line.Split(' ');
                var cardinput = split[0].ToCharArray();
                foreach (var c in cardinput)
                {
                    var cardd = AvailableCards.Where(x => x.Name == c.ToString()).First();
                    hand.Cards.Add(cardd);
                }
                hand.Bid = Int32.Parse(split[1]);
                allHands.Add(hand);
            }

            foreach (var hand in allHands)
            {
                hand.HandStrength = checkHandStrengthWithJ(hand);
            }

            allHands = allHands.OrderByDescending(x => x.HandStrength).ToList();

            var s = allHands.GroupBy(x => x.HandStrength).ToList();
            foreach (var sameHand in s.Where(x => x.Count() > 1))
            {
                var a = sameHand.ToList();
                var hstrength = a.Select(x => x.HandStrength).FirstOrDefault();
                a.Sort((x, y) =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (x.Cards[i].Strength == y.Cards[i].Strength)
                        {
                            continue;
                        }
                        else
                        {
                            return y.Cards[i].Strength - x.Cards[i].Strength;
                        }
                    }
                    return 0;
                });

                var indexesToReplace = new List<int>();
                foreach (var original in allHands.Where(x => x.HandStrength == hstrength))
                {
                    var idx = allHands.IndexOf(original);
                    indexesToReplace.Add(idx);

                }
                for (int i = 0; i < indexesToReplace.Count; i++)
                {
                    allHands[indexesToReplace[i]] = a[i];
                }
            }

            for (int i = 0; i < allHands.Count; i++)
            {
                allHands[i].Rank = allHands.Count - i;
            }

            for (int i = 1; i <= allHands.Count; i++)
            {
                var bid = allHands[i - 1].Bid;
                var ran = allHands[i - 1].Rank;
                answer += (allHands[i - 1].Bid * allHands[i - 1].Rank);
            }

            return answer;
        }
    }
}
