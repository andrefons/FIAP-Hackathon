﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string email, string subject, string content);
    }
}
