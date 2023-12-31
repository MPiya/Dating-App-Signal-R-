﻿using LinkTreeClone.DB;
using LinkTreeClone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace LinkTreeClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : Controller
    {
        private readonly ILogger<UserProfileController> _logger;
        private readonly UserDb _userDb;

        public UserProfileController(ILogger<UserProfileController> logger, UserDb userDb)
        {
            _logger = logger;
            _userDb = userDb;
        }

        [HttpGet]
        public IActionResult AllUsers()
        {
            var users = _userDb.GetUser();
            return View(users);
        }

        [HttpGet("allUsersAPI")]
        public IActionResult AllUsersAPI()
        {
            var users = _userDb.GetUser();
            return Ok(users);
        }

        [HttpGet("createUserProfile")]
        public IActionResult CreateUserProfile()
        {
            return View();
        }

        [HttpPost("createUserProfile")]
        public IActionResult CreateUserProfile([FromForm] UserProfile userProfile)
        {
            _userDb.CreateUser(userProfile);
           
            return Redirect("/api/UserProfile"); // Redirect to the UserProfile endpoint
        }

        




    }
}
