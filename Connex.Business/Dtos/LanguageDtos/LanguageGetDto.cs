namespace Connex.Business.Dtos;

public class LanguageGetDto : IDto
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string ImagePath { get; set; }=null!;    
}