﻿namespace Shooter
{
    public static class ValidatorExpansion 
    {
        public static bool IsCorrectNameRoom(this string name) =>
            string.IsNullOrEmpty(name) == false && string.IsNullOrWhiteSpace(name) == false;

        public static bool IsCorrectNickname(this string name) =>
           string.IsNullOrEmpty(name) == false && string.IsNullOrWhiteSpace(name) == false;
    }
}
