﻿using CommonLayer;
using MassTransit;
using System.Threading.Tasks;

namespace TicketConsumer.Services
{
    public class TicketConsumerservices:IConsumer<UserTicket>
    {
        public async Task Consume(ConsumeContext<UserTicket> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }


    }
}
