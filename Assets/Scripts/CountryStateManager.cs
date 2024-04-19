using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Countries
{
    public class CountryStateManager : MonoBehaviour
    {
        private BasicCountryState _currentState;

        public CountryIdleState IdleState = new CountryIdleState();
        public CountryInfectedState InfectedState = new CountryInfectedState();

        //variables
        public CountryData CountryData;

        private void Start()
        {
            _currentState = IdleState;
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
        }

        public void SwitchState(BasicCountryState state)
        {
            _currentState = state;
            state.EnterState(this);
        }
    }
}