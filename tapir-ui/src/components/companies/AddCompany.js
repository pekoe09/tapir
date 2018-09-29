import React from 'react'
import { connect } from 'react-redux'
import { withRouter } from 'react-router-dom'
import { addCompany } from '../../actions/companyActions'
import { addUIMessage } from '../../actions/uiMessageActions'
import TapirHeader from '../ui-structure/TapirHeader'
import { StyledLinkButton, StyledButton } from '../ui-structure/StyledComponents'
import { Form, FormGroup, FormControl, ControlLabel, Col } from 'react-bootstrap'

class AddCompany extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      fullName: "",
      shortName: ""
    }
  }

  handleChange = (event) => {
    this.setState({ [event.target.name]: event.target.value })
  }

  handleSubmit = async (event) => {
    event.preventDefault()
    const company = {
      fullName: this.state.fullName,
      shortName: this.state.shortName
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
        <Form horizontal>
          <FormGroup controlId='companyFullName'>
            <Col componentClass={ControlLabel} sm={2}>
              Full name
            </Col>
            <Col sm={6}>
              <FormControl
                name='fullName'
                type='text'
                value={this.state.fullName}
                onChange={this.handleChange}
              />
            </Col>
          </FormGroup>
          <FormGroup controlId='companyShortName'>
            <Col componentClass={ControlLabel} sm={2}>
              Short name
            </Col>
            <Col sm={6}>
              <FormControl
                name='shortName'
                type='text'
                value={this.state.shortName}
                onChange={this.handleChange}
              />
            </Col>
          </FormGroup>
          <FormGroup>
            <Col smOffset={2} sm={6}>
              <StyledButton type='primary' onClick={this.handleSubmit}>Save</StyledButton>
            </Col>
          </FormGroup>
        </Form>
      </div>
    )
  }
}

const mapStateToProps = store => {
  return {
    error: store.companies.error
  }
}

export default withRouter(connect(
  mapStateToProps,
  {
    addCompany,
    addUIMessage
  }
)(AddCompany))