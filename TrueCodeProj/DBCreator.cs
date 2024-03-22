using Microsoft.EntityFrameworkCore;
using TrueCodeTestProj;

public class DBCreator
{
    private readonly AppDbContext _dbContext;

    public DBCreator(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateDBAsync()
    {
        await Console.Out.WriteLineAsync("Wait a bit untile DB will created");
        if (!await _dbContext.Database.CanConnectAsync())
        {
            await _dbContext.Database.MigrateAsync();
        }
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
}
