﻿namespace FatecSisMed.IdentityServer.SeedDataBase.Interfaces
{
    public interface IDatabaseInitializer
    {
        void InitializeSeedRoles();
        void InitializeSeedUsers();
    }
}
