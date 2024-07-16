﻿namespace VerticalSliceArchitectureCQRSMediatRCarter.Entities
{
    public sealed class Book
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
