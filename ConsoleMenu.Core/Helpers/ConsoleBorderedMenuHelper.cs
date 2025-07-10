using System.Text;

namespace ConsoleMenu.Core.Helpers;

public static class ConsoleBorderedMenuHelper
{
    private const int ExtraSpacesOnLine = 1;
    private const string DefaultForeground = "\x1b[39m";
    private const string SelectedForeground = "\x1b[30m";
    private const string DefaultBackground = "\x1b[49m";
    private const string SelectedBackground = "\x1b[47m";

    public static int PrintMenuAndGetSelector(ref int selector, string? header, IReadOnlyList<string> lines)
    {
        if (selector <= 0)
            selector = 0;
        if (selector >= lines.Count - 1)
            selector = lines.Count - 1;

        do
        {
            Console.Clear();
            PrintMenu(header, lines, selector);
        } while (!IsNeedExitAfterKeyPressed(ref selector, lines.Count));

        return selector;
    }

    private static void PrintMenu(string? header, IReadOnlyList<string> lines, int selector)
    {
        var maxLineLength = lines.Max(line => line.Length);

        if (header != null)
            maxLineLength = Math.Max(maxLineLength, header.Length + ExtraSpacesOnLine * 2);

        var stringBuilder = new StringBuilder();

        AddOutputFirstLine(stringBuilder, maxLineLength);

        if (header != null)
        {
            AddOutputItemLine(stringBuilder, $"<{header}>", maxLineLength, false);
            AddOutputSeparatorLine(stringBuilder, maxLineLength);
        }

        AddOutputItemLine(stringBuilder, lines.First(), maxLineLength, selector == 0);

        for (var index = 1; index < lines.Count; index++)
        {
            AddOutputSeparatorLine(stringBuilder, maxLineLength);
            AddOutputItemLine(stringBuilder, lines[index], maxLineLength, selector == index);
        }

        AddOutputLastLine(stringBuilder, maxLineLength);

        Console.Write(stringBuilder.ToString());
    }

    private static void AddOutputFirstLine(StringBuilder stringBuilder, int maxLineLength)
    {
        stringBuilder.Append('╔').Append('═', maxLineLength + ExtraSpacesOnLine * 2).Append('╗').AppendLine();
    }

    private static void AddOutputItemLine(StringBuilder stringBuilder, string line, int maxLineLength, bool isSelected)
    {
        var spacesCount = maxLineLength - line.Length;
        var rightSpacesCount = spacesCount / 2;
        var leftSpacesCount = spacesCount - rightSpacesCount;

        stringBuilder.Append('║');

        if (isSelected)
            stringBuilder.Append(SelectedForeground).Append(SelectedBackground);

        stringBuilder.Append(' ', leftSpacesCount + ExtraSpacesOnLine);
        stringBuilder.Append(line);
        stringBuilder.Append(' ', rightSpacesCount + ExtraSpacesOnLine);

        if (isSelected)
            stringBuilder.Append(DefaultForeground).Append(DefaultBackground);

        stringBuilder.Append('║');
        stringBuilder.AppendLine();
    }

    private static void AddOutputSeparatorLine(StringBuilder stringBuilder, int maxLineLength)
    {
        stringBuilder.Append('╠').Append('═', maxLineLength + ExtraSpacesOnLine * 2).Append('╣').AppendLine();
    }

    private static void AddOutputLastLine(StringBuilder stringBuilder, int maxLineLength)
    {
        stringBuilder.Append('╚').Append('═', maxLineLength + ExtraSpacesOnLine * 2).Append('╝').AppendLine();
    }

    private static bool IsNeedExitAfterKeyPressed(ref int selector, int linesCount)
    {
        while (true)
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selector = selector <= 0 ? linesCount - 1 : selector - 1;
                    return false;

                case ConsoleKey.DownArrow:
                    selector = selector >= linesCount - 1 ? 0 : selector + 1;
                    return false;

                case ConsoleKey.Enter:
                    return true;
            }
        }
    }
}