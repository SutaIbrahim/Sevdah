publish locally:

u startupu izmijeniti
            string connectionString = _configuration.GetConnectionString("SevdahLocal_Development"); u  string connectionString = _configuration.GetConnectionString("SevdahLocal_IIS_Host");

uraditi publish u neki folder i prebaciti u IIS folder na local pc-u (mogu samo izmijenjeni fajlovi, vidi se po datumu!)



