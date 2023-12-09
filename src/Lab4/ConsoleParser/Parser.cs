using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleParser;

public class Parser
{
    private Dictionary<string, Dictionary<string, ICommandFactory>> _factories;

    public Parser(Dictionary<string, Dictionary<string, ICommandFactory>> factories)
    {
        _factories = factories;
    }

    public static ParserBuilder Builder => new ParserBuilder();

    public IFileSystemCommand Parse(IList<string> input)
    {
        string domain = input[0];
        int commandIdx = 1;
        if (!_factories.ContainsKey(domain))
        {
            domain = string.Empty;
            commandIdx = 0;
        }

        string commandName = input[commandIdx];
        var positionals = new List<string>();
        var parameters = new Dictionary<char, string>();

        int lineIdx = commandIdx + 1;
        while (lineIdx < input.Count)
        {
            if (input[lineIdx].Length > 0)
            {
                if (input[lineIdx][0] == '-')
                {
                    parameters.Add(input[lineIdx][1], input[lineIdx + 1]);
                    lineIdx++;
                }
                else
                {
                    positionals.Add(input[lineIdx]);
                }
            }

            lineIdx++;
        }

        if (_factories.TryGetValue(domain, out Dictionary<string, ICommandFactory>? factories))
        {
            if (factories.TryGetValue(commandName, out ICommandFactory? factory))
            {
                return factory.Create(positionals, parameters);
            }
        }

        return new UnknownCommand();
    }

    public class ParserBuilder
    {
        private Dictionary<string, Dictionary<string, ICommandFactory>> _factories = new();
        private string _lastDomain = string.Empty;

        public ParserBuilder()
        {
            _factories.Add(string.Empty, new Dictionary<string, ICommandFactory>());
        }

        public ParserBuilder WithDomain(string domain)
        {
            _lastDomain = domain;
            _factories.Add(domain, new Dictionary<string, ICommandFactory>());
            return this;
        }

        public ParserBuilder WithCommand(string name, ICommandFactory factory)
        {
            _factories[_lastDomain].Add(name, factory);
            return this;
        }

        public Parser Build()
        {
            return new Parser(_factories);
        }
    }
}