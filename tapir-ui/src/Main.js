import React, { Component } from 'react';
import { Route, withRouter } from 'react-router-dom'
import { connect } from 'react-redux'
import App from 'grommet/components/App'
import TapirLayout from './components/ui-structure/TapirLayout'
import CompaniesList from './components/companies/CompaniesList'
import EmploymentsList from './components/employments/EmploymentsList'
import PersonsList from './components/persons/PersonsList'

class Main extends Component {
  render() {
    return (
      <App centered={false}>
        <TapirLayout>
          <Route exact path='/companies' render={() => <CompaniesList />} />
          <Route exact path='/employments' render={() => <EmploymentsList />} />
          <Route exact path='/persons' render={() => <PersonsList />} />
        </TapirLayout>
      </App>
    )
  }
}

export default withRouter(connect(
  null
)(Main))