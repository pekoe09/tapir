import React from 'react'
import { connect } from 'react-redux'
import { addCompany } from '../../actions/companyActions'
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

  handleChange = (event, { value }) => {
    this.setState({ [event.target.name]: value })
  }

  handleSubmit = async () => {
    const company = {
      fullName: this.state.fullName,
      shortName: this.state.shortName
    }
    await this.props.addCompany(company)
    if (!this.props.error) {
      // add success message

    } else {
      // add failure message, stay in this view
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
              <FormControl type='text' />
            </Col>
          </FormGroup>
          <FormGroup controlId='companyShortName'>
            <Col componentClass={ControlLabel} sm={2}>
              Short name
            </Col>
            <Col sm={6}>
              <FormControl type='text' />
            </Col>
          </FormGroup>
          <FormGroup>
            <Col smOffset={2} sm={6}>
              <StyledButton type='primary'>Save</StyledButton>
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

export default connect(
  null,
  {
    addCompany
  }
)(AddCompany)