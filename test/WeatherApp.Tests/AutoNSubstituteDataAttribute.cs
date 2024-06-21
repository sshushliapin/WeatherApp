using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace WeatherApp.Tests;

public class AutoNSubstituteDataAttribute()
    : AutoDataAttribute(() => new Fixture().Customize(new AutoNSubstituteCustomization()));