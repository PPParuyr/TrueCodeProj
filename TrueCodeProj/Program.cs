using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using TrueCodeProj.Models;
using TrueCodeTestProj;
using TrueCodeTestProj.Services;

internal class Program
{
    static async Task Main(string[] args)
    {
        #region 1 Task
        await Console.Out.WriteLineAsync(new string('-', 50));
        await Console.Out.WriteLineAsync("First part");
        await Console.Out.WriteLineAsync(new string('-',50));
        byte[] data = Encoding.UTF8.GetBytes("Message1\xFMessage2\xFMessage3\xFMessage4\xF");

        using MemoryStream stream = new MemoryStream(data);

        MessageReader reader = new MessageReader(stream, 0xF);

        string message = reader.ReadNextMessage();

        while (message != null)
        {
            await Console.Out.WriteLineAsync("Received message: " + message);
            message = reader.ReadNextMessage();
        }

        await Console.Out.WriteLineAsync();
        #endregion

        #region 2 Task

        await Console.Out.WriteLineAsync(new string('-', 50));
        await Console.Out.WriteLineAsync("Second part");
        await Console.Out.WriteLineAsync(new string('-', 50));
        ServiceProvider serviceProvider = new ServiceCollection()
            .AddDbContext<AppDbContext>()
            .AddScoped<IUserService, UserService>()
            .AddTransient<DBCreator>()
            .BuildServiceProvider();

        var creator = serviceProvider.GetRequiredService<DBCreator>();
        await creator.CreateDBAsync();

        IUserService userRepository = serviceProvider.GetService<IUserService>();

        Guid userId = Guid.Parse("67ED6E86-26D3-4A36-BC98-549FC0812829");
        User userByIdAndDomain = await userRepository.GetUserByIdAndDomainAsync(userId, "example.com");

        await Console.Out.WriteLineAsync("User by Id and Domain:");
        await Console.Out.WriteLineAsync(userByIdAndDomain.Name);

        await Console.Out.WriteLineAsync();

        await Console.Out.WriteLineAsync("Users by Domain with pagination:");
        var usersByDomain = await userRepository.GetUsersByDomainAsync("example.com", 1, 10);
        foreach (var user in usersByDomain)
        {
            await Console.Out.WriteLineAsync(user.Name);
        }

        await Console.Out.WriteLineAsync();

        await Console.Out.WriteLineAsync("Users by Tag Value and Domain:");
        var usersByTagAndDomain = await userRepository.GetUsersByTagAndDomainAsync("tag1", "example.com");
        foreach (var user in usersByTagAndDomain)
        {
            await Console.Out.WriteLineAsync(user.Name);
        }

        #endregion
    }
}