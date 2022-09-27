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
                        Name = "Doug",
                        ObjectClass = "Student",
                        Classification = "Human",
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean m",
                        Containment = "Box",
                        ImageName = "placeholder text"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
