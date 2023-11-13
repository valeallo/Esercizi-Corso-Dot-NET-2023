using System;

namespace Eurozone_Calculator
{
    interface IEuropeanCentralBank
    {

        string CalculateSpread();
        string DisplayGovernmentBondValue();

    }

    interface IEuropeanHumanRightsCourt
    {
        string IsStateRespectingHumanRights();
    }



}
