using Xunit;

namespace Basics.Tests;

public class PropertyHashTests
{
    [Fact]
    public void PropertyHash_ConcatenatesSelectedFieldsInOrder()
    {
        //arrange
        var hasher = new PropertyHash();
        var item = new Cache.Item("url", "content", DateTime.Now);
        //act   
        var hash = hasher.Hash(item, i => i.Url, i => i.Content);
        //assert
        Assert.Equal("urlcontent", hash);
    }

    
    [Fact]
    public void AlgorithmPropertyHash_AppliesHashingAlgorithmToSeed()
    {
        //arrange
        var hasher = new AlgorithmPropertyHash("sha256");
        var item = new Cache.Item("url", "content", DateTime.Now);
        //act
        var hash = hasher.Hash(item, i => i.Url, i => i.Content);
        //assert
        Assert.Equal("9FyLxk+9z73XO8xhZ15emMaK+oa8aDg6LWiY6y40KyQ=", hash);
    }
}