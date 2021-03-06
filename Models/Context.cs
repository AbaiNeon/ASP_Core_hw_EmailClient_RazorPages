﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Context : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
    }
}
