﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide productPicture);
        OperationResult Edit(EditSlide productPicture);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();


    }
}
