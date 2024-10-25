using Microsoft.Extensions.Hosting;
using System;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using static MassTransit.MessageHeaders;

namespace BookChangePublisher
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var publisher = host.Services.GetRequiredService<BookInfoPublisher>();

            // Example of publishing a book info change message
            while (true)
            {
                Console.WriteLine("Enter Book ID to publish the change event:");
                var bookId = Console.ReadLine();
                if (bookId == "e")
                    break;
                await publisher.PublishBookInfoChange(bookId);

                Console.WriteLine("Message published. Press any key to exit...");
            }
    
           
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host("localhost", "/", h =>
                            {
                                h.Username("guest");
                                h.Password("guest");
                            });
                        });
                    });

                    services.AddScoped<BookInfoPublisher>();
                });
        }
    
    }
}
