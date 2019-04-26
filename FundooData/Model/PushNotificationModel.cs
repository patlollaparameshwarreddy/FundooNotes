using System;
using System.Collections.Generic;
using System.Text;

namespace FundooData.Model
{
   public class PushNotificationModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string PushToken { get; set; }
    }
}
