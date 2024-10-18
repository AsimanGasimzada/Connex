using Microsoft.EntityFrameworkCore;

namespace Connex.DataAccess.DataInitalizers;

public static class SeedDataService
{
    public static void AddSeedData(this ModelBuilder modelBuilder)
    {
        AddLanguages(modelBuilder);
    }

    private static void AddLanguages(ModelBuilder modelBuilder)
    {
        List<Language> languages = [];

        Language azerbaijanLanguage = new() { Id = 1, Code = "AZE", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/rc1flc3kendub8xvmo8a.png", IsDefault = true };
        Language englishLanguage = new() { Id = 2, Code = "ENG", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/ull5rtwaatdqi1qhuidn.png", IsDefault = false };
        Language russianLanguage = new() { Id = 3, Code = "RUS", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/n4p898pyw6gnxopu5hrc.png", IsDefault = false };

        languages.Add(englishLanguage);
        languages.Add(russianLanguage);
        languages.Add(azerbaijanLanguage);

        modelBuilder.Entity<Language>().HasData(languages);
    }
}
