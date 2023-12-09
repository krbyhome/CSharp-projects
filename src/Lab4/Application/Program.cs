using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleParser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application;

public static class Program
{
    public static void Main()
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

        IApplicationContext context = new ApplicationContext();
        while (true)
        {
            string? line = Console.ReadLine();
            if (line is null)
                continue;

            var commandLine = line.Split(" ").ToList();
            parser.Parse(commandLine).Invoke(context);
        }
    }
}