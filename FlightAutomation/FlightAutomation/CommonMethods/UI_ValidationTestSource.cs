using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FlightAutomation.CommonMethods;
namespace FlightAutomation.CommonMethods
{
    public class UI_ValidationTestSource
    {
        public static IEnumerable UiValidation
        {
            get
            {
                yield return new TestCaseData("Flights",ObjectRepository.flightButton);
                yield return new TestCaseData("RoundTrip" ,ObjectRepository.roundTripLabel);
                yield return new TestCaseData("Adult", ObjectRepository.buttonAdult);
                yield return new TestCaseData("Infant", ObjectRepository.buttonInfant);
                yield return new TestCaseData("Child", ObjectRepository.buttonChild);
                yield return new TestCaseData("ToDate", ObjectRepository.toInputField);
                yield return new TestCaseData("FromDate",ObjectRepository.fromInputField);
                yield return new TestCaseData("DestinationCity",ObjectRepository.spanNYC);
                yield return new TestCaseData("ArrivalCity",ObjectRepository.spanMIA);
                yield return new TestCaseData("SearchButton", ObjectRepository.buttonSearch);

            }
        }

    }
}
