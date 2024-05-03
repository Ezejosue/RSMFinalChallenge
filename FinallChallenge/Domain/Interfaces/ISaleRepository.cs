﻿using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    public interface ISaleRepository
    {
        Task<List<SaleReport>> GetSalesDataByFilterAsync(string categoryFilter, string? regionFilter, string? StartDate, string? EndDate, int? page, int? pageSize);

    }
}