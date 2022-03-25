using AutoMapper;
using System;

namespace LibraryExperiment
{
    internal class StringToEnumConverter<T> : IValueConverter<string, T> where T: struct
    {
        public T Convert(string sourceMember, ResolutionContext context)
        {
            if(Enum.TryParse(sourceMember, out T resolvedValue))
            {
                return resolvedValue;
            }

            return default(T);
        }


    }
}