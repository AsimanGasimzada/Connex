﻿namespace Connex.Core.Entities;

public class FeatureDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Language Language { get; set; } = null!;
    public int LanguageId { get; set; }
    public Feature Feature { get; set; } = null!;
    public int FeatureId { get; set; }
}
