import React, { Component } from 'react';
import { Route, withRouter } from 'react-router-dom'
import { connect } from 'react-redux'
import TapirLayout from './components/ui-structure/TapirLayout'
import CompaniesList from './components/companies/CompaniesList'
import AddCompany from './components/companies/AddCompany'
import EditCompany from './components/companies/EditCompany'
import EmploymentsList from './components/employments/EmploymentsList'
import AddEmployment from './components/employments/AddEmployment'
import PersonsList from './components/persons/PersonsList'
import AddPerson from './components/persons/AddPerson'
import EditPerson from './components/persons/EditPerson'

class App extends Component {
  render() {
    return (
      <TapirLayout>
        <Route exact path='/companies' render={() => <CompaniesList />} />
        <Route exact path='/companies/add' render={() => <AddCompany />} />
        <Route exact path='/companies/edit/:id' render={() => <EditCompany />} />
        <Route exact path='/employments' render={() => <EmploymentsList />} />
        <Route excat path='/employments/add' render={() => <AddEmployment />} />
        <Route exact path='/persons' render={() => <PersonsList />} />
        <Route exact path='/persons/add' render={() => <AddPerson />} />
        <Route exact path='/persons/edit/:id' render={() => <EditPerson />} />
      </TapirLayout>
    )
  }
}

export default withRouter(connect(
  null
)(App))