using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic.Menus;

public abstract class MenuBase
{
    private readonly bool _isBackAfterExecute;

    protected abstract string BackCommandDescription { get; }

    protected MenuBase(bool isBackAfterExecute = false)
    {
        _isBackAfterExecute = isBackAfterExecute;
    }

    public async Task StartAsync()
    {
        var selector = 0;

        while (true)
        {
            var header = GetHeader();
            var commandLines = GetCommandDescriptions().Append(BackCommandDescription).ToArray();

            selector = ConsoleBorderedMenuHelper.PrintMenuAndGetSelector(ref selector, header, commandLines);
            if (selector == commandLines.Length - 1)
                break;

            await ExecuteCommandAsync(selector).ConfigureAwait(false);
            if (_isBackAfterExecute || IsBackAfterExecuteCommand(selector))
                break;
        }
    }

    protected virtual string? GetHeader()
    {
        return null;
    }

    protected abstract IEnumerable<string> GetCommandDescriptions();

    protected abstract Task ExecuteCommandAsync(int index);

    protected abstract bool IsBackAfterExecuteCommand(int index);
}