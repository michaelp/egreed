using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace cli
{
    internal static partial class Program
    {
        private static async Task Main(string[] args)
        {

            
            var topicHostname = new Uri(topicEndpoint).Host;
            var topicCredentials = new TopicCredentials(topicKey);
            var ct = new CancellationTokenSource();
            using (var client = new EventGridClient(topicCredentials))
            {

                var msg = string.Empty;
                while ("q" != (msg = Console.ReadLine()))
                {
                    await client.PublishEventsAsync(topicHostname, GetEvents(msg), ct.Token);
                    Console.WriteLine($"sent:[{msg}] ");
                }
                ct.Cancel();
            }


        }

        private static IList<EventGridEvent> GetEvents(string msg = "") => new[] {
                new EventGridEvent()
                {
                    Id = Guid.NewGuid().ToString(),
                    Data = new EventSpecificData()
                    {
                        Message = msg,
                        FormId = "Grading/WorkersCompensation",
                        SomeInt = 10,
                        SomeDate = DateTime.Now
                    },
                    EventTime = DateTime.Now,
                    EventType = "Task.Form.Completed",
                    Subject = msg,
                    DataVersion = "1.0"
                }
            };
    }
}
