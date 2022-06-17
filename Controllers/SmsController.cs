using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Microsoft.AspNetCore.Mvc;

namespace TwilioReceive.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmsController : TwilioController
    {
        public SmsController()
        {

        }

        [HttpPost]

        public TwiMLResult Alta(SmsRequest incomingMessage)
        {
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("The copy cat says: " +
                                      incomingMessage.Body);

            return TwiML(messagingResponse);
        }

    }
}