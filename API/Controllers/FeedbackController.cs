﻿using System;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    public struct FeedBackRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Feedback { get; set; }
    }

    [Route("/api/v1/feedback")]
    public class FeedbackController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly string _supportMail;

        public FeedbackController(IConfiguration configuration, IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SaveFeedback([FromBody] FeedBackRequest request)
        {
            string name = request.Name;
            string feedback = request.Feedback;
            string type = request.Type;

            _emailService.SendMail("Feedback",
                string.Format("Ein neues Feedback wurde abgegeben:\n" +
                              "Name: {0}\n" +
                              "Art: {1}\n" +
                              "Feedback: {2}", name, type, feedback));

            return new EmptyResult();
        }
    }
}