﻿using Fluxor;
using Nasa.Client.Models;
using Nasa.Client.StateManagement.APOD.Actions;

namespace Nasa.Client.StateManagement.APOD.UseCases.ApodUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static CurrentApodState ReduceUpdateCurrentApodAction(CurrentApodState state, CurrentApodAction action)
        {
            return new(action.CurrentApodData, action.CurrentApodRefreshedData);
        }
    }
}