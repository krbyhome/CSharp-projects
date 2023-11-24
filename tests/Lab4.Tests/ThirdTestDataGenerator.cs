using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleParser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ThirdTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        Parser.ParserBuilder parserBuilder = Parser.Builder;
        parserBuilder
            .WithCommand("connect", new ConnectFactory())
            .WithCommand("disconnect", new DisconnectFactory())
            .WithDomain("tree")
            .WithCommand("goto", new TreeGotoFactory())
            .WithCommand("list", new TreeListFactory())
            .WithDomain("file")
            .WithCommand("show", new FileShowFactory())
            .WithCommand("move", new FileMoveFactory())
            .WithCommand("copy", new FileCopyFactory())
            .WithCommand("delete", new FileDeleteFactory())
            .WithCommand("rename", new FileRenameFactory());
        Parser parser = parserBuilder.Build();
        yield return new object[]
        {
            parser,
            new string[]
            {
                "tree",
                "list",
                "-d",
                "2",
            },
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}