using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager
{
    public class TrackData : ITrackData
    {
        public string Service { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool SChar { get; set; }
        public bool UCase { get; set; }
        public int PassLength { get; set; }
    }
}
