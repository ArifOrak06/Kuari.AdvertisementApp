﻿using FluentValidation;
using Orak.AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orak.AdvertisementApp.Business.ValidationRules
{
    public class ProvidedServiceUpdateDtoValidator : AbstractValidator<ProvidedServiceUpdateDto>
    {
        public ProvidedServiceUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
