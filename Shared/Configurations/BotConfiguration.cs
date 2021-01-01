#nullable disable

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Configurations
{
    public class BotConfiguration
    {
        public const string Section = "Bot";
        public char Prefix { get; set; }
        public string Token { get; set; }
    }
}
