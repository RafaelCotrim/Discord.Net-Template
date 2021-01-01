using Microsoft.EntityFrameworkCore;
using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Data
{
    public class BotDataContext : DataContext
    {
        public BotDataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
