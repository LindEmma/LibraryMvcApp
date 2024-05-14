using LibraryMvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMvcApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            Console.WriteLine("SeedData method is being executed.");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.Migrate();

                SeedBooks(context);
            }
        }
        //method to seed books to database
        private static void SeedBooks(ApplicationDbContext context)
        {
            //adds the books if the table is empty
            if (!context.Books.Any())
            {
                var books = new List<Book>
                {
                // Skönlitteratur
                new Book
                    {
                        BookName = "Mitt sanna jag",
                        Author = "Tara Westover",
                        Genre = "Skönlitteratur",
                        BookDescription = "En gripande självbiografisk roman om en kvinnas resa från en isolerad barndom i en mormonfamilj till akademisk framgång och personlig frigörelse.",
                        ReleaseYear = new DateTime(2018, 2, 20),
                        InStock = true,
                        ISBN = "9781501161307"
                    },
                new Book
                    {
                        BookName = "Norwegian Wood",
                        Author = "Haruki Murakami",
                        Genre = "Skönlitteratur",
                        BookDescription = "En lyrisk roman om kärlek och förlust, satt mot bakgrund av 1960-talets Japan. Murakamis mästerliga berättande tar läsarna på en emotionell resa genom en ung mans upplevelse av sorg och återhämtning.",
                        ReleaseYear = new DateTime(1987, 9, 4),
                        InStock = true,
                        ISBN = "9780099280099"
                    },
                new()
                    {
                        BookName = "To Kill a Mockingbird",
                        Author = "Harper Lee",
                        Genre = "Fiction",
                        BookDescription = "A novel set in the American South during the 1930s, focusing on the Finch family, with particular emphasis on the trial and conviction of an innocent black man accused of raping a white woman.",
                        ReleaseYear = new DateTime(1960, 7, 11),
                        InStock = true,
                        ISBN = "9780061120084"
                    },

                // Deckare
                new Book
                    {
                        BookName = "Män som hatar kvinnor",
                        Author = "Stieg Larsson",
                        Genre = "Deckare",
                        BookDescription = "Den första boken i Millennium-trilogin introducerar läsarna till journalisten Mikael Blomkvist och hackaren Lisbeth Salander när de samarbetar för att lösa ett mystiskt försvinnande. Fylld med spänning och intriger, är detta en modern klassiker inom deckargenren.",
                        ReleaseYear = new DateTime(2005, 8, 23),
                        InStock = true,
                        ISBN = "9780307269751"
                    },
                new Book
                    {
                        BookName = "Sherlock Holmes: A Study in Scarlet",
                        Author = "Arthur Conan Doyle",
                        Genre = "Deckare",
                        BookDescription = "Den första boken som introducerar läsarna till den legendariska detektiven Sherlock Holmes och hans trogna följeslagare, Dr. John Watson. Tillsammans löser de en mordgåta som involverar en hemlig sekt och en amerikansk koloni i Utah.",
                        ReleaseYear = new DateTime(1887, 11, 1),
                        InStock = true,
                        ISBN = "9780192123167"
                    },
                new()
                    {
                        BookName = "Människans Lott",
                        Author = "Malin Persson Giolito",
                        Genre = "Deckare",
                        BookDescription = "En spännande deckare som kastar ljus över mörka hemligheter och familjedramer. När en ung kvinna mördas, avslöjar utredningen skrämmande sanningar som hotar att förstöra flera liv.",
                        ReleaseYear = new DateTime(2020, 10, 1),
                        InStock = true,
                        ISBN = "9789177952816"
                    },

            // Feelgood
                new Book
                    {
                        BookName = "En man som heter Ove",
                        Author = "Fredrik Backman",
                        Genre = "Feelgood",
                        BookDescription = "En hjärtevärmande berättelse om en grinig gammal man som finner oväntad vänskap och mening i livet när han möter sina nya grannar. Med humor och värme fångar Backman läsarna och påminner dem om vikten av medmänsklighet och försoning.",
                        ReleaseYear = new DateTime(2012, 8, 27),
                        InStock = true,
                        ISBN = "9789170370499"
                    },
                new Book
                    {
                        BookName = "En man som heter Ove",
                        Author = "Fredrik Backman",
                        Genre = "Feelgood",
                        BookDescription = "En hjärtevärmande berättelse om en grinig man vid namn Ove som oväntat finner mening och glädje i livet när han möter sina nya grannar. En bok som får dig att skratta, gråta och känna värmen av mänsklig gemenskap.",
                        ReleaseYear = new DateTime(2012, 8, 27),
                        InStock = true,
                        ISBN = "9789175032063"
                    },
                new Book
                    {
                        BookName = "Brev från Klara",
                        Author = "Jessica Gedin",
                        Genre = "Feelgood",
                        BookDescription = "En charmig och gripande berättelse om kärlek, vänskap och det magiska med att skriva och få brev. Följ med Klara när hon utforskar livets alla nyanser genom sina brev och upptäcker den verkliga kraften i kommunikation.",
                        ReleaseYear = new DateTime(2020, 3, 16),
                        InStock = true,
                        ISBN = "9789189366218"
                    },
                new Book
                    {
                        BookName = "Den lilla bokhandeln runt hörnet",
                        Author = "Jenny Colgan",
                        Genre = "Feelgood",
                        BookDescription = "En underbar feelgood-roman om kärlek, vänskap och gemenskap som utspelar sig i en liten bokhandel. Följ med Nina när hon kämpar för att rädda sin bokhandel och hittar kärleken på vägen.",
                        ReleaseYear = new DateTime(2016, 3, 1),
                        InStock = true,
                        ISBN = "9789176291898"
                    },


            // Fantasy
                new Book
                    {
                        BookName = "Harry Potter och De Vises Sten",
                        Author = "J.K. Rowling",
                        Genre = "Fantasy",
                        BookDescription = "Den första boken i Harry Potter-serien tar läsarna med på en magisk resa till Hogwarts skola för häxkonster och trolldom. Följ med Harry Potter när han upptäcker sin sanna arv och står inför den mörka trollkarlen som dödade hans föräldrar.",
                        ReleaseYear = new DateTime(1997, 6, 26),
                        InStock = true,
                        ISBN = "9789129699390"
                    },
                new Book
                    {
                        BookName = "The Hobbit",
                        Author = "J.R.R. Tolkien",
                        Genre = "Fantasy",
                        BookDescription = "En klassisk fantasyroman som följer hobbiten Bilbo Baggins när han ger sig ut på ett äventyr för att återta en skatt som vaktas av draken Smaug. Med sin fantasifulla värld och oförglömliga karaktärer har The Hobbit lockat läsare i generationer.",
                        ReleaseYear = new DateTime(1937, 9, 21),
                        InStock = true,
                        ISBN = "9780547928227"
                    },
                new()
                    {
                        BookName = "Sagan om ringen: Härskarringen",
                        Author = "J.R.R. Tolkien",
                        Genre = "Fantasy",
                        BookDescription = "Den första boken i den episka trilogin Sagan om ringen. Följ med Frodo Bagger när han tar på sig uppdraget att förstöra den onda Härskarringen och rädda Midgård från Saurons mörka makt.",
                        ReleaseYear = new DateTime(1954, 7, 29),
                        InStock = true,
                        ISBN = "9789129693662"
                    },
                new()
                    {
                        BookName = "Eragon",
                        Author = "Christopher Paulini",
                        Genre="Fantasy",
                        BookDescription="En helt vanlig pojke hittar en dag ett drakägg i skogen vilket förändrar hela hans liv.",
                        ReleaseYear=DateTime.Parse("203-06-25"),
                        InStock=true,
                        ISBN="131324kjfhdkjfhd12"
                    },

                    // Rysare
                new Book
                    {
                        BookName = "The Shining",
                        Author = "Stephen King",
                        Genre = "Rysare",
                        BookDescription = "En skrämmande berättelse om en familj som tar jobb som vaktmästare på ett isolerat hotell under vintermånaderna. När hotellet börjar visa tecken på ett övernaturligt förflutet, står familjen inför en kamp för att överleva.",
                        ReleaseYear = new DateTime(1977, 1, 28),
                        InStock = true,
                        ISBN = "9780307743657"
                    },
                new Book
                    {
                        BookName = "Dracula",
                        Author = "Bram Stoker",
                        Genre = "Rysare",
                        BookDescription = "En klassisk skräckroman som följer advokaten Jonathan Harker när han reser till Transsylvanien för att hjälpa greve Dracula att köpa fastigheter i England. Men snart upptäcker han grevens mörka hemlighet och ställs inför en kamp mot vampyren.",
                        ReleaseYear = new DateTime(1897, 5, 26),
                        InStock = true,
                        ISBN = "978048"
                    },

                    //Romantik
                new Book
                    {
                        BookName = "Stolthet och fördom",
                        Author = "Jane Austen",
                        Genre = "Feelgood",
                        BookDescription = "En klassisk feelgood-roman som följer Elizabeth Bennet när hon navigerar genom komplicerade relationer och oväntade romanser i 1800-talets England. Austens skarpa dialog och levande karaktärer gör denna berättelse tidlös och underhållande.",
                        ReleaseYear = new DateTime(1813, 1, 28),
                        InStock = true,
                        ISBN = "9780141439518"
                    },
                new Book
                    {
                        BookName = "Bridgerton: The Duke and I",
                        Author = "Julia Quinn",
                        Genre = "Romantik",
                        BookDescription = "Den första boken i Bridgerton-serien följer Daphne Bridgerton och Simon Basset, hertigen av Hastings, när de spelar upp en falsk förlovning för att undvika påträngande matchmakers. Men vad som börjar som en överenskommelse utvecklar sig snabbt till äkta kärlek.",
                        ReleaseYear = new DateTime(2000, 7, 28),
                        InStock = true,
                        ISBN = "9780062353597"
                    },
                new Book
                    {
                        BookName = "Kärlek i kolerans tid",
                        Author = "Gabriel Garcia Marquez",
                        Genre = "Romantik",
                        BookDescription = "En gripande berättelse om kärlekens kraft mitt i en epidemi av kolera. Följ med Fermina och Florentino när de kämpar för sin kärlek trots alla hinder som står i deras väg.",
                        ReleaseYear = new DateTime(1985, 5, 6),
                        InStock = true,
                        ISBN = "9781400034682"
                    },
                new Book
                    {
                        BookName = "Den enda",
                        Author = "Nicholas Sparks",
                        Genre = "Romantik",
                        BookDescription = "En gripande berättelse om två personer vars kärlek övervinner alla odds. När Savannah och John möts förändras deras liv för alltid, men deras kärlek sätts på prov när de dras isär av omständigheterna.",
                        ReleaseYear = new DateTime(2003, 9, 8),
                        InStock = true,
                        ISBN = "9780446616182"
                    },

                //Barn
                new Book
                    {
                        BookName = "The Tale of Peter Rabbit",
                        Author = "Beatrix Potter",
                        Genre = "Barn",
                        BookDescription = "En tidlös barnbok som följer den äventyrliga kaninen Peter Rabbit när han utforskar Herr McGregors trädgård trots sin mors varningar. Med sin charmiga berättelse och vackra illustrationer har denna bok glatt barn i över ett sekel.",
                        ReleaseYear = new DateTime(1902, 10, 16),
                        InStock = true,
                        ISBN = "9780723247708"
                    },
                new Book
                    {
                        BookName = "Alice i Underlandet",
                        Author = "Lewis Carroll",
                        Genre = "Barn",
                        BookDescription = "Följ med Alice när hon faller genom kaninhålet och hamnar i en märklig värld full av konstiga figurer och äventyr. Denna klassiska berättelse har fascinerat barn i generationer med sin magi och fantasi.",
                        ReleaseYear = new DateTime(1865, 11, 26),
                        InStock = true,
                        ISBN = "9789172218893"
                    },
                new Book
                    {
                        BookName = "Pippi Långstrump",
                        Author = "Astrid Lindgren",
                        Genre = "Barn",
                        BookDescription = "Möt den starka och självständiga Pippi Långstrump, som bor ensam i Villa Villekulla med sin apa Herr Nilsson och hästen Lilla Gubben. Tillsammans med sina vänner Tommy och Annika upplever Pippi fantastiska äventyr.",
                        ReleaseYear = new DateTime(1945, 11, 21),
                        InStock = true,
                        ISBN = "9789129663001"
                    },
                new Book
                    {
                        BookName = "Dunderklumpen",
                        Author = "Beppe Wolgers",
                        Genre = "Barn",
                        BookDescription = "En spännande berättelse om vänskap och äventyr när lilla Doris möter den busiga och charmiga Dunderklumpen. Tillsammans ger de sig ut på en resa genom magiska skogar och möter en rad färgglada karaktärer.",
                        ReleaseYear = new DateTime(1974, 12, 17),
                        InStock = true,
                        ISBN = "9789127064092"
                    }
                };
                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }
        //private static void SeedUsers(UserManager<Customer> userManager)
        //{
        //    if (!userManager.Users.Any())
        //    {
        //        var user1 = new Customer { UserName = "Emma@mail.com", Email = "Emma@mail.com", CustomerFullName = "Emma Lind" };
        //        userManager.CreateAsync(user1, "EmmaLind123!").Wait();

        //        //var user2 = new Customer { UserName = "customer2@example.com", Email = "customer2@example.com", FullName = "Customer 2" };
        //        //userManager.CreateAsync(user2, "StrongPassword123!").Wait();

        //        // Lägg till fler användare här efter behov
        //    }
        //}
        //private static void SeedBookLoans(ApplicationDbContext context, UserManager<Customer> userManager)
        //{
        //    // Hitta användaren "Emma Lind"
        //    var emmaUser = userManager.FindByEmailAsync("Emma@mail.com").Result;

        //    if (emmaUser != null)
        //    {
        //        // Hämta alla böcker från databasen
        //        var allBooks = context.Books.ToList();

        //        // Lägg till boklån för Emma Lind
        //        context.BookLoans.AddRange(new List<BookLoan>()
        //{
        //    new BookLoan()
        //    {
        //        CustomerId = emmaUser.Id,
        //        BookId = allBooks[0].BookId,
        //        LoanStatus = LoanStatus.Utlånad,
        //        LoanDate = DateTime.Now,
        //        LastLoanDate = DateTime.Now.AddDays(30)
        //    },
        //    new BookLoan()
        //    {
        //        CustomerId = emmaUser.Id,
        //        BookId = allBooks[1].BookId,
        //        LoanStatus = LoanStatus.Utlånad,
        //        LoanDate = DateTime.Now,
        //        LastLoanDate = DateTime.Now.AddDays(30)
        //    },
        //    new BookLoan()
        //    {
        //        CustomerId = emmaUser.Id,
        //        BookId = allBooks[2].BookId,
        //        LoanStatus = LoanStatus.Utlånad,
        //        LoanDate = DateTime.Now,
        //        LastLoanDate = DateTime.Now.AddDays(30)
        //    },
        //    new BookLoan()
        //    {
        //        CustomerId = emmaUser.Id,
        //        BookId = allBooks[3].BookId,
        //        LoanStatus = LoanStatus.Utlånad,
        //        LoanDate = DateTime.Now,
        //        LastLoanDate = DateTime.Now.AddDays(30)
        //    },
        //    new BookLoan()
        //    {
        //        CustomerId = emmaUser.Id,
        //        BookId = allBooks[4].BookId,
        //        LoanStatus = LoanStatus.Utlånad,
        //        LoanDate = DateTime.Now,
        //        LastLoanDate = DateTime.Now.AddDays(30)
        //    }
        //});

        //        context.SaveChanges();
        //    }
        //}
    }
}
