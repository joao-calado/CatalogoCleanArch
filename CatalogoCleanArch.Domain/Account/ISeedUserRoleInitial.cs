﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoCleanArch.Domain.Account;

public interface ISeedUserRoleInitial
{
    void SeedUsers();
    void SeedRoles();
}
