﻿using Xunarmand.Domain.Common.Queries;

namespace Xunarmand.Application.Users.Models;

public class UserFilter:FilterPagination
{
    /// <summary>
    /// Overrides base GetHashCode method
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        return hashCode.ToHashCode();
    }
    /// <summary>
    /// Overrides base Equals method
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => 
        obj is UserFilter clientFilter 
        && clientFilter.GetHashCode() == GetHashCode();
}