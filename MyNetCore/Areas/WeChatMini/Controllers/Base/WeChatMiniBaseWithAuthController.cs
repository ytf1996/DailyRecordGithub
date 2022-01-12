﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyNetCore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetCore.Areas.WeChatMini.Controllers
{
    public class WeChatMiniBaseWithAuthController : WeChatMiniBaseController
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string accessToken = filterContext.HttpContext.Request.Headers["accessToken"];

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new Exception("未能获取accessToken，请重新打开小程序");
            }

            var currentUser = GetCurrentUserInfo(accessToken);
            if (currentUser == null || currentUser.Id == 0)
            {
                throw new Exception("请重新打开小程序");
            }
            if (currentUser.Disabled)
            {
                throw new Exception("该用户被禁用");
            }
        }
    }
}
