﻿namespace StyleCop.Baboon
{
    using System;
    using StyleCop.Baboon.Analyzer;
    using StyleCop.Baboon.Analyzer.StyleCop;
    using StyleCop.Baboon.Infrastructure;
    using StyleCop.Baboon.Renderer;

    public class MainClass
    {
        private const int NoViolationsFound = 0;
        private const int MissingArgumentsErrorCode = 1;
        private const int SettingsFileDoesNotExistErrorCode = 2;
        private const int InvalidPathToAnalyzeErrorCode = 3;
        private const int ViolationsFound = 4;

        public static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                PrintUsage();

                return MissingArgumentsErrorCode;
            }

            var settings = args[0];
            var projectPath = args[1];

            return Analyze(settings, projectPath);
        }

        private static int Analyze(string settings, string projectPath)
        {
            var fileSystemHandler = new FileSystemHandler();
            var outputWriter = new StandardOutputWriter();

            if (false == fileSystemHandler.Exists(settings))
            {
                outputWriter.WriteLineWithSeparator("Given settings file does not exist. Exiting...", string.Empty);

                return SettingsFileDoesNotExistErrorCode;
            }

            if (false == fileSystemHandler.Exists(projectPath))
            {
                outputWriter.WriteLineWithSeparator("Given path to analyze does not exist. Exiting...", string.Empty);

                return InvalidPathToAnalyzeErrorCode;
            }

            var analyzer = new StyleCopAnalyzer();
            var projectFactory = new ProjectFactory(new FileSystemHandler());
            var project = projectFactory.CreateFromPathWithCustomSettings(projectPath, settings);
            var violations = analyzer.GetViolationsFromProject(project);

            var renderer = new ConsoleRenderer(outputWriter);

            renderer.RenderViolationList(violations);

            if (violations.Empty)
            {
                return NoViolationsFound;
            }

            return ViolationsFound;
        }

        private static void PrintUsage()
        {
            System.Console.WriteLine("Usage: StyleCop.Baboon.exe [stylecop-settings-path] [path-to-analyze]");
        }
    }
}
