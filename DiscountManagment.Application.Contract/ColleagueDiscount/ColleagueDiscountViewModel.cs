﻿using System;

namespace DiscountManagment.Application.Contract.ColleagueDiscount
{
    public class ColleagueDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int DiscountRate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool  IsRemoved { get; set; }

    }


}