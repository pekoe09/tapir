import React, { Component } from 'react';
import { Route, withRouter } from 'react-router-dom'
import { connect } from 'react-redux'
import TapirLayout from './components/ui-structure/TapirLayout'
import CompaniesList from './components/companies/CompaniesList'
import AddCompany from './components/companies/AddCompany'
import EditCompany from './components/companies/EditCompany'
import EmploymentsList from './components/employments/EmploymentsList'
import PersonsList from './components/persons/PersonsList'

class App extends Component {
  render() {
    return (
      <TapirLayout>
        <Route exact path='/companies' render={() => <CompaniesList />} />
        <Route exact path='/companies/add' render={() => <AddCompany />} />
        <Route exact path='/companies/edit/:id' render={() => <EditCompany />} />
        <Route exact path='/employments' render={() => <EmploymentsList />} />
        <Route exact path='/persons' render={() => <PersonsList />} />
      </TapirLayout>
    )
  }
}

export default withRouter(connect(
  null
)(App))