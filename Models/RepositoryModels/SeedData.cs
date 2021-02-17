using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BabyTracker.Models.RepositoryModels
{
    public static class SeedData
    {

        public static void SeedDatabase(BabyTrackerContext ctx)
            {
                BabyTrackerContext context = ctx;

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
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
                            Infant = immanuelSantaElena,
                            FeedType = FeedEnum.LeftBreast,
                            Description = "Immanuel Leftbreast test 1",
                            Comments = "Immanuel test Leftbreast 1",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },
                        new Feeding {
                            Infant = immanuelSantaElena,
                            FeedType = FeedEnum.LeftBreast,
                            Description = "Immanuel leftbreast test 2",
                            Comments = "Immanuel test leftbreast 2",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },

                        new Feeding {
                            Infant = migiDatul,
                            FeedType = FeedEnum.RightBreast,
                            Description = "Migi right breast test 1",
                            Comments = "Migi test right breast 1",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 11),
                            Amount = 23,
                            Duration = 60
                        },
                        new Feeding {
                            Infant = migiDatul,
                            FeedType = FeedEnum.RightBreast,
                            Description = "Migi right breast test 2",
                            Comments = "Migi test Right breast 2",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },
                        new Feeding {
                            Infant = immanuelSantaElena,
                            FeedType = FeedEnum.RightBreast,
                            Description = "Immanuel right breast test 1",
                            Comments = "Immanuel test right breast 1",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },
                        new Feeding {
                            Infant = immanuelSantaElena,
                            FeedType = FeedEnum.RightBreast,
                            Description = "Immanuel rightbreast test 2",
                            Comments = "Immanuel test rightbreast 2",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },

                        new Feeding {
                            Infant = migiDatul,
                            FeedType = FeedEnum.Bottle,
                            Description = "Migi Bottle test 1",
                            Comments = "Migi test Bottle 1",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },
                        new Feeding {
                            Infant = migiDatul,
                            FeedType = FeedEnum.Bottle,
                            Description = "Migi Bottle test 2",
                            Comments = "Migi test bottle 2",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },
                        new Feeding {
                            Infant = immanuelSantaElena,
                            FeedType = FeedEnum.Bottle,
                            Description = "imman bottle test 2",
                            Comments = "Migi test bottle 2",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },
                        new Feeding {
                            Infant = migiDatul,
                            FeedType = FeedEnum.Bottle,
                            Description = "Migi bottle test 2",
                            Comments = "Migi test bottle 2",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },
                        new Feeding {
                            Infant = migiDatul,
                            FeedType = FeedEnum.Meal,
                            Description = "Migi Meal test 1",
                            Comments = "Migi test Meal 1",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },
                        new Feeding {
                            Infant = migiDatul,
                            FeedType = FeedEnum.Meal,
                            Description = "Migi Meal test 2",
                            Comments = "Migi test Meal 2",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },
                        new Feeding {
                            Infant = immanuelSantaElena,
                            FeedType = FeedEnum.Meal,
                            Description = "imman Meal test 2",
                            Comments = "Migi test Meal 2",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        },
                        new Feeding {
                            Infant = immanuelSantaElena,
                            FeedType = FeedEnum.Meal,
                            Description = "Migi Meal test 2",
                            Comments = "Migi test Meal 2",
                            StartTime = new DateTime(2020, 02, 20, 11,11, 7),
                            Amount = 2,
                            Duration = 61
                        }
                    );

                    context.Growths.AddRange(
                        new Growth {
                            Infant = migiDatul,
                            GrowthType = GrowthEnum.Height,
                            Amount = 100,
                            Description = "Migi Height Test 1 Description",
                            Comments = "Migit Height Test 1 Comments",
                            Date = new DateTime(2019, 02, 14, 11, 14 ,5)
                        },
                        new Growth {
                            Infant = migiDatul,
                            GrowthType = GrowthEnum.Height,
                            Amount = 88,
                            Description = "Migi Height Test 2 Description",
                            Comments = "Migit Height Test 2 Comments",
                            Date = new DateTime(2019, 02, 14, 11, 14 ,5)
                        },
                        new Growth {
                            Infant = immanuelSantaElena,
                            GrowthType = GrowthEnum.Height,
                            Amount = 100,
                            Description = "Imman Height Test 1 Description",
                            Comments = "Imman Height Test 1 Comments",
                            Date = new DateTime(2019, 02, 14, 11, 14 ,5)
                        },
                        new Growth {
                            Infant = immanuelSantaElena,
                            GrowthType = GrowthEnum.Height,
                            Amount = 88,
                            Description = "Imman Height Test 2 Description",
                            Comments = "Imman Height Test 2 Comments",
                            Date = new DateTime(2019, 02, 14, 11, 14 ,5)
                        },
                        new Growth {
                            Infant = migiDatul,
                            GrowthType = GrowthEnum.Weight,
                            Amount = 100,
                            Description = "Migi weight Test 1 Description",
                            Comments = "Migit weight Test 1 Comments",
                            Date = new DateTime(2019, 02, 14, 11, 14 ,5)
                        },
                        new Growth {
                            Infant = migiDatul,
                            GrowthType = GrowthEnum.Weight,
                            Amount = 88,
                            Description = "Migi weight Test 2 Description",
                            Comments = "Migit weight Test 2 Comments",
                            Date = new DateTime(2019, 02, 14, 11, 14 ,5)
                        },
                        new Growth {
                            Infant = immanuelSantaElena,
                            GrowthType = GrowthEnum.Weight,
                            Amount = 100,
                            Description = "Imman weight Test 1 Description",
                            Comments = "Imman weight Test 1 Comments",
                            Date = new DateTime(2019, 02, 14, 11, 14 ,5)
                        },
                        new Growth {
                            Infant = immanuelSantaElena,
                            GrowthType = GrowthEnum.Weight,
                            Amount = 88,
                            Description = "Imman weight Test 2 Description",
                            Comments = "Imman weight Test 2 Comments",
                            Date = new DateTime(2019, 02, 14, 11, 14 ,5)
                        }
                    );

                    context.Medications.AddRange(
                        new Medication {
                            Infant = migiDatul,
                            MedicationType = MedicationEnum.Medicine,
                            Date = new DateTime(2020, 02, 11, 01, 01, 20),
                            Description = "Migi Medician test 1 Description",
                            Comments = "Migi Medicine test 1 comments"
                        },
                        new Medication {
                            Infant = migiDatul,
                            MedicationType = MedicationEnum.Medicine,
                            Date = new DateTime(2020, 02, 11, 01, 01, 20),
                            Description = "Migi Medician test 2 Description",
                            Comments = "Migi Medicine test 2 comments"
                        },
                        new Medication {
                            Infant = immanuelSantaElena,
                            MedicationType = MedicationEnum.Medicine,
                            Date = new DateTime(2020, 02, 11, 01, 01, 20),
                            Description = "Immanuel Medician test 1 Description",
                            Comments = "Immanuel Medicine test 1 comments"
                        },
                        new Medication {
                            Infant = immanuelSantaElena,
                            MedicationType = MedicationEnum.Medicine,
                            Date = new DateTime(2020, 02, 11, 01, 01, 20),
                            Description = "Immanuel Medician test 2 Description",
                            Comments = "Immanuel Medicine test 2 comments"
                        },
                        new Medication {
                            Infant = migiDatul,
                            MedicationType = MedicationEnum.Vaccination,
                            Date = new DateTime(2020, 02, 11, 01, 01, 20),
                            Description = "Migi Vaccination test 1 Description",
                            Comments = "Migi Vaccination test 1 comments"
                        },
                        new Medication {
                            Infant = migiDatul,
                            MedicationType = MedicationEnum.Vaccination,
                            Date = new DateTime(2020, 02, 11, 01, 01, 20),
                            Description = "Migi Vaccination test 2 Description",
                            Comments = "Migi Vaccination test 2 comments"
                        },
                        new Medication {
                            Infant = immanuelSantaElena,
                            MedicationType = MedicationEnum.Vaccination,
                            Date = new DateTime(2020, 02, 11, 01, 01, 20),
                            Description = "Immanuel Vaccination test 1 Description",
                            Comments = "Immanuel Vaccination test 1 comments"
                        },
                        new Medication {
                            Infant = immanuelSantaElena,
                            MedicationType = MedicationEnum.Vaccination,
                            Date = new DateTime(2020, 02, 11, 01, 01, 20),
                            Description = "Immanuel Vaccination test 2 Description",
                            Comments = "Immanuel Vaccination test 2 comments"
                        }
                    );

                    context.Sleeps.AddRange(
                        new Sleep {
                            Infant = migiDatul,
                            StartTime = new DateTime(2021, 02, 20, 02, 02, 02),
                            EndTime = new DateTime(2021, 02, 20, 04, 02, 02),
                            Description = "Migi Sleep Test 1 Description",
                            Comments = "Migi Sleep Test 1 Comments"
                        },
                        new Sleep {
                            Infant = migiDatul,
                            StartTime = new DateTime(2021, 03, 20, 02, 02, 02),
                            EndTime = new DateTime(2021, 03, 20, 04, 02, 02),
                            Description = "Migi Sleep Test 2 Description",
                            Comments = "Migi Sleep Test 2 Comments"
                        },
                        new Sleep {
                            Infant = immanuelSantaElena,
                            StartTime = new DateTime(2021, 02, 20, 02, 02, 02),
                            EndTime = new DateTime(2021, 02, 20, 04, 02, 02),
                            Description = "Immanuel Sleep Test 1 Description",
                            Comments = "Immanuel Sleep Test 1 Comments"
                        },
                        new Sleep {
                            Infant = immanuelSantaElena,
                            StartTime = new DateTime(2021, 03, 20, 02, 02, 02),
                            EndTime = new DateTime(2021, 03, 20, 04, 02, 02),
                            Description = "Immanuel Sleep Test 2 Description",
                            Comments = "Immanuel Sleep Test 2 Comments"
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