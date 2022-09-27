using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PDMasterDetailContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PDMasterDetailContext>>()))
            {
                if (context == null || context.SCP == null)
                {
                    throw new ArgumentNullException("Null PDMasterDetailContext");
                }

                // Look for any SCP.
                if (context.SCP.Any())
                {
                    return;   // DB has been seeded
                }

                context.SCP.AddRange(
                    new SCP
                    {
                        Name = "Mike M",
                        ObjectClass = "Student",
                        Classification = "Human",
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean m",
                        Containment ="Box",
                        ImageName = "placeholder text"
                    },

                    new SCP
                    {
                        Name = "Mike T",
                        ObjectClass = "Student",
                        Classification = "Human",
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean m",
                        Containment = "Box",
                        ImageName = "placeholder text"
                    },

                    new SCP
                    {
                        Name = "Sammi",
                        ObjectClass = "Student",
                        Classification = "Human",
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean m",
                        Containment = "Box",
                        ImageName = "placeholder text"
                    },

                    new SCP
                    {
                        Name = "SCP-189",
                        ObjectClass = "Safe",
                        Classification = "Parasitic Roundworm",
                        Description = "SCP-189 is a species of parasitic roundworm (tentative taxonomic classification [DATA EXPUNGED]) " +
                        "capable of infesting any mammalian life form. Infection most commonly occurs as a result of direct skin contact " +
                        "with one or more egg sacs. These egg sacs are covered with microscopic \"hooks\" similar to those on the cuticles " +
                        "of some species of nematode, which anchor the sacs to the skin's surface. Contact with sebum then prompts the eggs " +
                        "inside to hatch, at which time the larvae seek out and burrow into one or more nearby hair follicles.",
                        Containment = "Cryo-containment Facility",
                        ImageName = "placeholder text"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
