﻿namespace FinallChallenge.DTOs
{
    /// <summary>
    /// Data transfer object for sales territories.
    /// </summary>
    public class GetSaleTerritoryDto
    {
        /// <summary>
        /// Gets or sets the ID of the sales territory.
        /// </summary>
        public int TerritoryID { get; set; }

        /// <summary>
        /// Gets or sets the name of the sales territory.
        /// </summary>
        public string? Name { get; set; }
    }
}
