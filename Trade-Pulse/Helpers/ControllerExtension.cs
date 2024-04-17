﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Trade_Pulse.Helpers
{
    public static class ControllerExtension
    {
        public static int GetAuthorizedUserId(this Controller controller)
        {
            return int.Parse(controller.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        }
    }
}
