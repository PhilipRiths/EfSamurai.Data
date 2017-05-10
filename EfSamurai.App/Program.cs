using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EfSamurai.Data;
using EfSamurai.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EfSamurai.App
{
    class Program
    {
       public SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            var program = new Program();
            program.ClearTables();
            AddSomeSamurais();
            AddOneSamuraiWithRelatedData();
            program.ListAllSamuraisById();
            program.FindSamuraiWithRealName("Kalle");
            program.ListAllQuotesOfType(QuoteTypes.Awesome);
            program.ListAllQuotesOfType_WithSamurai(QuoteTypes.Awesome);
            program.ListAllBattles(DateTime.Parse("2017-02-02"), DateTime.Parse("2017-04-04"), true);
            //Console.WriteLine("Remove all");
            Console.ReadLine();
        }


        public void ListAllBattles(DateTime from, DateTime to, bool? isBrutal)
        {
            foreach (var battle in _context.Battles)
            {
                
                if (from <= battle.StartDate && battle.EndDate >= to && isBrutal == true)
                {
                    Console.WriteLine($"{battle} is brutal within the period");
                }
                if (from < battle.StartDate && battle.EndDate > to && isBrutal == false)
                {
                    Console.WriteLine($"{battle} is not brutal within the period");

                }

            }
        }
        public void ListAllQuotesOfType_WithSamurai(QuoteTypes quoteType)
        {
            foreach (var quote in _context.Quotes)
            {
                if (quote.QuouteTypes == quoteType)
                {
                    Console.WriteLine($"{quote.SamuraiQuotes} is a {quoteType} quote by {quote.Samurai.Name}");
                }
            }
        }

        public void ListAllQuotesOfType(QuoteTypes quoteType)
        {

            foreach (var quote in _context.Quotes)
            {
                if (quote.QuouteTypes == quoteType)
                {
                    Console.WriteLine($"{quote.SamuraiQuotes}");
                }
            }
        }

        private static void AddOneSamurai()
        {
            var samuari = new Samurai { Name = "Zelda" };

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samuari);
                context.SaveChanges();
            }
        }

        public void ClearTables()
        {

            var samurais = from c in _context.Samurais select c;
            _context.Samurais.RemoveRange(samurais);

            var battles = from c in _context.Battles select c;
            _context.Battles.RemoveRange(battles);

            var battleEvents = from c in _context.BattleEvents select c;
            _context.BattleEvents.RemoveRange(battleEvents);

            var quotes = from c in _context.Quotes select c;
            _context.Quotes.RemoveRange(quotes);

            var battleLogs = from c in _context.BattleLogs select c;
            _context.BattleLogs.RemoveRange(battleLogs);
            _context.SaveChanges();

        }

        public void ListAllSamurais()
        {
            foreach (var samurai in _context.Samurais)
            {
                Console.WriteLine(" -----------------------------");
                Console.WriteLine($"|{samurai.Id }               ");
                Console.WriteLine($"|{samurai.Name}             ");
                Console.WriteLine($"|{samurai.HairStyleTypes}   ");
                Console.WriteLine(" -----------------------------");

            }
        }

        public void ListAllSamuraisByName()
        {
            var newlist = _context.Samurais.OrderBy(samurai => samurai.Name);
            foreach (var samurai in newlist)
            {
                Console.WriteLine(" -----------------------------");
                Console.WriteLine($"|{samurai.Id}               ");
                Console.WriteLine($"|{samurai.Name}             ");
                Console.WriteLine($"|{samurai.HairStyleTypes}   ");
                Console.WriteLine(" -----------------------------");

            }
        }

        public void ListAllSamuraisById()
        {
            var newlist = _context.Samurais.OrderByDescending(samurai => samurai.Id);
            foreach (var samurai in newlist)
            {
                Console.WriteLine(" -----------------------------");
                Console.WriteLine($"|{samurai.Id}               ");
                Console.WriteLine($"|{samurai.Name}             ");
                Console.WriteLine($"|{samurai.HairStyleTypes}   ");
                Console.WriteLine(" -----------------------------");

            }
        }

        private static void AddSomeSamurais()
        {
            var sams = new List<Samurai>
            {
                new Samurai {Name = "Zelda"},
                new Samurai {Name = "Hanzo"},
                new Samurai {Name = "Genji"}

            };
            using (var context = new SamuraiContext())
            {
                //context.Samurais.AddRange(SamuraiList);

                context.Samurais.AddRange(sams);

                context.SaveChanges();
            }



        }

        public static void AddOneSamuraiWithRelatedData()
        {


            var samurai = new Samurai
            {
                Name = "Zelda",
                Quotes = new List<Quotes>
                    {
                        new Quotes()
                        {

                            QuouteTypes = QuoteTypes.Awesome,
                            SamuraiQuotes = "My blade thirsts for blood"
                        }
                    },
                SecretIdentity = new SecretIdentity { Realname = "Kalle" },
                HairStyleTypes = HairStyles.Oicho,
                SamuraiBattle = new List<SamuraiBattle>
                    {
                        new SamuraiBattle
                        {Battle = GetBattle()}

                    },
            };


            using (var context = new SamuraiContext())
            {

                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }

        public void FindSamuraiWithRealName(string name)
        {

           bool isMatch = _context.Samurais.Any(p => p.SecretIdentity.Realname == name);
                if (isMatch == true)
                {
                    string foundSamurai = $"Samurai with real name {name} has been found";
                    Console.WriteLine(foundSamurai);
                }
                
                else
                {
                    var noMatch = $"Can't find a samurai with the realname {name}";
                    Console.WriteLine(noMatch);
                }
            
          
        }
        static Battle GetBattle()
        {
            return new Battle
            {
                Name = "war of hanomura",
                Brutal = true,
                BattleLog = new BattleLog()
                {
                    Name = "7000 thousand dies",

                    BattleEvents = new List<BattleEvent>()
                    {
                        new BattleEvent()
                        {

                            Description = "One of the biggest war was about to go off",
                            Summary = "Many lives was lost on that day"
                        }
                    }
                },StartDate = new DateTime(2017, 01, 01),
                EndDate = new DateTime(2017,05,09)
            };
        }


        public static void AddSomeBattles()
        {

            var battles = new List<Battle>
            {
                GetBattle()
            };
            using (var context = new SamuraiContext())
            {
                context.Battles.AddRange(battles);
                context.SaveChanges();

            }
        }

    }

}

