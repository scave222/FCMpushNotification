using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;

namespace FCMpushNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("private_key.json")
            });

            //This registartion token comes from the client FCM SDKs.
            var registrationToken = "Add_TOKEN";

            // message payload
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "myData", "1337" },
                },

                //Token = registrationToken,

                Topic = "all",
                Notification = new Notification()
                {
                    Title = "Test from code",
                    Body = "Here is your test!"
                }
            };

            //Send a message to the device corresponding to the provided registartion token
            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            //Response is a message ID string.
            Console.WriteLine("Successfully sent message:" + response);
        }
    }
}
