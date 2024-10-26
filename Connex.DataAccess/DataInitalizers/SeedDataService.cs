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
        Setting setting8 = new() { Id = 8, Key = "Unvan", Value = "Baku" };
        Setting setting9 = new() { Id = 9, Key = "Email", Value = "info@connex.az" };
        Setting setting10 = new() { Id = 10, Key = "TiktokLink", Value = "tiktok" };

        List<Setting> settings = [setting1, setting2, setting3, setting4, setting5, setting6, setting7, setting8, setting9, setting10];

        modelBuilder.Entity<Setting>().HasData(settings);

    }
    private static void AddLanguages(this ModelBuilder modelBuilder)
    {

        Language azerbaijanLanguage = new() { Id = 1, Code = "AZ", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1729631254/connex.az/qqaf2nprjoze4ovdya9o.png", IsDefault = true };
        Language englishLanguage = new() { Id = 2, Code = "EN", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1729631254/connex.az/cxoiku5tmvxcoxw6tj4m.png", IsDefault = false };
        Language russianLanguage = new() { Id = 3, Code = "RU", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1729631254/connex.az/gnw43upf9w6t2xkaxvka.png", IsDefault = false };

        List<Language> languages = [azerbaijanLanguage, englishLanguage, russianLanguage];


        modelBuilder.Entity<Language>().HasData(languages);
    }
}
