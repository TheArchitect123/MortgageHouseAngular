using MortgageHouse.Backend.Helpers;
using System;

namespace MortgageHouse.Backend.Extensions
{
    public static class ExceptionExtensions
    {
        public static void HandleException(this Exception ex)
        {
            //Any Notifications, push notifications, can be sent here in case of a failure
            LogHelper.LogException(ex);
        }
    }

}
