using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Countries
{
    public abstract class BasicCountryState
    {
        public abstract void EnterState(CountryStateManager stateManager);

        public abstract void UpdateState(CountryStateManager stateManager);
    }
}
