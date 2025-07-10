using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic.Menus;

public abstract class MenuBase<TValue>
{
    private readonly bool _isBackAfterExecute;

    protected abstract string BackCommandDescription { get; }

    protected MenuBase(bool isBackAfterExecute = false)
    {
        _isBackAfterExecute = isBackAfterExecute;
    }

    public async Task StartAsync(TValue value)
    {
        var selector = 0;

        while (true)
        {
            var header = GetHeader(value);
            var commandLines = GetCommandDescriptions(value).Append(BackCommandDescription).ToArray();

            ConsoleBorderedMenuHelper.PrintMenuAndGetSelector(ref selector, header, commandLines);
            if (selector == commandLines.Length - 1)
                break;

            await ExecuteCommandAsync(value, selector).ConfigureAwait(false);
            if (_isBackAfterExecute || IsBackAfterExecuteCommand(selector))
                break;
        }
    }

    protected virtual string? GetHeader(TValue value)
    {
        return null;
    }

    protected abstract IEnumerable<string> GetCommandDescriptions(TValue value);

    protected abstract Task ExecuteCommandAsync(TValue value, int index);

    protected abstract bool IsBackAfterExecuteCommand(int index);
}