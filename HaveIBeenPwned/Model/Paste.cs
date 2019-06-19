using System;

namespace HaveIBeenPwned.Model
{
    public class Paste
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Source { get; set; }

        public DateTime? Date { get; set; }

        public int EmailCount { get; set; }
    }
}