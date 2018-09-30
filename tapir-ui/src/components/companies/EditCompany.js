import React from 'react'
import { connect } from 'react-redux'
import { withRouter } from 'react-router-dom'
import { updateCompany } from '../../actions/companyActions'
import { addUIMessage } from '../../actions/uiMessageActions'
import TapirHeader from '../ui-structure/TapirHeader'
import { StyledLinkButton, StyledButton, StyledForm, StyledFormControl } from '../ui-structure/StyledComponents'
import { FormGroup, ControlLabel } from 'react-bootstrap'

class EditCompany extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      fullName: this.props.initialCompany ? this.props.initialCompany.fullName : '',
      shortName: this.props.initialCompany ? this.props.initialCompany.shortName : ''
    }
  }

  handleChange = (event) => {
    this.setState({ [event.target.name]: event.target.value })
  }

  handleSubmit = async (event) => {
    event.preventDefault()
    const company = {
      id: this.props.initialCompany.id,
      fullName: this.state.fullName,
      shortName: this.state.shortName
    }
    await this.props.updateCompany(company)
    if (!this.props.error) {
      this.props.addUIMessage('Updated company ' + company.fullName, 'success', 10)
      this.setState({ fullName: '', shortName: '' })
      this.props.history.push('/companies')
    } else {
      this.props.addUIMessage('Could not upate the company', 'danger', 10)
    }
  }


  render() {
    return (
      <div>
        <TapirHeader
          title='Edit Company details'
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

const mapStateToProps = (store, ownProps) => ({
    initialCompany: store.companies.items.find(c => c.id.toString() === ownProps.match.params.id.toString()),
    error: store.companies.error
})

export default withRouter(connect(
  mapStateToProps,
  {
    updateCompany,
    addUIMessage
  }
)(EditCompany))