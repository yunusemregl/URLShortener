﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANURLShortener
{
    public interface IURLShortener
    {
        string getShortUrl(string longURL);
    }
}
