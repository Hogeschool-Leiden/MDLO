using System;

namespace ModuleDomainService.Infrastructure.Exceptions
{
    public class ModuleAlreadyExistException : Exception
    {
        public ModuleAlreadyExistException() : base("Module already exist")
        {
        }
    }
}