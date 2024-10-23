namespace Connex.Business.Dtos;

public class CertificateGetDto : IDto
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = null!;
}

