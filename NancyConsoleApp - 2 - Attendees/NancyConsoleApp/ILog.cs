﻿namespace NancyConsoleApp
{
    public interface ILog
    {
        void Info(string message);
        void Error(string message);
    }
}