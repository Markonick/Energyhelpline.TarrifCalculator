﻿using System;

namespace Energyhelpline.TariffCalculator.Models
{
    public class InputModel
    {
        public int GasUsage { get; set; }
        public int ElectricityUsage { get; set; }
        public DateTime StartingDate { get; set; }
    }
}