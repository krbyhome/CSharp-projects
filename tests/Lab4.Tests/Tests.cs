using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleParser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    [Theory]
    [ClassData(typeof(FirstTestDataGenerator))]
    public void ParserShouldReturnConnectCommandWithRootPathAndLocalMode(
        Parser parser,
        IList<string> args)
    {
        IFileSystemCommand command = parser.Parse(args);
        Assert.IsType<ConnectCommand>(command);
        var connect = (ConnectCommand)command;
        Assert.Equal("C:\\", connect.Address);
        Assert.Equal(ConnectionMode.Local, connect.Mode);
    }

    [Theory]
    [ClassData(typeof(SecondTestDataGenerator))]
    public void ParserShouldReturnTreeGotoCommandWithUsersPath(
        Parser parser,
        IList<string> args)
    {
        IFileSystemCommand command = parser.Parse(args);
        Assert.IsType<TreeGotoCommand>(command);
        var treeGoto = (TreeGotoCommand)command;
        Assert.Equal("users", treeGoto.Path);
    }

    [Theory]
    [ClassData(typeof(ThirdTestDataGenerator))]
    public void ParserShouldReturnTreeListCommandWithDepth2(
        Parser parser,
        IList<string> args)
    {
        IFileSystemCommand command = parser.Parse(args);
        Assert.IsType<TreeListCommand>(command);
        var treeList = (TreeListCommand)command;
        Assert.Equal(2, treeList.Depth);
    }

    [Theory]
    [ClassData(typeof(FourthTestDataGenerator))]
    public void ParserShouldReturnCopyCommandFromSnab4ToCopy(
        Parser parser,
        IList<string> args)
    {
        IFileSystemCommand command = parser.Parse(args);
        Assert.IsType<FileCopyCommand>(command);
        var copyCommand = (FileCopyCommand)command;
        Assert.Equal("c:\\Users\\snab4", copyCommand.SourcePath);
        Assert.Equal("c:\\Users\\copy", copyCommand.DestinationPath);
    }
}