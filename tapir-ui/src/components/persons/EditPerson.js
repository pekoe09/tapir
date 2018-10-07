import React from 'react'
import { connect } from 'react-redux'
import { withRouter } from 'react-router-dom'
import { updatePerson } from '../../actions/personActions'
import { addUIMessage } from '../../actions/uiMessageActions'
import TapirHeader from '../ui-structure/TapirHeader'
import {
  StyledLinkButton,
  StyledButton,
  StyledForm,
  StyledSubForm,
  StyledSubFormBordered,
  StyledFormControl,
  StyledCol
} from '../ui-structure/StyledComponents'
import Address from '../general/Address'
import { FormGroup, ControlLabel, Radio, Col, Collapse } from 'react-bootstrap'
import { Typeahead } from 'react-bootstrap-typeahead'

class EditPerson extends React.Component {

  constructor(props) {
    super(props)
    if (this.props.initialPerson) {
      this.state = {
        lastName: this.props.initialPerson.lastName,
        firstNames: this.props.initialPerson.firstNames,
        SSN: this.props.initialPerson.ssn,
        address: this.props.initialPerson.address ?
          this.props.initialPerson.address :
          {
            street1: '',
            street2: '',
            zip: '',
            city: '',
            country: ''
          },
        email: this.props.initialPerson.email,
        phone: this.props.initialPerson.phone,
        language: this.props.initialPerson.language,
        citizenship: this.props.initialPerson.citizenship,
        profession: this.props.initialPerson.profession,
        IBAN: this.props.initialPerson.iban,
        isOwner: this.props.initialPerson.isOwner,
        ownershipSelf: this.props.initialPerson.ownershipSelf,
        votesSelf: this.props.initialPerson.votesSelf,
        ownershipWithFamily: this.props.initialPerson.ownershipWithFamily,
        votesWithFamily: this.props.initialPerson.votesWithFamily,
        positionInCompany: this.props.initialPerson.positionInCompany,
        placeOfRegularEmployment: this.props.initialPerson.placeOfRegularEmployment,
        cityOfRegularEmployment: this.props.initialPerson.cityOfRegularEmployment,
        regularEmploymentAddress: this.props.initialPerson.regularEmploymentAddress ?
          this.props.initialPerson.regularEmploymentAddress :
          {
            street1: '',
            street2: '',
            zip: '',
            city: '',
            country: ''
          }
      }
    } else {
      this.state = {
        lastName: '',
        firstNames: '',
        SSN: '',
        address: {
          street1: '',
          street2: '',
          zip: '',
          city: '',
          country: ''
        },
        email: '',
        phone: '',
        language: '',
        citizenship: '',
        profession: '',
        IBAN: '',
        isOwner: false,
        ownershipSelf: '',
        votesSelf: '',
        ownershipWithFamily: '',
        votesWithFamily: '',
        positionInCompany: '',
        placeOfRegularEmployment: '',
        cityOfRegularEmployment: '',
        regularEmploymentAddress: {
          street1: '',
          street2: '',
          zip: '',
          city: '',
          country: ''
        }
      }
    }
  }

  handleChange = (event) => {
    console.log(event)
    this.setState({ [event.target.name]: event.target.value })
  }

  handleAddressChange = (targetAddress, address) => {
    this.setState({ [targetAddress]: address })
  }

  handleOwnerToggle = (e) => {
    this.setState({ isOwner: e.currentTarget.value === 'true' })
    if (e.currentTarget.value !== 'true') {
      this.setState({
        ownershipSelf: '',
        ownershipWithFamily: '',
        votesSelf: '',
        votesWithFamily: ''
      })
    }
  }

  handleSubmit = async (event) => {
    event.preventDefault()
    const person = {
      id: this.props.initialPerson.id,
      lastName: this.state.lastName,
      firstNames: this.state.firstNames,
      ssn: this.state.SSN,
      address: this.state.address,
      email: this.state.email,
      phone: this.state.phone,
      language: this.state.language,
      citizenship: this.state.citizenship,
      profession: this.state.profession,
      iban: this.state.IBAN,
      isOwner: this.state.isOwner,
      ownershipSelf: this.state.ownershipSelf,
      votesSelf: this.state.votesSelf,
      ownershipWithFamily: this.state.ownershipWithFamily,
      votesWithFamily: this.state.votesWithFamily,
      positionInCompany: this.state.positionInCompany,
      placeOfRegularEmployment: this.state.placeOfRegularEmployment,
      cityOfRegularEmployment: this.state.cityOfRegularEmployment,
      regularEmploymentAddress: this.state.regularEmploymentAddress
    }
    await this.props.updatePerson(person)
    if (!this.props.error) {
      this.props.addUIMessage('Updated person ' + person.firstnames + ' ' + person.lastName, 'success', 10)
      this.props.history.push('/persons')
    } else {
      this.props.addUIMessage('Could not update the person', 'danger', 10)
    }
  }

  render() {
    return (
      <div>
        <TapirHeader title='Edit Person details'>
          <StyledLinkButton
            style={{ float: 'right' }}
            to={'/persons'}
            text={'Cancel'}
            type={'default'}
          />
        </TapirHeader>
        <StyledForm>
          <Col sm={6} style={{ marginBottom: 20 }}>
            <StyledSubForm componentClass='fieldset' style={{ marginBottom: 0 }}>
              <StyledCol sm={6} style={{ paddingRight: 7 }}>
                <FormGroup controlId='personLastName'>
                  <ControlLabel>Last name</ControlLabel>
                  <StyledFormControl
                    name='lastName'
                    type='text'
                    value={this.state.lastName}
                    onChange={this.handleChange}
                  />
                </FormGroup>
              </StyledCol>
              <StyledCol sm={6} style={{ paddingLeft: 7 }}>
                <FormGroup controlId='personFirstNames'>
                  <ControlLabel>First names</ControlLabel>
                  <StyledFormControl
                    name='firstNames'
                    type='text'
                    value={this.state.firstNames}
                    onChange={this.handleChange}
                  />
                </FormGroup>
              </StyledCol>
            </StyledSubForm>
            <StyledSubForm componentClass='fieldset' style={{ marginBottom: 0 }}>
              <StyledCol sm={6} style={{ paddingRight: 7 }}>
                <FormGroup controlId='ssn'>
                  <ControlLabel>SSN</ControlLabel>
                  <StyledFormControl
                    name='SSN'
                    type='text'
                    value={this.state.SSN}
                    onChange={this.handleChange}
                  />
                </FormGroup>
              </StyledCol>
              <StyledCol sm={6} style={{ paddingLeft: 7 }}>
                <FormGroup controlId='personIBAN'>
                  <ControlLabel>IBAN</ControlLabel>
                  <StyledFormControl
                    name='IBAN'
                    type='text'
                    value={this.state.IBAN}
                    onChange={this.handleChange}
                  />
                </FormGroup>
              </StyledCol>
            </StyledSubForm>
            <StyledSubForm componentClass='fieldset' style={{ marginBottom: 0 }}>
              <StyledCol sm={4} style={{ paddingRight: 15 }}>
                <FormGroup controlId='personLanguage'>
                  <ControlLabel>Language</ControlLabel>
                  <StyledFormControl
                    name='language'
                    type='text'
                    value={this.state.language}
                    onChange={this.handleChange}
                  />
                </FormGroup>
              </StyledCol>
              <StyledCol sm={8}>
                <FormGroup controlId='personCitizenship'>
                  <ControlLabel>Citizenship</ControlLabel>
                  <StyledFormControl
                    name='citizenship'
                    type='text'
                    value={this.state.citizenship}
                    onChange={this.handleChange}
                  />
                </FormGroup>
              </StyledCol>
            </StyledSubForm>
            <Address
              targetAddress={'address'}
              title={'Home address'}
              street1={this.state.address.street1}
              street2={this.state.address.street2}
              zip={this.state.address.zip}
              city={this.state.address.city}
              country={this.state.address.country}
              handleAddressChange={this.handleAddressChange}
            />
            <FormGroup controlId='personEmail'>
              <ControlLabel>Email</ControlLabel>
              <StyledFormControl
                name='email'
                type='text'
                value={this.state.email}
                onChange={this.handleChange}
              />
            </FormGroup>
            <FormGroup controlId='personPhone'>
              <ControlLabel>Phone</ControlLabel>
              <StyledFormControl
                name='phone'
                type='text'
                value={this.state.phone}
                onChange={this.handleChange}
              />
            </FormGroup>
            <FormGroup controlId='personProfession'>
              <ControlLabel>Profession</ControlLabel>
              <StyledFormControl
                name='profession'
                type='text'
                value={this.state.profession}
                onChange={this.handleChange}
              />
            </FormGroup>
            <ControlLabel>Is the person an owner of the company?</ControlLabel>
            <FormGroup controlId='personIsOwner'>
              <Radio
                name='isOwner'
                value={false}
                checked={!this.state.isOwner}
                onChange={this.handleOwnerToggle}
                inline
              >
                No
            </Radio>{' '}
              <Radio
                name='isOwner'
                value={true}
                checked={this.state.isOwner}
                onChange={this.handleOwnerToggle}
                inline
              >
                Yes
            </Radio>
            </FormGroup>

            <Collapse in={this.state.isOwner}>
              <StyledSubFormBordered componentClass='fieldset'>
                <ControlLabel>Person's ownership share and votes of the company</ControlLabel>
                <StyledSubForm componentClass='fieldset'>
                  <Col sm={4}>
                    <FormGroup controlId='personOwnershipSelf'>
                      <ControlLabel>Ownership, %</ControlLabel>
                      <StyledFormControl
                        name='ownershipSelf'
                        type='text'
                        value={this.state.ownershipSelf}
                        onChange={this.handleChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col sm={4}>
                    <FormGroup controlId='personVotesSelf'>
                      <ControlLabel>Votes, %</ControlLabel>
                      <StyledFormControl
                        name='votesSelf'
                        type='text'
                        value={this.state.votesSelf}
                        onChange={this.handleChange}
                      />
                    </FormGroup>
                  </Col>
                </StyledSubForm>

                <ControlLabel>Person's ownership share and votes together with family members</ControlLabel>
                <StyledSubForm componentClass='fieldset'>
                  <Col sm={4}>
                    <FormGroup controlId='personOwnershipWithFamily'>
                      <ControlLabel>Ownership, %</ControlLabel>
                      <StyledFormControl
                        name='ownershipWithFamily'
                        type='text'
                        value={this.state.ownershipWithFamily}
                        onChange={this.handleChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col sm={4}>
                    <FormGroup controlId='personVotesWithFamily'>
                      <ControlLabel>Votes, %</ControlLabel>
                      <StyledFormControl
                        name='votesWithFamily'
                        type='text'
                        value={this.state.votesWithFamily}
                        onChange={this.handleChange}
                      />
                    </FormGroup>
                  </Col>
                </StyledSubForm>
              </StyledSubFormBordered>
            </Collapse>

            <FormGroup controlId='personPositionInCompany'>
              <ControlLabel>Position in company</ControlLabel>
              <StyledFormControl
                name='positionInCompany'
                type='text'
                value={this.state.positionInCompany}
                onChange={this.handleChange}
              />
            </FormGroup>
            <FormGroup controlId='personPlaceOfRegularEmployment'>
              <ControlLabel>Place of regular employment</ControlLabel>
              <StyledFormControl
                name='placeOfRegularEmployment'
                type='text'
                value={this.state.placeOfRegularEmployment}
                onChange={this.handleChange}
              />
            </FormGroup>
            <FormGroup controlId='personCityOfRegularEmployment'>
              <ControlLabel>City of regular employment</ControlLabel>
              <StyledFormControl
                name='cityOfRegularEmployment'
                type='text'
                value={this.state.cityOfRegularEmployment}
                onChange={this.handleChange}
              />
            </FormGroup>
            <Address
              targetAddress={'regularEmploymentAddress'}
              title={'Address of the place of regular employment'}
              street1={this.state.regularEmploymentAddress.street1}
              street2={this.state.regularEmploymentAddress.street2}
              zip={this.state.regularEmploymentAddress.zip}
              city={this.state.regularEmploymentAddress.city}
              country={this.state.regularEmploymentAddress.country}
              handleAddressChange={this.handleAddressChange}
            />
            <FormGroup>
              <StyledButton
                type='primary'
                onClick={this.handleSubmit}
              >
                Save
            </StyledButton>
            </FormGroup>
          </Col>
        </StyledForm>
      </div>
    )
  }
}

const mapStateToProps = (store, ownProps) => {
  console.log(ownProps.match.params.id)
  const initialPerson = store.persons.items.find(p => p.id.toString() === ownProps.match.params.id.toString())
  console.log(initialPerson)
  return {
    initialPerson,
    error: store.persons.error
  }
}

export default withRouter(connect(
  mapStateToProps,
  {
    updatePerson,
    addUIMessage
  }
)(EditPerson))