using Microsoft.EntityFrameworkCore;

namespace Connex.DataAccess.DataInitalizers;

public static class SeedDataService
{
    public static void AddSeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.AddLanguages();
        modelBuilder.AddSettings();
    }

    private static void AddSettings(this ModelBuilder modelBuilder)
    {

        Setting setting1 = new() { Id = 1, Key = "Logo", Value = "logo.png" };
        Setting setting2 = new() { Id = 2, Key = "Telefon1", Value = "+994 51 434 15 23" };
        Setting setting3 = new() { Id = 3, Key = "Telefon2", Value = "+994 51 434 15 23" };
        Setting setting4 = new() { Id = 4, Key = "TelefonQaynarXett", Value = "+994 51 434 15 23" };
        Setting setting5 = new() { Id = 5, Key = "FacebookLink", Value = "fb.com" };
        Setting setting6 = new() { Id = 6, Key = "InstagramLink", Value = "instagram.com" };
        Setting setting7 = new() { Id = 7, Key = "LinkedinLink", Value = "linkedin.com" };

        List<Setting> settings = [setting1, setting2, setting3, setting4, setting5, setting6, setting7];

        modelBuilder.Entity<Setting>().HasData(settings);

    }
    private static void AddLanguages(this ModelBuilder modelBuilder)
    {

        Language azerbaijanLanguage = new() { Id = 1, Code = "AZE", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/rc1flc3kendub8xvmo8a.png", IsDefault = true };
        Language englishLanguage = new() { Id = 2, Code = "ENG", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/ull5rtwaatdqi1qhuidn.png", IsDefault = false };
        Language russianLanguage = new() { Id = 3, Code = "RUS", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1729197779/n4p898pyw6gnxopu5hrc.png", IsDefault = false };

        List<Language> languages = [azerbaijanLanguage, englishLanguage, russianLanguage];


        modelBuilder.Entity<Language>().HasData(languages);
    }
}
