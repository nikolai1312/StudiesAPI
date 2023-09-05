﻿using Microsoft.AspNetCore.Mvc.Filters;
using StudiesAPI.Logic.DTOs.ConcertDto;

namespace StudiesAPI.Filters
{
    public class ConcertNameSanitizeFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ConcertRequestDto _requestName = context.ActionArguments["concert"] as ConcertRequestDto;

            string[] _splitedNameInArray = _requestName.Name.Split(" ");

            for (int i = 0; i < _splitedNameInArray.Length; i++)
            {
                var firstLetter = _splitedNameInArray[i].ElementAt(0);
                var upperCaseFirstLetter = char.ToUpper(firstLetter);
                _splitedNameInArray[i] = _splitedNameInArray[i].Remove(0, 1).Insert(0, upperCaseFirstLetter.ToString());
            }

            string _nameToCamelCase = string.Join(" ", _splitedNameInArray);
            _requestName.Name = _requestName.Name.Remove(0);
            _requestName.Name = _requestName.Name.Insert(0, _nameToCamelCase);

            base.OnActionExecuting(context);
        }
    }
}
