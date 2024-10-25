using BookinfoCommon.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookChangePublisher
{
    public class BookInfoPublisher
    {
        public async Task PublishBookInfoChange(string bookId)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host("localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            await busControl.StartAsync();
            try
            {
                await busControl.Publish(new BookInfoChanged { BookId = bookId });
            }
            finally
            {
                await busControl.StopAsync();
            }
        }
    }
}
