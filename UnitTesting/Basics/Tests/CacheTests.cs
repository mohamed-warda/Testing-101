using Xunit;

namespace Basics.Tests;

public class CacheTests
{
    [Fact]
    public void Contains_CachesItemWithinTimeSpan_ReturnsTrue()
    {
        //arrange
        var cache = new Cache(TimeSpan.FromDays(1));
        cache.Add(new("url", "content", DateTime.Now));
        //act
        var contains = cache.Contains("url");
        //assert
        Assert.True(contains);
    }
    [Fact]
    public void Contains_WhenOutsideTimeSpan_ReturnsFalse()
    {
        //arrange
        var cache = new Cache(TimeSpan.FromDays(1));
        cache.Add(new("url", "content", DateTime.Now.AddDays(-3)));
        //act
        var contains = cache.Contains("url");
        //assert
        Assert.False(contains);
    }
    [Fact]
    public void Contains_WhenDoesntContainItem_ReturnsFalse()
    {
        //arrange
        var cache = new Cache(TimeSpan.FromDays(1));
        //act
        var contains = cache.Contains("url");
        //assert
        Assert.False(contains);
    }
}