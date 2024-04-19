using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Countries
{
    public class CountryIdleState : BasicCountryState
    {
        private int _population;
        public override void EnterState(CountryStateManager stateManager)
        {
            
        }

        public override void UpdateState(CountryStateManager stateManager)
        {
            //do smth
           // stateManager.SwitchState(stateManager.InfectedState);
        }
    }
}