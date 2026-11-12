using System.Collections.Generic;

public class FeatureCollection
{
    public List<Feature> Features { get; set; } = new List<Feature>();
}

public class Feature
{
    public EarthquakeProperties? Properties { get; set; }
}

public class EarthquakeProperties
{
    public double? Mag { get; set; }
    public string? Place { get; set; }
}