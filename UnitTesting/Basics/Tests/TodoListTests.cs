using Xunit;

namespace Basics.Tests;

public class TodoListTests
{
    [Fact]
    public void Add_SaveToDoItem()
    {
        //arrange 
        var list = new TodoList();

        //act
        list.Add(new TodoList.TodoItem("Test 1"));
        
        //assert
        var savedItem = Assert.Single(list.All);
        Assert.NotNull(savedItem);
        Assert.Equal("Test 1",savedItem.Content);
        Assert.False(savedItem.Complete);
    }
    
    [Fact]
    public void Add_TodoItemIdIncrementsEverTimeWeAdd()
    {
        // arrange
        var list = new TodoList();

        // act
        list.Add(new("Test 1"));
        list.Add(new("Test 2"));

        // assert
        var items = list.All;
        Assert.Equal(1, items.First().Id);
        Assert.Equal(2, items.Last().Id);
    }
    [Fact]
    public void Complete_SetsTodoItemCompleteFlagToTrue()
    {
        // arrange
        var list = new TodoList();
        list.Add(new("Test 1"));

        // act
        list.Complete(1);

        // assert
        var completedItem = Assert.Single(list.All);
        Assert.NotNull(completedItem);
        Assert.Equal(1, completedItem.Id);
        Assert.True(completedItem.Complete);
    }
}