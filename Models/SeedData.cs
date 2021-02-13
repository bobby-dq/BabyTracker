using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BabyTracker.Models
{
    public static class SeedData
    {
        public static void SeedDatabase (BabyTrackerContext context)
        {
            context.Database.Migrate();
            if (context.Infants.Count() == 0 &&
            context.Feedings.Count() == 0 &&
            context.Growths.Count() == 0 &&
            context.Medications.Count() == 0 &&
            context.Sleeps.Count() == 0 &&
            context.Diapers.Count() == 0)
            {
                Infant migiDatul = new Infant
                    {
                        FirstName="Migi",
                        LastName="Datul",
                        Dob = new DateTime(1999,1,1)
                    };
                Infant immanuelSantaElena = new Infant
                    {
                        FirstName = "Immanuel",
                        LastName = "Santa Elena",
                        Dob = new DateTime(2000, 02, 20)
                    };

                context.Feedings.AddRange(
                    new Feeding {
                        Infant = migiDatul,
                        FeedType = FeedEnum.LeftBreast,
                        Description = "Migi leftbreast test 1",
                        Comments = "Migi test leftbreast 1",
                        StartTime = new DateTime(2020, 02, 20, 11,11, 11),
                        Amount = 23,
                        Duration = 60
                    },
                    new Feeding {
                        Infant = migiDatul,
                        FeedType = FeedEnum.LeftBreast,
                        Description = "Migi leftbreast test 2",
                        Comments = "Migi test leftbreast 2",
                        StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                        Amount = 2,
                        Duration = 61
                    },
                    new Feeding {
                        Infant = migiDatul,
                        FeedType = FeedEnum.LeftBreast,
                        Description = "Migi leftbreast test 2",
                        Comments = "Migi test leftbreast 2",
                        StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                        Amount = 2,
                        Duration = 61
                    },
                    new Feeding {
                        Infant = migiDatul,
                        FeedType = FeedEnum.LeftBreast,
                        Description = "Migi leftbreast test 2",
                        Comments = "Migi test leftbreast 2",
                        StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                        Amount = 2,
                        Duration = 61
                    },
                    new Feeding {
                        Infant = migiDatul,
                        FeedType = FeedEnum.LeftBreast,
                        Description = "Migi leftbreast test 2",
                        Comments = "Migi test leftbreast 2",
                        StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                        Amount = 2,
                        Duration = 61
                    },
                    new Feeding {
                        Infant = migiDatul,
                        FeedType = FeedEnum.LeftBreast,
                        Description = "Migi leftbreast test 2",
                        Comments = "Migi test leftbreast 2",
                        StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                        Amount = 2,
                        Duration = 61
                    },
                    new Feeding {
                        Infant = migiDatul,
                        FeedType = FeedEnum.LeftBreast,
                        Description = "Migi leftbreast test 2",
                        Comments = "Migi test leftbreast 2",
                        StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                        Amount = 2,
                        Duration = 61
                    },
                    new Feeding {
                        Infant = migiDatul,
                        FeedType = FeedEnum.LeftBreast,
                        Description = "Migi leftbreast test 2",
                        Comments = "Migi test leftbreast 2",
                        StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                        Amount = 2,
                        Duration = 61
                    }
                );

                context.Growths.AddRange(
                    new Growth {
                        
                    }
                );

                context.Medications.AddRange(
                    new Medication {
                         
                    }
                );

                context.Sleeps.AddRange(
                    new Sleep {
                         
                    }
                );

                context.Diapers.AddRange(
                    new Diaper {
                        Infant = migiDatul,
                         DiaperType = DiaperEnum.Pee,
                         Description = "Migi Pee test 1",
                         Comments = " Test pee 1",
                         Time = new DateTime(2021, 02, 20, 10, 10, 20)
                    },
                    new Diaper {
                        Infant = migiDatul,
                         DiaperType = DiaperEnum.Pee,
                         Description = "Migi Pee test 2",
                         Comments = "Test pee 2",
                         Time = new DateTime(2021, 02, 20, 1, 10, 20)
                    },
                    new Diaper {
                        Infant = migiDatul,
                         DiaperType = DiaperEnum.Poo,
                         Description = "Migi Poo test 1",
                         Comments = "Test poo 1",
                         Time = new DateTime(2021, 02, 20, 11, 10, 20)
                    },
                    new Diaper {
                        Infant = migiDatul,
                         DiaperType = DiaperEnum.Pee,
                         Description = "Migi Poo test 2",
                         Comments = "Test poo 2",
                         Time = new DateTime(2021, 02, 20, 12, 10, 20)
                    },
                    new Diaper {
                        Infant = migiDatul,
                         DiaperType = DiaperEnum.Pee,
                         Description = "Migi Pee poo test 1",
                         Comments = "Test pee poo 2",
                         Time = new DateTime(2021, 02, 20, 15, 10, 20)
                    },
                    new Diaper {
                        Infant = migiDatul,
                         DiaperType = DiaperEnum.Pee,
                         Description = "Migi Pee poo test 2",
                         Comments = "Test pee 2",
                         Time = new DateTime(2021, 02, 20, 5, 11, 20)
                    },
                    new Diaper {
                        Infant = immanuelSantaElena,
                         DiaperType = DiaperEnum.Pee,
                         Description = "Immanuel Pee test 1",
                         Comments = " Test pee 1",
                         Time = new DateTime(2021, 02, 20, 10, 10, 20)
                    },
                    new Diaper {
                        Infant = immanuelSantaElena,
                         DiaperType = DiaperEnum.Pee,
                         Description = "Immanuel Pee test 2",
                         Comments = "Test pee 2",
                         Time = new DateTime(2021, 02, 20, 1, 10, 20)
                    },
                    new Diaper {
                        Infant = immanuelSantaElena,
                         DiaperType = DiaperEnum.Poo,
                         Description = "Immanuel Poo test 1",
                         Comments = "Test poo 1",
                         Time = new DateTime(2021, 02, 20, 11, 10, 20)
                    },
                    new Diaper {
                        Infant = immanuelSantaElena,
                         DiaperType = DiaperEnum.Pee,
                         Description = "Immanuel Poo test 2",
                         Comments = "Test poo 2",
                         Time = new DateTime(2021, 02, 20, 12, 10, 20)
                    },
                    new Diaper {
                        Infant = immanuelSantaElena,
                         DiaperType = DiaperEnum.Pee,
                         Description = "Immanuel Pee poo test 1",
                         Comments = "Test pee poo 2",
                         Time = new DateTime(2021, 02, 20, 15, 10, 20)
                    },
                    new Diaper {
                        Infant = immanuelSantaElena,
                         DiaperType = DiaperEnum.Pee,
                         Description = "Immanuel Pee poo test 2",
                         Comments = "Test pee 2",
                         Time = new DateTime(2021, 02, 20, 5, 11, 20)
                    }
                );

                context.SaveChanges();

            }
        }
        
    }
}