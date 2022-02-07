using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager
{
    public interface ITrackData
    {
        string Service { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        bool SChar { get; set; }
        bool UCase { get; set; }
        int PassLength { get; set; }
    }
}
