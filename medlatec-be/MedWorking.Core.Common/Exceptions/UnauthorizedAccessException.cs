﻿namespace MedWorking.Core.Common.Exceptions;

public class UnauthorizedAccessException : Exception 
{
    public UnauthorizedAccessException(string msg) : base(msg) { }
}
