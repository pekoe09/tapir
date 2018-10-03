import React from 'react'
import { connect } from 'react-redux'
import { withRouter } from 'react-router-dom'
import { addCompany } from '../../actions/companyActions'
import { addUIMessage } from '../../actions/uiMessageActions'
import TapirHeader from '../ui-structure/TapirHeader'
import { StyledLinkButton, StyledButton, StyledForm, StyledFormControl } from '../ui-structure/StyledComponents'
import { FormGroup, ControlLabel } from 'react-bootstrap'
import { Typeahead } from 'react-bootstrap-typeahead'

class AddCompany extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      fullName: '',
      shortName: '',
      businessID: '',
      selectedSector: [],
      insuranceNumber: '',
      bankAccount: ''
    }
  }

  handleChange = (event) => {
    this.setState({ [event.target.name]: event.target.value })
  }

  handleSectorChange = (selected) => {
    this.setState({ selectedSector: selected })
  }

  handleSubmit = async (event) => {
    event.preventDefault()
    const company = {
      fullName: this.state.fullName,
      shortName: this.state.shortName,
      businessId: this.state.businessId,
      sectorId: this.state.selectedSector[0].id,
      insuranceNumber: this.state.insuranceNumber,
      bankAccount: this.state.bankAccount
    }
    await this.props.addCompany(company)
    if (!this.props.error) {
      this.props.addUIMessage('Added company ' + company.fullName, 'success', 10)
      this.setState({ fullName: "", shortName: "" })
      this.props.history.push('/companies')
    } else {
      this.props.addUIMessage('Could not add the company', 'danger', 10)
    }
  }

  render() {
    return (
      <div>
        <TapirHeader
          title='Add a new Company'
        >
          <StyledLinkButton
            style={{ float: 'right' }}
            to={'/companies'}
            text={'Cancel'}
            type={'default'}
          />
        </TapirHeader>
        <StyledForm>
          <FormGroup controlId='companyFullName'>
            <ControlLabel>Full name</ControlLabel>
            <StyledFormControl
              name='fullName'
              type='text'
              value={this.state.fullName}
              onChange={this.handleChange}
            />
          </FormGroup>
          <FormGroup controlId='companyShortName'>
            <ControlLabel>Short name</ControlLabel>
            <StyledFormControl
              name='shortName'
              type='text'
              value={this.state.shortName}
              onChange={this.handleChange}
            />
          </FormGroup>
          <FormGroup controlId='companyBusinessId'>
            <ControlLabel>Business Id</ControlLabel>
            <StyledFormControl
              name='businessId'
              type='text'
              value={this.state.businessId}
              onChange={this.handleChange}
            />
          </FormGroup>
          <FormGroup controlId='companyBusinessSector'>
            <ControlLabel>Business sector</ControlLabel>
            <Typeahead
              options={this.props.businessSectors}
              onChange={(selected) => { this.handleSectorChange(selected) }}
              selected={this.state.selectedSector}
              labelKey='name'
              ignoreDiacritics={false}
              minLength={3}
              selectHintOnEnter={true}
            />
          </FormGroup>
          <FormGroup controlId='companyInsuranceNumber'>
            <ControlLabel>Insurance number</ControlLabel>
            <StyledFormControl
              name='insuranceNumber'
              type='text'
              value={this.state.insuranceNumber}
              onChange={this.handleChange}
            />
          </FormGroup>
          <FormGroup controlId='companyBankAccount'>
            <ControlLabel>Bank account</ControlLabel>
            <StyledFormControl
              name='bankAccount'
              type='text'
              value={this.state.bankAccount}
              onChange={this.handleChange}
            />
          </FormGroup>
          <FormGroup>
            <StyledButton
              type='primary'
              onClick={this.handleSubmit}
            >
              Save
            </StyledButton>
          </FormGroup>
        </StyledForm>
      </div>
    )
  }
}

const mapStateToProps = store => {
  return {
    error: store.companies.error,
    businessSectors: store.businessSectors.items,
  }
}

export default withRouter(connect(
  mapStateToProps,
  {
    addCompany,
    addUIMessage
  }
)(AddCompany))