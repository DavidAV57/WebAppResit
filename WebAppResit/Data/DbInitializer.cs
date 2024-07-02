using WebAppResit.Models;
namespace WebAppResit.Data
{
    public static class DbInitializer
    {
        public static void Initializer(WebAppResitContext context)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Check if any books exist
            if (context.BookItems.Any())
            {
                return;   // DB has been seeded
            }

            var booksItems = new BookItem[]
            {
                new BookItem()
                {
                    ISBN = "1447272838",
                    ItemName = "How To Drive: The Ultimate Guide, from the Man Who Was the Stig",
                    Item_desc = "Former Top Gear Stig Ben Collins shares expert skills and wisdom refined over a twenty-year career as one of the best drivers in the world - from Le Mans Series racing to NASCAR, piloting the Batmobile and dodging bullets with James Bond. Ben's philosophy of anticipation, smoothness and speed, honed over thousands of hours of elite-level performance, is really about economy of motion - which also gives you greater control, safety and fuel efficiency. How To Drive is about driving better, not faster. Whether you've been behind the wheel for the best part of thirty years or you bought your first L-plate ten seconds ago, this is the stuff your instructor missed, your dad forgot and your mates pretend to know . . . but don't.",
                    Author = "Ben Collins",
                    Available = true,
                    Price = 19.99M
                },
                new BookItem()
                {
                    ISBN = "1407109081",
                    ItemName = "The Hunger Games",
                    Item_desc = "Sixteen-year-old Katniss Everdeen regards it as a death sentence when she is forced to represent her district in the annual Hunger Games, a fight to the death on live TV. But Katniss has been close to death before—and survival, for her, is second nature. The Hunger Games is a searing novel set in a future with unsettling parallels to our present. Welcome to the deadliest reality TV show ever...",
                    Author = "Suzanne Collins",
                    Available = true,
                    Price = 9.99M
                },
                new BookItem()
                {
                    ISBN = "0330258648",
                    ItemName = "The Hitchhiker's Guide to the Galaxy",
                    Item_desc = "One Thursday lunchtime Earth is unexpectedly demolished to make way for a new hyperspace bypass. For Arthur Dent, who has only just had his house demolished that morning, this is already more than he can cope with. Sadly, however, the weekend has only just begun. And the Galaxy is a very, very large and startling place indeed.",
                    Author = "Douglas Adams",
                    Available = true,
                    Price = 14.99M
                },
                new BookItem()
                {
                    ISBN = "9781473620308",
                    ItemName = "Word Play: A cornucopia of puns, anagrams and other contortions...",
                    Item_desc = "'No matter how eloquently a dog may bark, he cannot tell you that his parents were poor but honest.' Only words can do that. Words are magic. Words are fun. Join Gyles Brandreth - wit and word-meister, Just A Minute regular, One Show reporter, denizen of Countdown's Dictionary Corner, founder of the National Scrabble Championships, patron of The Queen's English Society, QI, Room 101, Have I Got News For You and Pointless survivor - on an uproarious and unexpected magic carpet ride around the awesome world of words and wordplay. Puns, palindromes, pangrams, Malaprops, euphemisms, mnemonics, acronyms, anagrams, alphabeticals, Tweets, verbiage, verbarrhea - if you can name it, you should find it here, along with the longest, shortest, wittiest, wildest, oldest, latest, oddest, most interesting and most memorable words in the English language - the richest, most remarkable language ever known",
                    Author = "Gyles Brandreth",
                    Available = true,
                    Price = 11.99M
                }
            };

            context.BookItems.AddRange(booksItems);
            context.SaveChanges();
        }
    }
}